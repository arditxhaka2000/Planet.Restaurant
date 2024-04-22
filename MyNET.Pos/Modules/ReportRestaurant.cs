using iTextSharp.text;
using iTextSharp.text.pdf;
using MyNET.Pos.Modules;
using MyNET.Shops;
using RestSharp;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TremolZFP;

namespace MyNET.Pos.Modules
{
    public partial class ReportRestaurant : Form
    {

        public Form Parenti { get; set; }
        public static bool flag = false;
        public static bool flagcashbox = false;
        public static bool flagAll = false;
        public static DateTime dateT;
        public static DateTime dateTo;
        public static DateTime dateF;
        public static decimal openAmount;
        public static decimal totalsum;
        public static decimal gjendjaMomentale;
        public static decimal dorezimi;
        public static int dailyOpenId = Globals.User.Id;

        Services.DailyOpenCloseBalance dailyOpen = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(dailyOpenId);

        List<Services.Printer> printers = Services.Printer.Get();
        public ReportRestaurant()
        {
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();

            if (Globals.Settings.PIN == "0" || Globals.Settings.PIN == null)
            {
                frm.Show();
            }
            else
            {
                EnterPin enterPin = new EnterPin();
                enterPin.ShowDialog();
                if (enterPin.flag == true)
                {
                    frm.Show();
                }
            }


        }

        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            DailyReport frm = new DailyReport();
            frm.ShowDialog();
        }

        private void btnZRaport_Click(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();

            try
            {
                //shtyp raportin Z
                string path = "";
                if (globals != null)
                {
                    path = Globals.Settings.FiscalPrinterPath;

                }
                else
                {
                    MessageBox.Show(word_choose_fiscal_path.Text);
                }

                if (globals.FiscalPrinterType == "Tremol")
                {
                    if (globals.PosPrinter == "1")
                    {
                        TremolPrint.PrintZReport();

                    }
                }
                else
                {
                    var myUniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".inp";

                    string zReport = "E,1, ______,_,__; Planetaccounting.org;@Z,1,______,_,__;" + Environment.NewLine;
                    zReport = zReport.Replace("@", "\n");

                    File.WriteAllText(Path.Combine(path, myUniqueFileName), zReport);
                }
            }
            catch
            {

            }


            this.Close();
        }



        private void btnXReport_Click(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();

            ////shtyp raportin X
            try
            {
                string path = "";
                if (globals != null)
                {
                    path = Globals.Settings.FiscalPrinterPath;

                }
                else
                {
                    MessageBox.Show(word_choose_fiscal_path.Text);
                }
                if (globals.FiscalPrinterType == "Tremol")
                {
                    TremolPrint.PrintXReport();
                }
                else
                {
                    var myUniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".inp";
                    string xReport = "E,1,______,_,__;Planetaccounting.org;@X,1,______,_,__;" + Environment.NewLine;
                    xReport = xReport.Replace("@", "\n");

                    File.WriteAllText(Path.Combine(path, myUniqueFileName), xReport);

                }
            }
            catch
            {

            }

            this.Close();
        }

        private void btnCloseCashBox_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(paragraph_close_cashbox.Text, word_close_cashbox.Text, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                //paragraph_print_z_report.PerformClick();

                //mbull arken 
                CloseChashbox frm = new CloseChashbox();
                frm.Owner = this.Owner;
                frm.ShowDialog();

                Services.StationService.UnLockUserStation(Globals.User.Id, Globals.DeviceId);
                Globals.NextStep = "LoginForm";
                Globals.CashBoxStatus = "Locked";
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Globals.NextStep = "LoginForm";
            Globals.CashBoxStatus = "Locked";
            this.Owner.Close();
        }

        private void btnChangeLocServer_Click(object sender, EventArgs e)
        {
            var config = Globals.GetConfig();
            config.LocalServerHost = "";
            Globals.SaveConfig(config);
        }

        private void SalesReport_Click(object sender, EventArgs e)
        {
            ReportByDate frm = new ReportByDate();
            frm.ShowDialog();
        }

