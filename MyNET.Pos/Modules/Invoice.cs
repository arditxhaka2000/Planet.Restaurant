using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Word;
using Services.Models;
using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class Invoice : Form
    {
        public bool flags = false;
        public int saleId;

        bool flag = false;
        decimal totalPaTvsh = 0m;
        decimal DiscountValue = 0m;
        decimal TotalWithoutVat = 0m;
        decimal TotalVat = 0m;
        decimal TotalP = 0m;
        decimal basePrice18 = 0m;
        decimal basePrice8 = 0m;
        decimal basePrice0 = 0m;
        decimal totalVat18 = 0m;
        decimal totalVat8 = 0m;
        decimal totalVat0 = 0m;
        decimal totalWVat18 = 0m;
        decimal totalWVat8 = 0m;
        decimal totalWVat0 = 0m;
        public Invoice()
        {
            InitializeComponent();
        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            var sett = Services.Settings.Get();
            var partner = Services.Partner.Get(PosRestaurant.PartnerId);

            lblInvoiceNr.Text = Globals.Station.Id + "-" + Globals.Station.LastInvoiceNumber.ToString();
            lblDate.Text = DateTime.Now.ToString();
            lblStation.Text = Globals.Station.Name;
            lblUser.Text = Globals.User.Name;
            lblCompany.Text = sett.CompanyName;
            lblAddress.Text = sett.Address;
            lblPhone.Text = sett.PhoneNo;
            lblVatNr.Text = sett.VatNumber;
            lblUniqueNr.Text = sett.FiscalNumber;
            lblworker.Text = Globals.User.FirstName;
            lblPartner.Text = partner.Name;
            lblPartnerStation.Text = "";
            lblPartnerAddress.Text = partner.Address;
            lblPartnerPhone.Text = partner.Phone;
            lblPartnerNrFiscal.Text = partner.FiscalNo;
            lblUniqueNo.Text = partner.UniqueNo;
            lblPartnerVat.Text = partner.VatNo;
            lblPartnerUniqueNr.Text = "";


            if (flags == true)
            {
                btnConvertBillToInv.Visible = true;
            }

            System.Data.DataTable dt = new System.Data.DataTable();
            DataColumn c = new DataColumn();
            DataColumn c1 = new DataColumn();
            DataColumn c2 = new DataColumn();
            DataColumn c3 = new DataColumn();
            DataColumn c4 = new DataColumn();
            DataColumn c5 = new DataColumn();
            DataColumn c6 = new DataColumn();
            DataColumn c7 = new DataColumn();
            DataColumn c8 = new DataColumn();
            DataColumn c9 = new DataColumn();
            DataColumn c10 = new DataColumn();
            DataColumn c11 = new DataColumn();
            DataColumn c12 = new DataColumn();

            c.ColumnName = "Nr";
            c1.ColumnName = "Barkodi";
            c2.ColumnName = "Emërtimi";
            c3.ColumnName = "Njesia";
            c4.ColumnName = "Sasia";
            c5.ColumnName = "Çmimi Bazë";
            c6.ColumnName = "Zbritja(%)";
            //c11.ColumnName = "Çmimi pa TVSH";
            //c7.ColumnName = "TVSH(%)";
            c12.ColumnName = "Çmimi me TVSH";
            c8.ColumnName = "Vlera pa TVSH";
            c9.ColumnName = "Vlera e TVSH-së";
            c10.ColumnName = "Vlera Totale";
            dt.Columns.Add(c);
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            dt.Columns.Add(c6);
            //dt.Columns.Add(c11);
            //dt.Columns.Add(c7);
            dt.Columns.Add(c12);
            dt.Columns.Add(c8);
            dt.Columns.Add(c9);
            dt.Columns.Add(c10);
            for (int i = 0; i < PosRestaurant.data.Rows.Count; i++)
            {
                var basePrice = Convert.ToDecimal(PosRestaurant.data.Rows[i][8]);
                var Vat = Convert.ToInt32(PosRestaurant.data.Rows[i][16]) > 0 ? Convert.ToInt32(PosRestaurant.data.Rows[i][16]) : Services.Item.GetItemWithName(PosRestaurant.data.Rows[i][3].ToString()).First().Vat;
                var basePriceWithDiscount = basePrice - (basePrice * (Convert.ToDecimal(PosRestaurant.data.Rows[i][12]) / 100));
                var Quantity = Convert.ToDecimal(PosRestaurant.data.Rows[i][6]);
                var Discount = Convert.ToDecimal(PosRestaurant.data.Rows[i][12]);

                var TotalPrice = Math.Round(((basePrice + (basePrice * Vat / 100)) * Quantity) - (((basePrice + (basePrice * Vat / 100)) * Quantity) * Discount / 100), 2);
                var priceWithoutQuantity = Math.Round((basePriceWithDiscount + (basePriceWithDiscount * Vat / 100)), 2);
                var totalWithoutVat = Math.Round(basePriceWithDiscount * Quantity, 2);
                var VatTotal = Math.Round(TotalPrice - totalWithoutVat, 2);
                totalPaTvsh += (basePrice * Quantity);
                DiscountValue += (basePrice - basePriceWithDiscount) * Quantity;
                TotalWithoutVat += totalWithoutVat;
                TotalVat += VatTotal;
                TotalP += TotalPrice;

                if (Convert.ToInt32(PosRestaurant.data.Rows[i][16]) == 18)
                {
                    basePrice18 += totalWithoutVat;
                    totalVat18 += VatTotal;
                    totalWVat18 += TotalPrice;
                }
                if (Convert.ToInt32(PosRestaurant.data.Rows[i][16]) == 8)
                {
                    basePrice8 += totalWithoutVat;
                    totalVat8 += VatTotal;
                    totalWVat8 += TotalPrice;


                }
                if (Convert.ToInt32(PosRestaurant.data.Rows[i][16]) == 0)
                {
                    basePrice0 += totalWithoutVat;
                    totalVat0 += VatTotal;
                    totalWVat0 += TotalPrice;


                }


                dt.Rows.Add(PosRestaurant.data.Rows[i][2], PosRestaurant.data.Rows[i][4], PosRestaurant.data.Rows[i][3], PosRestaurant.data.Rows[i][5], PosRestaurant.data.Rows[i][6], basePrice, PosRestaurant.data.Rows[i][12], priceWithoutQuantity, totalWithoutVat, VatTotal, TotalPrice);
            }

            dataGridView1.DataSource = dt;

            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    totalPaTvsh += Convert.ToDecimal(item.Cells[8].Value);
            //}

            lblTotalwithoutDiscount.Text = Math.Round(totalPaTvsh, 2).ToString();
            lblDiscountTotal.Text = Math.Round(DiscountValue, 2).ToString();
            lblTotalWithoutVat.Text = TotalWithoutVat.ToString();
            lblTotalVat.Text = TotalVat.ToString();
            lblTotalPrice.Text = TotalP.ToString();
            lbl18Base.Text = basePrice18.ToString();
            lbl8Base.Text = basePrice8.ToString();
            lbl0Base.Text = basePrice0.ToString();
            lbl18BaseWOVat.Text = totalVat18.ToString();
            lbl8BaseWOVat.Text = totalVat8.ToString();
            lbl0BaseWOVat.Text = totalVat0.ToString();
            lbl18BaseWVat.Text = totalWVat18.ToString();
            lbl8BaseWVat.Text = totalWVat8.ToString();
            lbl0BaseWVat.Text = totalWVat0.ToString();


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(168, 168, 168);
            dataGridView1.EnableHeadersVisualStyles = false;
            AdjustRowHeight();
            AdjustFormHeight();
        }

        private void AdjustRowHeight()
        {
            int totalHeight = 40;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalHeight += row.Height;
            }

            totalHeight += 5;

            // Set the height of the third row in the TableLayoutPanel
            tableLayoutPanel2.RowStyles[2].SizeType = SizeType.Absolute;
            tableLayoutPanel2.RowStyles[2].Height = totalHeight;
            tableLayoutPanel2.Height = totalHeight + 100;
            // Update the layout
            tableLayoutPanel2.PerformLayout();

        }
        private void AdjustFormHeight()
        {
            // Calculate the height based on the TableLayoutPanel's height
            int newHeight = tableLayoutPanel2.Height;

            newHeight += 20;

            // Set the form's height
            this.Height = newHeight;

        }

        private void CopyColumns(System.Data.DataTable source, System.Data.DataTable dest, params string[] columns)
        {
            foreach (DataRow sourcerow in source.Rows)
            {
                DataRow destRow = dest.NewRow();
                foreach (string colname in columns)
                {
                    destRow[colname] = sourcerow[colname];
                }
                dest.Rows.Add(destRow);
            }
        }

        private void Invoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag == false)
            {
                DialogResult dialogResult = MessageBox.Show("A deshironi te vazhdoni pa shtypur Faturen?", "Invoice", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Dispose();
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            Dispose();
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            var partner = Services.Partner.Get(PosRestaurant.PartnerId);

            if (dataGridView1.Rows.Count > 0)
            {
                string faturatPOSFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FaturatPOS");
                if (!Directory.Exists(faturatPOSFolder))
                {
                    Directory.CreateDirectory(faturatPOSFolder);
                }

                // Construct the invoice filename with the folder path
                string invoiceFilename = Path.Combine(faturatPOSFolder, $"Fatura {lblInvoiceNr.Text}.pdf");
                bool fileError = false;
                iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 13, 1);
                iTextSharp.text.Font fontS = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1);
                iTextSharp.text.Font fontR = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9, 1);
                iTextSharp.text.Font fontT = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7, 1);

                if (!fileError)
                {
                    try
                    {
                        PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                        PdfPTable pdfTable1 = new PdfPTable(4);
                        PdfPTable pdfTable2 = new PdfPTable(2);
                        PdfPTable pdfTable3 = new PdfPTable(dataGridView1.Columns.Count);

                        //pdfTable.WidthPercentage = 100;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));

                            // Set background color to gray
                            cell.BackgroundColor = new iTextSharp.text.BaseColor(128, 128, 128); // Light gray

                            // Set font color to white
                            cell.Phrase.Font.Color = BaseColor.WHITE;

                            pdfTable.AddCell(cell);
                        }



                        float[] columnWidths = new float[dataGridView1.Columns.Count];
                        columnWidths[dataGridView1.Columns["Nr"].Index] = 0; // Set the width of the "Nr." column
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            if (i == dataGridView1.Columns["Nr"].Index)
                            {
                                columnWidths[i] = 8;
                            }
                            else if (i == dataGridView1.Columns["Barkodi"].Index)
                            {
                                columnWidths[i] = 32;

                            }
                            else if (i == dataGridView1.Columns["Emërtimi"].Index)
                            {
                                columnWidths[i] = 32;

                            }
                            else if (i == dataGridView1.Columns["Zbritja(%)"].Index)
                            {
                                columnWidths[i] = 18;

                            }
                            else if (i == dataGridView1.Columns["Njesia"].Index)
                            {
                                columnWidths[i] = 17;

                            }
                            else if (i == dataGridView1.Columns["Sasia"].Index)
                            {
                                columnWidths[i] = 15;

                            }
                            else
                            {
                                columnWidths[i] = 20;

                            }

                        }

                        pdfTable.SetWidths(columnWidths);

                        //pdfTable1.AddCell("Norma");
                        //pdfTable1.AddCell("Baza");
                        //pdfTable1.AddCell("Vl. pa Tvsh");
                        //pdfTable1.AddCell("Vl. me Tvsh");
                        PdfPCell cells1 = new PdfPCell(new Phrase("Norma", fontT));
                        PdfPCell cells2 = new PdfPCell(new Phrase("Baza", fontT));
                        PdfPCell cells3 = new PdfPCell(new Phrase("Vl. pa Tvsh", fontT));
                        PdfPCell cells4 = new PdfPCell(new Phrase("Vl. me Tvsh", fontT));
                        PdfPCell cells5 = new PdfPCell(new Phrase("TVSH18%", fontT));
                        PdfPCell cells6 = new PdfPCell(new Phrase($"{lbl18Base.Text}€", fontT));
                        PdfPCell cells7 = new PdfPCell(new Phrase($"{lbl18BaseWOVat.Text}€", fontT));
                        PdfPCell cells8 = new PdfPCell(new Phrase($"{lbl18BaseWVat.Text}€", fontT));
                        PdfPCell cells9 = new PdfPCell(new Phrase("TVSH8%", fontT));
                        PdfPCell cells10 = new PdfPCell(new Phrase($"{lbl8Base.Text}", fontT));
                        PdfPCell cells11 = new PdfPCell(new Phrase($"{lbl8BaseWOVat.Text}€", fontT));
                        PdfPCell cells12 = new PdfPCell(new Phrase($"{lbl8BaseWVat.Text} €", fontT));
                        PdfPCell cells13 = new PdfPCell(new Phrase("TVSH0%", fontT));
                        PdfPCell cells14 = new PdfPCell(new Phrase($"{lbl0Base.Text} €", fontT));
                        PdfPCell cells15 = new PdfPCell(new Phrase($"{lbl0BaseWOVat.Text} €", fontT));
                        PdfPCell cells16 = new PdfPCell(new Phrase($"{lbl8BaseWVat.Text} €", fontT));
                        pdfTable1.AddCell(cells1);
                        pdfTable1.AddCell(cells2);
                        pdfTable1.AddCell(cells3);
                        pdfTable1.AddCell(cells4);
                        pdfTable1.AddCell(cells5);
                        pdfTable1.AddCell(cells6);
                        pdfTable1.AddCell(cells7);
                        pdfTable1.AddCell(cells8);
                        pdfTable1.AddCell(cells9);
                        pdfTable1.AddCell(cells10);
                        pdfTable1.AddCell(cells11);
                        pdfTable1.AddCell(cells12);
                        pdfTable1.AddCell(cells13);
                        pdfTable1.AddCell(cells14);
                        pdfTable1.AddCell(cells15);
                        pdfTable1.AddCell(cells16);


                        PdfPCell cells17 = new PdfPCell(new Phrase($"Vlera pa zbritje:", fontT));
                        PdfPCell cells18 = new PdfPCell(new Phrase($"Vlera e zbritjes:", fontT));
                        PdfPCell cells19 = new PdfPCell(new Phrase($"Vlera pa TVSH:", fontT));
                        PdfPCell cells20 = new PdfPCell(new Phrase($"Vlera e TVSH-se:", fontT));
                        PdfPCell cells21 = new PdfPCell(new Phrase($"Vlera Totale:", fontS));
                        PdfPCell cells22 = new PdfPCell(new Phrase($"{lblTotalwithoutDiscount.Text}€", fontT));
                        PdfPCell cells23 = new PdfPCell(new Phrase($"{lblDiscountTotal.Text}€", fontT));
                        PdfPCell cells24 = new PdfPCell(new Phrase($"{lblTotalWithoutVat.Text}€", fontT));
                        PdfPCell cells25 = new PdfPCell(new Phrase($"{lblTotalVat.Text}€", fontT));
                        PdfPCell cells26 = new PdfPCell(new Phrase($"{lblTotalPrice.Text}€", fontS));

                        cells17.Border = PdfPCell.NO_BORDER;
                        cells17.BackgroundColor = BaseColor.WHITE;
                        cells18.Border = PdfPCell.NO_BORDER;
                        cells18.BackgroundColor = BaseColor.WHITE;
                        cells19.Border = PdfPCell.NO_BORDER;
                        cells19.BackgroundColor = BaseColor.WHITE;
                        cells20.Border = PdfPCell.NO_BORDER;
                        cells20.BackgroundColor = BaseColor.WHITE;
                        cells21.Border = PdfPCell.NO_BORDER;
                        cells21.BackgroundColor = BaseColor.WHITE;
                        cells22.Border = PdfPCell.NO_BORDER;
                        cells22.BackgroundColor = BaseColor.WHITE;
                        cells23.Border = PdfPCell.NO_BORDER;
                        cells23.BackgroundColor = BaseColor.WHITE;
                        cells24.Border = PdfPCell.NO_BORDER;
                        cells24.BackgroundColor = BaseColor.WHITE;
                        cells25.Border = PdfPCell.NO_BORDER;
                        cells25.BackgroundColor = BaseColor.WHITE;
                        cells26.Border = PdfPCell.NO_BORDER;
                        cells26.BackgroundColor = BaseColor.WHITE;

                        cells22.PaddingRight = 10;
                        cells23.PaddingRight = 10;
                        cells24.PaddingRight = 10;
                        cells25.PaddingRight = 10;
                        cells26.PaddingRight = 10;
                        cells22.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cells23.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cells24.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cells25.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cells26.HorizontalAlignment = Element.ALIGN_RIGHT;

                        pdfTable2.AddCell(cells17);
                        pdfTable2.AddCell(cells22);
                        pdfTable2.AddCell(cells18);
                        pdfTable2.AddCell(cells23);
                        pdfTable2.AddCell(cells19);
                        pdfTable2.AddCell(cells24);
                        pdfTable2.AddCell(cells20);
                        pdfTable2.AddCell(cells25);
                        pdfTable2.AddCell(cells21);
                        pdfTable2.AddCell(cells26);





                        using (FileStream stream = new FileStream(invoiceFilename, FileMode.Create))
                        {
                            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 5f, 10f, 105f, 5f);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                            writer.PageEvent = new Helper.InvoicePDF();


                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        PdfPCell cells = new PdfPCell(new Phrase(cell.Value.ToString(), fontR));

                                        pdfTable.AddCell(cells);
                                    }
                                }
                            }

                            pdfDoc.Open();

                            PdfContentByte cb = writer.DirectContent;

                            Helper.InvoicePDF invoice = new Helper.InvoicePDF();
                            invoice.InvoiceNo = Globals.Station.Id + "-" + Globals.Station.LastInvoiceNumber.ToString();
                            invoice.OnOpenDocument(writer, pdfDoc);

                            int pageRows = 0;
                            int a = 1;



                            double asa = dataGridView1.Rows.Count / 17.0;
                            int v = asa > 1 ? (int)Math.Ceiling(dataGridView1.Rows.Count / 17.0) : 0;

                            int firstpage = 0;

                            while (pageRows < dataGridView1.Rows.Count)
                            {
                                pdfTable.TotalWidth = 580f;

                                int ypos = a > 1 ? 800 : 620;

                                if (firstpage == 0)
                                {
                                    int req = dataGridView1.Rows.Count == 17 ? 17 + 1 : 17;
                                    pdfTable.WriteSelectedRows(pageRows, pageRows + req, 8, ypos, cb);
                                    var lastR = pageRows;
                                    pageRows += 17;

                                    if (pageRows >= dataGridView1.Rows.Count)
                                    {
                                        //qitu duhet me e kqyr sa qysh tek!!!!
                                        float lastPageHeight = pdfDoc.PageSize.Height - (dataGridView1.Rows.Count - lastR) * pdfTable.TotalHeight / dataGridView1.Rows.Count;

                                        pdfTable1.TotalWidth = 200f;
                                        pdfTable2.TotalWidth = 150f;

                                        float pdfTable1Height = pdfTable1.TotalHeight;
                                        float pdfTable2Height = pdfTable2.TotalHeight;

                                        if (pdfTable2Height <= lastPageHeight)
                                        {
                                            // There is enough space to fit both tables on the last page
                                            float yPosition = pdfDoc.TopMargin + 60; // Adjust this as needed
                                            pdfTable1.WriteSelectedRows(0, 4, 10, yPosition, cb);
                                            pdfTable2.WriteSelectedRows(0, 5, pdfDoc.PageSize.Width / 2 + 150, yPosition, cb);
                                        }
                                        else
                                        {
                                            pdfDoc.NewPage();
                                            pdfTable1.WriteSelectedRows(0, 4, 10, pdfDoc.GetBottom(180), cb);
                                            pdfTable2.WriteSelectedRows(0, 5, pdfDoc.PageSize.Width / 2 + 150, pdfDoc.GetBottom(180), cb);
                                        }
                                        invoice.OnCloseDocument(writer, pdfDoc);

                                    }

                                    if (v > 0)
                                    {
                                        pdfDoc.NewPage();
                                        v--;
                                        firstpage++;
                                    }

                                    a++;
                                }
                                else
                                {
                                    pdfTable.WriteSelectedRows(pageRows, pageRows + 27, 8, ypos, cb);
                                    var lastR = pageRows;
                                    pageRows += 27;
                                    if (pageRows > dataGridView1.Rows.Count)
                                    {
                                        float lastPageHeight = pdfDoc.PageSize.Height - (dataGridView1.Rows.Count - lastR) * pdfTable.TotalHeight / dataGridView1.Rows.Count;

                                        pdfTable1.TotalWidth = 200f;
                                        pdfTable2.TotalWidth = 150f;

                                        float pdfTable1Height = pdfTable1.TotalHeight;
                                        float pdfTable2Height = pdfTable2.TotalHeight;

                                        if (pdfTable2Height <= lastPageHeight)
                                        {
                                            // There is enough space to fit both tables on the last page
                                            float yPosition = pdfDoc.TopMargin + 60; // Adjust this as needed
                                            pdfTable1.WriteSelectedRows(0, 4, 10, yPosition, cb);
                                            pdfTable2.WriteSelectedRows(0, 5, pdfDoc.PageSize.Width / 2 + 150, yPosition, cb);
                                        }
                                        else
                                        {
                                            pdfDoc.NewPage();
                                            pdfTable1.WriteSelectedRows(0, 4, 10, pdfDoc.GetBottom(180), cb);
                                            pdfTable2.WriteSelectedRows(0, 5, pdfDoc.PageSize.Width / 2 + 150, pdfDoc.GetBottom(180), cb);
                                        }
                                        invoice.OnCloseDocument(writer, pdfDoc);

                                    }
                                    if (v - 1 > 0)
                                    {
                                        pdfDoc.NewPage();
                                        v--;
                                    }

                                    a++;
                                }
                            }





                            pdfDoc.Close();
                            stream.Close();


                        }
                        Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument();

                        // Load the PDF file from the desktop
                        doc.LoadFromFile(invoiceFilename);

                        // Print to the default printer
                        doc.Print();

                        MessageBox.Show("Fatura u shtyp me sukses!", "Info");


                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Nuk ka te dhena!", "Info");
            }

        }

        private void btnConvertBillToInv_Click(object sender, EventArgs e)
        {
            Services.Sale.updateConvert(saleId, PosRestaurant.PartnerId, 1);
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
