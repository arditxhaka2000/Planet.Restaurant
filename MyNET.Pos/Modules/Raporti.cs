using MyNET.Shops;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iText.Layout.Properties;
using Microsoft.Office.Interop.Word;
using Spire.Doc;
using Services.Models;
using Font = System.Drawing.Font;

namespace MyNET.Pos.Modules
{
    public partial class Raporti : Form
    {
        public static int dailyOpenId = Globals.User.Id;
        Services.DailyOpenCloseBalance dailyOpen = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(dailyOpenId);
        const int x = 320;
        const int y = 0;
        public decimal totalShitje = 0;
        public decimal totalCash = 0;
        public decimal totalBank = 0;
        public int totalKupona = 0;
        public int EmpId;


        public Raporti()
        {
            InitializeComponent();
        }
        private void Raporti_Load(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();

            CloseChashbox close = new CloseChashbox();

            this.Location = new System.Drawing.Point(x, y);
            char[] compName = Globals.Settings.CompanyName.ToCharArray();

            lblCompanyName.Location = new System.Drawing.Point(this.Size.Width / 2 - 100, 3);

            if (compName.Length < 10)
            {
                report_closing_of_the_day_fast_food.Location = new System.Drawing.Point(lblCompanyName.Location.X + 20, lblCompanyName.Location.Y + 43);

            }
            else
            {
                report_closing_of_the_day_fast_food.Location = new System.Drawing.Point(lblCompanyName.Location.X + 50, lblCompanyName.Location.Y + 43);
            }


            var totalsale = "";
            if (dailyOpen.Status == "closed")
            {
                totalsale = PosRestaurant.totalSumOpenBalance.ToString("N");

            }



            var daily = Services.DailyOpenCloseBalance.GetDailyBalance(Globals.User.Id).Where(p => p.Date.Day == DateTime.Now.Day && p.Status == "open");

            foreach (var item in daily)
            {
                DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();
                row.Cells[0].Value = item.DailyFiscalCount.ToString();
                row.Cells[1].Value = item.Amount.ToString("N");
                row.Cells[2].Value = item.TotalCash.ToString("N");
                row.Cells[3].Value = item.TotalCreditCard;
                row.Cells[4].Value = item.TotalShitje.ToString("N");
                totalShitje += item.TotalShitje;
                totalCash += item.TotalCash;
                totalBank += item.TotalCreditCard;
                totalKupona += item.DailyFiscalCount;
                dg.Rows.Add(row);
            }

            label1.Text = label1.Text + " " + totalShitje.ToString() + " EUR";
            label2.Text = label2.Text + " " + totalCash.ToString() + " EUR";
            label3.Text = label3.Text + " " + totalKupona.ToString();
            label4.Text = label4.Text + " " + totalBank.ToString() + " EUR";
        }

        Bitmap bitmap;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Panel panel = new Panel();
            //Graphics graphics = panel1.CreateGraphics();
            //Size size = panel1.ClientSize;
            //bitmap = new Bitmap(size.Width, size.Height, graphics);
            //graphics = Graphics.FromImage(bitmap);

            //Point point = PointToScreen(panel1.Location);
            //graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);

            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();


            FolderBrowserDialog flb = new FolderBrowserDialog();

            flb.ShowDialog();

