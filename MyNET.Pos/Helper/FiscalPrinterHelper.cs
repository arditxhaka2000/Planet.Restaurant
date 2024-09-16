using System;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using Org.BouncyCastle.Asn1.X500;
using System.IO;
using Services;
using System.Data.Entity.Core;
using System.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using Microsoft.Office.Interop.Word;

namespace MyNET.Shops
{
    public class FiscalPrinterHelper
    {
        private static void DeleteFile(string invoiceid)
        {
            string errpath = Globals.Settings.FiscalPrinterPath + "\\PrintErrors";
            if (errpath == string.Empty)
            {
                return;
            }
            errpath = errpath + "\\" + invoiceid + ".INP";
            if (System.IO.File.Exists(errpath))
            {
                System.IO.File.Delete(errpath);
            }
        }
        static void TransferFile(string filePath, string sharedFolderPath)
        {
            try
            {
                string fileName = Path.GetFileName(filePath);
                string destinationPath = Path.Combine(sharedFolderPath, fileName);

                File.Copy(filePath, destinationPath, true);

                Console.WriteLine("File transferred successfully to the shared folder.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        /// <summary>
        /// Metoda per shtypje e fatures ne printer fiskal
        /// </summary>
        /// <param name="SaleId"></param>
        /// <param name="invoiceid">Numri i fatures</param>
        /// <param name="dt">Tabela me te dhenate e artikujve</param>
        /// <param name="totalcash"></param>
        /// <param name="totalKupon"></param>
        /// <param name="totalcek"></param>
        /// <param name="totalCreditCard"></param>
        /// <param name="totalsum"></param>

        public static bool PrintInvoice(int saleId, string invoiceid, System.Data.DataTable dt,
        decimal totalcash, decimal totalKupon, decimal totalcek, decimal totalCreditCard, decimal totalsum)
        {
            Decimal dif = Math.Abs(totalcash + totalKupon + totalcek + totalCreditCard - totalsum);

            if (dif > 0.05M)
            {
                MessageBox.Show("Shuma e paguar nuk eshte e barabart me shumen totale!");
                return false;
            }

            bool retvalue = false;
            if (Globals.Settings.FiscalPrinterPath == string.Empty)
                return false;

            if (Globals.Settings.FiscalPrinterPath.ToLower().Contains("temp"))
            {
                //retvalue = GekosPrint(saleId, invoiceid, dt, totalcash, totalKupon, totalcek, totalCreditCard, totalsum);
            }
            else
            {
                retvalue = DukagjiniPrint(saleId, invoiceid, dt, totalcash, totalKupon, totalcek, totalCreditCard, totalsum);
            }
            return retvalue;
        }

        public static bool GekosPrint(int SaleId, string invoiceid, System.Data.DataTable dt, decimal totalsum, long invoiceNr, int withBank, decimal clientPayed)
        {
            var settings = Services.Settings.Get();
            //S,[numër logjik],______,_,__;[artikulli];[cmimi];[sasia];[departamenti];+
            //[grupi i artikujve];[grupi i TVSH];0;[Kodi i (PLU)];[sasia e rabatit në %];[s999asia e rabatit]

            decimal payedsum = 0;
            string command = "";

            int i = 0;
            int articleCount = 0;
            string invoiceN = "Q,1,______,_,__; 1;Fatura Nr.:" + SaleId;
            string planet = "Q,1,______,_,__; 2;PlanetAccounting.org";
            command = command + invoiceN + "\r\n";
            command = command + planet + "\r\n";
            var discountprice = 0m;
            var clientDiscount = 0m;
            for (i = 1; i <= dt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == false)
                {
                    string salerow = "S,1,______,_,__;";
                    string aaa = dt.Rows[i - 1]["price"].ToString();
                    decimal price = decimal.Parse(dt.Rows[i - 1]["price"].ToString());
                    //decimal discount = price - discountprice;
                    decimal quantity = decimal.Parse(dt.Rows[i - 1]["Quantity"].ToString());
                    decimal printedFiscalQuantity;

                    if (dt.Rows[i - 1].Table.Columns.Contains("PrintedFiscalQuantity"))
                    {
                        printedFiscalQuantity = decimal.Parse(dt.Rows[i - 1].Field<string>("PrintedFiscalQuantity"));
                    }
                    else
                    {
                        printedFiscalQuantity = decimal.Parse(dt.Rows[i - 1].Field<string>("PrintedQuantity"));
                    }


                    if (quantity == printedFiscalQuantity)
                    {
                        articleCount++;
                        continue;
                    }
                    else if(quantity > printedFiscalQuantity)
                    {
                        quantity -= printedFiscalQuantity;
                        var id = dt.Rows[i - 1]["Id"].ToString();
                        Services.Models.TablesSaleDetails.UpdateTableFiscalQuantityPrinted(quantity, id);

                    }

                    //Dim discount As Decimal = (price - discountprice) * quantity
                    decimal discountpercent = decimal.Parse(dt.Rows[i - 1]["Discount"].ToString());
                    decimal vat = decimal.Parse(dt.Rows[i - 1]["Vat"].ToString());
                    decimal priceWithVat = Math.Round(price * (1 + vat / 100), 5);
                    decimal discountprc = discountpercent > 0 ? (priceWithVat * discountpercent / 100) : 0;
                    decimal clientD = decimal.Parse(dt.Rows[i - 1]["ClientDiscount"].ToString());
                    decimal clientDisc = clientD > 0 ? (priceWithVat * clientD / 100) : 0;
                    Services.Models.TablesSaleDetails.UpdateTableFiscalQuantityPrinted(quantity, dt.Rows[i - 1]["Id"].ToString());
                    discountprc *= quantity;

                    //payedsum = totalsum;

                    salerow = salerow + dt.Rows[i - 1]["ItemName"].ToString().Replace(",", " ").Replace(";", " ") + ";";
                    //[artikulli];
                    salerow = salerow + priceWithVat.ToString() + ";";
                    //[cmimi];
                    //if(settings.ForReturn == 1)
                    //{
                    //    if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == false)
                    //        salerow = salerow + (quantity - printedFiscalQuantity).ToString() + ";";

                    //    if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == true)
                    //        salerow = salerow + (-quantity - printedFiscalQuantity).ToString() + ";";
                    //}
                    //else
                    //{
                    //    salerow = salerow + quantity.ToString() + ";";

                    //}
                    salerow = salerow + quantity.ToString() + ";";

                    //[sasia];
                    salerow = salerow + "1;1;";
                    //[departamenti];[grupi i artikujve];

                    //bool WithVat = Globals.Settings.WithVat;
                    int vatgroup = 0;

                    //if (WithVat)
                    //{
                    if (vat == 0)
                        vatgroup = 3;
                    else if (vat == 16)
                        vatgroup = 2;
                    else if (vat == 8)
                        vatgroup = 4;
                    else if (vat == 18)
                        vatgroup = 5;
                    //}
                    //else
                    //vatgroup = 1;

                    //[grupi i TVSH]
                    salerow = salerow + vatgroup.ToString() + ";0;";


                    salerow = salerow + dt.Rows[i - 1]["ItemId"].ToString() + ";";

                    command = command + salerow + "\r\n";

                    clientDiscount += clientDisc;
                    discountprice += discountprc;
                }

            }
            for (i = 1; i <= dt.Rows.Count; i++)
            {
                if (settings.ForReturn == 1 && Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == true)
                {
                    string salerow = "S,1,______,_,__;";
                    string aaa = dt.Rows[i - 1]["price"].ToString();
                    decimal price = decimal.Parse(dt.Rows[i - 1]["price"].ToString());
                    //decimal discount = price - discountprice;
                    decimal quantity = decimal.Parse(dt.Rows[i - 1]["Quantity"].ToString());
                    decimal printedFiscalQuantity;

                    if (dt.Rows[i - 1].Table.Columns.Contains("PrintedFiscalQuantity"))
                    {
                        printedFiscalQuantity = decimal.Parse(dt.Rows[i - 1].Field<string>("PrintedFiscalQuantity"));
                    }
                    else
                    {
                        printedFiscalQuantity = decimal.Parse(dt.Rows[i - 1].Field<string>("PrintedQuantity"));
                    }


                    if (quantity == printedFiscalQuantity)
                    {
                        continue;
                    }

                    //Dim discount As Decimal = (price - discountprice) * quantity
                    decimal discountpercent = decimal.Parse(dt.Rows[i - 1]["Discount"].ToString());
                    decimal vat = Convert.ToInt32(dt.Rows[i - 1]["VAT"].ToString());

                    decimal priceWithVat = Math.Round(price * (1 + vat / 100), 5);
                    decimal discountprc = discountpercent > 0 ? (priceWithVat * discountpercent / 100) : 0;
                    decimal clientD = decimal.Parse(dt.Rows[i - 1]["ClientDiscount"].ToString());
                    decimal clientDisc = clientD > 0 ? (priceWithVat * clientD / 100) : 0;
                    Services.Models.TablesSaleDetails.UpdateTableFiscalQuantityPrinted(quantity, dt.Rows[i - 1]["Id"].ToString());
                    discountprc *= quantity;

                    //payedsum = totalsum;

                    salerow = salerow + dt.Rows[i - 1]["ItemName"].ToString().Replace(",", " ").Replace(";", " ") + ";";
                    //[artikulli];
                    salerow = salerow + priceWithVat.ToString() + ";";
                    //[cmimi];
                    //if(settings.ForReturn == 1)
                    //{
                    //    if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == false)
                    //        salerow = salerow + (quantity - printedFiscalQuantity).ToString() + ";";

                    //    if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == true)
                    //        salerow = salerow + (-quantity - printedFiscalQuantity).ToString() + ";";
                    //}
                    //else
                    //{
                    //    salerow = salerow + quantity.ToString() + ";";

                    //}
                    salerow = salerow + (-quantity - printedFiscalQuantity).ToString() + ";";

                    //[sasia];
                    salerow = salerow + "1;1;";
                    //[departamenti];[grupi i artikujve];

                    //bool WithVat = Globals.Settings.WithVat;
                    int vatgroup = 0;

                    //if (WithVat)
                    //{
                    if (vat == 0)
                        vatgroup = 3;
                    else if (vat == 16)
                        vatgroup = 2;
                    else if (vat == 8)
                        vatgroup = 4;
                    else if (vat == 18)
                        vatgroup = 5;
                    //}
                    //else
                    //vatgroup = 1;

                    //[grupi i TVSH]
                    salerow = salerow + vatgroup.ToString() + ";0;";

                    salerow = salerow + dt.Rows[i - 1]["ItemId"].ToString() + ";";

                    command = command + salerow + "\r\n";

                    clientDiscount += clientDisc;
                    discountprice += discountprc;
                }

            }

            if (articleCount == dt.Rows.Count)
            {
                return false;
            }

            if (discountprice > 0)
            {
                command = command + "C,1,______,_,__;0;0;" + "-" + Math.Round(discountprice, 5) + ";" + "\r\n";

            }
            else if (clientDiscount > 0)
            {
                command = command + "C,1,______,_,__;0;0;" + "-" + Math.Round(clientDiscount, 5) + ";" + "\r\n";

            }

            //if (clientPayed > 0)
            //{
            //    command = command + $"T,1,______,_,__;{withBank};{clientPayed}";
            //}
            //else
            //{
            //    command = command + $"T,1,______,_,__;{withBank}";
            //}
            foreach (var item in Payment.GetBySaleId(SaleId))
            {
                if (item.BankId > 0 && item.AmountPaid > 0.0m)
                {
                    command = command + $"T,1,______,_,__;3;" + "\r\n";

                }
                else if (item.BankId == 0 && item.AmountPaid > 0.0m)
                {
                    command = command + $"T,1,______,_,__;0;" + "\r\n";

                }
            }
            ///Pagesat
            //if (totalcash != 0)
            //    command = command + "T,1,______,_,__;0;" + Math.Round(totalcash, 2) + ";\n";

            //if (totalKupon != 0)
            //    command = command + "T,1,______,_,__;1;" + Math.Round(totalKupon, 2) + ";\n";

            //if (totalcek != 0)
            //    command = command + "T,1,______,_,__;2;" + Math.Round(totalcek, 2) + ";\n";

            //if (totalCreditCard != 0)
            //    command = command + "T,1,______,_,__;3;" + Math.Round(totalCreditCard, 2) + ";\n";

            //Formo fajllin per printer fiskal dhe dergo ne folderin temp
            Random rnd = new Random();
            int num = rnd.Next();
            CreateFile(command, num + ".INP");
            if (Printer.Get().Find(p => p.Id == Globals.DeviceId).IsShared == "0")
            {
                SaleDetails.UpdatePrinted(SaleId);
            }

            //if (withBank > 0)
            //{
            //    CopyBill(num.ToString());
            //}

            //Shiko a eshte sthtyp fatura me sukses

            //if (Printer.Get().Find(p => p.Id == Globals.DeviceId).IsShared != "1")
            //{
            //    var checkbool = CheckPrintStatus(SaleId, num.ToString());
            //    Sale.ChngPrintStatus(SaleId, checkbool);
            //}

            return true;
        }
        public static bool GekosPrintOldV(int SaleId, string invoiceid, System.Data.DataTable dt, decimal totalsum, long invoiceNr, int withBank, decimal clientPayed)
        {
            var settings = Services.Settings.Get();
            //S,[numër logjik],______,_,__;[artikulli];[cmimi];[sasia];[departamenti];
            //[grupi i artikujve];[grupi i TVSH];0;[Kodi i (PLU)];[sasia e rabatit në %];[sasia e rabatit]

            decimal payedsum = 0;
            string command = "";
            int articleCount = 0;

            int i = 0;

            string invoiceN = "Q,1,______,_,__; 1;Fatura Nr.:" + SaleId;
            string planet = "Q,1,______,_,__; 2;PlanetAccounting.org";
            command = command + invoiceN + "\r\n";
            command = command + planet + "\r\n";
            var discountprice = 0m;
            var clientDiscount = 0m;
            for (i = 1; i <= dt.Rows.Count; i++)
            {

                if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == false)
                {
                    string salerow = "S,1,______,_,__;";
                    string aaa = dt.Rows[i - 1]["price"].ToString();
                    decimal price = decimal.Parse(dt.Rows[i - 1]["price"].ToString());
                    //decimal discount = price - discountprice;
                    decimal quantity = decimal.Parse(dt.Rows[i - 1]["Quantity"].ToString());
                    decimal printedFiscalQuantity;

                    if (dt.Rows[i - 1].Table.Columns.Contains("PrintedFiscalQuantity"))
                    {
                        printedFiscalQuantity = decimal.Parse(dt.Rows[i - 1].Field<string>("PrintedFiscalQuantity"));
                    }
                    else
                    {
                        printedFiscalQuantity = decimal.Parse(dt.Rows[i - 1].Field<string>("PrintedQuantity"));
                    }


                    if (quantity == printedFiscalQuantity)
                    {
                        articleCount++;
                        continue;
                    }
                    else if (quantity > printedFiscalQuantity)
                    {
                        quantity -= printedFiscalQuantity;
                    }
                    //Dim discount As Decimal = (price - discountprice) * quantity
                    decimal discountpercent = decimal.Parse(dt.Rows[i - 1]["Discount"].ToString());
                    decimal vat = Convert.ToInt32(dt.Rows[i - 1]["VAT"].ToString());
                    decimal priceWithVat = Math.Round(price * (1 + vat / 100), 5);
                    decimal discountprc = discountpercent > 0 ? (priceWithVat * discountpercent / 100) : 0;
                    discountprc *= quantity;
                    decimal clientD = decimal.Parse(dt.Rows[i - 1]["ClientDiscount"].ToString());
                    decimal clientDisc = clientD > 0 ? (priceWithVat * clientD / 100) : 0;

                    //payedsum = totalsum;

                    salerow = salerow + dt.Rows[i - 1]["ItemName"].ToString().Replace(",", " ").Replace(";", " ") + ";";
                    //[artikulli];
                    salerow = salerow + priceWithVat.ToString() + ";";

                    //if (settings.ForReturn == 1)
                    //{
                    //    if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == false)
                    //        salerow = salerow + (quantity - printedFiscalQuantity).ToString() + ";";

                    //    if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == true)
                    //        salerow = salerow + (-quantity - printedFiscalQuantity).ToString() + ";";
                    //}
                    //else
                    //{
                    //    salerow = salerow + quantity.ToString() + ";";

                    //}
                    salerow = salerow + quantity.ToString() + ";";
                    //[cmimi];
                    //[sasia];
                    salerow = salerow + "1;1;";
                    //[departamenti];[grupi i artikujve];

                    //bool WithVat = Globals.Settings.WithVat;
                    int vatgroup = 0;

                    //if (WithVat)
                    //{
                    if (vat == 0)
                        vatgroup = 3;
                    else if (vat == 16)
                        vatgroup = 2;
                    else if (vat == 8)
                        vatgroup = 4;
                    else if (vat == 18)
                        vatgroup = 5;
                    //}
                    //else
                    //vatgroup = 1;

                    //[grupi i TVSH]
                    salerow = salerow + vatgroup.ToString() + ";0;";


                    salerow = salerow + dt.Rows[i - 1]["ItemId"].ToString() + ";0;";

                    command = command + salerow + "\r\n";

                    clientDiscount += clientDisc;
                    discountprice += discountprc;

                }

            }
            for (i = 1; i <= dt.Rows.Count; i++)
            {

                if (settings.ForReturn == 1 && Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == true)
                {
                    string salerow = "S,1,______,_,__;";
                    string aaa = dt.Rows[i - 1]["price"].ToString();
                    decimal price = decimal.Parse(dt.Rows[i - 1]["price"].ToString());
                    //decimal discount = price - discountprice;
                    decimal quantity = decimal.Parse(dt.Rows[i - 1]["Quantity"].ToString());
                    decimal printedFiscalQuantity;

                    if (dt.Rows[i - 1].Table.Columns.Contains("PrintedFiscalQuantity"))
                    {
                        printedFiscalQuantity = decimal.Parse(dt.Rows[i - 1].Field<string>("PrintedFiscalQuantity"));
                    }
                    else
                    {
                        printedFiscalQuantity = decimal.Parse(dt.Rows[i - 1].Field<string>("PrintedQuantity"));
                    }


                    if (quantity == printedFiscalQuantity)
                    {
                        continue;
                    }
                    //Dim discount As Decimal = (price - discountprice) * quantity
                    decimal discountpercent = decimal.Parse(dt.Rows[i - 1]["Discount"].ToString());
                    decimal vat = decimal.Parse(dt.Rows[i - 1]["Vat"].ToString());
                    decimal priceWithVat = Math.Round(price * (1 + vat / 100), 5);
                    decimal discountprc = discountpercent > 0 ? (priceWithVat * discountpercent / 100) : 0;
                    discountprc *= quantity;
                    decimal clientD = decimal.Parse(dt.Rows[i - 1]["ClientDiscount"].ToString());
                    decimal clientDisc = clientD > 0 ? (priceWithVat * clientD / 100) : 0;

                    //payedsum = totalsum;

                    salerow = salerow + dt.Rows[i - 1]["ItemName"].ToString().Replace(",", " ").Replace(";", " ") + ";";
                    //[artikulli];
                    salerow = salerow + priceWithVat.ToString() + ";";

                    //if (settings.ForReturn == 1)
                    //{
                    //    if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == false)
                    //        salerow = salerow + (quantity - printedFiscalQuantity).ToString() + ";";

                    //    if (Convert.ToBoolean(dt.Rows[i - 1]["ForReturn"].ToString()) == true)
                    //        salerow = salerow + (-quantity - printedFiscalQuantity).ToString() + ";";
                    //}
                    //else
                    //{
                    //    salerow = salerow + quantity.ToString() + ";";

                    //}
                    salerow = salerow + (-quantity - printedFiscalQuantity).ToString() + ";";
                    //[cmimi];
                    //[sasia];
                    salerow = salerow + "1;1;";
                    //[departamenti];[grupi i artikujve];

                    //bool WithVat = Globals.Settings.WithVat;
                    int vatgroup = 0;

                    //if (WithVat)
                    //{
                    if (vat == 0)
                        vatgroup = 3;
                    else if (vat == 16)
                        vatgroup = 2;
                    else if (vat == 8)
                        vatgroup = 4;
                    else if (vat == 18)
                        vatgroup = 5;
                    //}
                    //else
                    //vatgroup = 1;

                    //[grupi i TVSH]
                    salerow = salerow + vatgroup.ToString() + ";0;";


                    salerow = salerow + dt.Rows[i - 1]["ItemId"].ToString() + ";0;";

                    command = command + salerow + "\r\n";

                    clientDiscount += clientDisc;
                    discountprice += discountprc;

                }

            }
            if (articleCount == dt.Rows.Count)
            {
                return false;
            }
            if (discountprice > 0)
            {
                command = command + "C,1,______,_,__;0;0;" + "-" + Math.Round(discountprice, 5) + ";" + "\r\n";

            }
            else if (clientDiscount > 0)
            {
                command = command + "C,1,______,_,__;0;0;" + "-" + Math.Round(clientDiscount, 5) + ";" + "\r\n";

            }

            //if (clientPayed > 0)
            //{
            //    command = command + $"T,1,______,_,__;{withBank};{clientPayed}";
            //}
            //else
            //{
            //    command = command + $"T,1,______,_,__;{withBank}";
            //}
            foreach (var item in Payment.GetBySaleId(SaleId))
            {
                if (item.BankId > 0 && item.AmountPaid > 0.0m)
                {
                    command = command + $"T,1,______,_,__;3;" + "\r\n";

                }
                else if (item.BankId == 0 && item.AmountPaid > 0.0m)
                {
                    command = command + $"T,1,______,_,__;0;" + "\r\n";

                }
            }
            ///Pagesat
            //if (totalcash != 0)
            //    command = command + "T,1,______,_,__;0;" + Math.Round(totalcash, 2) + ";\n";

            //if (totalKupon != 0)
            //    command = command + "T,1,______,_,__;1;" + Math.Round(totalKupon, 2) + ";\n";

            //if (totalcek != 0)
            //    command = command + "T,1,______,_,__;2;" + Math.Round(totalcek, 2) + ";\n";

            //if (totalCreditCard != 0)
            //    command = command + "T,1,______,_,__;3;" + Math.Round(totalCreditCard, 2) + ";\n";

            //Formo fajllin per printer fiskal dhe dergo ne folderin temp
            Random rnd = new Random();
            int num = rnd.Next();


            CreateFile(command, num + ".INP");

            //Important per printimin e kuponav me ni ark te ni pc tjeter
            if (Printer.Get().Find(p => p.Id == Globals.DeviceId).IsShared == "0")
            {
                SaleDetails.UpdatePrinted(SaleId);
            }
            //if (withBank>0)
            //{
            //    CopyBill(num.ToString());
            //}

            //Shiko a eshte sthtyp fatura me sukses



            //if (Printer.Get().Find(p => p.Id == Globals.DeviceId).IsShared != "0")
            //{
            //    var checkbool = CheckPrintStatus(SaleId, num.ToString());
            //    Sale.ChngPrintStatus(SaleId, checkbool);
            //}
            return true;
        }

        private static bool DukagjiniPrint(int SaleId, string invoiceid, System.Data.DataTable dt,
              decimal totalcash, decimal totalKupon, decimal totalcek, decimal totalCreditCard, decimal totalsum)
        {
            decimal totalSum = 0.0M;
            string command = "";

            int i = 0;
            //of article; Name of article in English; Albanian; Serbian Quantity VAT; Price of article; Discount by article; Discount on entire bill;
            for (i = 1; i <= dt.Rows.Count; i++)
            {
                //1;shifra;enN;sqN;srN;qty;vatgroup;price;discount%;entirediscount%
                string salerow = "1;{0};{1};{2};{3};{4};{5};{6};{7}%;{8}%;";

                string itemId = dt.Rows[i - 1]["ItemId"].ToString();
                decimal price = decimal.Parse(dt.Rows[i - 1]["price"].ToString());
                decimal discount = decimal.Parse(dt.Rows[i - 1]["Discount"].ToString());
                decimal vat = decimal.Parse(dt.Rows[i - 1]["Vat"].ToString());
                string itemName = dt.Rows[i - 1]["ItemName"].ToString().Replace(",", " ").Replace(";", " ");
                decimal qty = decimal.Parse(dt.Rows[i - 1]["Quantity"].ToString());


                decimal discountprice = price * (1 - discount / 100);
                decimal priceWithVat = Math.Round(price * (1 + vat / 100), 2);

                totalSum += priceWithVat * qty;

                //bool withVat = Globals.Settings.WithVat;
                string vatgroup = "C";

                //if (withVat)
                //{
                if (vat == 0)
                    vatgroup = "A";
                else if (vat == 16)
                    vatgroup = "B";
                else if (vat == 0)
                    vatgroup = "C";
                else if (vat == 8)
                    vatgroup = "D";
                else if (vat == 18)
                    vatgroup = "E";
                /// }
                // else
                //     vatgroup = "C";

                string itemDiscount = "0";
                string saleDiscount = "0";

                salerow = string.Format(salerow, itemId, itemName, itemName, itemName, qty, vatgroup, priceWithVat, discount.ToString("N"), saleDiscount);

                //[Kodi i (PLU)];               
                command = command + salerow + "\r\n";
            }

            ///Pagesat
            string payment = "{0};{1};{2};{3}"; //1.78; 3.50; 1.00; 0 //cash;card;check;voucher
            payment = String.Format(payment, totalSum, totalCreditCard, totalcek, totalKupon);
            command += payment;

            //Formo fajllin per printer fiskal dhe dergo ne folderin temp
            CreateFile(command, "Bill.txt");

            System.Diagnostics.Process.Start(Globals.Settings.FiscalPrinterPath + @"\delio.exe", Globals.Settings.FiscalPrinterPath + @"\Bill.txt");

            //Shiko a eshte sthtyp fatura me sukses
            return CheckPrintStatusD(SaleId, invoiceid);
        }

        // Per printeat gekos
        public static bool CheckPrintStatus(int saleId, string invoiceId)
        {
            //shiko a ekziston fajlli i gabimit
            bool succes = false;
            string errfile = Printer.Get().Find(p => p.Id == Globals.DeviceId).Path + "\\PrintErrors" + "\\" + invoiceId + ".INP";
            string printfile = Printer.Get().Find(p => p.Id == Globals.DeviceId).Path + "\\" + invoiceId + ".INP";


            int count = 0;
            while ((true))
            {
                bool existerrfile = System.IO.File.Exists(errfile);
                bool existprintfile = System.IO.File.Exists(printfile);

                if (!existprintfile && !existerrfile)
                {
                    //Nese fajlli printfile eshte fshi prej folderi dhe fajlli erron nuk eksziton
                    //fatura eshte shtyp me sukses
                    succes = true;
                    break;
                }
                else if (!existprintfile && existerrfile)
                {
                    //Nese fajlli printfile eshte fshi prej folderi ndesa fajlli error ekziston  
                    //fatura nuk ka mujte me u shtyp ne printer fiskal
                    succes = false;
                    //MessageBox.Show("Gabim ne shtypjen e fatures ne printerin fiskal! Ju lutem kontrolloni mesazhin e gabimit ne printer fiskal.",
                    //    "Shtypja ne printer fiskal!",
                    //    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else if (count > 1)
                {
                    //Nese ka kalu koha e pritjes
                    //fatura nuk eshte shtyp me sukes
                    //Ndoshta printeri fiskal eshte i ndalur
                    succes = false;
                    //MessageBox.Show("Gabim ne shtypjen e fatures ne printerin fiskal! Ju lutem kontrollo nese printeri fiskal eshte i kyqur?",
                    //    "Shtypja ne printer fiskal!",
                    //    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else
                    //pendryshe prit 1 second provo prap
                    System.Threading.Thread.Sleep(1000);

                count = count + 1;
            }

            return succes;

        }

        //per printerat e dukagjinit
        private static bool CheckPrintStatusD(int saleid, string invoiceId)
        {
            //shiko a ekziston fajlli i gabimit
            bool succes = false;
            string printfile = Globals.Settings.FiscalPrinterPath + "\\Bill.txt";

            int count = 0;
            while ((true))
            {
                //bool existerrfile = System.IO.File.Exists(errfile);
                bool existprintfile = System.IO.File.Exists(printfile);

                if (!existprintfile)
                {
                    //Nese fajlli printfile eshte fshi prej folderi
                    //fatura eshte shtyp me sukses
                    succes = true;
                    break;
                }
                else if (count > 5)
                {
                    //Nese ka kalu koha e pritjes
                    //fatura nuk eshte shtyp me sukes
                    //Ndoshta printeri fiskal eshte i ndalur
                    succes = false;
                    MessageBox.Show("Gabim ne shtypjen e fatures ne printerin fiskal! Ju lutem kontrollo nese printeri fiskal eshte i kyqur?",
                        "Shtypja ne printer fiskal!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else
                    //pendryshe prit 1 second provo prap
                    System.Threading.Thread.Sleep(1000);

                count = count + 1;
            }

            return succes;
        }

        public static void CashInOrCashOut(decimal sum)
        {
            //?,1,______,_,__;CashInOut;Cash in or Cash out;;;Entering or withdrawal of cash in cashdrawer. If we have sign- before amount it is withdrawal from cashdrawer;
            //V,1,______,_,__;F<CashInOut>
            CreateFile("V,1,______,_,__;F" + sum.ToString(), "display.inp");
        }

        public static void ShowInDisplay(string firstrow, string secondrow)
        {
            CreateFile("E,1,______,_,__;" + firstrow + ";" + secondrow + ";", "display");
        }

        public static void CopyBill(string invoiceId)
        {
            //V,1,______,_,__;m1
            CreateFile("V,1,______,_,__;m1", $"{invoiceId}-C.inp");
        }

        public static void OpenChashDrawer()
        {
            //Opening cash drawer
            CreateFile("V,1,______,_,__;j15", "opencashdrawer");
        }

        public static void PrintXReport()
        {
            //Print XReport
            //V,1,______,_,__;j
            CreateFile("X,1,______,_,__;", "xreport");
        }

        public static void PrintZReport()
        {
            //Print Z Report
            CreateFile("Z,1,______,_,__;", "zreport");
        }

        protected static void CreateFile(string command, string filename)
        {
            try
            {
                var printer = Services.Printer.Get().Find(p => p.Id == Globals.DeviceId);

                if (printer.Path == string.Empty || command == string.Empty)
                    return;

                printer.Path = Path.Combine(printer.Path, filename);

                DeleteFile(filename);

                using (StreamWriter sw = new StreamWriter(printer.Path))
                {
                    sw.WriteLine(command);
                    sw.Flush();
                }
                //if (printer.IsShared == "1")
                //{
                //    string sharedFolderPath = printer.SharedPath;
                //    TransferFile(printer.Path, sharedFolderPath);
                //}

            }
            catch (Exception)
            {

            }

        }

    }
}