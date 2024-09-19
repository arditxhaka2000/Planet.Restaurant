using Dapper;
using iText.IO.Image;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MyNET.Pos.Modules;
using Spire.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MyNET.Pos.Helper
{
    public class InvoicePDF : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;
        public string InvoiceNo;
        #region Fields
        private string _header;
        #endregion

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(100, 100);
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException de)
            {
            }
            catch (System.IO.IOException ioe)
            {
            }
            base.OnEndPage(writer, document);
            iTextSharp.text.Font baseFontDate = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font baseFontImportant = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            PdfPTable pdfTab = new PdfPTable(3);
            string assemblyPath = System.Windows.Forms.Application.StartupPath + $"\\ImagesPath{Globals.Settings.Id}\\Logo.jpg";

            System.Drawing.Image myImage = System.Drawing.Image.FromFile(assemblyPath);
            using (MemoryStream ms = new MemoryStream())
            {
                myImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Adjust format as needed
                byte[] imageBytes = ms.ToArray();
                iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageBytes);
                PdfPCell cell = new PdfPCell(pdfImage);
                cell.FixedHeight = 80f; // Set desired height in float units
                cell.Border = 0;
                pdfTab.AddCell(cell);


            }

            PdfPCell p1Header = new PdfPCell(new Phrase($"FATURA: {InvoiceNo}", baseFontBig));
            PdfPCell pdfCell5 = new PdfPCell(new Phrase("Date: " + PrintTime.ToShortDateString(), baseFontDate));
            PdfPCell pdfCell8 = new PdfPCell(new Phrase(Globals.Station.Name, baseFontNormal));
            PdfPCell pdfCell7 = new PdfPCell(new Phrase("Personi pergjegjes: " + Globals.User.Name, baseFontNormal));

            PdfPTable headerSplit = new PdfPTable(1);
            p1Header.Border = 0;
            pdfCell5.Border = 0;
            pdfCell8.Border = 0;
            pdfCell7.Border = 0;
            headerSplit.AddCell(p1Header);
            headerSplit.AddCell(pdfCell5);
            headerSplit.AddCell(pdfCell8);
            headerSplit.AddCell(pdfCell7);
            pdfTab.DefaultCell.Border = 0;

            pdfTab.AddCell(headerSplit);
            //Create PdfTable object
            var partner = Services.Partner.Get(RestaurantPos.PartnerId);

            //We will have to create separate cells to include image logo and 2 separate strings
            //Row 1
            //PdfPCell pdfCell2 = new PdfPCell(p1Header);
            String text = "ardit";
            //string a = $"Gjeneruar me: {DateTime.Now}" + " nga PlanetAccounting.org, info@planetaccounting.org/044 916 828";

            //Add paging to header
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(100));
                cb.EndText();
                float len = bf.GetWidthPoint(text, 12);
                //Adds "12" in Page 1 of 12
                //cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
            }
            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 12);
                cb.SetTextMatrix(document.PageSize.GetRight(120), document.PageSize.GetBottom(30));
                //cb.ShowText(text);
                cb.SetTextMatrix(document.PageSize.GetLeft(80), document.PageSize.GetBottom(30));
                //cb.ShowText(a);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 12);
                //cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180) + len, document.PageSize.GetBottom(30));
            }

            //Row 2

            //Row 3 
            //PdfPCell pdfCell4 = new PdfPCell(new Phrase(Globals.Settings.CompanyName, baseFontBig));
            //PdfPCell pdfCell6 = new PdfPCell();

            //PdfPCell pdfCell7 = new PdfPCell(new Phrase("Personi pergjegjes: " + Globals.User.Name, baseFontNormal));
            //PdfPCell pdfCell8 = new PdfPCell(new Phrase(Globals.Station.Name, baseFontNormal));
            PdfPCell pdfCell9 = new PdfPCell();
            PdfPCell pdfCell10 = new PdfPCell(new Phrase("Shitësi: " + Globals.Settings.CompanyName, baseFontNormal));
            PdfPCell pdfCell11 = new PdfPCell(new Phrase($"Nr.Unik: {Globals.Settings.BusinessNumber}", baseFontNormal));
            PdfPCell pdfCell12 = new PdfPCell(new Phrase($"Nr. Fiskal: {Globals.Settings.FiscalNumber}", baseFontNormal));
            PdfPCell pdfCell18 = new PdfPCell(new Phrase($"Nr. TVSH-se: {Globals.Settings.VatNumber}", baseFontNormal));
            PdfPCell pdfCell13 = new PdfPCell(new Phrase($"Adresa: {Globals.Settings.Address}", baseFontNormal));

            PdfPCell pdfCell14 = new PdfPCell(new Phrase($"Blerësi: {partner.CompanyName}", baseFontNormal));
            PdfPCell pdfCell15 = new PdfPCell(new Phrase($"Nr.Unik: {partner.UniqueNo}", baseFontNormal));
            PdfPCell pdfCell16 = new PdfPCell(new Phrase($"Nr. Fiskal: {partner.FiscalNo}", baseFontNormal));
            PdfPCell pdfCell19 = new PdfPCell(new Phrase($"Nr. TVSH-se: {partner.VatNo}", baseFontNormal));
            PdfPCell pdfCell17 = new PdfPCell(new Phrase($"Adresa: {partner.Address}", baseFontNormal));


            pdfCell10.Border = 2;
            pdfCell11.Border = 2;
            pdfCell12.Border = 2;
            pdfCell14.Border = 2;
            pdfCell15.Border = 2;
            pdfCell16.Border = 2;

            PdfPTable pdfCell4Split = new PdfPTable(2);
            pdfCell4Split.AddCell(pdfCell10);
            pdfCell4Split.AddCell(pdfCell12);
            pdfCell4Split.AddCell(pdfCell11);
            pdfCell4Split.AddCell(pdfCell18);
            pdfCell4Split.AddCell(pdfCell13);

            PdfPTable pdfCell5Split = new PdfPTable(2);
            pdfCell5Split.AddCell(pdfCell14);
            pdfCell5Split.AddCell(pdfCell16);
            pdfCell5Split.AddCell(pdfCell15);
            pdfCell5Split.AddCell(pdfCell19);
            pdfCell5Split.AddCell(pdfCell17);


            //set the alignment of all three cells and set border to 0
            //pdfCell2.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfCell4.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfCell5.HorizontalAlignment = Element.ALIGN_RIGHT;
            //pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell7.HorizontalAlignment = Element.ALIGN_RIGHT;


            //pdfCell4.VerticalAlignment = Element.ALIGN_TOP;
            //pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
            //pdfCell6.VerticalAlignment = Element.ALIGN_TOP;
            //pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE;


            //pdfCell4.Colspan = 3;
            //pdfCell5.Colspan = 3;
            //pdfCell7.Colspan = 3;

            //pdfCell2.Border = 0;
            //pdfCell4.Border = 0;
            pdfCell5.Border = 0;
            pdfCell7.Border = 0;
            pdfTab.DefaultCell.Border = 0;


            //add all three cells into PdfTable
            //pdfTab.AddCell(pdfCell2);
            //pdfTab.AddCell(pdfCell4);
            //pdfTab.AddCell(pdfCell5);

            PdfPCell cellBlankRow = new PdfPCell(new Phrase(" "));
            cellBlankRow.Border = 0;
            pdfCell10.HorizontalAlignment = 1;
            pdfCell4Split.HorizontalAlignment = 1;
            pdfCell5Split.HorizontalAlignment = 1;
            pdfCell13.HorizontalAlignment = 1;
            pdfCell18.HorizontalAlignment = 1;
            pdfCell19.HorizontalAlignment = 1;
            pdfCell17.HorizontalAlignment = 1;
            pdfCell14.HorizontalAlignment = 1;
            pdfCell15.HorizontalAlignment = 1;
            pdfCell16.HorizontalAlignment = 1;
            pdfCell10.Border = 2;
            pdfCell13.Border = 2;
            pdfCell17.Border = 2;
            pdfCell14.Border = 2;
            pdfTab.AddCell(cellBlankRow);
            pdfTab.AddCell("");
            pdfTab.AddCell("");
            pdfTab.AddCell(cellBlankRow);
            pdfTab.AddCell(pdfCell4Split);
            pdfTab.AddCell("");
            pdfTab.AddCell(pdfCell5Split);
            pdfTab.AddCell(pdfCell13);
            pdfTab.AddCell("");
            pdfTab.AddCell(pdfCell17);
            //pdfTab.AddCell(pdfCell7);


            pdfTab.TotalWidth = document.PageSize.Width - 80f;
            pdfTab.WidthPercentage = 70;
            //pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;    

            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
            pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);



        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);
            //    iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            //    iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            //    Phrase p1Header = new Phrase("Fatura", baseFontBig);

            //    //Create PdfTable object
            //    PdfPTable pdfTab = new PdfPTable(3);

            //    //We will have to create separate cells to include image logo and 2 separate strings
            //    //Row 1
            PdfPCell pdfCell3 = new PdfPCell();
            String text = "ardit";
            string a = $"Gjeneruar me: {DateTime.Now}" + " nga PlanetAccounting.org, info@planetaccounting.org/044 916 828";

            //    //Add paging to header
            //    {
            //        cb.BeginText();
            //        cb.SetFontAndSize(bf, 9);
            //        cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(100));
            //        cb.EndText();
            //        float len = bf.GetWidthPoint(text, 12);
            //        //Adds "12" in Page 1 of 12
            //        //cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
            //    }
            //    //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(document.PageSize.GetRight(2), document.PageSize.GetBottom(30));
                //cb.ShowText(text);
                cb.SetTextMatrix(document.PageSize.GetLeft(750), document.PageSize.GetBottom(15));
                cb.ShowText(a);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 12);
                //cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180) + len, document.PageSize.GetBottom(30));
            }

            //    //Row 2
            //    PdfPCell pdfCell4 = new PdfPCell(new Phrase("Date:" + PrintTime.ToShortDateString(), baseFontNormal));

            //    //Row 3 
            //    PdfPCell pdfCell5 = new PdfPCell(new Phrase("Njesia e shitjes: " + Globals.Station.Name, baseFontNormal));
            //    //PdfPCell pdfCell6 = new PdfPCell();

            //    PdfPCell pdfCell7 = new PdfPCell(new Phrase("Personi pergjegjes: " + Globals.User.Name, baseFontNormal));

            //    //set the alignment of all three cells and set border to 0
            //    pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //    pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
            //    pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER;
            //    pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER;
            //    pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER;
            //    //pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER;
            //    pdfCell7.HorizontalAlignment = Element.ALIGN_CENTER;

            //    pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;
            //    pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
            //    pdfCell4.VerticalAlignment = Element.ALIGN_TOP;
            //    pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
            //    //pdfCell6.VerticalAlignment = Element.ALIGN_TOP;
            //    pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE;

            //    pdfCell4.Colspan = 3;
            //    pdfCell5.Colspan = 3;
            //    pdfCell7.Colspan = 4;

            //    pdfCell1.Border = 0;
            //    pdfCell2.Border = 0;
            //    pdfCell3.Border = 0;
            //    pdfCell4.Border = 0;
            //    pdfCell5.Border = 0;
            //    //pdfCell6.Border = 0;
            //    pdfCell7.Border = 0;

            //    //add all three cells into PdfTable
            //    pdfTab.AddCell(pdfCell1);
            //    pdfTab.AddCell(pdfCell2);
            //    pdfTab.AddCell(pdfCell3);
            //    pdfTab.AddCell(pdfCell4);
            //    pdfTab.AddCell(pdfCell5);
            //    //pdfTab.AddCell(pdfCell6);
            //    pdfTab.AddCell(pdfCell7);

            //    pdfTab.TotalWidth = document.PageSize.Width - 80f;
            //    pdfTab.WidthPercentage = 70;
            //    //pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;    

            //    //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //    //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //    //Third and fourth param is x and y position to start writing
            //    pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
            //    //set pdfContent value

            //    ////Move the pointer and draw line to separate header section from rest of page
            //    //cb.MoveTo(40, document.PageSize.Height - 100);
            //    //cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
            //    //cb.Stroke();

            //    ////Move the pointer and draw line to separate footer section from rest of page
            //    //cb.MoveTo(40, document.PageSize.GetBottom(50));
            //    //cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
            //    //cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            headerTemplate.BeginText();
            headerTemplate.SetFontAndSize(bf, 9);
            headerTemplate.SetTextMatrix(0, 0);
            headerTemplate.ShowText((writer.PageNumber - 1).ToString());
            headerTemplate.EndText();
            string a = $"Gjeneruar me: {DateTime.Now}" + " nga PlanetAccounting.org, info@planetaccounting.org/044 916 828";
            string b = "Shitesi:_______________";
            string c = "Bleresi:_______________";

            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 9);
                cb.SetTextMatrix(document.PageSize.GetLeft(80), document.PageSize.GetBottom(30));
                cb.ShowText(a);
                cb.SetTextMatrix(document.PageSize.GetLeft(30), document.PageSize.GetBottom(70));
                cb.ShowText(b);
                cb.SetTextMatrix(document.PageSize.GetRight(140), document.PageSize.GetBottom(70));
                cb.ShowText(c);

                cb.EndText();
                float len = bf.GetWidthPoint(a, 9);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180) + len, document.PageSize.GetBottom(30));
            }

        }
    }
}

