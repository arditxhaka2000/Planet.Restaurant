using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using TremolZFP;
using RestSharp;
using MyNET.Pos;
using System.Data;
using Services;

namespace MyNET.Shops
{
    public class TremolPrint
    {
        public static long versionDef;

        public static bool CreateReceipt(System.Data.DataTable dt,decimal clientPayed)
        {
            bool flag = false;
            var sett = Services.Printer.Get();
            var s = sett.Where(p => p.Id == Globals.DeviceId).ToList();
            var totalM = 0m;

            if (Globals.Settings.PosPrinter == "1")
            {
                versionDef = (long)Convert.ToDouble(s.FirstOrDefault().DefVersion);
            }
            var allowdiscount = Globals.Settings.AllowDiscount;

            try
            {
                FP fp = new FP(versionDef) { ServerAddress = "http://LocalHost:4444/" };
                fp.ServerSetDeviceSerialPortSettings(s.FirstOrDefault().COM, 115200);
                fp.OpenReceipt(1, "0", OptionPrintType.Postponed_printing);

                for (int i = 1; i <= dt.Rows.Count; i++)
                {

                    decimal vat = decimal.Parse(dt.Rows[i - 1]["Vat"].ToString());
                    OptionVATClass vATClass = new OptionVATClass();

                    if (vat == 18)
                    {
                        vATClass = OptionVATClass.VAT_Class_E;

                    }
                    if (vat == 0)
                    {
                        vATClass = OptionVATClass.VAT_Class_C;

                    }
                    if (vat == 8)
                    {
                        vATClass = OptionVATClass.VAT_Class_D;

                    }

                    string itemName = dt.Rows[i - 1]["ItemName"].ToString();
                    decimal price = decimal.Parse(dt.Rows[i - 1]["Price"].ToString());
                    decimal priceWithVat = Math.Round(price * (1 + vat / 100), 2);

                    decimal quantity;
                    decimal quantityT;

                    if (dt.Columns.Contains("PrintedFiscalQuantity"))
                    {
                        quantity = decimal.Parse(dt.Rows[i - 1]["Quantity"].ToString()) - decimal.Parse(dt.Rows[i - 1]["PrintedFiscalQuantity"].ToString());
                        quantityT = decimal.Parse(dt.Rows[i - 1]["Quantity"].ToString()) - decimal.Parse(dt.Rows[i - 1]["PrintedFiscalQuantity"].ToString());
                    }
                    else
                    {
                        quantity = decimal.Parse(dt.Rows[i - 1]["Quantity"].ToString());
                        quantityT = decimal.Parse(dt.Rows[i - 1]["Quantity"].ToString());
                    }
                    decimal discountpercent = 0;

                    if (allowdiscount == "1")
                    {
                        discountpercent = decimal.Parse(dt.Rows[i - 1]["Discount"].ToString());
                    }
                    else
                    {
                        discountpercent = decimal.Parse(dt.Rows[i - 1]["ClientDiscount"].ToString());
                    }
                    decimal discountamount = 0;
                    //
                    if (discountpercent > 0)
                    {
                        discountamount = quantityT * priceWithVat * (discountpercent / 100);
                        discountamount = discountamount * -1;
                        //priceWithVat += discountamount; 

                    }
                    else
                    {
                        if (priceWithVat > discountamount)
                        {
                            discountamount = discountamount * -1;
                        }
                    }
                    if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == false)
                    {
                        fp.SellPLUwithSpecifiedVAT(itemName, vATClass, priceWithVat, quantity, -(discountpercent), null, null);

                    }
                    totalM += priceWithVat;
                }

                foreach (DataRow item in dt.Rows)
                {
                    decimal price = decimal.Parse(item["Price"].ToString());
                    decimal vat = decimal.Parse(item["Vat"].ToString());
                    OptionVATClass vATClass = new OptionVATClass();

                    if (vat == 18)
                    {
                        vATClass = OptionVATClass.VAT_Class_E;

                    }
                    if (vat == 0)
                    {
                        vATClass = OptionVATClass.VAT_Class_C;

                    }
                    if (vat == 8)
                    {
                        vATClass = OptionVATClass.VAT_Class_D;

                    }
                    decimal priceWithVat = Math.Round(price * (1 + vat / 100), 2);

                    if (Convert.ToBoolean(item["ForReturn"]) == true)
                    {
                        fp.RefundPLUwithSpecifiedVAT(item["ItemName"].ToString(), vATClass, priceWithVat, decimal.Parse(item["Quantity"].ToString()), 0, null, null);
                    }
                }

                //OptionPaymentType optionPaymentType = new OptionPaymentType();
                //OptionChange optionchange = new OptionChange();
                //OptionChangeType optionChangeType = new OptionChangeType();

                //optionChangeType = OptionChangeType.Change_In_Cash;

                //foreach (var item in Payment.GetBySaleId(int.Parse(dt.Rows[0]["Sale_Id"].ToString())))
                //{
                //    if (item.BankId > 0 && item.AmountPaid > 0.0m)
                //    {
                //        optionPaymentType = OptionPaymentType.Card;

                //    }
                //    else if (item.BankId == 0 && item.AmountPaid > 0.0m)
                //    {
                //        optionPaymentType = OptionPaymentType.Cash;

                //    }

                //}

                //fp.Payment(optionPaymentType, optionchange, clientPayed, optionChangeType);
                fp.PayExactSum(OptionPaymentType.Cash);
                flag = true;

                fp.CloseReceipt();


                //fp.DisplayTextLines1and2("Për kusur: " + frmPayment.numreturn.ToString() + "\nJu Faleminderit!");


                if (Globals.Settings.PrintCopy == "1")
                {
                    fp.PrintLastReceiptDuplicate();
                }


            }
            catch (SException ex)
            {
                flag = false;
            }

