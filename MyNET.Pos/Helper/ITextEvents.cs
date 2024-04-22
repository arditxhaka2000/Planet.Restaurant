using iTextSharp.text;
using iTextSharp.text.pdf;
using MyNET.Pos.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Pos.Helper
{
    public class ITextEvents : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;

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

                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bf, 14);
                cb.BeginText();
                string text = "";
                if (Options.formButton == 1)
                {
                    text = "Shitjet ne periudhen:" + Options.dateF.ToString() + " deri me: " + Options.dateTo.ToString();
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text, 170, 520, 0);


                }
                if (Options.formButton == 2)
                {
                    text = "Shitjet e pasinkronizuara ne periudhen:" + Options.dateFF.ToString() + " deri me: " + Options.dateFTo.ToString();
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text, 170, 520, 0);


                }
                if (Options.formButton == 3)
                {
                    text = "Artikujt pa stok te ndare me muaj";
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text, 330, 520, 0);


                }
                cb.SetFontAndSize(bf, 22);

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{Globals.Station.Name}", 350, 550, 0);
                cb.SetFontAndSize(bf, 12);
                //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"Gjeneruar me: {DateTime.Now}" + "nga PlanetAccounting.org, info@planetaccounting.org/044 916 828", 200, 20, 0);
                cb.EndText();
            }
            catch (DocumentException de)
            {
            }
            catch (System.IO.IOException ioe)
            {
            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            //base.OnEndPage(writer, document);
            //iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            //iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            //Phrase p1Header = new Phrase($"{Globals.Station.Name}", baseFontBig);

            ////Create PdfTable object
            //PdfPTable pdfTab = new PdfPTable(3);

            ////We will have to create separate cells to include image logo and 2 separate strings
            ////Row 1
            //PdfPCell pdfCell1 = new PdfPCell();
            //PdfPCell pdfCell2 = new PdfPCell(p1Header);
            //PdfPCell pdfCell3 = new PdfPCell();
            //String text = "ardit";
            //string a = $"Gjeneruar me: {DateTime.Now}" + " nga PlanetAccounting.org, info@planetaccounting.org/044 916 828";

            ////Add paging to header
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(bf, 12);
            //    cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(45));
            //    cb.EndText();
            //    float len = bf.GetWidthPoint(text, 12);
            //    //Adds "12" in Page 1 of 12
            //    //cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
            //}
            ////Add paging to footer
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(bf, 12);
            //    cb.SetTextMatrix(document.PageSize.GetRight(120), document.PageSize.GetBottom(30));
            //    //cb.ShowText(text);
            //    cb.SetTextMatrix(document.PageSize.GetLeft(80), document.PageSize.GetBottom(30));
            //    cb.ShowText(a);
            //    cb.EndText();
            //    float len = bf.GetWidthPoint(text, 12);
            //    //cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180) + len, document.PageSize.GetBottom(30));
            //}

            ////Row 2
            //PdfPCell pdfCell4 = new PdfPCell(new Phrase("Shitjet sipas artikujve ne periudhen:" + Options.dateF.ToString() + " deri me: " + Options.dateTo.ToString(), baseFontNormal));

            ////Row 3 
            ////PdfPCell pdfCell5 = new PdfPCell(new Phrase("Date:" + PrintTime.ToShortDateString(), baseFontNormal));
            //PdfPCell pdfCell6 = new PdfPCell();
            ////PdfPCell pdfCell7 = new PdfPCell(new Phrase("TIME:" + string.Format("{0:t}", DateTime.Now), baseFontNormal));

            ////set the alignment of all three cells and set border to 0
            //pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER;
            ////pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER;
            //pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER;
            ////pdfCell7.HorizontalAlignment = Element.ALIGN_CENTER;

            //pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;
            //pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
            //pdfCell4.VerticalAlignment = Element.ALIGN_TOP;
            ////pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
            //pdfCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
            ////pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE;

            //pdfCell4.Colspan = 3;

            //pdfCell1.Border = 0;
            //pdfCell2.Border = 0;
            //pdfCell3.Border = 0;
            //pdfCell4.Border = 0;
            ////pdfCell5.Border = 0;
            //pdfCell6.Border = 0;
            ////pdfCell7.Border = 0;

            ////add all three cells into PdfTable
            //pdfTab.AddCell(pdfCell1);
            //pdfTab.AddCell(pdfCell2);
            //pdfTab.AddCell(pdfCell3);
            //pdfTab.AddCell(pdfCell4);
            ////pdfTab.AddCell(pdfCell5);
            //pdfTab.AddCell(pdfCell6);
            ////pdfTab.AddCell(pdfCell7);

            //pdfTab.TotalWidth = document.PageSize.Width - 80f;
            //pdfTab.WidthPercentage = 70;
            ////pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;    

            ////call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            ////first param is start row. -1 indicates there is no end row and all the rows to be included to write
            ////Third and fourth param is x and y position to start writing
            //pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
            ////set pdfContent value

            ////Move the pointer and draw line to separate header section from rest of page
            //cb.MoveTo(40, document.PageSize.Height - 100);
            //cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
            //cb.Stroke();

            ////Move the pointer and draw line to separate footer section from rest of page
            //cb.MoveTo(40, document.PageSize.GetBottom(50));
            //cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
            //cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            //base.OnCloseDocument(writer, document);
            cb = writer.DirectContent;
            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            //footerTemplate = cb.CreateTemplate(100, 100);

            //footerTemplate.BeginText();
            //footerTemplate.SetFontAndSize(bf, 9);
            //footerTemplate.SetTextMatrix(0, 0);
            //footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            //footerTemplate.EndText();
            string a = $"Gjeneruar me: {DateTime.Now}" + " nga PlanetAccounting.org, info@planetaccounting.org/044 916 828";

            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 12);
                cb.SetTextMatrix(document.PageSize.GetLeft(80), document.PageSize.GetBottom(30));
                cb.ShowText(a);
                cb.SetTextMatrix(document.PageSize.GetLeft(40), document.PageSize.GetBottom(70));

                cb.EndText();
                float len = bf.GetWidthPoint(a, 9);
                //cb.AddTemplate(footerTemplate, document.PageSize.GetRight(180) + len, document.PageSize.GetBottom(30));
            }

        }
    }
}

