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

namespace MyNET.Pos.Modules
{
    public partial class Raporti : Form
    {
        public static int dailyOpenId = Globals.User.Id;
        Services.DailyOpenCloseBalance dailyOpen = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(dailyOpenId);
        const int x = 320;
        const int y = 0;


        public Raporti()
        {
            InitializeComponent();
        }
        private void Raporti_Load(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();

            //if (globals.Language == "Sq")
            //{
            //    var data = LoadJson.DataSq;
            //    foreach(var item in data.dataWords)
            //    {
            //        foreach (Control c in this.Controls)
            //        {
            //            if (c.Name == item.name)
            //            {
            //                c.Text = item.translate;
            //            }
            //        }
            //        foreach (Control c in tableLayoutPanel1.Controls)
            //        {
            //            if (c.Name == item.name)
            //            {
            //                c.Text = item.translate;
            //            }
            //        }
            //    }
                
            //}
            //else
            //{
            //    var data = LoadJson.DataEn;
            //    foreach (var item in data.dataWords)
            //    {
            //        foreach (Control c in this.Controls)
            //        {
            //            if (c.Name == item.name)
            //            {
            //                c.Text = item.translate;
            //            }
            //        }
            //        foreach (Control c in tableLayoutPanel1.Controls)
            //        {
            //            if (c.Name == item.name)
            //            {
            //                c.Text = item.translate;
            //            }
            //        }
            //    }
            //}
            CloseChashbox close = new CloseChashbox();
           
            this.Location = new Point(x, y);
            char[] compName = Globals.Settings.CompanyName.ToCharArray();

            lblCompanyName.Location = new Point(this.Size.Width / 2 - 100, 3);

            if (compName.Length < 10)
            {
                report_closing_of_the_day_fast_food.Location = new Point(lblCompanyName.Location.X + 20, lblCompanyName.Location.Y + 43);

            }
            else
            {
               report_closing_of_the_day_fast_food.Location = new Point(lblCompanyName.Location.X + 50, lblCompanyName.Location.Y + 43);
            }

            
            var totalsale = "";
            if (dailyOpen.Status == "closed")
            {
                 totalsale = PosRestaurant.totalSumOpenBalance.ToString("N");

            }
            else

            totalsale = dailyOpen.TotalShitje.ToString("N");
            var daily = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(Globals.User.Id);
          

            DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();
            row.Cells[0].Value = daily.DailyFiscalCount.ToString();
            row.Cells[1].Value = 0;
            row.Cells[3].Value = daily.TotalCash.ToString("N");
            row.Cells[4].Value = daily.TotalCreditCard.ToString("N");
            row.Cells[5].Value = totalsale;
            row.Cells[6].Value = dailyOpen.Amount.ToString("N");
            row.Cells[7].Value = Options.totalsum.ToString("N");
            row.Cells[8].Value = Options.dorezimi.ToString("N");
            row.Cells[9].Value = Options.gjendjaMomentale.ToString("N");
            dg.Rows.Add(row);

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

                                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                                {
                                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 5f, 10f, 150f, 5f);
                                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                                    pdfDoc.Open();
                                    PdfContentByte cb = writer.DirectContent;

                                    BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                    cb.SetColorFill(BaseColor.BLACK);
                                    cb.SetFontAndSize(bf, 14);
                                    cb.BeginText();
                                    string text = "Mbyllja e Dites";
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text, 364, 520, 0);
                                    cb.SetFontAndSize(bf, 22);

                                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{Globals.Station.Name}", 350, 550, 0);
                                    cb.SetFontAndSize(bf, 12);
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"Gjeneruar me + {DateTime.Now}" + "nga PlanetAccounting.org, info@planetaccounting.org/044 916 828", 200, 20, 0);
                                    cb.EndText();

                                    pdfDoc.Add(pdfTable);
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

      
    }
}
