using MyNET.Shops;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            if (settings.PIN == "0" || settings.PIN == null)
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
                    this.Owner.Close();

                    Services.StationService.UnLockUserStation(Globals.User.Id, Globals.DeviceId);
                    Globals.NextStep = "LoginForm";
                    Globals.CashBoxStatus = "Locked";
                    this.Close();
                }

            }



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
            this.Close();

        }

        private void paragraph_print_the_report_Click(object sender, EventArgs e)
        {
            Raporti raporti = new Raporti();

            raporti.Owner = this;
            raporti.ShowDialog();
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

        private void paragraph_print_the_report_Click_1(object sender, EventArgs e)
        {
            Raporti raporti = new Raporti();

            raporti.Owner = this;
            raporti.ShowDialog();
        }
    }
}