            return flag;
        }

        public static void PrintZReport()
        {
            try
            {

                var printer = Services.Printer.Get();
                var s = printer.Find(p => p.Id == Globals.DeviceId);

                FP fp = new FP(Convert.ToInt32(s.DefVersion)) { ServerAddress = "http://LocalHost:4444/" };

                var restClient = GetRestClient("http://LocalHost:4444/");
                var request = new RestRequest($"/settings(com={s.COM},baud=,tcp=,ip=,port=,password=)", Method.GET);
                var response = restClient.Execute(request);

                var requests = new RestRequest("/PrintDailyReport(OptionZeroing=Z)", Method.GET);

                if (response.IsSuccessful)
                {
                    var responses = restClient.Execute(requests);
                    if (responses.IsSuccessful)
                    {
                        AutoClosingMessageBox.Show("Eshte duke u shtypur Z Raporti!", "Sukses", 800);

                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Printeri nuk eshte i lidhur!");
            }

        }
        public static void PrintXReport()
        {
            try
            {
                var printer = Services.Printer.Get();
                var s = printer.Find(p => p.Id == Globals.DeviceId);

                FP fp = new FP(Convert.ToInt32(s.DefVersion)) { ServerAddress = "http://LocalHost:4444/" };
                fp.ServerSetDeviceSerialPortSettings(s.COM, 115200);
                fp.OpenReceipt(1, "0", OptionPrintType.Postponed_printing);

                var restClient = GetRestClient("http://LocalHost:4444/");
                var request = new RestRequest($"/settings(com={s.COM},baud=,tcp=,ip=,port=,password=)", Method.GET);
                var response = restClient.Execute(request);

                var requests = new RestRequest("/PrintDailyReport(OptionZeroing=X)", Method.GET);

                if (response.IsSuccessful)
                {
                    var responses = restClient.Execute(requests);
                    if (responses.IsSuccessful)
                    {
                        AutoClosingMessageBox.Show("Eshte duke u shtypur Z Raporti!", "Sukses", 800);

                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Printeri nuk eshte i lidhur!");
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


    }
}