            string sSelectedPath = flb.SelectedPath;

        }
        private void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg.Rows.Count > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF (*.pdf)|*.pdf";
                    sfd.FileName = "Output.pdf";
                    bool fileError = false;
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sfd.FileName))
                        {
                            try
                            {
                                File.Delete(sfd.FileName);
                            }
                            catch (IOException ex)
                            {
                                fileError = true;
                                MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                            }
                        }
                        if (!fileError)
                        {
                            try
                            {
                                PdfPTable pdfTable = new PdfPTable(dg.Columns.Count);
                                pdfTable.DefaultCell.Padding = 3;
                                pdfTable.WidthPercentage = 100;
                                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                                foreach (DataGridViewColumn column in dg.Columns)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                    pdfTable.AddCell(cell);
                                }

                                foreach (DataGridViewRow row in dg.Rows)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        if (cell.Value != null) { pdfTable.AddCell(cell.Value.ToString()); }
                                    }
                                }
                                PdfPTable pdfTable2 = new PdfPTable(1);
                                pdfTable2.WidthPercentage = 50;
                                pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;

                                for (int col = 1; col < 2; col++)
                                {
                                    Control headerControl = tableLayoutPanel1.GetControlFromPosition(col, 0);
                                    if (headerControl != null)
                                    {
                                        PdfPCell cell = new PdfPCell(new Phrase(headerControl.Text));
                                        pdfTable2.AddCell(cell);
                                    }
                                }

                                // Add the tableLayoutPanel1 data cells
                                for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
                                {
                                    for (int col = 0; col < 2; col++)
                                    {
                                        Control cellControl = tableLayoutPanel1.GetControlFromPosition(col, row);
                                        if (cellControl != null)
                                        {
                                            PdfPCell cell = new PdfPCell(new Phrase(cellControl.Text));
                                            pdfTable2.AddCell(cell);
                                        }
                                    }
                                }
                                iTextSharp.text.Paragraph spacing = new iTextSharp.text.Paragraph(" ");
                                spacing.SpacingBefore = 10f;
                                spacing.SpacingAfter = 10f;
                                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                {
                                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 5f, 10f, 150f, 5f);
                                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                                    pdfDoc.Open();
                                    PdfContentByte cb = writer.DirectContent;

                                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                    cb.SetColorFill(BaseColor.BLACK);
                                    cb.SetFontAndSize(bf, 14);
                                    cb.BeginText();
                                    string text = $"Mbyllja e Dites për Puntorin: {Globals.User.Name}";
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text, 170, 750, 0);
                                    cb.SetFontAndSize(bf, 22);

                                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{Globals.Station.Name}", 220, 800, 0);
                                    cb.SetFontAndSize(bf, 12);
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"Gjeneruar me {DateTime.Now}" + " nga PlanetAccounting.org, info@planetaccounting.org/044 916 828", 40, 20, 0);
                                    cb.EndText();

                                    pdfDoc.Add(pdfTable);
                                    pdfDoc.Add(spacing);
                                    pdfDoc.Add(pdfTable2);
                                    pdfDoc.Close();
                                    stream.Close();
                                }

                                MessageBox.Show("Data Exported Successfully !!!", "Info");
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error :" + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Record To Export !!!", "Info");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);

        }

        private void Raporti_Move(object sender, EventArgs e)
        {
            //this.Location = new Point(x, y);

        }

        private void button1_Click(object sender, EventArgs e)
        {


            var printer = Services.Printer.Get().Find(p => p.Id == Globals.DeviceId);
            var settings = Services.Settings.Get();

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = settings.PosPrinter == "1" ? printer.TermalName : settings.ThermalPrinterName;
            printDoc.PrintPage += new PrintPageEventHandler(PrintRestaurantDataGridView);
            printDoc.Print();





        }
        public void PrintRestaurantDataGridView(object sender, PrintPageEventArgs e)
        {
            var settings = Services.Settings.Get();
            var printer = Services.Printer.Get().Find(p => p.Id == Globals.DeviceId);


            float total_width = settings.PosPrinter == "0" ? Convert.ToInt32(settings.ThermalPrinterPageWidth) + 110f : Convert.ToInt32(printer.TermalPaperWidth) + 110f;

            Font headingFont = new Font("Calibri", total_width / 18f, FontStyle.Bold);
            Font boldFont = new Font("Calibri", total_width / 23f, FontStyle.Bold);
            Font normalFont = new Font("Calibri", total_width / 23f, FontStyle.Regular);

            float topMargin = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;

            string receipt_date = DateTime.Now.ToString();
            decimal net_total = 0;
            string company = Globals.Settings.CompanyName;
            string line = "--------------------------------------------------------------------------------";
            float height = 5;
            // float printerWidth;
            // float printerHight;


            float company_name = 2f;
            float company_address = 2.5f;
            float receipt_number = 19f;
            float rec_date = 1.08f;
            float rec_desc = 19f;

            float rec_qty = 1.6f;
            float rec_price = 1.1f;
            float rec_total = 0.85f;




            //Print Company Name
            e.Graphics.DrawString($"Raporti i mbylljes së ditës të {Services.User.Get(EmpId).Name}", headingFont, Brushes.Black, 0, height, new StringFormat());
            height += 30;
            //Print Company Address
            e.Graphics.DrawString(company, normalFont, Brushes.Black, total_width / company_address, height, new StringFormat());
            height += 40;

            //Print Receipt No
            e.Graphics.DrawString("Date :\n " + receipt_date, boldFont, Brushes.Black,0, height, new StringFormat());
            height += 40;

            //Print Line
            e.Graphics.DrawString(line, normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20;

            //Printe Table Headings

            e.Graphics.DrawString($"Total Kupona: {totalKupona}", normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20; 
            
            e.Graphics.DrawString($"Bilanci Fillestar: {totalKupona}", normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20;

            e.Graphics.DrawString($"Total Kesh: {totalCash} EUR", normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20;

            e.Graphics.DrawString($"Total Banka: {totalBank}  EUR", normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20;

            e.Graphics.DrawString($"Total Shitje: {totalShitje}  EUR", normalFont, Brushes.Black, 0, height, new StringFormat());

            height += 20;


            //Print Line
            e.Graphics.DrawString(line, normalFont, Brushes.Black, 0, height, new StringFormat());


            e.HasMorePages = false;
        }
    }
}