        private void Options_Load(object sender, EventArgs e)
        {

            var globals = Services.Settings.Get();


        }
        public void ReloadForm()
        {
            Options_Load(null, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Options.flag == true)
            {
                timer1.Stop();

                ReloadForm();
                timer1.Start();


            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm:ss tt";
            dFDate.Format = DateTimePickerFormat.Custom;
            dFDate.CustomFormat = "MM/dd/yyyy HH:mm:ss tt";
            dFDate.Value = DateTime.Now.AddDays(-1);
            var users = User.GetByStation(Globals.Station.Id);
            cmbUsers.DataSource = users;
            cmbUsers.DisplayMember = "Name";
            cmbUsers.ValueMember = "Id";
            cmbUsers.Text = "Të gjithë";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            try
            {

                int stationId = Globals.Station.Id;
                var selectedDate = dtDate.Value;
                var date = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);


                var items = Services.DailyOpenCloseBalance.GetDailyBalance(stationId, date);
                int i = 1;
                decimal saleTotal = 0.0M;
                List<Services.Models.DailyBalance> rptItems = new List<Services.Models.DailyBalance>();
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        item.No = i;
                        rptItems.Add((Services.Models.DailyBalance)item);
                        if (item.Status.ToLower() == "shitje")
                            saleTotal += item.Amount;
                        i++;
                    }
                }

                dg.DataSource = items;
                dg.Columns[2].HeaderText = "Puntori";
                dg.Columns[4].HeaderText = "Shuma(€)";
                dg.Columns[5].Visible = false;
                dg.Columns[6].Visible = false;
                dg.Columns[7].Visible = false;
                dg.Columns[8].Visible = false;
                dg.Columns[9].Visible = false;

