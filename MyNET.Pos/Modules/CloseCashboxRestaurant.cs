using MyNET.Shops;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class CloseCashboxRestaurant : Form
    {
        public static decimal openAmount;
        public static decimal totalsum;
        public static decimal gjendjaMomentale;
        public static decimal dorezimi;
        public static int dailyOpenId = Globals.User.Id;

        Services.DailyOpenCloseBalance dailyOpen = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(dailyOpenId);
        public CloseCashboxRestaurant()
        {
            InitializeComponent();
        }

        private void word_complete_Click(object sender, EventArgs e)
        {

            var settings = Settings.Get();
            var printer = Printer.Get().Find(p => p.Id == Globals.DeviceId);
            DateTime foo = DateTime.Now;
            double unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = settings.PosPrinter == "1" ? printer.TermalName : settings.ThermalPrinterName;
            if ((settings.PIN != "0" || settings.PIN != null) && Globals.User.Role == "1")
            {
                openAmount = Convert.ToDecimal(txtTotali.Text);

                DailyOpenCloseBalance b = new DailyOpenCloseBalance();
                b.UserId = dailyOpenId;
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
                printDoc.PrintPage += new PrintPageEventHandler(PrintRestaurantDataGridView);
                printDoc.Print();

                Globals.NextStep = "LoginForm";
                this.Owner.Close();

                Services.StationService.UnLockUserStation(dailyOpenId, Globals.DeviceId);
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
                    printDoc.PrintPage += new PrintPageEventHandler(PrintRestaurantDataGridView);
                    printDoc.Print();

                    Globals.NextStep = "LoginForm";
                    this.Owner.Close();

                    Services.StationService.UnLockUserStation(Globals.User.Id, Globals.DeviceId);
                    Globals.NextStep = "LoginForm";
                    Globals.CashBoxStatus = "Locked";
                    this.Close();
                }

            }

            




        }
        public void PrintRestaurantDataGridView(object sender, PrintPageEventArgs e)
        {
            var settings = Services.Settings.Get();
            var printer = Services.Printer.Get().Find(p => p.Id == Globals.DeviceId);

            float total_width = settings.PosPrinter == "0"
                ? Convert.ToInt32(settings.ThermalPrinterPageWidth) + 110f
                : Convert.ToInt32(printer.TermalPaperWidth) + 110f;

            Font headingFont = new Font("Calibri", total_width / 18f, FontStyle.Bold);
            Font boldFont = new Font("Calibri", total_width / 23f, FontStyle.Bold);
            Font normalFont = new Font("Calibri", total_width / 23f, FontStyle.Regular);

            float height = 5;
            string company = Globals.Settings.CompanyName;
            string receiptDate = DateTime.Now.ToString();

            // Print Header
            e.Graphics.DrawString($"Raporti i mbylljes së ditës të {Services.User.Get(dailyOpenId).Name}", headingFont, Brushes.Black, 0, height, new StringFormat());
            height += 30;

            e.Graphics.DrawString(company, normalFont, Brushes.Black, total_width / 2f, height, new StringFormat() { Alignment = StringAlignment.Center });
            height += 40;

            e.Graphics.DrawString("Date: " + receiptDate, boldFont, Brushes.Black, 0, height, new StringFormat());
            height += 40;

            float tableTop = height + 20; // Start of the table
            float rowHeight = 30; 
            float col1Width = total_width-63; // Width of the first column
            float col2Width = total_width -63; // Width of the second column

            // Define rows
            var rows = new List<(string Label, string Value)>
    {
        ("Total Kupona:", txtNrKuponav.Text),
        ("Bilanci Fillestar:", txtOpenAmount.Text),
        ("Total Kesh:", $"{txtKesh.Text} EUR"),
        ("Total Banka:", $"{txtBankat.Text} EUR"),
        ("Total Shitje:", $"{txtTotaliShitje.Text} EUR"),
        ("Totali:", $"{txtTotali.Text} EUR")
    };
         
            // Draw table rows
            foreach (var row in rows)
            {
                e.Graphics.DrawRectangle(Pens.Black, 0, height, col1Width, rowHeight);
                e.Graphics.DrawRectangle(Pens.Black, col1Width, height, col2Width, rowHeight);

                e.Graphics.DrawString(row.Label, normalFont, Brushes.Black, 5, height + 5, new StringFormat());
                e.Graphics.DrawString(row.Value, normalFont, Brushes.Black, col1Width + 5, height + 5, new StringFormat());

                height += rowHeight; // Move to the next row
            }

            e.HasMorePages = false;
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
                    MessageBox.Show("");
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
        private void word_cancel_Click(object sender, EventArgs e)
        {
            if (Globals.User.Role == "1")
            {
                pnlChooseEmp.Visible = true;
            }
            else
            {
                this.Close();
            }

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

        private void CloseCashboxRestaurant_Load(object sender, EventArgs e)
        {
            if (Globals.User.Role == "1")
            {
                pnlChooseEmp.Visible = true;

                cmbEmp.DisplayMember = "Name";
                cmbEmp.ValueMember = "Id";
                cmbEmp.DataSource = Services.User.GetAll();


            }
            else
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

                //kur te mbylli permes menaxherit me e mbyll me id te puntorit qe dojna me e mbyll
            }
        }

        private void paragraph_print_the_report_Click_1(object sender, EventArgs e)
        {
            Raporti raporti = new Raporti();
            raporti.EmpId = dailyOpenId;
            raporti.Owner = this;
            raporti.ShowDialog();
        }

        private void cmbEmp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbEmp.SelectedValue != null)
            {
                dailyOpenId = (int)cmbEmp.SelectedValue;

                var tables = Services.Tables.GetTables().Where(p => p.inPos == 1 && p.Emp_id == dailyOpenId);

                if (tables.Count() == 0)
                {


                    dailyOpen = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(dailyOpenId);

                    txtNrKuponav.Text = RestaurantPos.countNumFiscal.ToString();
                    if (dailyOpen != null)
                    {
                        if (dailyOpen.Status == "open")
                        {
                            txtOpenAmount.Text = dailyOpen.Amount.ToString("N");

                        }

                        var daily = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(dailyOpenId);
                        txtTotaliShitje.Text = daily.TotalShitje.ToString("N");
                        totalsum = Convert.ToDecimal(txtOpenAmount.Text) + daily.TotalCash;
                        txtTotali.Text = totalsum.ToString("N");
                        txtDorzimi.Text = totalsum.ToString("N");
                        txtNrKuponav.Text = daily.DailyFiscalCount.ToString();
                        txtKesh.Text = daily.TotalCash.ToString("N");
                        txtBankat.Text = daily.TotalCreditCard.ToString("N");

                        pnlChooseEmp.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show($"Nuk ka dite të hapur nga {User.Get((int)cmbEmp.SelectedValue).Name}");
                    }

                }
                else
                {
                    MessageBox.Show("Nuk mund ta mbyllni diten pa i mbyll te gjitha tavolinat!");
                    this.Close();
                }
               

            }
        }
    }
}
