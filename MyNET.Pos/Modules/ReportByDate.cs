using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class ReportByDate : Form
    {
        public static DateTime dateT;
        public static DateTime dateF;
        public ReportByDate()
        {
            InitializeComponent();
        }

        private void ReportByDate_Load(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();

            //if (globals.Language == "Sq")
            //{
            //    var data = LoadJson.DataSq;
            //    foreach(var item in data.dataWords)
            //    {
            //        foreach(Control c in this.Controls)
            //        {
            //            if(c.Name == item.name)
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
            //    }
            //}

            dtDate.Format = DateTimePickerFormat.Custom;
            dtDate.CustomFormat = "MM/dd/yyyy HH:mm:ss tt";
            dFDate.Format = DateTimePickerFormat.Custom;
            dFDate.CustomFormat = "MM/dd/yyyy HH:mm:ss tt";
            dFDate.Value = DateTime.Now.AddDays(-1);

        }

        public void LoadReport()
        {
            //int saleId = 1;

            //var items
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            int stationId = Globals.Station.Id;
            var totalshitje = 0.0m;
            var selectedFromDate = dFDate.Value;
            var selectedToDate = dtDate.Value;
            dateF = new DateTime(selectedFromDate.Year, selectedFromDate.Month, selectedFromDate.Day, selectedFromDate.Hour, selectedFromDate.Minute, selectedFromDate.Second);
            dateT = new DateTime(selectedToDate.Year, selectedToDate.Month, selectedToDate.Day, selectedToDate.Hour, selectedToDate.Minute, selectedToDate.Second);


            var items = Services.SaleDetails.getSalesDetailsByDate(dateF, dateT);

            Column1.Visible = true;
            DataTable dt = new DataTable();

            dt.Columns.Add("Shifra");
            dt.Columns.Add("Emri");
            dt.Columns.Add("Sasia");
            dt.Columns.Add("Vlera e Shitjes");

            DataColumn[] keyColumns = new DataColumn[1];
            keyColumns[0] = dt.Columns["Shifra"];
            dt.PrimaryKey = keyColumns;
            var quantity = 0.0M;

            var allItem = Services.Item.GetItemsDiscount(Globals.Station.Id);


            foreach (var item in items)
            {

                if (dt.Rows.Count > 0)
                {
                    bool exists = dt.Rows.Contains(item.ItemId);
                    var it = allItem.Where(i => i.Id == item.ItemId);
                    var list = it.ToList();
                    decimal vat = list.First().Vat;


                    if (!exists)
                    {
                        var ta = Math.Round(item.Price + (item.Price * (vat / 100)), 2);
                        dt.Rows.Add(item.ItemId, it.FirstOrDefault().ItemName, item.Quantity, ta);
                    }

                    else
                    {
                        //DataRow dr = dt.Select($"Shifra={item.ItemId}").FirstOrDefault();
                        string find = item.ItemId.ToString();
                        var result = dt.Rows.Find(find);
                        if (result != null)
                        {
                            var ta = Math.Round(item.Price + (item.Price * (vat / 100)), 2);
                            quantity = Convert.ToDecimal(result["Sasia"].ToString()) + item.Quantity;
                            var total = ta * quantity;

                            result["Vlera e Shitjes"] = Math.Round(total, 2);
                            result["Sasia"] = quantity;
                        }

                    }

                }

                else
                {
                    var it = allItem.Where(i => i.Id == item.ItemId);
                    var list = it.ToList();
                    decimal vat = list.First().Vat;
                    var total = (item.Price + (item.Price * (vat / 100))) * item.Quantity;
                    var ta = Math.Round(total, 2);
                    dt.Rows.Add(item.ItemId, it.FirstOrDefault().ItemName, item.Quantity, ta);


                }
            }

            int b = 0;
            dataGridView1.DataSource = dt;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                b += 1;
                row.Cells[0].Value = b;
                totalshitje += Convert.ToDecimal(row.Cells[4].Value);
            }

            var t = Math.Round(totalshitje, 2);
            lblTotal.Text = t.ToString();

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
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
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4.Rotate(), 5f, 10f, 105f, 5f);
                                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                                writer.PageEvent = new Helper.ITextEvents();
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                { 
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        if (cell.Value != null) 
                                        {
                                            pdfTable.AddCell(cell.Value.ToString());
                                        }
                                    }
                                }
                                pdfDoc.Open();

                                PdfContentByte cb = writer.DirectContent;

                                int pageRows = 0;
                                //Ky loop e lejon tabelen ne pdf me pas veq 20 rreshta
                                while (pageRows < dataGridView1.Rows.Count)
                                {
                                    cb.BeginText();
                                    pdfTable.TotalWidth = 770f;
                                    pdfTable.WriteSelectedRows(pageRows, pageRows + 20, 20, 450, cb);
                                    pageRows += 20;
                                    cb.EndText();
                                    pdfDoc.NewPage();
                                }
                                Paragraph para = new Paragraph("Hello world. Checking Header Footer");
                                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                //cb.SetColorFill(BaseColor.BLACK);
                                //cb.SetFontAndSize(bf, 14);
                                //cb.BeginText();
                                //string text = "Shitjet sipas artikujve ne periudhen:" + dFDate.Value.ToString() + " deri me: " + dtDate.Value.ToString();
                                //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text, 200, 520, 0);
                                //cb.SetFontAndSize(bf, 22);

                                //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"{Globals.Station.Name}", 350, 550, 0);
                                //cb.SetFontAndSize(bf, 12);
                                //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, $"Gjeneruar me: {DateTime.Now}" + "nga PlanetAccounting.org, info@planetaccounting.org/044 916 828", 200, 20, 0);
                                //cb.EndText();

                                //pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
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
    }
}