                lblTotal.Text = saleTotal.ToString("N");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
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
            label1.Text = t.ToString();
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
                                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);

                                writer.PageEvent = new Helper.ITextEvents();
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        if (cell.Value != null)
                                        {
                                            string cellValue = cell.Value.ToString();
                                            if (cellValue.Length > 20)
                                            {
                                                cellValue = cellValue.Substring(0, 20);
                                            }
                                            pdfTable.AddCell(cellValue);
                                        }
                                    }
                                }
                                pdfDoc.Open();

                                PdfContentByte cb = writer.DirectContent;
                                Helper.ITextEvents report = new Helper.ITextEvents();



                                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                                int a = 1;

                                double asa = dataGridView1.Rows.Count / 20f;
                                int v = asa > 1 ? dataGridView1.Rows.Count / 20 : 0;
                                int pageRows = 0;

                                //Ky loop e lejon tabelen ne pdf me pas veq 20 rreshta

                                while (pageRows < dataGridView1.Rows.Count)
                                {
                                    int ypos = a > 1 ? 550 : 450;
                                    pdfTable.TotalWidth = 770f;

                                    if (v == 0)
                                    {
                                        pdfTable.WriteSelectedRows(pageRows, pageRows + 21, 20, ypos, cb);

                                    }
                                    else
                                    {
                                        pdfTable.WriteSelectedRows(pageRows, pageRows + 20, 20, ypos, cb);

                                    }
                                    pageRows += 20;
                                    if (v > 0)
                                    {
                                        pdfDoc.NewPage();
                                        v--;
                                    }

                                    a++;

                                }
                                report.OnCloseDocument(writer, pdfDoc);
                                pdfDoc.Close();
                                stream.Close();
                                //pdfDoc.Add(pdfTable);

                                if (MessageBox.Show("A deshironi ta printoni Raportin?", "Raport", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    Process p = new Process();
                                    p.StartInfo = new ProcessStartInfo()
                                    {
                                        CreateNoWindow = true,
                                        Verb = "print",
                                        FileName = sfd.FileName
                                    };
                                    p.Start();
                                    p.Dispose();
                                }
                            }

                            MessageBox.Show("Eshte ruajtur Raporti me sukses!", "Info");


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

        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();

            if (tabControl1.SelectedIndex == 1)
            {
                txtCompanyName.Text = globals.CompanyName;
                txtBusinessNumber.Text = globals.BusinessNumber;
                txtFiscalNumber.Text = globals.FiscalNumber;
                txtVatNumber.Text = globals.VatNumber;
                txtAddress.Text = globals.Address;
                txtCity.Text = globals.City;
                txtCountry.Text = globals.Country;
                txtPhoneNumber.Text = globals.PhoneNo;



                if (globals.PagDirekte == 1)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;

                }
                if (globals.DiscountCol == 1)
                {
                    checkboxDisc.Checked = true;
                }
                else
                {
                    checkboxDisc.Checked = false;
                }
                if (globals.UnitCol == 1)
                {
                    chckUnitCol.Checked = true;
                }
                else
                {
                    chckUnitCol.Checked = false;
                }
                if (globals.BarcMode == 1)
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;

                }
                if (globals.StockRibbon == 1)
                {
                    chckStockRibbon.Checked = true;
                }
                else
                {
                    chckStockRibbon.Checked = false;

                }
                if (globals.LocationRibbon == 1)
                {
                    checkBox3.Checked = true;
                }
                else
                {
                    checkBox3.Checked = false;

                }

                checkBox2.CheckedChanged -= new EventHandler(BarcMode_CheckedChanged);
                checkBox1.CheckedChanged -= new EventHandler(checkBox1_CheckedChanged);
                checkboxDisc.CheckedChanged -= new EventHandler(checkboxDisc_CheckedChanged);
                chckUnitCol.CheckedChanged -= new EventHandler(checkBox3_CheckedChanged);
                checkBox2.CheckedChanged += new EventHandler(BarcMode_CheckedChanged);
                checkBox1.CheckedChanged += new EventHandler(checkBox1_CheckedChanged);
                checkboxDisc.CheckedChanged += new EventHandler(checkboxDisc_CheckedChanged);
                chckUnitCol.CheckedChanged += new EventHandler(checkBox3_CheckedChanged);
                chckStockRibbon.CheckedChanged += new EventHandler(chckStockRibbon_CheckedChanged);
                checkBox3.CheckedChanged += new EventHandler(checkBox3_CheckedChanged_1);

            }
            if (tabControl1.SelectedIndex == 2)
            {
                if (Tables.GetTables().Where(p => p.inPos > 0).Count() == 0)
                {


                    txtNrKuponav.Text = RestaurantPos.countNumFiscal.ToString();

                    if (dailyOpen.Status == "open")
                    {
                        txtOpenAmount.Text = dailyOpen.Amount.ToString("N");

                    }

                    var daily = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(Globals.User.Id);
                    txtTotaliShitje.Text = daily.TotalShitje.ToString("N");
                    totalsum = Convert.ToDecimal(txtOpenAmount.Text) + daily.TotalCash;
                    txtTotali.Text = totalsum.ToString("N");
                    txtDorzimi.Text = totalsum.ToString("N");
                    txtNrKuponav.Text = daily.DailyFiscalCount.ToString();
                    txtKesh.Text = daily.TotalCash.ToString("N");
                    txtBankat.Text = daily.TotalCreditCard.ToString("N");
                }
                else
                {
                    MessageBox.Show("Nuk mund ta mbyllni diten. Keni tavolina te hapura!");
                    tabControl1.SelectedIndex = 1;
                    this.Refresh();
                }
            }
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            var sett = Services.Settings.Get();

            if (checkBox3.Checked == true)
            {
                sett.UpdateLocation(1, sett.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
            if (checkBox3.Checked == false)
            {
                sett.UpdateLocation(0, sett.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
        }

        private void BarcMode_CheckedChanged(object sender, EventArgs e)
        {
            var sett = Globals.Settings;

            if (checkBox2.Checked)
            {
                sett.BarcodeMode(1, Globals.Settings.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
            else
            {
                sett.BarcodeMode(0, Globals.Settings.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }

        }

        private void checkboxDisc_CheckedChanged(object sender, EventArgs e)
        {
            var sett = Globals.Settings;
            if (checkboxDisc.Checked)
            {
                sett.UpdateF(1, Globals.Settings.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");
            }
            else
            {
                sett.UpdateF(0, Globals.Settings.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var sett = Globals.Settings;

            if (checkBox1.Checked)
            {
                sett.UpdateP(1, Globals.Settings.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
            else
            {
                sett.UpdateP(0, Globals.Settings.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var sett = Globals.Settings;
            if (checkBox2.Checked)
            {
                sett.BarcodeMode(1, Globals.Settings.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
            else
            {
                sett.BarcodeMode(0, Globals.Settings.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();
                var sett = Services.Settings.Get();
                var printer = Services.Printer.Get().Find(p => p.Id == Globals.DeviceId);


                if (tabControl3.SelectedIndex == 2)
                {
                    if (sett.PosPrinter == "1")
                    {



                        cmbFiscalPrinterType.SelectedItem = printer.FiscalType != null ? printer.FiscalType : " ";
                        COMcmb.SelectedItem = printer.COM == null ? "" : printer.COM;
                        txtPath.Text = printer.Path != null ? printer.Path : "";
                        cmbDatecsType.SelectedItem = printer != null ? printer.DatecsType : "";

                        if (printer.PrintTermal != null)
                        {
                            cmbPrinterType.SelectedItem = printer.PrintTermal == "1" ? "Printer Termal" : "Printer Fiskal";

                        }
                    }
                    else
                    {
                        panel1.Visible = true;
                        panel1.Dock = DockStyle.Fill;
                        label7.Visible = false;
                        cmbDatecsType.Visible = false;


                        Label messageLabel = new Label();
                        messageLabel.Text = "Konfigurimin duhet ta bëni në Server!";
                        messageLabel.AutoSize = true;
                        messageLabel.Dock = DockStyle.Fill;
                        messageLabel.TextAlign = ContentAlignment.MiddleCenter;

                        panel1.Controls.Add(messageLabel);
                    }
                }

                //dataGridView2.DataSource = Services.Item.GetFav(0);
                dataGridView3.DataSource = Services.Item.GetFav(1);

                //dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Lato", 11);
                //for (int i = 1; i <= 30; i++)
                //{
                //    dataGridView2.Columns[i].Visible = false;
                //}


                dataGridView3.DefaultCellStyle.Font = new System.Drawing.Font("Lato", 11);
                for (int i = 1; i <= 31; i++)
                {
                    dataGridView3.Columns[i].Visible = false;
                }
                dataGridView3.Columns[33].Visible = false;

                this.ResumeLayout();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void word_save_Click(object sender, EventArgs e)
        {
            try
            {
                var favItems = Services.Item.GetFav(1);
                //var nofav = Services.Item.GetFav(0);
                dataGridView3.DataSource = favItems;

                Services.Item itemss = new Services.Item();

                var checkedRows = from DataGridViewRow r in dataGridView2.Rows
                                  where Convert.ToBoolean(r.Cells[0].Value) == true
                                  select r;


                if (flagAll == true)
                {
                    itemss.UpdateFavAll1();
                }
                else
                {
                    foreach (var row in checkedRows)
                    {
                        itemss.Favorite = Convert.ToInt32(row.Cells[0].Value);
                        itemss.Id = Convert.ToInt32(row.Cells[1].Value);
                        itemss.UpdateFav(itemss.Favorite, itemss.Id);

                    }
                }


                //dataGridView2.DataSource = Services.Item.GetFav(0);
                dataGridView3.DataSource = Services.Item.GetFav(1);
                word_choose_all.Checked = false;
                flagAll = false;
                MessageBox.Show("Veprimi perfundoi me sukses!");

                tabControl3.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void word_delete_Click(object sender, EventArgs e)
        {
            try
            {
                var fav = Services.Item.GetFav(1);

                //dataGridView2.DataSource = Services.Item.GetFav(0);
                Services.Item itemss = new Services.Item();


                var checkedRows = from DataGridViewRow r in dataGridView3.Rows
                                  where Convert.ToBoolean(r.Cells[0].Value) == true
                                  select r;

                if (flagAll == true)
                {
                    itemss.UpdateFavAll0();
                }
                else
                {
                    foreach (var row in checkedRows)
                    {
                        itemss.Id = Convert.ToInt32(row.Cells[1].Value);
                        itemss.UpdateFav(itemss.Favorite, itemss.Id);

                    }

                }

                dataGridView3.DataSource = Services.Item.GetFav(1);
                //dataGridView2.DataSource = Services.Item.GetFav(0);
                radioButton1.Checked = false;
                flagAll = false;
                MessageBox.Show("Veprimi perfundoi me sukses!");

                tabControl3.Refresh();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void word_choose_all_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (word_choose_all.Checked)
            //    {
            //        foreach (DataGridViewRow row in dataGridView2.Rows)
            //        {
            //            row.Cells[0].Value = Convert.ToBoolean(row.Cells[0].Value) == false ? true : false;
            //            flagAll = true;
            //        }
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (radioButton1.Checked)
            //    {
            //        foreach (DataGridViewRow row in dataGridView3.Rows)
            //        {
            //            row.Cells[0].Value = Convert.ToBoolean(row.Cells[0].Value) == false ? true : false;
            //            flagAll = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}

        }

        private void SyncFiscC_Click(object sender, EventArgs e)
        {
            try
            {
                var sett = Settings.Get();
                var DefVersion = "";
                var clientPayed = frmPayment.Kesh;

                if (sett.PosPrinter == "1")
                {
                    var pr = printers.Where(p => p.Id == Globals.DeviceId);

                    DefVersion = pr.First().DefVersion;
                }
                //Duhet me e bo check a eshte me ni printer ne server apo secili pos me printerat fiskal te vet

                string comPort = "";
                int baud = 1152000;
                if (COMcmb.SelectedItem != null)
                {
                    comPort = COMcmb.SelectedItem.ToString();

                    var fp = new FP((long)Convert.ToDouble(DefVersion)) { ServerAddress = "http://LocalHost:4444/" };
                    fp.ServerFindDevice(out comPort, out baud);

                    var unprinted = Services.SaleDetails.getUnprintedInvoice();

                    if (unprinted != null && unprinted.Count > 0)
                    {
                        var invoice = unprinted.GroupBy(x => new { x.SaleId })
 .Select(g => g.GroupBy(x => x.SaleId))
 .ToList();
                        foreach (var item in invoice)
                        {
                            foreach (var i in item)
                            {
                                var table = RestaurantPos.SaleDtoDataTable(i);
                                if (TremolPrint.CreateReceipt(table, clientPayed))
                                {
                                    foreach (DataRow row in table.Rows)
                                    {
                                        int rowvalue = Convert.ToInt32(row[1]);
                                        Services.SaleDetails.UpdatePrinted(rowvalue);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nuk ka asgje per tu sinkronizuar!");
                    }


                }
                else
                {
                    MessageBox.Show("Ju lutem zgjedhni COM portin per te vazhduar!");
                }

            }
            catch (SException sx)
            {
                //MessageBox.Show(sx.Message, "Error", MessageBoxButtons.OK);
                MessageBox.Show("Kontrolloni a eshte hapur serveri i printerit!", "Error", MessageBoxButtons.OK);
            }
        }

        private void FindFiscalPrnt_Click(object sender, EventArgs e)
        {
            try
            {
                var settings = Settings.Get();

                if (COMcmb.SelectedItem != null)
                {

                    if (settings.PosPrinter == "1")
                    {
                        Printer.UpdateCOM(COMcmb.SelectedItem.ToString(), Globals.DeviceId);
                    }


                    var restClient = GetRestClient("http://LocalHost:4444/");
                    var request = new RestRequest($"/settings(com={COMcmb.SelectedItem},baud=,tcp=,ip=,port=,password=)", Method.GET);
                    var response = restClient.Execute(request);
                    if (response.IsSuccessful)
                    {

                        string comPort = "";
                        int baud = 115200;

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(response.Content);

                        string xml;
                        xml = response.Content;
                        Services.Res result;
                        XmlSerializer ser = new XmlSerializer(typeof(Services.Res));
                        using (StringReader reader = new StringReader(xml))
                        {
                            result = (Services.Res)ser.Deserialize(reader);
                            string UserID = Convert.ToString(Guid.NewGuid());

                            if (settings.PosPrinter == "1")
                            {
                                Printer.UpdateDefVersion(result.Settings.First().defVer, Globals.DeviceId);
                            }

                        }
                        if (COMcmb.SelectedItem != null)
                        {
                            comPort = COMcmb.SelectedItem.ToString();
                            try
                            {
                                var fp = new FP((long)Convert.ToDouble(result.Settings.First().defVer)) { ServerAddress = "http://LocalHost:4444/" };
                                fp.PaperFeed();
                            }
                            catch
                            {

                                MessageBox.Show($"Printeri nuk eshte ne portin {comPort}. Provoni portet tjera!");

                            }

                        }
                        else
                        {
                            MessageBox.Show("Ju lutem zgjedhni COM portin per te vazhduar!");

                        }

                    }
                    else
                    {
                        MessageBox.Show("Shikoni a eshte hap serveri i printerit!");

                    }
                }
                else
                {
                    MessageBox.Show("Ju lutem zgjedhni COM portin per te vazhduar!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private static RestClient GetRestClient(string connectionUrl)
        {
            var restClient = new RestClient(connectionUrl);
            //restClient.Authenticator = new HttpBasicAuthenticator("ClientUid", mEtlSettings.ClientUid);
            //todo: include client certificate
            //restClient.ClientCertificates.Add(certificate);
            return restClient;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var printer = Printer.Get().Find(p => p.Id == Globals.DeviceId);

                if (cmbPrinterType.SelectedItem.ToString() == "Printer Termal")
                {
                    printer.UpdatePrintTermal("1", Globals.DeviceId);
                }
                else
                {
                    printer.UpdatePrintTermal("0", Globals.DeviceId);

                    if (cmbFiscalPrinterType.SelectedItem != null && txtPath.Text != "")
                    {
                        if (cmbDatecsType.SelectedItem == null)
                        {
                            MessageBox.Show("Please select a Datecs type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        flag = true;
                    }
                    printer.UpdateFiscalType(cmbFiscalPrinterType.Text, Globals.DeviceId);

                    if (cmbFiscalPrinterType.SelectedItem.ToString() == "Datecs")
                    {
                        printer.UpdatePath(txtPath.Text, Globals.DeviceId);
                    }
                }

                AutoClosingMessageBox.Show("Jane ruajtur me sukses te dhenat", "Sukses", 800);
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
            flag = flagcashbox == false ? true : false;

        }

        private void paragraph_print_the_report_Click(object sender, EventArgs e)
        {
            Raporti raporti = new Raporti();

            raporti.Owner = this;
            raporti.ShowDialog();
        }

        private void word_complete_Click(object sender, EventArgs e)
        {
            try
            {
                var tables = Tables.GetTables().Where(p => p.inPos == 1);

                if (tables.Count() == 0)
                {
                    var settings = Settings.Get();
                    var printer = Printer.Get().Find(p => p.Id == Globals.DeviceId);
                    flag = true;
                    DateTime foo = DateTime.Now;
                    double unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();

                    if (Globals.Settings.PIN == "0" || Globals.Settings.PIN == null)
                    {
                        openAmount = Convert.ToDecimal(txtTotali.Text);

                        DailyOpenCloseBalance b = new DailyOpenCloseBalance();
                        b.UserId = Globals.User.Id;
                        b.Amount = openAmount;
                        b.Status = "close";
                        b.StationId = Globals.Station.Id;
                        b.Date = DateTime.Now.ToLocalTime().AddHours(1);
                        b.TotalShitje = RestaurantPos.totalSumOpenBalance;
                        b.neArke = Convert.ToDecimal(txtGjendjaMomentale.Text);
                        b.Insert();



                        RestaurantPos.totalSumOpenBalance = 0M;
                        RestaurantPos.countNumFiscal = 0;
                        frmPayment.Kesh = 0M;
                        frmPayment.CreditCard = 0M;
                        RestaurantPos.daily.DailyFiscalCount = 0;

                        if (settings.PosPrinter == "1" && printer.FiscalType == "Tremol")
                        {
                            btnZRaport_Click(sender, e);

                        }

                        Globals.NextStep = "LoginForm";
                        this.Owner.Close();

                        Services.StationService.UnLockUserStation(Globals.User.Id, Globals.DeviceId);
                        Globals.NextStep = "LoginForm";
                        Globals.CashBoxStatus = "Locked";
                        this.Close();
                    }
                    else
                    {
                        EnterPin enter = new EnterPin();
                        enter.ShowDialog();
                        if (enter.flag == true)
                        {
                            openAmount = Convert.ToDecimal(txtTotali.Text);

                            DailyOpenCloseBalance b = new DailyOpenCloseBalance();
                            b.UserId = Globals.User.Id;
                            b.Amount = openAmount;
                            b.Status = "close";
                            b.StationId = Globals.Station.Id;
                            b.Date = DateTime.Now.ToLocalTime().AddHours(1);
                            b.TotalShitje = RestaurantPos.totalSumOpenBalance;
                            b.Insert();



                            RestaurantPos.totalSumOpenBalance = 0M;
                            RestaurantPos.countNumFiscal = 0;
                            frmPayment.Kesh = 0M;
                            frmPayment.CreditCard = 0M;
                            RestaurantPos.daily.DailyFiscalCount = 0;

                            if (settings.PosPrinter == "1")
                            {
                                btnZRaport_Click(sender, e);

                            }


                            Globals.NextStep = "LoginForm";
                            this.Close();

                            Services.StationService.UnLockUserStation(Globals.User.Id, Globals.DeviceId);
                            Globals.NextStep = "LoginForm";
                            Globals.CashBoxStatus = "Locked";
                            this.Close();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Nuk mund ta mbyllni diten pa i mbyll te gjitha tavolinat!");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void word_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtNrKuponav.Text = RestaurantPos.countNumFiscal.ToString();

            if (dailyOpen.Status == "open")
            {
                txtOpenAmount.Text = dailyOpen.Amount.ToString("N");

            }

            var daily = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(Globals.User.Id);
            txtTotaliShitje.Text = daily.TotalShitje.ToString("N");
            totalsum = Convert.ToDecimal(txtOpenAmount.Text) + daily.TotalCash;
            txtTotali.Text = totalsum.ToString("N");
            txtNrKuponav.Text = daily.DailyFiscalCount.ToString();
            txtKesh.Text = daily.TotalCash.ToString("N");
            txtBankat.Text = daily.TotalCreditCard.ToString("N");
            this.ResumeLayout();

        }

        private void txtDorzimi_TextChanged(object sender, EventArgs e)
        {
            decimal number;
            if (txtDorzimi.Text == "")
            {
                txtDorzimi.Text = "0";
            }
            if (decimal.TryParse(txtDorzimi.Text, out number))
            {
                dorezimi = Convert.ToDecimal(txtDorzimi.Text);
                if (number <= Convert.ToDecimal(txtTotali.Text))
                {
                    gjendjaMomentale = Convert.ToDecimal(txtTotali.Text) - Convert.ToDecimal(txtDorzimi.Text);
                    txtGjendjaMomentale.Text = gjendjaMomentale.ToString();


                }
                else
                {
                    MessageBox.Show("Ju lutem vendosni nje shumë te barabarte ose me te vogel se totali ne arke!s");
                    txtDorzimi.Text = "";
                    txtGjendjaMomentale.Text = "0.00";

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Globals.NextStep = "LoginForm";
            Globals.CashBoxStatus = "Locked";
            Services.StationService.UnLockUserStation(Globals.User.Id, Globals.DeviceId);
            RestaurantOptions.flag = false;
            this.Owner.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var config = Globals.GetConfig();
            config.LocalServerHost = "";
            Globals.SaveConfig(config);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int stationId = Globals.Station.Id;
                var totalshitje = 0.0m;
                var selectedFromDate = dFDate.Value;
                var selectedToDate = dateTimePicker1.Value;
                dateF = new DateTime(selectedFromDate.Year, selectedFromDate.Month, selectedFromDate.Day, selectedFromDate.Hour, selectedFromDate.Minute, selectedFromDate.Second);
                dateTo = new DateTime(selectedToDate.Year, selectedToDate.Month, selectedToDate.Day, selectedToDate.Hour, selectedToDate.Minute, selectedToDate.Second);
                Column1.Visible = true;
                DataTable dt = new DataTable();

                dt.Columns.Add("Shifra");
                dt.Columns.Add("Emri");
                dt.Columns.Add("Sasia");
                dt.Columns.Add("Vlera e Shitjes");
                dt.Columns.Add("Puntori");

                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = dt.Columns["Shifra"];
                dt.PrimaryKey = keyColumns;
                var quantity = 0.0M;

                var allItem = new List<Services.Models.ItemsDiscount>();

                if (Globals.Settings.StockWMinus == "0")
                {
                    allItem = Services.Item.GetItemsDiscount(Globals.Station.ParentId);
                }
                else
                {
                    allItem = Services.Item.GetAllItem();

                }
                if (cmbUsers.Text != "Të gjithë")
                {
                    var items = Services.SaleDetails.getSalesDetailsByDateAndEmp(dateF, dateTo, (int)cmbUsers.SelectedValue);
                    foreach (var item in items)
                    {

                        if (dt.Rows.Count > 0)
                        {
                            bool exists = dt.Rows.Contains(item.ItemId);
                            var it = allItem.Where(i => i.Id == item.ItemId);
                            var list = it.ToList();
                            decimal vat = list.First().Vat != 0 ? list.First().Vat : 18;
                            var empl = User.Get(items.First().id_saler).FirstName;



                            if (!exists)
                            {
                                var ta = Math.Round((item.Price + (item.Price * (vat / 100))) * item.Quantity, 2);
                                dt.Rows.Add(item.ItemId, it.FirstOrDefault().ItemName, item.Quantity, ta, empl);
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
                            decimal vat = list.First().Vat != 0 ? list.First().Vat : 18;
                            //var total = (item.Price + (item.Price * (vat / 100))) * item.Quantity;
                            decimal vatshuma = (item.Price) * (1 * vat / 100.0M);
                            decimal shuma = Math.Round((vatshuma + item.Price), 2);
                            decimal shumatotale = Math.Round(shuma * item.Quantity, 2);
                            var empl = User.Get(items.First().id_saler).FirstName;
                            //var ta = Math.Round(shumatotale, 2);
                            dt.Rows.Add(item.ItemId, it.FirstOrDefault().ItemName, item.Quantity, shumatotale, empl);
                            ;

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
                    label1.Text = t.ToString();

                }
                else
                {
                    var items = Services.SaleDetails.getSalesDetailsByDate(dateF, dateTo);
                    var empname = "";
                    foreach (var item in items)
                    {
                        empname = item.CreatedBy;
                        if (dt.Rows.Count > 0)
                        {
                            bool exists = dt.Rows.Contains(item.ItemId);
                            var it = allItem.Where(i => i.Id == item.ItemId);
                            var list = it.ToList();
                            decimal vat = list.First().Vat != 0 ? list.First().Vat : 18;


                            if (!exists)
                            {
                                var ta = Math.Round((item.Price + (item.Price * (vat / 100))) * item.Quantity, 2);
                                dt.Rows.Add(item.ItemId, it.FirstOrDefault().ItemName, item.Quantity, ta, item.CreatedBy);
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
                            decimal vat = list.First().Vat != 0 ? list.First().Vat : 18;
                            //var total = (item.Price + (item.Price * (vat / 100))) * item.Quantity;
                            decimal vatshuma = (item.Price) * (1 * vat / 100.0M);
                            decimal shuma = Math.Round((vatshuma + item.Price), 2);
                            decimal shumatotale = Math.Round(shuma * item.Quantity, 2);
                            //var ta = Math.Round(shumatotale, 2);
                            dt.Rows.Add(item.ItemId, it.FirstOrDefault().ItemName, item.Quantity, shumatotale, item.CreatedBy);


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
                    label1.Text = t.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void cmbFiscalPrinterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiscalPrinterType.SelectedItem.ToString() == "Tremol")
            {
                word_path.Visible = false;
                txtPath.Visible = false;
                COMcmb.Visible = true;
                txtBitrate.Visible = true;
                SyncFiscC.Visible = true;
                FindFiscalPrnt.Visible = true;
                word_choose_port.Visible = true;
                word_bitrate.Visible = true;
                cmbDatecsType.Enabled = false;

            }
            if (cmbFiscalPrinterType.SelectedItem.ToString() == "Datecs")
            {
                word_path.Visible = true;
                txtPath.Visible = true;
                COMcmb.Visible = false;
                txtBitrate.Visible = false;
                SyncFiscC.Visible = false;
                FindFiscalPrnt.Visible = false;
                word_choose_port.Visible = false;
                word_bitrate.Visible = false;
                txtBitrate.Visible = false;
                cmbDatecsType.Enabled = true;


            }
        }

        private void txtPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog flb = new FolderBrowserDialog();

            flb.ShowDialog();

            string sSelectedPath = flb.SelectedPath;
            txtPath.Text = sSelectedPath;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ThermalPrinter thermal = new ThermalPrinter();
            thermal.ShowDialog();
        }

        private void chkPrintCopy_CheckedChanged(object sender, EventArgs e)
        {
            var sett = Services.Settings.Get();

            if (chkPrintCopy.Checked == true)
            {
                Settings.UpdatePrintCopy("1", sett.Id);
            }
            if (chkPrintCopy.Checked == false)
            {
                Settings.UpdatePrintCopy("0", sett.Id);

            }
        }

        private void chk_BllokoParametrat_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_BllokoParametrat.Checked)
            {

                txtPath.ReadOnly = true;
                cmbFiscalPrinterType.Enabled = false;
            }
            else
            {

                txtPath.ReadOnly = false;
                cmbFiscalPrinterType.Enabled = true;
            }
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            Restaurant parentForm = (Restaurant)this.Owner;
            // Reload the visual settings in the parent form
            //if (flag == false)
            //{
            //    if (checkBox2.Checked != true)
            //    {
            //        this.FormClosing -= Options_FormClosing;
            //        parentForm.ReOpenForm();
            //        this.FormClosing += Options_FormClosing;
            //    }
            //    else
            //    {
            //        parentForm.ReloadForm();

            //    }
            //}

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            var sett = Services.Settings.Get();

            if (chckUnitCol.Checked == true)
            {
                sett.UpdateUnitCol(1, sett.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
            if (chckUnitCol.Checked == false)
            {
                sett.UpdateUnitCol(0, sett.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
        }
        private void chckStockRibbon_CheckedChanged(object sender, EventArgs e)
        {
            var sett = Services.Settings.Get();

            if (chckStockRibbon.Checked == true)
            {
                sett.UpdateStockRibbon(1, sett.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
            if (chckStockRibbon.Checked == false)
            {
                sett.UpdateStockRibbon(0, sett.Id);
                MessageBox.Show("Veprimi perfundoi me sukses!");

            }
        }

        private void cmbPrinterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrinterType.SelectedItem.ToString() == "Printer Fiskal" && cmbPrinterType.SelectedItem != null)
            {
                cmbFiscalPrinterType.Enabled = true;
                COMcmb.Enabled = true;
                FindFiscalPrnt.Enabled = true;
                chkPrintCopy.Enabled = true;
                SyncFiscC.Enabled = true;
                cmbFiscalPrinterType.Select();
                txtBitrate.Visible = true;
                word_bitrate.Visible = true;
                txtPath.Enabled = true;

            }
            else
            {

                cmbFiscalPrinterType.Enabled = false;
                COMcmb.Enabled = false;
                FindFiscalPrnt.Enabled = false;
                chkPrintCopy.Enabled = false;
                SyncFiscC.Enabled = false;
                txtBitrate.Visible = false;
                word_bitrate.Visible = false;
                txtPath.Enabled = false;

            }
        }

        private void txtToFavorite_TextChanged(object sender, EventArgs e)
        {
            var item = Services.Item.GetItemWithName(txtToFavorite.Text);
            dataGridView2.DataSource = item;
            if (item.Count() > 0)
            {
                for (int i = 3; i <= 25; i++)
                {
                    dataGridView2.Columns[i].Visible = false;
                }
                dataGridView2.Columns[1].Visible = false;

            }

        }

        private void txtToUnFavorite_TextChanged(object sender, EventArgs e)
        {
            var item = Services.Item.GetItemWithName(txtToUnFavorite.Text).Where(p => p.Favorite == 1);
            dataGridView3.DataSource = item;

            if (item.Count() > 0)
            {
                for (int i = 3; i <= 25; i++)
                {
                    dataGridView3.Columns[i].Visible = false;
                }
                dataGridView3.Columns[1].Visible = false;
            }

        }
    }
}
