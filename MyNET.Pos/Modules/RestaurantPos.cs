using iText.Layout.Element;
using Microsoft.Office.Interop.Word;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using MyNET.Pos.Helper;
using MyNET.Pos.Modules;
using MyNET.Shops;
using Newtonsoft.Json;
using Services;
using Services.Models;
using SocketClient;
using Sprache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Printing;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using TremolZFP;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using DataTable = System.Data.DataTable;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = System.Drawing.Point;

namespace MyNET.Pos
{
    public partial class RestaurantPos : Form
    {
        #region  Members

        protected decimal mTotalWithoutVat = 0M;
        protected decimal mVatSum = 0M;
        protected decimal mTotalSum = 0M;
        protected decimal mTotalSumWVat = 0M;
        protected int mSaleId = 0;
        protected int currentTblSaleId = 0;

        public static decimal totalSumOpenBalance = 0.0M;
        public decimal totaltoPay { get { decimal tot = Convert.ToDecimal(txtTotalSum.Text); return tot; } }
        public static int countNumFiscal;
        public string fullPath;
        public static DailyOpenCloseBalance daily = DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(Globals.User.Id);
        public static string language = "";
        public int DailyOpenFiscalCount = daily.DailyFiscalCount;
        protected bool mIsChanged = true;
        public static int PartnerId;
        public static int catButtonL;
        public static int Panelsize;
        public static bool refresh = false;
        public static decimal qnt = 0;
        public List<Services.Action> aksionet = null;
        public static Size bSize;
        public static Size CbSize;
        public static Size subCbSize;
        public static Font bTextSize;
        public static int buttonSize;
        public static BonusCard bonuscard = null;
        public static decimal bonuscardValue = 0.0m;
        public static decimal bonuscardValue1 = 0.0m;
        public static System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();


        public static string lastInvNumber;
        public string tableId = "";
        public static System.Data.DataTable data = new System.Data.DataTable();

        /// <summary>
        /// Artikujt ne fature
        /// </summary>
        protected List<Services.Models.ItemsDiscount> mItems;
        protected List<Services.Models.ItemsDiscount> mAllItems;
        protected List<Services.Models.ItemsDiscount> mSubCatItem;
        protected List<Services.Action> mActions;
        protected List<Services.ItemCategory> mSubCat;
        protected List<Services.ItemCategory> mAllSubCat;
        protected Services.SaleDetails mCurrentSaleDetail;
        //public System.Collections.Generic.List<ItemsDiscount> allItems = Services.Item.GetFav(1);
        /// <summary>
        /// gjendja  e kontonles hyrese
        /// 0 barkodet
        /// 1 sasia
        /// 2 cmimi
        /// </summary>
        protected InputControlState inputstate = InputControlState.ShearchItem;
        #endregion

        #region Constructors
        public RestaurantPos(string bname)
        {

            InitializeComponent();
            tableId = bname;
        }
        public RestaurantPos()
        {
            InitializeComponent();

            ug.Dock = DockStyle.Fill;
            mPaymentDialog = new frmPayment(displayInfo);
        }

        #endregion

        #region buttons

        //info disply dialog form
        private DisplayInfo displayInfo = new DisplayInfo();

        //payment dialog form
        private frmPayment mPaymentDialog = new frmPayment();

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //var sett = Services.Settings.Get();

                if (cbPartners.SelectedItem != null)
                {
                    if (ug.Rows.Count > 0)
                    {
                        //mPaymentDialog.TotalForPay = decimal.Parse(txtTotalSum.Text);  

                        //Screen secondScreen = Screen.AllScreens.FirstOrDefault(s => s != Screen.PrimaryScreen);
                        //if (secondScreen != null)

                        //{
                        //    displayInfo.Location = secondScreen.Bounds.Location;
                        //    displayInfo.StartPosition = FormStartPosition.Manual;
                        //    displayInfo.Show();
                        //}
                        DialogResult dialogResult = mPaymentDialog.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {

                            mSaleId = SaveSale();
                            //save sales details

                            int rows = SaveSaleDetails(mSaleId);

                            if (rows > 0)
                            {
                                SavePayment();
                                //print invoice                               
                                PrintF();
                                //change sale status . Now sale is ready for sync
                                Services.Sale.ChngStatus(mSaleId, 0);
                            }



                            if (ug.Columns.Contains(" ") == true)
                            {
                                ug.Columns.RemoveAt(27);
                            }

                            countNumFiscal++;
                            lblFiscalCount.Text = (Convert.ToInt32(lblFiscalCount.Text) + 1).ToString();
                            ClearFields();
                            txtDiscount.Text = "0.0";
                            txt.Text = "";
                            lblNameAndQuant.Text = "";
                            txtsearch.DataSource = null;

                            Services.Tables.UpdateTablePos(0, tableId);
                            Services.Models.TablesSaleDetails.UpdateTableSDPrinted(1, tableId);
                            Services.Models.TablesSaleDetails.UpdateStatus(1, tableId);
                            Services.Tables.UpdateTableFiscalCount("0", tableId);
                            Services.Tables.UpdateTableEmpId("0", tableId);


                            Services.Tables.UpdateTotalInPos("0", tableId);
                            Globals.NextStep = "Restaurant";
                            this.Close();
                        }
                    }
                    else
                    {
                        Services.Tables.UpdateTablePos(0, tableId);
                        Services.Models.TablesSaleDetails.UpdateTableSDPrinted(1, tableId);
                        Services.Models.TablesSaleDetails.UpdateStatus(1, tableId);
                        Services.Tables.UpdateTableFiscalCount("0", tableId);
                        Services.Tables.UpdateTableEmpId("0", tableId);


                        Services.Tables.UpdateTotalInPos("0", tableId);
                        Globals.NextStep = "Restaurant";
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show(paragraph_invoice_error.Text);
                }

                if (Globals.Settings.StockWMinus == "0")
                {
                    mAllItems = Services.Item.GetItemsDiscount(Globals.Station.ParentId);

                }
                else
                {
                    mAllItems = Services.Item.GetAllItem();

                }
                Globals.Settings = Services.Settings.Get();
            }
            catch (Exception ex)
            {
                TrackError.ReportError(ex.Message);

            }
        }



        private void PrintThermal()
        {
            var printer = Services.Printer.Get().Find(p => p.Id == Globals.DeviceId);

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printer.TermalName;
            printDoc.PrintPage += new PrintPageEventHandler(PrintDataGridView);
            printDoc.Print();


        }
        private void PrintRestaurantThermal()
        {

            var printer = Services.Printer.Get().Find(p => p.Id == Globals.DeviceId);
            var settings = Services.Settings.Get();

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = settings.PosPrinter == "1" ? printer.TermalName : settings.ThermalPrinterName;
            printDoc.PrintPage += new PrintPageEventHandler(PrintRestaurantDataGridView);
            bool flag = false;
            foreach (DataGridViewRow item in ug.Rows)
            {
                int quantity = Convert.ToInt32(item.Cells["Quantity"].Value);
                int printedQuantity = Convert.ToInt32(item.Cells["PrintedQuantity"].Value);

                if (quantity > printedQuantity)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                printDoc.Print();

            }


        }

        public void ClickAll()
        {

            foreach (var item in mAllItems.Skip(12).Take(20))
            {
                int buttonNumber = item.Id;
                IdentifierButtonEventArgs args = new IdentifierButtonEventArgs(buttonNumber);
                button_Clicker(this, args);

            }


        }
        private void ug_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ug.CurrentCell.ColumnIndex == 6)
            {
                ug.EndEdit();
                e.Handled = true;
                if (Globals.Settings.BarcMode == 1)
                {
                    txtsrchB.Focus();
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DiscountTotalPercentage discountTotalPercentage = new DiscountTotalPercentage();
            discountTotalPercentage.ShowDialog();
            foreach (DataGridViewRow row in ug.Rows)
            {
                row.Cells["Discount"].Value = DiscountTotalPercentage.TotalPercentage;
                SimulateCellEndEdit(row.Index, 12);

            }
        }
        private void btn_savePOS_Click(object sender, EventArgs e)
        {
            if (ug.Rows.Count == 0)
            {
                SavePOS savePOS = new SavePOS();
                savePOS.Owner = this;
                savePOS.Show();
            }
            else
            {
                SavedPOS savedPOS = new SavedPOS();
                SavedPOSItems savedPOSI = new SavedPOSItems();
                savedPOS.Status = "1";
                savedPOS.TotalSum = mTotalSum;
                savedPOS.ArticleNr = ug.Rows.Count;
                savedPOS.StationId = Globals.Station.Id;

                var result = savedPOS.Insert();

                foreach (DataGridViewRow row in ug.Rows)
                {
                    savedPOSI.ItemId = Convert.ToInt32(row.Cells["ItemId"].Value);
                    savedPOSI.POSId = savedPOS.Id;
                    savedPOSI.Insert();
                }
                SavePOS savePOS = new SavePOS();
                savePOS.Owner = this;
                savePOS.ShowDialog();
            }

        }
        private void txtt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtsearch.DroppedDown = false;

                txtsearch.Cursor = Cursors.Arrow;
                List<ItemsDiscount> item = null;
                ItemsDiscount foundItems = null;
                var clientDiscount = Partner.Get(PartnerId).Discount;

                try
                {
                    if (txt.Text != "Emri,Çmimi,Shifra" && txt.Text != "")
                    {
                        if (ug.Columns.Contains(" ") == false)
                        {
                            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                            col.UseColumnTextForButtonValue = true;
                            col.Name = " ";
                            ug.Columns.Add(col);

                        }
                        if (Globals.Settings.BarcMode == 0)
                        {
                            item = mAllItems.Where(p => p.Barcode == txt.Text).ToList();

                            if (item.Count > 0)
                            {
                                foundItems = item.First();
                            }
                            if (foundItems != null)
                            {
                                bool found = false;
                                if (foundItems.Service == 0)
                                {


                                    var itemAction = aksionet.Find(p => p.item_id == foundItems.Id);
                                    var categoryAction = aksionet.Find(p => p.category_id == foundItems.CategoryId);
                                    var availableStock = Globals.Settings.StockWMinus == "0" ? Warehouse.GetbyId(foundItems.Id).InStock : -1;

                                    if (itemAction != null && Globals.Settings.AllowDiscount == "0")
                                    {
                                        var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                        var totalPrice = tp - (tp * clientDiscount / 100);

                                        if (itemAction.quantity == 1)
                                        {
                                            if (ug.Rows.Count > 0)
                                            {
                                                foreach (DataGridViewRow row in ug.Rows)
                                                {
                                                    if (row.Cells[4].Value.ToString() == txt.Text && txt.Text != "")
                                                    {
                                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && availableStock != -1)
                                                        {
                                                            if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                            {
                                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                                                row.Cells["Discount"].Value = itemAction.discount;
                                                                txt.Text = "";
                                                                CalculateGridColumns();
                                                            }
                                                            else
                                                            {
                                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                txt.Text = "";
                                                                CalculateGridColumns();

                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                            {
                                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                                {
                                                                    EnterPin enter = new EnterPin();
                                                                    enter.ShowDialog();
                                                                    if (enter.flag == true)
                                                                    {
                                                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                                        {
                                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                                                            row.Cells["Discount"].Value = itemAction.discount;
                                                                            txt.Text = "";
                                                                            CalculateGridColumns();
                                                                        }
                                                                        else
                                                                        {
                                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                            txt.Text = "";
                                                                            CalculateGridColumns();

                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                            }
                                                        }
                                                        found = true;
                                                    }


                                                }
                                                if (!found)
                                                {
                                                    foundItems.Discount = itemAction.discount;
                                                    AddItem(foundItems);
                                                    txt.Text = "";
                                                    CalculateGridColumns();

                                                }
                                            }
                                            else
                                            {
                                                foundItems.Discount = itemAction.discount;
                                                AddItem(foundItems);
                                                txt.Text = "";
                                                CalculateGridColumns();

                                            }
                                        }
                                        else
                                        {

                                            if (ug.Rows.Count > 0)
                                            {
                                                foreach (DataGridViewRow row in ug.Rows)
                                                {
                                                    if (row.Cells[4].Value.ToString() == txt.Text && txt.Text != "")
                                                    {
                                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && availableStock != -1)
                                                        {
                                                            if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                            {
                                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                                                row.Cells["Discount"].Value = itemAction.discount;
                                                                txt.Text = "";
                                                                CalculateGridColumns();


                                                            }
                                                            else
                                                            {
                                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                txt.Text = "";
                                                                CalculateGridColumns();

                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                            {
                                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                                {
                                                                    EnterPin enter = new EnterPin();
                                                                    enter.ShowDialog();
                                                                    if (enter.flag == true)
                                                                    {
                                                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                                        {
                                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                                                            row.Cells["Discount"].Value = itemAction.discount;
                                                                            txt.Text = "";
                                                                            CalculateGridColumns();


                                                                        }
                                                                        else
                                                                        {
                                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                            txt.Text = "";
                                                                            CalculateGridColumns();

                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                            }
                                                        }
                                                        found = true;

                                                    }

                                                }
                                                if (!found)
                                                {
                                                    AddItem(foundItems);
                                                    txt.Text = "";
                                                    CalculateGridColumns();

                                                }
                                            }
                                            else
                                            {
                                                AddItem(foundItems);
                                                txt.Text = "";
                                                CalculateGridColumns();

                                            }
                                        }
                                    }



                                    else if (categoryAction != null && Globals.Settings.AllowDiscount == "0")
                                    {
                                        var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                        var totalPrice = tp - (tp * clientDiscount / 100);
                                        if (categoryAction.quantity == 1)
                                        {
                                            if (ug.Rows.Count > 0)
                                            {
                                                foreach (DataGridViewRow row in ug.Rows)
                                                {
                                                    if (row.Cells[4].Value.ToString() == txt.Text && txt.Text != "")
                                                    {
                                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && availableStock != -1)
                                                        {
                                                            if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                            {
                                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                                                row.Cells["Discount"].Value = categoryAction.discount;
                                                                txt.Text = "";
                                                                CalculateGridColumns();

                                                            }
                                                            else
                                                            {
                                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                txt.Text = "";
                                                                CalculateGridColumns();

                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                            {
                                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                                {
                                                                    EnterPin enter = new EnterPin();
                                                                    enter.ShowDialog();
                                                                    if (enter.flag == true)
                                                                    {
                                                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                                        {
                                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                                                            row.Cells["Discount"].Value = categoryAction.discount;
                                                                            txt.Text = "";
                                                                            CalculateGridColumns();

                                                                        }
                                                                        else
                                                                        {
                                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                            txt.Text = "";
                                                                            CalculateGridColumns();

                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                            }
                                                        }
                                                        found = true;

                                                    }
                                                }
                                                if (!found)
                                                {
                                                    foundItems.Discount = categoryAction.discount;
                                                    AddItem(foundItems);
                                                    txt.Text = "";
                                                    CalculateGridColumns();

                                                }
                                            }
                                            else
                                            {
                                                foundItems.Discount = categoryAction.discount;
                                                AddItem(foundItems);
                                                txt.Text = "";
                                                CalculateGridColumns();

                                            }
                                        }
                                        else
                                        {

                                            if (ug.Rows.Count > 0)
                                            {
                                                foreach (DataGridViewRow row in ug.Rows)
                                                {
                                                    if (row.Cells[4].Value.ToString() == txt.Text && txt.Text != "")
                                                    {
                                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && availableStock != -1)
                                                        {
                                                            if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                            {
                                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                                                row.Cells["Discount"].Value = categoryAction.discount;
                                                                txt.Text = "";
                                                                CalculateGridColumns();

                                                            }
                                                            else
                                                            {
                                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                txt.Text = "";
                                                                CalculateGridColumns();


                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                            {
                                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                                {
                                                                    EnterPin enter = new EnterPin();
                                                                    enter.ShowDialog();
                                                                    if (enter.flag == true)
                                                                    {
                                                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                                        {
                                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                                                            row.Cells["Discount"].Value = categoryAction.discount;
                                                                            txt.Text = "";
                                                                            CalculateGridColumns();

                                                                        }
                                                                        else
                                                                        {
                                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                            txt.Text = "";
                                                                            CalculateGridColumns();


                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                            }
                                                        }
                                                        found = true;
                                                    }


                                                }
                                                if (!found)
                                                {
                                                    AddItem(foundItems);
                                                    txt.Text = "";
                                                    CalculateGridColumns();

                                                }
                                            }
                                            else
                                            {
                                                AddItem(foundItems);
                                                txt.Text = "";
                                                CalculateGridColumns();

                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (ug.Rows.Count > 0)
                                        {
                                            foreach (DataGridViewRow row in ug.Rows)
                                            {
                                                if (row.Cells[4].Value.ToString() == txt.Text && txt.Text != "")
                                                {
                                                    if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && availableStock != -1)
                                                    {
                                                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                                                        var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                                        var totalPrice = tp - (tp * clientDiscount / 100);

                                                        if ((decimal)row.Cells["Discount"].Value != 0)
                                                        {
                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);
                                                            txt.Text = "";
                                                            CalculateGridColumns();


                                                        }
                                                        else
                                                        {
                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txt.Text = "";
                                                            CalculateGridColumns();

                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                        {
                                                            if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                            {
                                                                EnterPin enter = new EnterPin();
                                                                enter.ShowDialog();
                                                                if (enter.flag == true)
                                                                {
                                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                                                                    var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                                                    var totalPrice = tp - (tp * clientDiscount / 100);

                                                                    if ((decimal)row.Cells["Discount"].Value != 0)
                                                                    {
                                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);
                                                                        txt.Text = "";
                                                                        CalculateGridColumns();


                                                                    }
                                                                    else
                                                                    {
                                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                        txt.Text = "";
                                                                        CalculateGridColumns();

                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                        }
                                                    }

                                                    //var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                                    //mTotalSum = total;
                                                    //txtTotalSum.Text = mTotalSum.ToString();
                                                    AdjustTblTotalColumnWidths();
                                                    found = true;
                                                    return;
                                                }

                                            }
                                            if (!found)
                                            {
                                                AddItem(foundItems);

                                                txt.Text = "";
                                                CalculateGridColumns();

                                            }
                                        }
                                        else
                                        {
                                            //add found item.
                                            if (txt.Text == "")
                                                return;
                                            var items = foundItems;
                                            AddItem(items);
                                            txt.Text = "";
                                            CalculateGridColumns();


                                        }
                                    }
                                }
                                else
                                {
                                    var itemAction = aksionet.Find(p => p.item_id == foundItems.Id);
                                    var categoryAction = aksionet.Find(p => p.category_id == foundItems.CategoryId);

                                    if (itemAction != null && Globals.Settings.AllowDiscount == "0")
                                    {
                                        var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                        var totalPrice = tp - (tp * clientDiscount / 100);

                                        if (itemAction.quantity == 1)
                                        {
                                            if (ug.Rows.Count > 0)
                                            {
                                                foreach (DataGridViewRow row in ug.Rows)
                                                {
                                                    if (row.Cells[4].Value.ToString() == txt.Text && txt.Text != "")
                                                    {
                                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                                            row.Cells["Discount"].Value = itemAction.discount;
                                                            txt.Text = "";
                                                            CalculateGridColumns();
                                                        }
                                                        else
                                                        {
                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txt.Text = "";
                                                            CalculateGridColumns();

                                                        }
                                                        found = true;
                                                    }


                                                }
                                                if (!found)
                                                {
                                                    foundItems.Discount = itemAction.discount;
                                                    AddItem(foundItems);
                                                    txt.Text = "";
                                                    CalculateGridColumns();

                                                }
                                            }
                                            else
                                            {
                                                foundItems.Discount = itemAction.discount;
                                                AddItem(foundItems);
                                                txt.Text = "";
                                                CalculateGridColumns();

                                            }
                                        }
                                        else
                                        {

                                            if (ug.Rows.Count > 0)
                                            {
                                                foreach (DataGridViewRow row in ug.Rows)
                                                {
                                                    if (row.Cells[4].Value.ToString() == txt.Text && txt.Text != "")
                                                    {
                                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                                            row.Cells["Discount"].Value = itemAction.discount;
                                                            txt.Text = "";
                                                            CalculateGridColumns();


                                                        }
                                                        else
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txt.Text = "";
                                                            CalculateGridColumns();

                                                        }
                                                        found = true;

                                                    }

                                                }
                                                if (!found)
                                                {
                                                    AddItem(foundItems);
                                                    txt.Text = "";
                                                    CalculateGridColumns();

                                                }
                                            }
                                            else
                                            {
                                                AddItem(foundItems);
                                                txt.Text = "";
                                                CalculateGridColumns();

                                            }
                                        }
                                    }



                                    else if (categoryAction != null && Globals.Settings.AllowDiscount == "0")
                                    {
                                        var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                        var totalPrice = tp - (tp * clientDiscount / 100);
                                        if (categoryAction.quantity == 1)
                                        {
                                            if (ug.Rows.Count > 0)
                                            {
                                                foreach (DataGridViewRow row in ug.Rows)
                                                {
                                                    if (row.Cells[4].Value.ToString() == txt.Text && txt.Text != "")
                                                    {
                                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                                            row.Cells["Discount"].Value = categoryAction.discount;
                                                            txt.Text = "";
                                                            CalculateGridColumns();

                                                        }
                                                        else
                                                        {
                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txt.Text = "";
                                                            CalculateGridColumns();

                                                        }

                                                    }
                                                    found = true;
                                                }
                                                if (!found)
                                                {
                                                    foundItems.Discount = categoryAction.discount;
                                                    AddItem(foundItems);
                                                    txt.Text = "";
                                                    CalculateGridColumns();

                                                }
                                            }
                                            else
                                            {
                                                foundItems.Discount = categoryAction.discount;
                                                AddItem(foundItems);
                                                txt.Text = "";
                                                CalculateGridColumns();

                                            }
                                        }
                                        else
                                        {

                                            if (ug.Rows.Count > 0)
                                            {
                                                foreach (DataGridViewRow row in ug.Rows)
                                                {
                                                    if (row.Cells[4].Value.ToString() == txt.Text && txt.Text != "")
                                                    {
                                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                                            row.Cells["Discount"].Value = categoryAction.discount;
                                                            txt.Text = "";
                                                            CalculateGridColumns();

                                                        }
                                                        else
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txt.Text = "";
                                                            CalculateGridColumns();


                                                        }
                                                        found = true;
                                                    }


                                                }
                                                if (!found)
                                                {
                                                    AddItem(foundItems);
                                                    txt.Text = "";
                                                    CalculateGridColumns();

                                                }
                                            }
                                            else
                                            {
                                                AddItem(foundItems);
                                                txt.Text = "";
                                                CalculateGridColumns();

                                            }
                                        }

                                    }
                                }
                            }
                            else
                            {
                                item = Services.Item.GetItemWithName(txt.Text.ToLower());
                                txtsearch.DataSource = item;
                                txtsearch.DrawItem += comboBox1_DrawItem;

                                // Set the DrawMode to OwnerDrawFixed to enable custom drawing
                                txtsearch.DrawMode = DrawMode.OwnerDrawFixed;
                                txtsearch.ValueMember = "Id";
                                //AutosizeDropdown(txtsearch);
                                if (item.Count > 0)
                                {
                                    txtsearch.DroppedDown = true;
                                    txtsearch.Focus();
                                }
                                else
                                {
                                    txtsearch.DroppedDown = false;

                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Nuk ka artikuj me kete emer!");
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (txtsearch.SelectedIndex > 0)
                {
                    txtsearch.SelectedIndex--;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtsearch.SelectedIndex < txtsearch.Items.Count - 1)
                {
                    txtsearchB.SelectedIndex++;
                }
            }
        }
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;
            ItemsDiscount item = (ItemsDiscount)comboBox.Items[e.Index];

            // Set the desired display format (only displaying the Name)
            string displayText = item.Name.Length <= 44 ? item.Name : item.Name.Substring(0, 41) + "...";


            // Draw the item (Name)
            e.DrawBackground();

            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(displayText, e.Font, brush, e.Bounds);
            }

            e.DrawFocusRectangle();

            // Draw the Price separately in red
            using (Brush brush = new SolidBrush(Color.Red))
            {
                string priceText = $"{item.TotalPrice:C}";

                // Calculate the position for the Price
                float x = e.Bounds.Right - e.Graphics.MeasureString(priceText, e.Font).Width - 5;
                float y = e.Bounds.Top + (e.Bounds.Height - e.Graphics.MeasureString(priceText, e.Font).Height) / 2;

                e.Graphics.DrawString(priceText, e.Font, brush, x, y);
            }
        }
        private void FiscalTimer_Tick(object sender, EventArgs e)
        {

            if (Globals.Settings.PosPrinter == "1")
            {
                BeginInvoke(new System.Action(PrintFromSharedPC));

            }
        }
        public void PrintFromSharedPC()
        {
            var global = Services.Settings.Get();
            var printer = Printer.Get().Find(p => p.Id == Globals.DeviceId);
            if (printer.ToPrint == 1)
            {
                var noPrinterPos = Printer.Get().Where(p => p.IsShared == "1" && p.PosId == Globals.Station.Id);
                var sales = Sale.getAllSalesPrintedSd(Globals.Station.Id.ToString());
                var withBank = 0;
                var clientPayed = 0m;

                List<Services.SaleDetails> sd = new List<Services.SaleDetails>();

                foreach (var item in sales)
                {
                    foreach (var items in Services.SaleDetails.GetSdById(item.Id).Where(p => p.Printed == 0))
                    {
                        sd.Add(items);
                    }
                    if (sd.Count > 0)
                    {
                        var table = SaleDtoDataTables(sd);


                        if (printer.DatecsType == "FP-700")
                        {
                            clientPayed = Payment.GetBySaleId(item.Id).First().ClientCash;
                            FiscalPrinterHelper.GekosPrint(item.Id, item.InvoiceNo, table, mTotalSum, item.SaleId, withBank, clientPayed);
                            Services.SaleDetails.UpdatePrinted(item.Id);

                        }
                        else
                        {
                            clientPayed = Payment.GetBySaleId(item.Id).First().ClientCash;

                            FiscalPrinterHelper.GekosPrintOldV(item.Id, item.InvoiceNo, table, mTotalSum, item.SaleId, withBank, clientPayed);
                            Services.SaleDetails.UpdatePrinted(item.Id);

                        }


                    }

                }
            }

        }
        public static DataTable SaleDtoDataTables(List<Services.SaleDetails> saleDetail)
        {
            DataTable dt = new DataTable();
            DataColumn c = new DataColumn("Id");
            DataColumn c1 = new DataColumn("SaleId");
            DataColumn c2 = new DataColumn("ItemId");
            DataColumn c8 = new DataColumn("ItemName");
            DataColumn c3 = new DataColumn("Quantity");
            DataColumn c10 = new DataColumn("Discount");
            DataColumn c4 = new DataColumn("Price");
            DataColumn c5 = new DataColumn("VAT");
            DataColumn c6 = new DataColumn("VATSum");
            DataColumn c7 = new DataColumn("Printed");
            DataColumn c9 = new DataColumn("ClientDiscount");
            DataColumn c11 = new DataColumn("PrintedQuantity");
            DataColumn c12 = new DataColumn("ForReturn");

            dt.Columns.Add(c); dt.Columns.Add(c1); dt.Columns.Add(c2); dt.Columns.Add(c3); dt.Columns.Add(c8); dt.Columns.Add(c4);
            dt.Columns.Add(c5); dt.Columns.Add(c6); dt.Columns.Add(c7); dt.Columns.Add(c10); dt.Columns.Add(c9); dt.Columns.Add(c11); dt.Columns.Add(c12);

            foreach (var saleDetails in saleDetail)
            {
                DataRow r = dt.NewRow();
                var allitems = Services.Item.GetById(saleDetails.ItemId).First();
                string itemname = allitems.ItemName;
                r["Id"] = saleDetails.Id;
                r["SaleId"] = saleDetails.SaleId;
                r["ItemId"] = saleDetails.ItemId;
                r["ItemName"] = itemname;
                r["Quantity"] = saleDetails.Quantity;
                r["Price"] = saleDetails.Price;
                r["Discount"] = saleDetails.Discount;
                r["VAT"] = saleDetails.VAT;
                r["VATSum"] = saleDetails.VatSum;
                r["Printed"] = saleDetails.Printed;
                r["ClientDiscount"] = saleDetails.ClientDiscount;
                r["PrintedQuantity"] = saleDetails.PrintedQuantity;
                r["ForReturn"] = saleDetails.ForReturn;

                dt.Rows.Add(r);
            }

            return dt;
        }
        private void btn_bonusCard_Click(object sender, EventArgs e)
        {
            BonusCardForm bonusCard = new BonusCardForm();
            bonusCard.ShowDialog();
            bonuscard = bonusCard.BonusCard;

            if (ug.Rows.Count > 0)
            {
                if (bonuscard != null && bonusCard.isClicked == true)
                {
                    if (bonuscard.Type == "Pikë")
                    {
                        var total = mTotalSum + bonuscardValue;
                        decimal totalDiscount = 0.0m;
                        if (total >= bonuscard.CurrentPointsValue)
                        {
                            totalDiscount = ((total - (total - bonuscard.CurrentPointsValue)) / total) * 100;

                            foreach (DataGridViewRow row in ug.Rows)
                            {
                                row.Cells["Discount"].Value = Math.Round(totalDiscount, 2);
                                SimulateCellEndEdit(row.Index, 12);

                            }
                            bonuscardValue = bonuscard.CurrentPointsValue;
                        }
                        else
                        {
                            totalDiscount = 100m;

                            bonuscardValue = Math.Round(mTotalSum, 2);

                            foreach (DataGridViewRow row in ug.Rows)
                            {
                                row.Cells["Discount"].Value = Math.Round(totalDiscount, 2);
                                SimulateCellEndEdit(row.Index, 12);

                            }

                        }


                    }
                    else
                    {
                        foreach (DataGridViewRow row in ug.Rows)
                        {
                            row.Cells[12].Value = bonuscard.Discount;
                            SimulateCellEndEdit(row.Index, 12);

                        }
                    }
                }
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            DiscountTotalAmount discountTotalAmount = new DiscountTotalAmount();
            discountTotalAmount.ShowDialog();
            var total = (mTotalSum);
            var totalDiscount = ((total - (total - DiscountTotalAmount.TotalPercentage)) / total) * 100;

            foreach (DataGridViewRow row in ug.Rows)
            {
                row.Cells["Discount"].Value = Math.Round(totalDiscount, 2);
                SimulateCellEndEdit(row.Index, 12);

            }
        }
        public void PrintDataGridView(object sender, PrintPageEventArgs e)
        {
            var settings = Services.Settings.Get();
            var printer = Services.Printer.Get().Find(p => p.Id == Globals.DeviceId);


            float total_width = Convert.ToInt32(printer.TermalPaperWidth) + 110f;

            Font headingFont = new Font("Calibri", total_width / 14f, FontStyle.Bold);
            Font boldFont = new Font("Calibri", total_width / 23f, FontStyle.Bold);
            Font normalFont = new Font("Calibri", total_width / 23f, FontStyle.Regular);

            float topMargin = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;

            string receipt_no = daily.DailyFiscalCount.ToString();
            string receipt_date = DateTime.Now.ToString();
            decimal net_total = 0;
            string company = Globals.Settings.CompanyName;
            string line = "--------------------------------------------------------------------------------";
            float height = 5;
            // float printerWidth;
            // float printerHight;


            float company_name = 2f;
            float company_address = 2.5f;
            float receipt_number = 19f;
            float rec_date = 1.08f;
            float rec_desc = 19f;

            float rec_qty = 1.6f;
            float rec_price = 1.1f;
            float rec_total = 0.85f;




            //Print Company Name
            e.Graphics.DrawString("ORDER BILL", headingFont, Brushes.Black, total_width / company_name, height, new StringFormat());
            height += 30;
            //Print Company Address
            e.Graphics.DrawString(company, normalFont, Brushes.Black, total_width / company_address, height, new StringFormat());
            height += 40;

            //Print Receipt No
            e.Graphics.DrawString("Receipt No :\n " + receipt_no, boldFont, Brushes.Black, total_width / receipt_number, height, new StringFormat());
            //Print Receipt Date
            e.Graphics.DrawString("Date :\n " + receipt_date, boldFont, Brushes.Black, total_width / rec_date, height, new StringFormat());
            height += 40;

            //Print Line
            e.Graphics.DrawString(line, normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20;

            //Printe Table Headings

            e.Graphics.DrawString("Qty", normalFont, Brushes.Black, total_width / rec_qty, height, new StringFormat());
            e.Graphics.DrawString("Çmimi", normalFont, Brushes.Black, total_width / rec_total, height, new StringFormat());
            height += 20;

            //Print Line
            e.Graphics.DrawString(line, normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20;

            foreach (DataGridViewRow row in ug.Rows)
            {
                var iName = row.Cells["ItemName"].Value.ToString().Count() > 40 ? row.Cells["ItemName"].Value.ToString().Substring(0, 20) : row.Cells["ItemName"].Value.ToString();

                var words = iName.Split(' ');
                var lines = new List<string>();
                var currentLine = new StringBuilder();
                foreach (var word in words)
                {
                    if (currentLine.Length + word.Length + 1 > 20)
                    {
                        lines.Add(currentLine.ToString());
                        currentLine.Clear();
                    }
                    currentLine.Append(word + " ");
                }
                if (currentLine.Length > 0)
                {
                    lines.Add(currentLine.ToString());
                }
                iName = string.Join("\n", lines);

                SizeF qtyWidth = e.Graphics.MeasureString(row.Cells["Quantity"].Value.ToString(), normalFont);
                SizeF priceWidth = e.Graphics.MeasureString(row.Cells["Total"].Value.ToString(), normalFont);
                SizeF totalWidth = e.Graphics.MeasureString(row.Cells["TotalWithVat"].Value.ToString(), normalFont);

                e.Graphics.DrawString(iName, normalFont, Brushes.Black, total_width / receipt_number, height, new StringFormat());

                e.Graphics.DrawString(row.Cells["Quantity"].Value.ToString(), normalFont, Brushes.Black, total_width / rec_qty, height, new StringFormat());
                e.Graphics.DrawString(row.Cells["TotalWithVat"].Value.ToString(), normalFont, Brushes.Black, total_width / rec_total, height, new StringFormat());
                net_total += Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                height += 30 + (lines.Count * 10);
            }
            //Print Line
            e.Graphics.DrawString(line, normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20;

            //Print Net Total
            e.Graphics.DrawString("Total", normalFont, Brushes.Black, total_width, height, new StringFormat());

            SizeF netWidth = e.Graphics.MeasureString(net_total.ToString(), normalFont);
            e.Graphics.DrawString(Math.Round(net_total, 2).ToString(), normalFont, Brushes.Black, total_width / rec_total, height, new StringFormat());
            height += 20;

            //Print Line
            e.Graphics.DrawString(line, normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 40;

            e.Graphics.DrawString("Thank You", headingFont, Brushes.Black, total_width / company_name, height, new StringFormat());

            e.HasMorePages = false;
        }
        public void PrintRestaurantDataGridView(object sender, PrintPageEventArgs e)
        {
            var settings = Services.Settings.Get();
            var printer = Services.Printer.Get().Find(p => p.Id == Globals.DeviceId);


            float total_width = settings.PosPrinter == "0" ? Convert.ToInt32(settings.ThermalPrinterPageWidth) + 110f : Convert.ToInt32(printer.TermalPaperWidth) + 110f;

            Font headingFont = new Font("Calibri", total_width / 14f, FontStyle.Bold);
            Font boldFont = new Font("Calibri", total_width / 23f, FontStyle.Bold);
            Font normalFont = new Font("Calibri", total_width / 23f, FontStyle.Regular);

            float topMargin = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;

            string receipt_no = daily.DailyFiscalCount.ToString();
            string receipt_date = DateTime.Now.ToString();
            decimal net_total = 0;
            string company = Globals.Settings.CompanyName;
            string line = "--------------------------------------------------------------------------------";
            float height = 5;
            // float printerWidth;
            // float printerHight;


            float company_name = 2f;
            float company_address = 2.5f;
            float receipt_number = 19f;
            float rec_date = 1.08f;
            float rec_desc = 19f;

            float rec_qty = 1.6f;
            float rec_price = 1.1f;
            float rec_total = 0.85f;




            //Print Company Name
            e.Graphics.DrawString("ORDER BILL", headingFont, Brushes.Black, total_width / company_name, height, new StringFormat());
            height += 30;
            //Print Company Address
            e.Graphics.DrawString(company, normalFont, Brushes.Black, total_width / company_address, height, new StringFormat());
            height += 40;

            //Print Receipt No
            e.Graphics.DrawString("Receipt No :\n " + receipt_no, boldFont, Brushes.Black, total_width / receipt_number, height, new StringFormat());
            //Print Receipt Date
            e.Graphics.DrawString("Date :\n " + receipt_date, boldFont, Brushes.Black, total_width / rec_date, height, new StringFormat());
            height += 40;

            //Print Line
            e.Graphics.DrawString(line, normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20;

            //Printe Table Headings

            e.Graphics.DrawString("Qty", normalFont, Brushes.Black, total_width / rec_qty, height, new StringFormat());
            e.Graphics.DrawString("Çmimi", normalFont, Brushes.Black, total_width / rec_total, height, new StringFormat());
            height += 20;

            //Print Line
            e.Graphics.DrawString(line, normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20;

            var orderDetails = Services.Models.TablesSaleDetails.GetSaleDetailsBySaleId(Convert.ToInt32(tableId));

            foreach (DataGridViewRow row in ug.Rows)
            {
                var currentItem = orderDetails.Where(p => p.ItemId == (int)row.Cells["ItemId"].Value);

                if ((int)row.Cells["Printed"].Value == 0)
                {

                    var iName = row.Cells["ItemName"].Value.ToString().Count() > 40 ? row.Cells["ItemName"].Value.ToString().Substring(0, 20) : row.Cells["ItemName"].Value.ToString();

                    var words = iName.Split(' ');
                    var lines = new List<string>();
                    var currentLine = new StringBuilder();
                    foreach (var word in words)
                    {
                        if (currentLine.Length + word.Length + 1 > 20)
                        {
                            lines.Add(currentLine.ToString());
                            currentLine.Clear();
                        }
                        currentLine.Append(word + " ");
                    }
                    if (currentLine.Length > 0)
                    {
                        lines.Add(currentLine.ToString());
                    }
                    iName = string.Join("\n", lines);

                    SizeF qtyWidth = e.Graphics.MeasureString(row.Cells["Quantity"].Value.ToString(), normalFont);
                    SizeF priceWidth = e.Graphics.MeasureString(row.Cells["Total"].Value.ToString(), normalFont);
                    SizeF totalWidth = e.Graphics.MeasureString(row.Cells["TotalWithVat"].Value.ToString(), normalFont);

                    e.Graphics.DrawString(iName, normalFont, Brushes.Black, total_width / receipt_number, height, new StringFormat());


                    if (currentItem.First().PrintedQuantity == 0)
                    {
                        e.Graphics.DrawString(((decimal)row.Cells["Quantity"].Value).ToString(), normalFont, Brushes.Black, total_width / rec_qty, height, new StringFormat());
                        e.Graphics.DrawString(((decimal)row.Cells["TotalWithVat"].Value).ToString(), normalFont, Brushes.Black, total_width / rec_total, height, new StringFormat());
                    }
                    else
                    {
                        e.Graphics.DrawString(((decimal)row.Cells["Quantity"].Value - currentItem.First().PrintedQuantity).ToString(), normalFont, Brushes.Black, total_width / rec_qty, height, new StringFormat());
                        e.Graphics.DrawString(((decimal)row.Cells["TotalWithVat"].Value - currentItem.First().TotalWithVat).ToString(), normalFont, Brushes.Black, total_width / rec_total, height, new StringFormat());
                    }


                    net_total += (decimal)row.Cells["TotalWithVat"].Value;
                    height += 30 + (lines.Count * 10);


                }
                else
                {
                    if ((decimal)row.Cells["Quantity"].Value - currentItem.First().PrintedQuantity > 0)
                    {
                        var iName = row.Cells["ItemName"].Value.ToString().Count() > 40 ? row.Cells["ItemName"].Value.ToString().Substring(0, 20) : row.Cells["ItemName"].Value.ToString();

                        var words = iName.Split(' ');
                        var lines = new List<string>();
                        var currentLine = new StringBuilder();
                        foreach (var word in words)
                        {
                            if (currentLine.Length + word.Length + 1 > 20)
                            {
                                lines.Add(currentLine.ToString());
                                currentLine.Clear();
                            }
                            currentLine.Append(word + " ");
                        }
                        if (currentLine.Length > 0)
                        {
                            lines.Add(currentLine.ToString());
                        }
                        iName = string.Join("\n", lines);

                        SizeF qtyWidth = e.Graphics.MeasureString(row.Cells["Quantity"].Value.ToString(), normalFont);
                        SizeF priceWidth = e.Graphics.MeasureString(row.Cells["Total"].Value.ToString(), normalFont);
                        SizeF totalWidth = e.Graphics.MeasureString(row.Cells["TotalWithVat"].Value.ToString(), normalFont);

                        e.Graphics.DrawString(iName, normalFont, Brushes.Black, total_width / receipt_number, height, new StringFormat());
                        string tot = "";
                        if (currentItem.Count() > 0)
                        {

                            tot = ((decimal)row.Cells["TotalWithVat"].Value - (((decimal)row.Cells["Quantity"].Value - currentItem.First().PrintedQuantity) * currentItem.First().DiscountPriceWithVat)).ToString();
                            e.Graphics.DrawString(((decimal)row.Cells["Quantity"].Value - currentItem.First().PrintedQuantity).ToString(), normalFont, Brushes.Black, total_width / rec_qty, height, new StringFormat());
                            e.Graphics.DrawString(tot, normalFont, Brushes.Black, total_width / rec_total, height, new StringFormat());
                        }
                        else
                        {
                            e.Graphics.DrawString(((decimal)row.Cells["Quantity"].Value).ToString(), normalFont, Brushes.Black, total_width / rec_qty, height, new StringFormat());
                            e.Graphics.DrawString(((decimal)row.Cells["TotalWithVat"].Value).ToString(), normalFont, Brushes.Black, total_width / rec_total, height, new StringFormat());
                        }


                        net_total += (((decimal)row.Cells["Quantity"].Value - currentItem.First().PrintedQuantity) * currentItem.First().DiscountPriceWithVat);
                        height += 30 + (lines.Count * 10);

                    }

                }

                Services.Models.TablesSaleDetails.UpdateTableQuantityPrinted((decimal)row.Cells["Quantity"].Value, tableId, (int)row.Cells["ItemId"].Value);
                TablesSaleDetails tabledt = new TablesSaleDetails();
                tabledt.UpdateTableItem((decimal)row.Cells["Quantity"].Value, (decimal)row.Cells["Total"].Value, (decimal)row.Cells["TotalWithVat"].Value, row.Cells["ItemName"].Value.ToString());

            }
            //Print Line
            e.Graphics.DrawString(line, normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 20;

            //Print Net Total
            e.Graphics.DrawString("Total", normalFont, Brushes.Black, total_width, height, new StringFormat());

            SizeF netWidth = e.Graphics.MeasureString(net_total.ToString(), normalFont);
            e.Graphics.DrawString(Math.Round(net_total, 2).ToString(), normalFont, Brushes.Black, total_width / rec_total, height, new StringFormat());
            height += 20;

            //Print Line
            e.Graphics.DrawString(line, normalFont, Brushes.Black, 0, height, new StringFormat());
            height += 40;

            e.Graphics.DrawString("Thank You", headingFont, Brushes.Black, total_width / company_name, height, new StringFormat());

            e.HasMorePages = false;
        }

        private void SavePayment()
        {
            List<Services.Payment> payments = new List<Services.Payment>();

            if (mPaymentDialog.TotalCash > 0)
            {
                //add payment cash
                Services.Payment pmt = new Services.Payment();
                pmt.AmountPaid = mPaymentDialog.TotalCash;

                payments.Add(pmt);
            }

            if (mPaymentDialog.numPos1.Text != "")
            {
                if (mPaymentDialog.BankPos1 != 0 && Convert.ToDecimal(mPaymentDialog.numPos1.Text) != 0.0M)
                {
                    //add pos payment 1
                    Services.Payment posP1 = new Services.Payment();
                    posP1.BankId = mPaymentDialog.BankPos1;
                    posP1.AmountPaid = Convert.ToDecimal(mPaymentDialog.numPos1.Text);
                    payments.Add(posP1);
                }
            }

            //if (mPaymentDialog.BankPos2 != 0 && Convert.ToDecimal(mPaymentDialog.numPos2.Text) != 0.0M)
            //{
            //    //add pos payment 2
            //    Services.Payment posP2 = new Services.Payment();
            //    posP2.BankId = mPaymentDialog.BankPos2;
            //    posP2.AmountPaid = Convert.ToDecimal(mPaymentDialog.numPos2.Text);
            //    payments.Add(posP2);
            //}

            //if (mPaymentDialog.BankPos3 != 0 && Convert.ToDecimal(mPaymentDialog.numPos3.Text) != 0.0M)
            //{
            //    //add pos payment 3
            //    Services.Payment posP3 = new Services.Payment();
            //    posP3.BankId = mPaymentDialog.BankPos3;
            //    posP3.AmountPaid = Convert.ToDecimal(mPaymentDialog.numPos3.Text);
            //    payments.Add(posP3);
            //}

            //if (mPaymentDialog.BankPos4 != 0 && Convert.ToDecimal(mPaymentDialog.numPos4.Text) != 0.0M)
            //{
            //    //add pos payment 4
            //    Services.Payment posP4 = new Services.Payment();
            //    posP4.BankId = mPaymentDialog.BankPos4;
            //    posP4.AmountPaid = Convert.ToDecimal(mPaymentDialog.numPos4.Text);
            //    payments.Add(posP4);
            //}


            List<Payment> pm = new List<Payment>();

            foreach (var payment in payments)
            {
                pm.Add(new Services.Payment
                {
                    SaleId = this.mSaleId,
                    BankId = payment.BankId,
                    AmountPaid = payment.AmountPaid,
                    ClientCash = mPaymentDialog.clientPayed


                });

            }
            Payment.BatchInsert(pm);
        }

        #endregion

        #region Forms

        private void PosSales_Load(object sender, EventArgs e)
        {
            var sett = Services.Settings.Get();

            if (sett.StockRibbon == 0)
            {
                panel2.Visible = false;
            }
            splitContainer2.Visible = false;

            AdjustText();
            var globals = Services.Settings.Get();
            var printers = Services.Printer.Get().Find(p => p.Id == Globals.DeviceId);

            daily = DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(Globals.User.Id);
            txt.Text = "Emri,Çmimi,Shifra";
            txtB.Text = "Emri,Çmimi,Shifra";
            txt.ForeColor = Color.Gray;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            //this.WindowState = FormWindowState.Maximized;
            PrinterConfig printer = new PrinterConfig();

            if (globals.BarcMode == 1)
            {
                splitContainer2.Visible = true;
                splitContainer2.BorderStyle = BorderStyle.Fixed3D;
                txtsearchB.Visible = true;
                txtsearchB.DropDownStyle = ComboBoxStyle.DropDown;
                txtsearchB.Width = splitContainer2.Panel1.Width / 2;
                txtsrchB.Width = splitContainer2.Panel2.Width / 2;
                txtB.Width = splitContainer2.Panel1.Width / 2 - 20;
                txtsearchB.Click += Test_Click;
                tableLayoutPanel11.Visible = false;
                pnlGrids.Location = new System.Drawing.Point(5, 150);
                pnlGrids.Size = new Size(this.Width, this.Height - 380);

                tableLayoutPanel2.SetColumnSpan(this.pnlGrids, 2);

                tableLayoutPanel3.RowStyles[2].SizeType = SizeType.Percent;
                tableLayoutPanel3.RowStyles[2].Height = 49;

            }



            if (printers.PrintTermal == null && globals.PosPrinter == "1")
            {
                printer.ShowDialog();
            }


            string version = UpdateModule.GetVersion();

            word_user.Text = Globals.User.Name + " - F5";
            //word_no_order.Text = word_no_order.Text;
            word_station_branch.Text = "Njesia: " + sett.CompanyName;
            word_station_branch.Left = (pnlMenu.Width - word_station_branch.Width) / 2;
            word_station_branch.Top = (pnlMenu.Height - word_station_branch.Height) / 2;

            this.Text = "Planet POS Version: " + version;

            lblFiscalCount.Text = Services.Tables.GetTables().Where(p => p.Id == Convert.ToInt32(tableId)).First().FiscalCount > 0 ? Services.Tables.GetTables().Where(p => p.Id == Convert.ToInt32(tableId)).First().FiscalCount.ToString() : Services.Tables.GetLastFiscalCount().First().FiscalCount > 0 ? (Services.Tables.GetLastFiscalCount().First().FiscalCount + 1).ToString() : /*daily.DailyFiscalCount.ToString()*/"1";

            Services.Tables.UpdateTableFiscalCount(lblFiscalCount.Text, tableId);


            txtShortcuts.Text = "F2 - Sasia , F3 - Çmimi , F6 - Detajet e Artikujve,  F9 - Konverto , F11 - FullScreen";
            pnlDrinks.Visible = false;

            LoadData();
            LoadActions();
            LoadCategory();

            aksionet = Services.Action.Get();

            if (sett.DefaultClientId != 0)
            {
                var clients = Partner.GetSid(sett.DefaultClientId);
                if (clients != null)
                {
                    var partner = Services.Partner.Search("Status=0");
                    cbPartners.Text = "";
                    cbPartners.DataSource = partner;
                    cbPartners.Text = clients.Name;
                    cbPartners.SelectedItem = partner.Where(p => p.Id == clients.Id);
                    PartnerId = clients.Id;
                }
            }
            else
            {
                var clients = Partner.Search(" ").FirstOrDefault();

                if (clients != null)
                {
                    var partner = Services.Partner.Search("Status=0");
                    cbPartners.Text = "";
                    cbPartners.DataSource = partner;
                    cbPartners.Text = clients.Name;
                    cbPartners.SelectedItem = partner.Where(p => p.Id == clients.Id);
                    PartnerId = clients.Id;
                }

            }




            //if (sett.PagDirekte == 0)
            //{
            //    btn_DirectPay.Visible = false;
            //}
            //else
            //{
            //    btn_DirectPay.Visible = true;
            //}
            if (ug.Columns.Contains(" ") == false)
            {
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Name = " ";
                col.FillWeight = 30;
                col.FlatStyle = FlatStyle.Flat;
                ug.Columns.Add(col);
            }
            if (ug.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in ug.Rows)
                {
                    mTotalSum += (decimal)item.Cells["TotalWithVat"].Value;
                    mTotalSumWVat += (Convert.ToDecimal(item.Cells["Total"].Value) * (1 - Convert.ToDecimal(item.Cells["Discount"].Value) / 100)) * Convert.ToDecimal(item.Cells["Quantity"].Value);

                }
                txtTotalSum.Text = mTotalSum.ToString("N");
                txtTotalWVatSum.Text = mTotalSumWVat.ToString("N");
            }

        }

        private void Test_Click(object sender, EventArgs e)
        {
            ClickAll();
            CallCellEndEditForColumn12();
        }
        private void CallCellEndEditForColumn12()
        {
            List<Services.Payment> payments = new List<Services.Payment>();

            Random random = new Random();
            decimal cashPayment = (decimal)(Convert.ToDouble(mTotalSum) - (random.NextDouble()));

            //// Create the cash payment object
            Services.Payment pmt = new Services.Payment();
            pmt.AmountPaid = Math.Round(cashPayment, 2);
            payments.Add(pmt);

            //// Calculate the remaining amount for the bank payment
            decimal remainingAmountForBank = mTotalSum - Math.Round(cashPayment, 2);

            int columnIndex = 12; // Adjust this to match the index of the 12th column
            foreach (DataGridViewRow row in ug.Rows)
            {

                // The cell in the 12th column of this row is being edited
                SimulateCellEndEdit(row.Index, columnIndex);

            }
            Services.Sale sale = Services.Sale.Get(mSaleId);

            if (sale == null)
                sale = new Services.Sale();

            if (cbPartners.SelectedItem != null)
            {
                sale.PartnerId = (int)cbPartners.SelectedValue;
            }
            else
                sale.PartnerId = Globals.Settings.DefaultClientId;
            //DateTime currentDate = DateTime.Now.ToLocalTime();
            //DateTime saleDate = new DateTime(currentDate.Year, 9, 7, 0, 0, 0);

            //// Add 2 hours to the `sale.Date`
            //saleDate = saleDate.AddHours(2);
            //sale.Date = saleDate;
            sale.Date = DateTime.Now.ToLocalTime().AddHours(2);

            // Assign the `sale.Date` to your `sale` object

            sale.PosId = Globals.Station.Id;
            sale.StationId = Globals.ParentStationId;
            var totals = 0.0m;

            //foreach (DataGridViewRow item in ug.Rows)
            //{
            //    if (Convert.ToInt32(item.Cells["ForReturn"].Value) == 0)
            //    {
            //        totals += Convert.ToDecimal(item.Cells["TotalWithVat"].Value);
            //    }
            //}

            sale.TotalSum = Math.Round(mTotalSum, 2);
            sale.VatSum = mVatSum;

            sale.Comment = "";

            int result = 0;

            if (mSaleId == 0)
            {
                //tipi i shitjes me POS kupon
                sale.SalesTypeId = 1;
                sale.CreatedAt = DateTime.Now.ToLocalTime().AddHours(2);
                sale.CreatedBy = Globals.User.Name;
                sale.Status = -1;
                sale.id_saler = Globals.User.Id;

                sale.SaleId = Sale.getAllSales().Count > 0 ? Sale.getAllSales().Last().SaleId + 1 : Globals.Station.LastInvoiceNumber + 1;

                //while (result == 0)
                //{
                sale.InvoiceNo = Globals.Station.Id + "-" + sale.SaleId;

                //result = sale.Insert();
                //sale.SaleId++;

                //}


                //StationService.UpdateLastInvoiceNumber(sale.SaleId, Globals.Station.Id);

                //Services.Sale.IdSaler(sale.Id, Globals.User.Id);

                Globals.Station.LastInvoiceNumber++;
                DailyOpenFiscalCount += 1;
                var daily = new DailyOpenCloseBalance();
                var lastdaily = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(Globals.User.Id);
                totalSumOpenBalance = sale.TotalSum + lastdaily.TotalShitje;
                var totalcash = 0.0m;

                totalcash += lastdaily.TotalCash + cashPayment;

                var totalcredit = remainingAmountForBank + lastdaily.TotalCreditCard;



                OverallObj overallObj = new OverallObj
                {
                    sale = sale,
                    LastInvoiceNumber = sale.SaleId,
                    stationId = Globals.Station.Id,
                    id_saler = Globals.User.Id,
                    saleId = sale.SaleId,
                    dailyId = lastdaily.Id,
                    DailyFiscalCount = DailyOpenFiscalCount,
                    TotalShitje = totalSumOpenBalance,
                    TotalCash = totalcash,
                    TotalCreditCard = totalcredit,
                    status = sale.Status.ToString()
                };
                result = overallObj.UpdateA();
                if (result > 0)
                    mSaleId = overallObj.Id;
                else
                {
                    MessageBox.Show("Fatura nuk munde te ruhet! Ju lutem kontaktoni administratorin!");
                    mSaleId = -1;
                }
                //save sales details
                int rows = SaveSaleDetails(mSaleId);




                // Create the bank payment object
                Services.Payment posP1 = new Services.Payment();
                posP1.BankId = 1; // Replace with your bank ID
                posP1.AmountPaid = remainingAmountForBank;
                payments.Add(posP1);
                List<Payment> pm = new List<Payment>();

                foreach (var payment in payments)
                {
                    pm.Add(new Services.Payment
                    {
                        SaleId = this.mSaleId,
                        BankId = payment.BankId,
                        AmountPaid = payment.AmountPaid
                    });

                }
                Payment.BatchInsert(pm);
                PrintF();
                //change sale status . Now sale is ready for sync
                Services.Sale.ChngStatus(mSaleId, 0);

                ClearFields();

            }
        }
        private void SimulateCellEndEdit(int rowIndex, int columnIndex)
        {
            DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(columnIndex, rowIndex);
            ug_CellEndEdit(ug, e);
        }
        private void AdjustText()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width;

            if (Screen.PrimaryScreen.WorkingArea.Width == 1920f)
            {
                word_discount.Font = new Font("Lato", 22, FontStyle.Regular);
                word_totalwithoutVat.Font = new Font("Lato", 22, FontStyle.Regular);
                word_total.Font = new Font("Lato", 36, FontStyle.Bold);
                txtDiscount.Font = new Font("Lato", 22, FontStyle.Regular);
                txtTotalWVatSum.Font = new Font("Lato", 22, FontStyle.Regular);
                txtTotalSum.Font = new Font("Lato", 36, FontStyle.Bold);
                percSymb.Font = new Font("Lato", 22, FontStyle.Regular);
                eursymb.Font = new Font("Lato", 22, FontStyle.Regular);
                eurSymbol.Font = new Font("Lato", 36, FontStyle.Bold);
                word_cancel_order.Font = new Font("Lato", 9, FontStyle.Regular);
                word_print_the_coupon.Font = new Font("Lato", 9, FontStyle.Regular);
                //btn_DirectPay.Font = new Font("Lato", 22, FontStyle.Regular);
                txtShortcuts.Font = new Font("Lato", 8, FontStyle.Regular);
                CbSize = new Size(100, 50); subCbSize = new Size(90, 40);
                bTextSize = new Font("Arial", 9, FontStyle.Regular);
                catButtonL = 10;
            }
            if (x >= 1400 && x <= 1680)
            {
                word_discount.Font = new Font("Lato", 20, FontStyle.Regular);
                word_totalwithoutVat.Font = new Font("Lato", 20, FontStyle.Regular);
                word_total.Font = new Font("Lato", 28, FontStyle.Bold);
                txtDiscount.Font = new Font("Lato", 20, FontStyle.Regular);
                txtTotalWVatSum.Font = new Font("Lato", 20, FontStyle.Regular);
                txtTotalSum.Font = new Font("Lato", 28, FontStyle.Bold);
                percSymb.Font = new Font("Lato", 20, FontStyle.Regular);
                eursymb.Font = new Font("Lato", 20, FontStyle.Regular);
                eurSymbol.Font = new Font("Lato", 28, FontStyle.Bold);
                word_cancel_order.Font = new Font("Lato", 16, FontStyle.Regular);
                word_print_the_coupon.Font = new Font("Lato", 16, FontStyle.Regular);
                //btn_DirectPay.Font = new Font("Lato", 16, FontStyle.Regular);
                txtShortcuts.Font = new Font("Lato", 7, FontStyle.Regular);
                bTextSize = new Font("Arial", 8, FontStyle.Regular);

                CbSize = new Size(100, 50); subCbSize = new Size(90, 40);
                catButtonL = 10;

            }
            if (x >= 1280 && x <= 1366)
            {
                word_discount.Font = new Font("Lato", 18, FontStyle.Regular);
                word_totalwithoutVat.Font = new Font("Lato", 18, FontStyle.Regular);
                word_total.Font = new Font("Lato", 26, FontStyle.Bold);
                txtDiscount.Font = new Font("Lato", 18, FontStyle.Regular);
                txtTotalWVatSum.Font = new Font("Lato", 18, FontStyle.Regular);
                txtTotalSum.Font = new Font("Lato", 26, FontStyle.Bold);
                percSymb.Font = new Font("Lato", 18, FontStyle.Regular);
                eursymb.Font = new Font("Lato", 18, FontStyle.Regular);
                eurSymbol.Font = new Font("Lato", 26, FontStyle.Bold);
                word_cancel_order.Font = new Font("Lato", 16, FontStyle.Regular);
                word_print_the_coupon.Font = new Font("Lato", 16, FontStyle.Regular);
                //btn_DirectPay.Font = new Font("Lato", 16, FontStyle.Regular);
                txtShortcuts.Font = new Font("Lato", 7, FontStyle.Regular);
                bTextSize = new Font("Arial", 7, FontStyle.Regular);

                CbSize = new Size(80, 40); subCbSize = new Size(70, 30);
                catButtonL = 0;


            }
            if (x < 1280)
            {
                word_discount.Font = new Font("Lato", 16, FontStyle.Regular);
                word_totalwithoutVat.Font = new Font("Lato", 16, FontStyle.Regular);
                word_total.Font = new Font("Lato", 24, FontStyle.Bold);
                txtDiscount.Font = new Font("Lato", 16, FontStyle.Regular);
                txtTotalWVatSum.Font = new Font("Lato", 16, FontStyle.Regular);
                txtTotalSum.Font = new Font("Lato", 24, FontStyle.Bold);
                percSymb.Font = new Font("Lato", 16, FontStyle.Regular);
                eursymb.Font = new Font("Lato", 16, FontStyle.Regular);
                eurSymbol.Font = new Font("Lato", 24, FontStyle.Bold);
                word_cancel_order.Font = new Font("Lato", 16, FontStyle.Regular);
                word_print_the_coupon.Font = new Font("Lato", 16, FontStyle.Regular);
                //btn_DirectPay.Font = new Font("Lato", 16, FontStyle.Regular);
                txtShortcuts.Font = new Font("Lato", 6, FontStyle.Regular);
                bTextSize = new Font("Arial", 6, FontStyle.Regular);

                CbSize = new Size(80, 40); subCbSize = new Size(70, 30);
                catButtonL = 0;


            }
        }
        private void AdjustTblTotalColumnWidths()
        {
            for (int i = 0; i < tblInfo.ColumnCount; i++)
            {
                int colWidth = 0;

                for (int j = 0; j < tblInfo.RowCount; j++)
                {
                    System.Windows.Forms.Control control = tblInfo.GetControlFromPosition(i, j);
                    if (control != null)
                    {
                        colWidth = Math.Max(control.PreferredSize.Width, colWidth);

                    }
                }

                tblInfo.ColumnStyles[i].Width = colWidth;

                foreach (System.Windows.Forms.Control control in tblInfo.Controls)
                {
                    if (control is System.Windows.Forms.TextBox && control.Name == "txtTotalSum")
                    {
                        int colIndex = tblInfo.GetColumn(control);
                        control.Dock = DockStyle.Fill;
                        control.Width = tblInfo.GetColumnWidths()[colIndex];
                    }
                }
            }
        }

        bool clicked = false;

        private void Pos_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {
                if (ug.Rows.Count > 0)
                {
                    ug.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                    ug.CurrentCell = ug[6, ug.CurrentRow.Index];
                    ug.BeginEdit(true);
                }


            }
            else if (e.KeyCode == Keys.F3)
            {
                if (ug.Columns[12].Visible == true)
                {
                    if (ug.Rows.Count > 0)
                    {
                        ug.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
                        ug.CurrentCell = ug[12, ug.CurrentRow.Index];
                        ug.BeginEdit(true);
                    }
                }

            }
            else if (e.KeyCode == Keys.F4)
            {
                btnSignOut_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnLogedUser_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                ItemDetails itemDetails = new ItemDetails();
                itemDetails.ShowDialog();
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnPrint_Click(sender, e);
            }
            //else if (e.KeyCode == Keys.F8)
            //{
            //    btnDirectPay_Click(sender, e);
            //}
            else if (e.KeyCode == Keys.F9)
            {
                Shitjet_e_Fundit shitjet = new Shitjet_e_Fundit();
                shitjet.ShowDialog();
            }
            else if (e.KeyCode == Keys.F11)
            {
                FormState formState = new FormState();

                if (!clicked)
                {
                    formState.Maximize(this);
                    clicked = true;

                }
                else
                {
                    ReloadForm();
                    clicked = false;

                }

            }
            else if (e.KeyCode == Keys.F12)
            {
                btnCancel_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                Invoice invoice = new Invoice();
                invoice.ShowDialog();
            }

        }

        private void SelectRowDown(KeyEventArgs e)
        {
            if (ug.SelectedRows == null || ug.SelectedRows.Count < 1)
                return;

            int rowindex = ug.SelectedRows[0].Index;

            if (rowindex >= ug.Rows.Count - 1)
            {
                return;
            }

            foreach (DataGridViewRow row1 in ug.SelectedRows)
            {
                row1.Selected = false;
            }

            ug.Rows[rowindex + 1].Selected = true;
        }

        private void SelectRowUp(KeyEventArgs e)
        {
            if (ug.SelectedRows == null || ug.SelectedRows.Count < 1)
                return;

            int rowindex = ug.SelectedRows[0].Index;

            if (rowindex < 1)
            {
                return;
            }

            foreach (DataGridViewRow row1 in ug.SelectedRows)
            {
                row1.Selected = false;
            }

            ug.Rows[rowindex - 1].Selected = true;

        }

        protected string mGetNumericFormat = Globals.GetNumericFormat();

        protected string mCurrencyformat = Globals.GetCurrencyFormat();



        void disableCbPartner()
        {
            cbPartners.Enabled = false;
            inputstate = InputControlState.ShearchItem;
            ChangeInputControlState();
            txtsrch.Focus();
        }

        private void cbCustomers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                disableCbPartner();
                e.Handled = true;
            }
        }

        private void cbCustomers_ValueChanged(object sender, EventArgs e)
        {
            //this.Text = cbPartner.Text;
            LoadItems();
        }



        public void CalculateColums(string columnname)
        {
            try
            {
                //todo: row
                var activerow = ug.Rows[0];

                if (activerow != null)
                {
                    var quantitynowcell = activerow.Cells["QuantityNow"];
                    var totalcell = activerow.Cells["Total"];
                    var totalWithVatcell = activerow.Cells["TotalWithVat"];
                    var discountcell = activerow.Cells["Discount"];
                    var discountpricecell = activerow.Cells["DiscountPrice"];
                    var priceWithVatcell = activerow.Cells["DiscountPriceWithVat"];
                    var pricecell = activerow.Cells["Price"];
                    var vatcell = activerow.Cells["Vat"];
                    var quantitycell = activerow.Cells["Quantity"];
                    var vatsumcell = activerow.Cells["VatSum"];

                    decimal discount = 0.0M, discountprice = 0.0M, discountpriceWithVat = 0.0M, price = 0.0M, vat = 0.0M, quantity = 0.0M, quantitynow = 0.0M, vatsum = 0.0M, total = 0.0M, totalWithVat = 0.0M;

                    if (quantitynowcell.Value.ToString() != "")
                        quantitynow = decimal.Parse(quantitynowcell.Value.ToString());
                    //if (packagecell.Value.ToString() != "")
                    //    package = decimal.Parse(packagecell.Value.ToString());
                    if (totalcell.Value.ToString() != "")
                        total = decimal.Parse(totalcell.Value.ToString());

                    if (totalWithVatcell.Value.ToString() != "")
                        totalWithVat = decimal.Parse(totalWithVatcell.Value.ToString());

                    if (vatsumcell.Value.ToString() != "")
                        vatsum = decimal.Parse(vatsumcell.Value.ToString());

                    if (discountcell.Value.ToString() != "")
                        discount = decimal.Parse(discountcell.Value.ToString());

                    if (discountpricecell.Value.ToString() != "")
                        discountprice = decimal.Parse(discountpricecell.Value.ToString());

                    if (priceWithVatcell.Value.ToString() != "")
                        discountpriceWithVat = decimal.Parse(priceWithVatcell.Value.ToString());

                    if (pricecell.Value.ToString() != "")
                        price = decimal.Parse(pricecell.Value.ToString());

                    if (quantitycell.Value.ToString() != "")
                        quantity = decimal.Parse(quantitycell.Value.ToString());

                    if (vatcell.Value.ToString() != "")
                        vat = decimal.Parse(vatcell.Value.ToString());
                    //decimal discount = discountprice;
                    switch (columnname)
                    {
                        case "Vat":
                            {
                                discountpriceWithVat = discountprice * (1 + vat / 100);
                            }
                            break;
                        case "Price":
                            {
                                discountprice = price * (1 - discount / 100);
                                discountpriceWithVat = discountprice * (1 + vat / 100);
                            }; break;
                        case "DiscountPrice":
                            //if(discount != 100)
                            {
                                price = discountprice / (1 - discount / 100);
                                discountpriceWithVat = discountprice * (1 + vat / 100);
                            }; break;
                        case "Discount":
                            {
                                discountprice = price * (1 - discount / 100);
                                discountpriceWithVat = discountprice * (1 + vat / 100);
                            }; break;
                        case "DiscountPriceWithVat":
                            //if(discount != 100)
                            {
                                discountprice = discountpriceWithVat / (1 + vat / 100);
                                price = discountprice / (1 - discount / 100);

                            }; break;
                        default: break;
                    }

                    total = quantity * discountprice;
                    vatsum = quantity * discountprice * (vat / 100);
                    totalWithVat = quantity * discountprice + (1 + vat / 100);

                    pricecell.Value = price;
                    quantitycell.Value = quantity;
                    discountcell.Value = discount;
                    discountpricecell.Value = discountprice;
                    priceWithVatcell.Value = discountpriceWithVat;
                    totalcell.Value = total;
                    //totalWithVatcell.Value = totalWithVat;
                    vatcell.Value = vat;
                    vatsumcell.Value = vatsum;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(word_error.Text + ":" + ex.Message, word_error.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Error error = new Error();
                error.File = ex.StackTrace.ToString();
                error.Message = ex.Message;
                error.Line = ex.StackTrace.ToString();
                error.Company_Id = Globals.Settings.Id;
                error.Station_Id = Globals.Station.Id;
                error.Insert();
            }
            finally
            {

            }
        }

        private void LoadItemsOfAction(IEnumerable<Services.Models.INamedObj> items)
        {
            if (items == null)
                return;


            pnlDrinks.Controls.Clear();
            pnlDrinks.Visible = true;

            Modules.CreateButtons MakeButtons = new Modules.CreateButtons()
            {
                /*ParentControl = pnlDrinks,*/

                ButtonBaseName = "btnItems_",
                BaseAddition = 110,
                ButtonSize = new Size(150, 50),
                ButtonText = new Font("Arial", 9, FontStyle.Regular),
                ButtonFlat = FlatStyle.Flat,
                ButtonDock = DockStyle.Fill,
                ImageAlignButton = TextImageRelation.TextAboveImage

            };

            MakeButtons.ClickedHandler += button_Clicker;

            MakeButtons.CreateButtonsFromList(items);
            //txtsrch.Focus();
        }

        private void LoadItems()
        {
            if (mItems == null)
                return;



            Modules.CreateButtons MakeButtons = new Modules.CreateButtons()
            {
                ParentControl = pnlItems1,
                ButtonBaseName = "btnItems_",
                BaseAddition = 110,
                ButtonSize = bSize,
                ButtonText = bTextSize,
                ButtonFlat = FlatStyle.Popup,
                ButtonDock = DockStyle.Fill,

            };

            MakeButtons.ClickedHandler += button_Clicker;
            MakeButtons.CreateButtonsFromLists(mItems.Where(p => p.CategoryId > 0));



            AddButtonsBasedOnScreenResolution();
            //txtsrch.Focus();

        }
        private int CalculateButtonSize()
        {
            int buttonSize = pnlItems1.Width / 4;
            return buttonSize;
        }
        private void AddButtonsBasedOnScreenResolution()
        {
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            buttonSize = screenHeight / 9;


            bSize = new Size(buttonSize, buttonSize + buttonSize / 2);
            pnlItems1.Size = new Size(pnlItems.Width, pnlItems.Height);


        }
        private void LoadTeGjitha()
        {
            //pnlDrinks.Controls.Clear();

            var favItems = Services.Item.GetFav(1);

            //var s =favItems.First().SalePrice;
            if (favItems == null)
                return;

            pnlItems1.Size = new Size(pnlItems.Width, pnlItems.Height);


            pnlDrinks.Visible = false;

            Modules.CreateButtons MakeButtons = new Modules.CreateButtons()
            {

                ParentControl = pnlItems1,
                ButtonBaseName = "btnItems_",
                BaseAddition = 110,
                ButtonSize = bSize,
                ButtonText = bTextSize,
                ButtonFlat = FlatStyle.Flat,
                ButtonDock = DockStyle.Fill,

            };

            MakeButtons.ClickedHandler += button_Clicker;
            MakeButtons.CreateButtonsFromLists(favItems);
            txtsrch.Focus();
            //ClickAll();
            //timer2.Enabled = true;
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        private void LoadActions()
        {
            //mActions = Services.Action.Get();

            //CreateButtons MakeButtons = new CreateButtons()
            //{
            //    ParentControl = pnlItems1,
            //    Base = 10,

            //    ButtonBaseName = "btnAction_",
            //    BaseAddition = 110,
            //    ButtonSize = new Size(100, 50),
            //    ButtonText = new Font("Arial", 9, FontStyle.Regular),
            //    ButtonFlat = FlatStyle.Flat,
            //    ButtonDock = DockStyle.Fill,
            //    ButtonColor = Color.FromArgb(75, 95, 113),
            //    TextColor = Color.White,
            //    ImageAlignButton = TextImageRelation.TextAboveImage

            //};

            //MakeButtons.ClickedHandler += buttonAction_Clicker;
            //MakeButtons.CreateButtonsFromList(mActions);

        }

        private void buttonAction_Clicker(object sender, IdentifierButtonEventArgs e)
        {
            var id = e.Identifier;
            var action = mActions.Find(p => p.Id == id);

            //foreach (var item in action.Items)
            //{
            //    if (item.Type == "product")
            //    {
            //        var itemDiscount = mAllItems.Find(p => p.Id == item.Id);
            //        AddItem(itemDiscount);
            //    }
            //    else
            //    {
            //        var itemCat = mAllItems.Where(p => p.CategoryId == item.Id).ToList();
            //        itemCat.ForEach(i => i.Discount = item.Discount);
            //        LoadItemsOfAction(itemCat);
            //    }
            //}
        }

        private void LoadCategory()
        {
            ItemCategory itemCategory = new ItemCategory();
            var items = Services.ItemCategory.Get();

            CreateButtons createButtons = new CreateButtons()
            {
                ParentControl = pnlCategories,
                Base = 10,
                BaseAddition = 110,
                ButtonBaseName = "btn_tegjitha",
                ButtonSize = CbSize,
                ButtonText = new Font("Arial", 9, FontStyle.Regular),
                ButtonAnchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                TextColor = Color.White,
                ImageAlignButton = TextImageRelation.TextAboveImage,
                y = catButtonL,

                //CatId
            };
            createButtons.ClickedHandler += btnTeGjitha_Clicker;
            createButtons.CreateTeGjitha();



            CreateButtons MakeButtons = new CreateButtons()
            {

                ParentControl = pnlCategories,
                Base = 10,


                ButtonBaseName = "btnItems_",
                BaseAddition = 110,
                ButtonSize = CbSize,
                ButtonText = new Font("Arial", 9, FontStyle.Regular),
                ButtonFlat = FlatStyle.Flat,
                ButtonAnchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ButtonColor = Color.FromArgb(52, 58, 64),
                TextColor = Color.White,
                ImageAlignButton = TextImageRelation.TextAboveImage,

            };

            MakeButtons.ClickedHandler += buttonCategory_Clicker;
            MakeButtons.CreateCatfromList(items);

            pnlCategories.Height = CbSize.Height + CbSize.Height / 2;

            //txtsrch.Focus();
        }

        Image trash = Properties.Resources.trash_removebg_preview;
        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 31)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = 23;
                var h = 23;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top - 2 + (e.CellBounds.Height - h) / 2;
                var rect = new System.Drawing.Rectangle(x, y, w, h);
                //using (var brush = new SolidBrush(Color.IndianRed))
                //    e.Graphics.FillRectangle(brush,e.CellBounds.X,e.CellBounds.Y,e.CellBounds.Width,e.CellBounds.Height - 2);
                e.Graphics.DrawImage(trash, rect);
                e.Handled = true;
            }
        }

        private void button_Clicker(object sender, IdentifierButtonEventArgs e)
        {
            try
            {
                var item = Services.Item.GetById(e.Identifier).First();
                var itemAction = Globals.Settings.AllowDiscount == "0" ? aksionet.Find(p => p.item_id == item.Id) : null;
                var categoryAction = Globals.Settings.AllowDiscount == "0" ? aksionet.Find(p => p.category_id == item.CategoryId) : null;

                Services.Models.TablesSaleDetails sd = new Services.Models.TablesSaleDetails();
                bool found = false;
                int searchValue = item.Id;

                if (item.Service == 0)
                {


                    var availableStock = Globals.Settings.StockWMinus == "0" && item.Service != 1 ? Warehouse.GetbyId(item.Id).InStock : -1;



                    decimal shuma = (item.SalePrice * (1 - item.Discount / 100)) * (1 * (decimal)item.Vat / 100.0M);
                    decimal clientDiscount = Partner.Get(PartnerId).Discount;

                    decimal shumatotale = Math.Round(shuma + item.SalePrice, 2);
                    if (Globals.Settings.AllowDiscount == "0" && clientDiscount > 0)
                    {
                        shumatotale = Math.Round(shumatotale - (shumatotale * clientDiscount / 100), 2);

                    }
                    if (ug.Columns.Contains(" ") == false)
                    {
                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.UseColumnTextForButtonValue = true;
                        col.Name = " ";
                        col.FillWeight = 30;
                        col.FlatStyle = FlatStyle.Flat;
                        ug.Columns.Add(col);
                    }




                    //check per aksion me produkt

                    if (itemAction != null && Globals.Settings.AllowDiscount == "0")
                    {
                        if (itemAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {

                                    sd.Discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                    if ((int)row.Cells[1].Value == searchValue)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || Globals.Settings.StockWMinus != "0" && item.Service != 1)
                                        {
                                            decimal discount = sd.Discount / 100;

                                            sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                            decimal quantity = sd.Quantity + 1;
                                            sd.Vat = item.Vat;
                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                            sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;

                                            var totalP = Math.Round((decimal)row.Cells["Price"].Value * sd.Vat / 100 + (decimal)row.Cells["Price"].Value, 2);
                                            decimal totalwithvat = (totalP - (totalP * discount)) * quantity;
                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat - (totalwithvat * clientDiscount / 100), 2);
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {item.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        decimal discount = sd.Discount / 100;

                                                        sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                        decimal quantity = sd.Quantity + 1;
                                                        sd.Vat = item.Vat;
                                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                                        sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;

                                                        var totalP = Math.Round((decimal)row.Cells["Price"].Value * sd.Vat / 100 + (decimal)row.Cells["Price"].Value, 2);
                                                        decimal totalwithvat = (totalP - (totalP * discount)) * quantity;
                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat - (totalwithvat * clientDiscount / 100), 2);
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {item.ItemName}!");
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();
                                    }
                                }
                                if (!found)
                                {
                                    item.Discount = itemAction.discount;
                                    AddItem(item);

                                }

                            }

                            else
                            {
                                item.Discount = itemAction.discount;
                                AddItem(item);
                            }

                        }
                        else
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {

                                    sd.Discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                    if ((int)row.Cells[1].Value == searchValue)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || Globals.Settings.StockWMinus != "0" && item.Service != 1)
                                        {
                                            if (itemAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                            {

                                                decimal discount = (itemAction.discount) / 100;

                                                sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                decimal quantity = sd.Quantity + 1;
                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;

                                                //decimal totalwithvat = (sd.TotalWithVat + (sd.TotalWithVat * discount));
                                                decimal totalwithvat = (shumatotale - (shumatotale * discount)) * quantity;
                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                row.Cells["Discount"].Value = (discount * 100).ToString("N");


                                            }
                                            else
                                            {
                                                if (sd.Discount == 0)
                                                {


                                                    sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                    decimal quantity = sd.Quantity + 1;
                                                    row.Cells["Quantity"].Value = quantity.ToString("N");

                                                    sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                    decimal totalwithvat = shumatotale * quantity;
                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);



                                                }
                                                else
                                                {
                                                    decimal discount = (sd.Discount) / 100;

                                                    sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                    decimal quantity = sd.Quantity + 1;
                                                    row.Cells["Quantity"].Value = quantity.ToString("N");

                                                    sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                    decimal totalwithvat = (shumatotale * quantity) - (shumatotale * quantity) * discount;
                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {item.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        if (itemAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                                        {

                                                            decimal discount = (itemAction.discount) / 100;

                                                            sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                            decimal quantity = sd.Quantity + 1;
                                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                                            sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;

                                                            //decimal totalwithvat = (sd.TotalWithVat + (sd.TotalWithVat * discount));
                                                            decimal totalwithvat = (shumatotale - (shumatotale * discount)) * quantity;
                                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                            row.Cells["Discount"].Value = (discount * 100).ToString("N");


                                                        }
                                                        else
                                                        {
                                                            if (sd.Discount == 0)
                                                            {


                                                                sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                                decimal quantity = sd.Quantity + 1;
                                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                                decimal totalwithvat = shumatotale * quantity;
                                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);



                                                            }
                                                            else
                                                            {
                                                                decimal discount = (sd.Discount) / 100;

                                                                sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                                decimal quantity = sd.Quantity + 1;
                                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                                decimal totalwithvat = (shumatotale * quantity) - (shumatotale * quantity) * discount;
                                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {item.ItemName}!");
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();
                                    }
                                }
                                if (!found)
                                {
                                    AddItem(item);

                                }

                            }

                            else
                                AddItem(item);
                        }



                    }

                    //check per aksion me kategori
                    else if (categoryAction != null && Globals.Settings.AllowDiscount == "0")
                    {
                        if (categoryAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {

                                    sd.Discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                    if ((int)row.Cells[1].Value == searchValue)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || Globals.Settings.StockWMinus != "0" && item.Service != 1)
                                        {

                                            decimal discount = sd.Discount / 100;

                                            sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                            decimal quantity = sd.Quantity + 1;
                                            sd.VatSum = (decimal)item.Vat / 100;
                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                            sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                            var totalP = (decimal)row.Cells[14].Value - ((decimal)row.Cells[14].Value * sd.Discount / 100);
                                            totalP = totalP - (totalP * clientDiscount / 100);
                                            decimal totalwithvat = totalP * quantity;
                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {item.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        decimal discount = sd.Discount / 100;

                                                        sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                        decimal quantity = sd.Quantity + 1;
                                                        sd.VatSum = (decimal)item.Vat / 100;
                                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                                        sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                        var totalP = (decimal)row.Cells[14].Value - ((decimal)row.Cells[14].Value * sd.Discount / 100);
                                                        totalP = totalP - (totalP * clientDiscount / 100);
                                                        decimal totalwithvat = totalP * quantity;
                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {item.ItemName}!");
                                            }
                                        }

                                        found = true;
                                        CalculateGridColumns();
                                    }
                                }
                                if (!found)
                                {
                                    item.Discount = categoryAction.discount;
                                    AddItem(item);

                                }

                            }

                            else
                            {
                                item.Discount = categoryAction.discount;
                                AddItem(item);
                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {

                                    sd.Discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                    if ((int)row.Cells[1].Value == searchValue)
                                    {

                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || Globals.Settings.StockWMinus != "0" && item.Service != 1)
                                        {


                                            if (categoryAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                            {

                                                decimal discount = (sd.Discount + categoryAction.discount) / 100;

                                                sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                decimal quantity = sd.Quantity + 1;
                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                decimal totalwithvat = ((shumatotale * quantity) - (shumatotale * quantity * discount));
                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                row.Cells["Discount"].Value = (discount * 100).ToString("N");


                                            }
                                            else
                                            {
                                                if (sd.Discount == 0)
                                                {


                                                    sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                    decimal quantity = sd.Quantity + 1;
                                                    row.Cells["Quantity"].Value = quantity.ToString("N");

                                                    sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                    decimal totalwithvat = shumatotale * quantity;
                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);



                                                }
                                                else
                                                {
                                                    decimal discount = sd.Discount / 100;

                                                    sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                    decimal quantity = sd.Quantity + 1;
                                                    row.Cells["Quantity"].Value = quantity.ToString("N");

                                                    sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                    decimal totalwithvat = sd.TotalWithVat + (shumatotale - (shumatotale * discount));
                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {item.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {

                                                        if (categoryAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                                        {

                                                            decimal discount = (sd.Discount + categoryAction.discount) / 100;

                                                            sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                            decimal quantity = sd.Quantity + 1;
                                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                                            sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                            decimal totalwithvat = ((shumatotale * quantity) - (shumatotale * quantity * discount));
                                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                            row.Cells["Discount"].Value = (discount * 100).ToString("N");


                                                        }
                                                        else
                                                        {
                                                            if (sd.Discount == 0)
                                                            {


                                                                sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                                decimal quantity = sd.Quantity + 1;
                                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                                decimal totalwithvat = shumatotale * quantity;
                                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);



                                                            }
                                                            else
                                                            {
                                                                decimal discount = sd.Discount / 100;

                                                                sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                                decimal quantity = sd.Quantity + 1;
                                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                                decimal totalwithvat = sd.TotalWithVat + (shumatotale - (shumatotale * discount));
                                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {item.ItemName}!");
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();
                                    }
                                }
                                if (!found)
                                {
                                    AddItem(item);

                                }

                            }

                            else
                                AddItem(item);
                        }

                    }
                    else
                    {

                        if (ug.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in ug.Rows)
                            {


                                sd.Discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                if ((int)row.Cells[1].Value == searchValue)
                                {
                                    if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || Globals.Settings.StockWMinus != "0" && item.Service != 1)
                                    {


                                        if (sd.Discount == 0)
                                        {


                                            sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                            decimal quantity = sd.Quantity + 1;
                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                            sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                            decimal totalwithvat = shumatotale * quantity;
                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                            if (Globals.Settings.StockRibbon == 1 && Globals.Settings.LocationRibbon == 1)
                                            {
                                                lblNameAndQuant.Text = item.Name + " / Sasia e disponueshme: " + Warehouse.GetbyId(e.Identifier).InStock + ((Globals.ItemLocation.Find(p => p.Id == item.Location)?.Name != null) ? " / Lokacioni: " + Globals.ItemLocation.Find(p => p.Id == item.Location).Name : "");
                                            }
                                            else if (Globals.Settings.StockRibbon == 1 && Globals.Settings.LocationRibbon == 0)
                                            {
                                                lblNameAndQuant.Text = item.Name + " / Sasia e disponueshme: " + Warehouse.GetbyId(e.Identifier).InStock;

                                            }
                                            else
                                            {
                                                lblNameAndQuant.Text = ((Globals.ItemLocation.Find(p => p.Id == item.Location)?.Name != null) ? " Lokacioni: " + Globals.ItemLocation.Find(p => p.Id == item.Location).Name : "");

                                            }

                                        }
                                        else
                                        {
                                            decimal discount = sd.Discount / 100;

                                            sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                            decimal quantity = sd.Quantity + 1;
                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                            sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                            decimal totalwithvat = sd.TotalWithVat + (shumatotale - (shumatotale * discount));
                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                        }
                                    }
                                    else
                                    {
                                        if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                        {
                                            if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {item.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                            {
                                                EnterPin enter = new EnterPin();
                                                enter.ShowDialog();
                                                if (enter.flag == true)
                                                {
                                                    if (sd.Discount == 0)
                                                    {


                                                        sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                        decimal quantity = sd.Quantity + 1;
                                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                                        sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                        decimal totalwithvat = shumatotale * quantity;
                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                                        if (Globals.Settings.StockRibbon == 1 && Globals.Settings.LocationRibbon == 1)
                                                        {
                                                            lblNameAndQuant.Text = item.Name + " / Sasia e disponueshme: " + Warehouse.GetbyId(e.Identifier).InStock + ((Globals.ItemLocation.Find(p => p.Id == item.Location)?.Name != null) ? " / Lokacioni: " + Globals.ItemLocation.Find(p => p.Id == item.Location).Name : "");
                                                        }
                                                        else if (Globals.Settings.StockRibbon == 1 && Globals.Settings.LocationRibbon == 0)
                                                        {
                                                            lblNameAndQuant.Text = item.Name + " / Sasia e disponueshme: " + Warehouse.GetbyId(e.Identifier).InStock;

                                                        }
                                                        else
                                                        {
                                                            lblNameAndQuant.Text = ((Globals.ItemLocation.Find(p => p.Id == item.Location)?.Name != null) ? " Lokacioni: " + Globals.ItemLocation.Find(p => p.Id == item.Location).Name : "");

                                                        }

                                                    }
                                                    else
                                                    {
                                                        decimal discount = sd.Discount / 100;

                                                        sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                        decimal quantity = sd.Quantity + 1;
                                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                                        sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                        decimal totalwithvat = sd.TotalWithVat + (shumatotale - (shumatotale * discount));
                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {item.ItemName}!");
                                        }
                                    }
                                    found = true;


                                    CalculateGridColumns();

                                }
                            }
                            if (!found)
                            {
                                AddItem(item);

                            }

                        }

                        else
                            AddItem(item);


                    }
                }
                else
                {
                    decimal shuma = (item.SalePrice * (1 - item.Discount / 100)) * (1 * (decimal)item.Vat / 100.0M);
                    decimal clientDiscount = Partner.Get(PartnerId).Discount;

                    decimal shumatotale = Math.Round(shuma + item.SalePrice, 2);
                    if (Globals.Settings.AllowDiscount == "0" && clientDiscount > 0)
                    {
                        shumatotale = Math.Round(shumatotale - (shumatotale * clientDiscount / 100), 2);

                    }
                    if (ug.Columns.Contains(" ") == false)
                    {
                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.UseColumnTextForButtonValue = true;
                        col.Name = " ";
                        col.FillWeight = 30;
                        col.FlatStyle = FlatStyle.Flat;
                        ug.Columns.Add(col);
                    }




                    if (itemAction != null && Globals.Settings.AllowDiscount == "0")
                    {
                        if (itemAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {

                                    sd.Discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                    if ((int)row.Cells[1].Value == searchValue)
                                    {

                                        decimal discount = sd.Discount / 100;

                                        sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                        decimal quantity = sd.Quantity + 1;
                                        sd.Vat = item.Vat;
                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                        sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;

                                        var totalP = Math.Round((decimal)row.Cells["Price"].Value * sd.Vat / 100 + (decimal)row.Cells["Price"].Value, 2);
                                        decimal totalwithvat = (totalP - (totalP * discount)) * quantity;
                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat - (totalwithvat * clientDiscount / 100), 2);


                                        found = true;
                                        CalculateGridColumns();
                                    }
                                }
                                if (!found)
                                {
                                    item.Discount = itemAction.discount;
                                    AddItem(item);

                                }

                            }

                            else
                            {
                                item.Discount = itemAction.discount;
                                AddItem(item);
                            }

                        }
                        else
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {

                                    sd.Discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                    if ((int)row.Cells[1].Value == searchValue)
                                    {


                                        if (itemAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                        {

                                            decimal discount = (itemAction.discount) / 100;

                                            sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                            decimal quantity = sd.Quantity + 1;
                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                            sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;

                                            //decimal totalwithvat = (sd.TotalWithVat + (sd.TotalWithVat * discount));
                                            decimal totalwithvat = (shumatotale - (shumatotale * discount)) * quantity;
                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                            row.Cells["Discount"].Value = (discount * 100).ToString("N");


                                        }
                                        else
                                        {
                                            if (sd.Discount == 0)
                                            {


                                                sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                decimal quantity = sd.Quantity + 1;
                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                decimal totalwithvat = shumatotale * quantity;
                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);



                                            }
                                            else
                                            {
                                                decimal discount = (sd.Discount) / 100;

                                                sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                decimal quantity = sd.Quantity + 1;
                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                decimal totalwithvat = (shumatotale * quantity) - (shumatotale * quantity) * discount;
                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();
                                    }
                                }
                                if (!found)
                                {
                                    AddItem(item);

                                }

                            }

                            else
                                AddItem(item);
                        }



                    }

                    //check per aksion me kategori
                    else if (categoryAction != null && Globals.Settings.AllowDiscount == "0")
                    {
                        if (categoryAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {

                                    sd.Discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                    if ((int)row.Cells[1].Value == searchValue)
                                    {

                                        decimal discount = sd.Discount / 100;

                                        sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                        decimal quantity = sd.Quantity + 1;
                                        sd.VatSum = (decimal)item.Vat / 100;
                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                        sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                        var totalP = (decimal)row.Cells[14].Value - ((decimal)row.Cells[14].Value * sd.Discount / 100);
                                        totalP = totalP - (totalP * clientDiscount / 100);
                                        decimal totalwithvat = totalP * quantity;
                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);


                                        found = true;
                                        CalculateGridColumns();
                                    }
                                }
                                if (!found)
                                {
                                    item.Discount = categoryAction.discount;
                                    AddItem(item);

                                }

                            }

                            else
                            {
                                item.Discount = categoryAction.discount;
                                AddItem(item);
                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {

                                    sd.Discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                    if ((int)row.Cells[1].Value == searchValue)
                                    {


                                        if (categoryAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                        {

                                            decimal discount = (sd.Discount + categoryAction.discount) / 100;

                                            sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                            decimal quantity = sd.Quantity + 1;
                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                            sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                            decimal totalwithvat = ((shumatotale * quantity) - (shumatotale * quantity * discount));
                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                            row.Cells["Discount"].Value = (discount * 100).ToString("N");


                                        }
                                        else
                                        {
                                            if (sd.Discount == 0)
                                            {


                                                sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                decimal quantity = sd.Quantity + 1;
                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                decimal totalwithvat = shumatotale * quantity;
                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);



                                            }
                                            else
                                            {
                                                decimal discount = sd.Discount / 100;

                                                sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                                decimal quantity = sd.Quantity + 1;
                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                                decimal totalwithvat = sd.TotalWithVat + (shumatotale - (shumatotale * discount));
                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();
                                    }
                                }
                                if (!found)
                                {
                                    AddItem(item);

                                }

                            }

                            else
                                AddItem(item);
                        }

                    }
                    else
                    {

                        if (ug.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in ug.Rows)
                            {


                                sd.Discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                if ((int)row.Cells[1].Value == searchValue)
                                {
                                    if (sd.Discount == 0)
                                    {


                                        sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                        decimal quantity = sd.Quantity + 1;
                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                        sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                        decimal totalwithvat = shumatotale * quantity;
                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                        if (Globals.Settings.StockRibbon == 1 && Globals.Settings.LocationRibbon == 1)
                                        {
                                            lblNameAndQuant.Text = item.Name + " / Sasia e disponueshme: " + Warehouse.GetbyId(e.Identifier).InStock + ((Globals.ItemLocation.Find(p => p.Id == item.Location)?.Name != null) ? " / Lokacioni: " + Globals.ItemLocation.Find(p => p.Id == item.Location).Name : "");
                                        }
                                        else if (Globals.Settings.StockRibbon == 1 && Globals.Settings.LocationRibbon == 0)
                                        {
                                            lblNameAndQuant.Text = item.Name + " / Sasia e disponueshme: " + Warehouse.GetbyId(e.Identifier).InStock;

                                        }
                                        else
                                        {
                                            lblNameAndQuant.Text = ((Globals.ItemLocation.Find(p => p.Id == item.Location)?.Name != null) ? " Lokacioni: " + Globals.ItemLocation.Find(p => p.Id == item.Location).Name : "");

                                        }

                                    }
                                    else
                                    {
                                        decimal discount = sd.Discount / 100;

                                        sd.Quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString());
                                        decimal quantity = sd.Quantity + 1;
                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                        sd.TotalWithVat = (decimal)row.Cells["TotalWithVat"].Value;
                                        decimal totalwithvat = sd.TotalWithVat + (shumatotale - (shumatotale * discount));
                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                    }

                                    found = true;


                                    CalculateGridColumns();

                                }
                            }
                            if (!found)
                            {
                                AddItem(item);

                            }

                        }

                        else
                            AddItem(item);


                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                ReloadForm();


            }



        }

        private void ug_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            //ktu me e vendos zbritjen tavan dhe me pass 
            var settings = Services.Settings.Get();

            var id = (int)ug[ug.Columns["ItemId"].Index, e.RowIndex].Value;
            var name = ug[ug.Columns["ItemName"].Index, e.RowIndex].Value.ToString();
            var vat = (int)ug[ug.Columns["VAT"].Index, e.RowIndex].Value;
            var categoryId = ug[ug.Columns["CategoryId"].Index, e.RowIndex].Value.ToString();
            var item = Services.Item.GetById(id).First();

            var quantityRowIndex = ug.Columns["Quantity"].Index;
            var totalRowIndex = ug.Columns["TotalWithVat"].Index;
            var TotalPaTvsh = ug.Columns["Price"].Index;
            var DiscountPrice = ug.Columns["Discount"].Index;

            Services.Action itemAction = null;
            Services.Action categoryAction = null;
            var quantity = (decimal)ug[quantityRowIndex, e.RowIndex].Value;
            var discount = 0.0m;
            var clientDiscount = 0.0m;
            if (item.Service == 0)
            {
                var availableStock = Globals.Settings.StockWMinus == "0" ? Warehouse.GetbyId(id).InStock : -1;

                if (availableStock < quantity && Globals.Settings.StockWMinus == "0")
                {
                    if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                    {
                        if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                        {
                            EnterPin enter = new EnterPin();
                            enter.ShowDialog();
                            if (enter.flag == true)
                            {
                                quantity = (decimal)ug[quantityRowIndex, e.RowIndex].Value;

                            }
                            else
                            {
                                ug[quantityRowIndex, e.RowIndex].Value = 1.0m;
                                quantity = 1.0m;
                            }
                        }
                        else
                        {
                            ug[quantityRowIndex, e.RowIndex].Value = 1.0m;
                            quantity = 1.0m;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name}!");
                    }
                }
                Services.Action action = new Services.Action();
                if (settings.AllowDiscount == "0")
                {
                    clientDiscount = Partner.Get(PartnerId).Discount;

                    itemAction = aksionet.Find(p => p.item_id == id);
                    categoryAction = aksionet.Find(p => p.category_id.ToString() == categoryId);
                    if (itemAction != null && categoryAction != null)
                    {
                        action = itemAction;
                    }
                    else if (itemAction == null)
                    {
                        action = categoryAction;
                    }
                    else if (categoryAction == null)
                    {
                        action = itemAction;

                    }
                    else
                        action = null;

                    discount = action != null ? action.quantity <= quantity ? action.discount : 0 : 0;
                }
                else
                {
                    //qitu me ja vendos tavanin
                    if (settings.MaxDiscount >= (decimal)ug[DiscountPrice, e.RowIndex].Value)
                    {
                        discount = (decimal)ug[DiscountPrice, e.RowIndex].Value;

                    }
                    else
                    {
                        ug[DiscountPrice, e.RowIndex].Value = 0.0m;

                        MessageBox.Show($"Slejohet zbritje me e madhe se zbitja MAX :{settings.MaxDiscount}%");
                    }
                }


                var discountPriceWithoutVat = ((decimal)ug[TotalPaTvsh, e.RowIndex].Value * (1 - discount / 100));

                var discountPriceWithVat = (decimal)ug[TotalPaTvsh, e.RowIndex].Value * (1 + (decimal)vat / 100);

                var total = discountPriceWithoutVat * quantity;
                var vatsum = total * vat / 100;

                //var totalprice = clientDiscount > 0 ? Math.Round((discountPriceWithVat * (1 - discount / 100) * quantity) * clientDiscount / 100, 2) : Math.Round((discountPriceWithVat * (1 - discount / 100) * quantity), 2);
                var totalprice = clientDiscount > 0 ? Math.Round((discountPriceWithVat * (1 - discount / 100) * quantity) * clientDiscount / 100, 2) : Math.Round((discountPriceWithVat * (1 - discount / 100) * quantity), 2);


                if (e.ColumnIndex == quantityRowIndex)
                {

                    if (categoryAction != null)
                    {
                        if (categoryAction != null && categoryAction.quantity <= (decimal)ug[quantityRowIndex, e.RowIndex].Value)
                        {

                            ug[totalRowIndex, e.RowIndex].Value = totalprice;

                            ug[DiscountPrice, e.RowIndex].Value = categoryAction.discount;



                        }
                        else
                        {

                            ug[totalRowIndex, e.RowIndex].Value = totalprice;
                            ug[DiscountPrice, e.RowIndex].Value = "0";


                        }

                        CalculateGridColumns();

                    }
                    else if (itemAction != null)
                    {

                        if (itemAction != null && itemAction.quantity <= (decimal)ug[quantityRowIndex, e.RowIndex].Value)
                        {

                            ug[totalRowIndex, e.RowIndex].Value = totalprice;

                            ug[DiscountPrice, e.RowIndex].Value = itemAction.discount;

                        }
                        else
                        {

                            ug[totalRowIndex, e.RowIndex].Value = totalprice;

                            ug[DiscountPrice, e.RowIndex].Value = "0";



                        }
                        CalculateGridColumns();

                    }
                    else
                    {
                        ug[totalRowIndex, e.RowIndex].Value = totalprice;
                        //ug[DiscountPrice, e.RowIndex].Value = "0";
                        CalculateGridColumns();

                    }

                }
                //else
                //{
                //    if ((decimal)ug[DiscountPrice, e.RowIndex].Value == 0)
                //    {

                //        ug[totalRowIndex, e.RowIndex].Value = Math.Round(totalprice * quantity, 2);

                //    }
                //    else
                //    {
                //        ug[totalRowIndex, e.RowIndex].Value = Math.Round((totalprice - (totalprice * ((decimal)ug[DiscountPrice, e.RowIndex].Value / 100))) * quantity, 2);


                //    }
                //    if(e.ColumnIndex != 24)
                //    {
                //        CalculateGridColumns();

                //    }
                //}





                if (e.ColumnIndex == DiscountPrice)
                {



                    ug[totalRowIndex, e.RowIndex].Value = totalprice;


                    CalculateGridColumns();
                }
            }
            else
            {
                Services.Action action = new Services.Action();

                if (settings.AllowDiscount == "0")
                {
                    clientDiscount = Partner.Get(PartnerId).Discount;

                    itemAction = aksionet.Find(p => p.item_id == id);
                    categoryAction = aksionet.Find(p => p.category_id.ToString() == categoryId);
                    if (itemAction != null && categoryAction != null)
                    {
                        action = itemAction;
                    }
                    else if (itemAction == null)
                    {
                        action = categoryAction;
                    }
                    else if (categoryAction == null)
                    {
                        action = itemAction;

                    }
                    else
                        action = null;

                    discount = action != null ? action.quantity <= quantity ? action.discount : 0 : 0;
                }
                else
                {
                    //qitu me ja vendos tavanin
                    if (settings.MaxDiscount >= (decimal)ug[DiscountPrice, e.RowIndex].Value)
                    {
                        discount = (decimal)ug[DiscountPrice, e.RowIndex].Value;

                    }
                    else
                    {
                        ug[DiscountPrice, e.RowIndex].Value = 0.0m;

                        MessageBox.Show($"Slejohet zbritje me e madhe se zbitja MAX :{settings.MaxDiscount}%");
                    }
                }


                var discountPriceWithoutVat = ((decimal)ug[TotalPaTvsh, e.RowIndex].Value * (1 - discount / 100));

                var discountPriceWithVat = (decimal)ug[TotalPaTvsh, e.RowIndex].Value * (1 + (decimal)vat / 100);

                var total = discountPriceWithoutVat * quantity;
                var vatsum = total * vat / 100;

                //var totalprice = clientDiscount > 0 ? Math.Round((discountPriceWithVat * (1 - discount / 100) * quantity) * clientDiscount / 100, 2) : Math.Round((discountPriceWithVat * (1 - discount / 100) * quantity), 2);
                var totalprice = clientDiscount > 0 ? Math.Round((discountPriceWithVat * (1 - discount / 100) * quantity) * clientDiscount / 100, 2) : Math.Round((discountPriceWithVat * (1 - discount / 100) * quantity), 2);


                if (e.ColumnIndex == quantityRowIndex)
                {

                    if (categoryAction != null)
                    {
                        if (categoryAction != null && categoryAction.quantity <= (decimal)ug[quantityRowIndex, e.RowIndex].Value)
                        {

                            ug[totalRowIndex, e.RowIndex].Value = totalprice;

                            ug[DiscountPrice, e.RowIndex].Value = categoryAction.discount;



                        }
                        else
                        {

                            ug[totalRowIndex, e.RowIndex].Value = totalprice;
                            ug[DiscountPrice, e.RowIndex].Value = "0";


                        }

                        CalculateGridColumns();

                    }
                    else if (itemAction != null)
                    {

                        if (itemAction != null && itemAction.quantity <= (decimal)ug[quantityRowIndex, e.RowIndex].Value)
                        {

                            ug[totalRowIndex, e.RowIndex].Value = totalprice;

                            ug[DiscountPrice, e.RowIndex].Value = itemAction.discount;

                        }
                        else
                        {

                            ug[totalRowIndex, e.RowIndex].Value = totalprice;

                            ug[DiscountPrice, e.RowIndex].Value = "0";



                        }
                        CalculateGridColumns();

                    }
                    else
                    {
                        ug[totalRowIndex, e.RowIndex].Value = totalprice;
                        //ug[DiscountPrice, e.RowIndex].Value = "0";
                        CalculateGridColumns();

                    }

                }
                //else
                //{
                //    if ((decimal)ug[DiscountPrice, e.RowIndex].Value == 0)
                //    {

                //        ug[totalRowIndex, e.RowIndex].Value = Math.Round(totalprice * quantity, 2);

                //    }
                //    else
                //    {
                //        ug[totalRowIndex, e.RowIndex].Value = Math.Round((totalprice - (totalprice * ((decimal)ug[DiscountPrice, e.RowIndex].Value / 100))) * quantity, 2);


                //    }
                //    if(e.ColumnIndex != 24)
                //    {
                //        CalculateGridColumns();

                //    }
                //}





                if (e.ColumnIndex == DiscountPrice)
                {



                    ug[totalRowIndex, e.RowIndex].Value = totalprice;


                    CalculateGridColumns();
                }
            }

        }

        private void AddItem(ItemsDiscount item)
        {
            var settings = Services.Settings.Get();
            decimal clientDiscount = 0;

            if (Globals.Settings.AllowDiscount == "0")
            {

                clientDiscount = Partner.Get(PartnerId).Discount;

            }
            Services.Models.TablesSaleDetails sd = new Services.Models.TablesSaleDetails();
            sd.No = ug.Rows.Count + 1;

            sd.Id = 0;
            sd.ItemId = item.Id;
            sd.No = ug.Rows.Count + 1;
            sd.Barcode = item.Barcode;
            sd.ItemName = item.Name;
            sd.Unit = item.Unit;
            sd.Quantity = 1.00M;
            sd.QuantityNow = Warehouse.GetbyId(sd.ItemId).InStock;
            sd.Price = item.SalePrice;
            sd.Discount = item.Discount;
            sd.CategoryId = item.CategoryId;
            int count = ug.Rows.Count + 1;
            ((BindingList<Services.Models.TablesSaleDetails>)ug.DataSource).Add(sd);

            sd.DiscountPrice = item.SalePrice * (1 - item.Discount / 100);

            sd.DiscountPriceWithVat = Math.Round(item.SalePrice * (1 + (decimal)item.Vat / 100.00M), 2);
            sd.Vat = item.Vat;
            sd.VatSum = sd.DiscountPrice * item.Vat / 100;

            sd.Total = sd.Quantity * sd.DiscountPrice;
            sd.TotalWithVat = clientDiscount > 0 ? Math.Round(sd.Total + sd.VatSum - ((sd.Total + sd.VatSum) * clientDiscount / 100), 2) : Math.Round(sd.Total + sd.VatSum, 2);

            CalculateGridColumns();

            if (ug.Rows.Count > 1)
            {
                ug.CurrentCell = ug[2, ug.Rows.Count - 1];

            }

            if (Globals.Settings.StockRibbon == 1 && Globals.Settings.LocationRibbon == 1)
            {
                lblNameAndQuant.Text = sd.ItemName + " / Sasia e disponueshme: " + sd.QuantityNow.ToString() +
                        ((Globals.ItemLocation.Find(p => p.Id == item.Location)?.Name != null) ? " / Lokacioni: " + Globals.ItemLocation.Find(p => p.Id == item.Location).Name : "");


                lblNameAndQuant.Left = (panel2.Width - lblNameAndQuant.Width) / 2;
                lblNameAndQuant.Top = (panel2.Height - lblNameAndQuant.Height) / 2;
            }
            else if (Globals.Settings.StockRibbon == 1 && Globals.Settings.LocationRibbon == 0)
            {
                lblNameAndQuant.Text = sd.ItemName + " / Sasia e disponueshme: " + sd.QuantityNow.ToString();
                lblNameAndQuant.Left = (panel2.Width - lblNameAndQuant.Width) / 2;
                lblNameAndQuant.Top = (panel2.Height - lblNameAndQuant.Height) / 2;
            }
            else
            {

                lblNameAndQuant.Text = ((Globals.ItemLocation.Find(p => p.Id == item.Location)?.Name != null) ? " Lokacioni: " + Globals.ItemLocation.Find(p => p.Id == item.Location).Name : "");
                lblNameAndQuant.Left = (panel2.Width - lblNameAndQuant.Width) / 2;
                lblNameAndQuant.Top = (panel2.Height - lblNameAndQuant.Height) / 2;
            }


            mIsChanged = true;
        }

        int mSelectedCatId = 0;


        private void btnTeGjitha_Clicker(object sender, IdentifierButtonEventArgs e)
        {
            pnlDrinks.Controls.Clear();
            pnlItems1.Visible = true;
            pnlDrinks.Visible = false;

            LoadTeGjitha();

        }
        int lastid = 0;
        private void buttonCategory_Clicker(object sender, IdentifierButtonEventArgs e)
        {
            //pnlDrinks.Controls.Clear();
            //pnlDrinks.Visible = true;
            //pnlDrinks.AutoSize = true;
            pnlSubCat.Controls.Clear();
            pnlItems1.Controls.Clear();

            pnlSubCat.Location = new Point(pnlSubCat.Location.X, pnlCategories.Location.Y + pnlCategories.Height);

            int y = 50;

            mSelectedCatId = e.Identifier;

            mAllSubCat = Services.ItemCategory.SubCategories(mSelectedCatId);

            mItems = mAllItems.Where(p => p.CategoryId == mSelectedCatId).ToList();

            foreach (System.Windows.Forms.Button item in pnlCategories.Controls)
            {
                if (item.Tag.ToString() == e.Identifier.ToString())
                {
                    item.BackColor = Color.FromArgb(0, 175, 240);
                }
                else
                    item.BackColor = Color.FromArgb(52, 58, 64);
            }

            if (mAllSubCat.Count > 0)
            {
                LoadItems();

                Modules.CreateButtons MakeButtons = new Modules.CreateButtons()
                {
                    ParentControl = pnlSubCat,
                    Base = 10,
                    ButtonBaseName = "btnSubCat",
                    BaseAddition = 110,
                    ButtonSize = subCbSize,
                    ButtonText = new Font("Arial", 9, FontStyle.Regular),
                    ButtonFlat = FlatStyle.Flat,
                    ButtonColor = Color.FromArgb(75, 95, 113),
                    TextColor = Color.White,
                    ImageAlignButton = TextImageRelation.TextAboveImage,

                };
                MakeButtons.ClickedHandler += buttonSubCategory_Clicker;
                MakeButtons.CreateCatfromList(mAllSubCat);

                pnlSubCat.Height = subCbSize.Height + subCbSize.Height / 4;

                // Set the new panel height
                AddButtonsBasedOnScreenResolution();



            }


            else
            {
                LoadItems();

            }
        }
        private void buttonSubCategory_Clicker(object sender, IdentifierButtonEventArgs e)
        {

            mSelectedCatId = e.Identifier;

            foreach (System.Windows.Forms.Button item in pnlSubCat.Controls)
            {
                if (item.Tag.ToString() == e.Identifier.ToString())
                {
                    item.BackColor = Color.FromArgb(0, 175, 240);
                }
                else
                    item.BackColor = Color.FromArgb(75, 95, 113);
            }

            mItems = mAllItems.Where(p => p.Nen_Category == mSelectedCatId).ToList();
            LoadItems();

        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);
            //using (Graphics g = e.Graphics)
            //{
            //    var p = new Pen(Color.Black, 2);
            //    var point1 = new Point(0, 30);
            //    var point2 = new Point(440, 30);
            //    g.DrawLine(p, point1, point2);
            //}
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

        }

        private void txtsrch_TextChanged(object sender, EventArgs e)
        {
            var settings = Services.Settings.Get();
            var clientDiscount = Partner.Get(PartnerId).Discount;
            bool found = false;
            if (txtsrch.Text != "")
            {
                var foundItems = mAllItems.Find(p => p.Barcode == txtsrch.Text);


                if (ug.Columns.Contains(" ") == false)
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.Name = " ";
                    ug.Columns.Add(col);
                }


                if (foundItems != null)
                {
                    decimal shuma = (foundItems.SalePrice * (1 - foundItems.Discount / 100)) * (1 * (decimal)foundItems.Vat / 100.0M);

                    decimal shumatotale = Math.Round(shuma + foundItems.SalePrice, 2);
                    if (settings.AllowDiscount == "0" && clientDiscount > 0)
                    {
                        shumatotale = shumatotale - (shumatotale * clientDiscount / 100);

                    }

                    var itemAction = aksionet.Find(p => p.item_id == foundItems.Id);
                    var categoryAction = aksionet.Find(p => p.category_id == foundItems.CategoryId);
                    if (categoryAction != null && itemAction != null && settings.AllowDiscount == "0")
                    {
                        var action = itemAction;
                        if (ug.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in ug.Rows)
                            {
                                if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                {
                                    if (itemAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                    {
                                        decimal discount = (itemAction.discount) / 100;
                                        decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                        decimal totalwithvat = ((decimal)row.Cells["TotalWithVat"].Value + ((decimal)row.Cells["TotalWithVat"].Value * discount));
                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                        row.Cells["Discount"].Value = (discount * 100).ToString("N");

                                    }
                                    else
                                    {
                                        if (decimal.Parse(row.Cells["Discount"].Value.ToString()) == 0 && action.discount == 0)
                                        {
                                            decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                            row.Cells["Quantity"].Value = quantity.ToString("N");
                                            decimal totalwithvat = shumatotale * quantity;
                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                        }
                                        else
                                        {
                                            decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;
                                            decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                            decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                        }
                                    }
                                    found = true;
                                    CalculateGridColumns();
                                }

                            }
                            if (!found)
                            {
                                if (itemAction.discount == 1)
                                {
                                    foundItems.Discount = itemAction.discount;
                                    AddItem(foundItems);
                                }
                                if (itemAction.discount == foundItems.Quantity + 1 || itemAction.discount > foundItems.Quantity + 1)
                                {
                                    foundItems.Discount = itemAction.discount;
                                    AddItem(foundItems);
                                }
                                else
                                    AddItem(foundItems);


                            }

                        }
                        else
                        {
                            if (action.quantity == 1)
                            {
                                foundItems.Discount = action.discount;

                            }
                            AddItem(foundItems);
                        }
                    }

                    if (itemAction != null && settings.AllowDiscount == "0")
                    {
                        var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                        var totalPrice = tp - (tp * clientDiscount / 100);

                        if (itemAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {

                                    if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                    {
                                        decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;


                                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                                        var vat = Convert.ToDecimal(row.Cells["Vat"].Value) / 100;
                                        var totalP = Math.Round((decimal)row.Cells["Price"].Value * vat + (decimal)row.Cells["Price"].Value, 2);
                                        decimal totalwithvat = (totalP - (totalP * discount)) * (decimal)row.Cells["Quantity"].Value;
                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat - (totalwithvat * clientDiscount / 100), 2);

                                        txtsrch.Text = "";
                                        CalculateGridColumns();


                                        found = true;
                                    }

                                }
                                if (!found)
                                {
                                    foundItems.Discount = itemAction.discount;
                                    AddItem(foundItems);
                                    txtsrch.Text = "";

                                }
                            }
                            else
                            {
                                foundItems.Discount = itemAction.discount;
                                AddItem(foundItems);
                                txtsrch.Text = "";

                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                    if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                    {
                                        if (itemAction.quantity == (decimal)row.Cells["Quantity"].Value + 1)
                                        {
                                            decimal itDiscount = (itemAction.discount) / 100;

                                            decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                            row.Cells["Quantity"].Value = quantity.ToString("N");
                                            decimal totalwithvat = (shumatotale - (shumatotale * discount)) * quantity;
                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                            row.Cells["Discount"].Value = (discount * 100).ToString("N");

                                            txtsrch.Text = "";
                                            CalculateGridColumns();


                                        }
                                        else
                                        {
                                            if (discount == 0)
                                            {
                                                decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                decimal totalwithvat = shumatotale * quantity;
                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);


                                            }
                                            else
                                            {
                                                decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                decimal totalwithvat = (shumatotale * quantity) - (shumatotale * quantity) * discount;
                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }

                                }
                                if (!found)
                                {
                                    AddItem(foundItems);
                                    txtsrch.Text = "";

                                }
                            }
                            else
                            {
                                AddItem(foundItems);
                                txtsrch.Text = "";

                            }
                        }
                    }



                    else if (categoryAction != null && settings.AllowDiscount == "0")
                    {
                        var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                        var totalPrice = tp - (tp * clientDiscount / 100);
                        if (categoryAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                    if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                    {

                                        decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                        var VatSum = (decimal)foundItems.Vat / 100;
                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                        var totalP = ((decimal)row.Cells["Price"].Value * VatSum + (decimal)row.Cells["Price"].Value) * discount;
                                        decimal totalwithvat = totalP * quantity;
                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                        found = true;
                                        CalculateGridColumns();
                                    }
                                }
                                if (!found)
                                {
                                    foundItems.Discount = categoryAction.discount;
                                    AddItem(foundItems);
                                    txtsrch.Text = "";

                                }
                            }
                            else
                            {
                                foundItems.Discount = categoryAction.discount;
                                AddItem(foundItems);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                    {
                                        if (categoryAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                        {

                                            decimal discount = (decimal.Parse(row.Cells["Discount"].Value.ToString()) + categoryAction.discount) / 100;


                                            decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                            decimal totalwithvat = ((shumatotale * quantity) - (shumatotale * quantity * discount));
                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                            row.Cells["Discount"].Value = (discount * 100).ToString("N");


                                        }
                                        else
                                        {
                                            if (decimal.Parse(row.Cells["Discount"].Value.ToString()) == 0)
                                            {


                                                decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                decimal totalwithvat = shumatotale * quantity;
                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);



                                            }
                                            else
                                            {
                                                decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;

                                                decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();
                                    }


                                }
                                if (!found)
                                {
                                    AddItem(foundItems);
                                    txtsrch.Text = "";

                                }
                            }
                            else
                            {
                                AddItem(foundItems);
                                txtsrch.Text = "";

                            }
                        }
                    }
                    else
                    {
                        if (ug.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in ug.Rows)
                            {
                                if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                {


                                    if ((decimal)row.Cells["Discount"].Value != 0)
                                    {
                                        decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                        row.Cells["Quantity"].Value = quantity.ToString("N");
                                        decimal totalwithvat = shumatotale * quantity;
                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                        txtsrch.Text = "";


                                    }
                                    else
                                    {
                                        decimal discount = (decimal)row.Cells["Discount"].Value / 100;
                                        decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                        row.Cells["Quantity"].Value = quantity.ToString("N");
                                        decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                        txtsrch.Text = "";

                                    }


                                    var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                    mTotalSum = total;
                                    txtTotalSum.Text = mTotalSum.ToString();
                                    AdjustTblTotalColumnWidths();
                                    found = true;
                                    CalculateGridColumns();

                                    return;
                                }

                            }
                            if (!found)
                            {
                                AddItem(foundItems);

                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {
                            //add found item.
                            if (txtsrch.Text == "")
                                return;
                            var item = foundItems;
                            AddItem(item);
                            txtsrch.Text = "";
                            CalculateGridColumns();


                        }
                    }
                }
            }
        }

        #endregion

        #region Protected methods

        protected void LoadData()
        {
            //var settings = MyNET.DAL.Settings.Get();
            //List<Services.Partner> partners = Services.Partner.Search("Status=0");
            //if (partners == null)
            //    partners = new List<Services.Partner>();
            ////partners.Insert(0, new Services.Partner());
            //cbPartners.DataSource = partners;
            cbPartners.DisplayMember = "Name";
            cbPartners.ValueMember = "Id";

            //Loading users

            var users = Services.User.GetByStation(Globals.Station.ParentId);
            if (users == null)
                users = new List<Services.User>();
            //cbUsers.DataSource = users;
            //cbUsers.DisplayMember = "FirstName";
            //cbUsers.ValueMember = "Id";

            //cbPartner.Value = 2;
            //if (Globals.Settings.StockWMinus == "0")
            //{
            //    mAllItems = Services.Item.GetItemsDiscount(Globals.Station.ParentId);

            //}
            //else
            //{
            //    mAllItems = Services.Item.GetAllItem();

            //}

            // show favorite items in start
            if (Globals.Settings.BarcMode == 0)
            {
                if (Globals.Settings.StockWMinus == "0")
                {
                    var items = Services.Item.GetItemsDiscount(Globals.Station.ParentId);

                    mAllItems = items;
                    var t = mAllItems.Where(p => p.Favorite == 1);
                    mItems = t.ToList();
                }
                else
                {
                    mAllItems = Services.Item.GetAllItem();
                }

                LoadItems();
                LoadItems();

            }

            LoadSale(mSaleId);
            //ugItemsList.DataSource = items;           
        }


        protected void LoadSale(int saleId)
        {
            var s = Services.Sale.Get(saleId);

            if (s != null && s.PartnerId != 0)
            {
                mSaleId = saleId;
                cbPartners.SelectedValue = s.PartnerId;
                this.Text = cbPartners.Text;
            }



            LoadSaleDetails();
        }
        protected void LoadSaleDetails()
        {

            var sett = Services.Settings.Get();

            List<Services.Models.TablesSaleDetails> salesd = Services.Models.TablesSaleDetails.GetSaleDetailsBySaleId(Convert.ToInt32(tableId));


            var groupedSalesd = salesd.GroupBy(sd => sd.ItemName)
                                     .Select(group => new Services.Models.TablesSaleDetails
                                     {

                                         Id = group.First().Id,
                                         ItemId = group.First().ItemId,
                                         No = group.First().No,
                                         ItemName = group.Key,
                                         Barcode = group.First().Barcode,
                                         Unit = group.First().Unit,
                                         Quantity = group.Sum(sd => sd.Quantity),
                                         QuantityNow = group.First().QuantityNow,
                                         Price = group.First().Price,
                                         AvgPrice = group.First().AvgPrice,
                                         CategoryId = group.First().CategoryId,
                                         CostOfGoods = group.First().CostOfGoods,
                                         Discount = group.First().Discount,
                                         DiscountPrice = group.First().DiscountPrice,
                                         DiscountPriceWithVat = group.First().DiscountPriceWithVat,
                                         TotalWithVatAvg = group.First().TotalWithVatAvg,
                                         Vat = group.First().Vat,
                                         VatSum = group.First().VatSum,
                                         VatPrice = group.First().VatPrice,
                                         Total = group.First().Total,
                                         TotalWithVat = group.Sum(sd => sd.TotalWithVat),
                                         Status = group.First().Status,
                                         tableId = group.First().tableId,
                                         Printed = group.First().Printed,
                                         PrintedQuantity = group.First().PrintedQuantity,
                                         PrintedFiscal = group.First().PrintedFiscal,
                                         PrintedFiscalQuantity = group.First().PrintedFiscalQuantity,
                                         DiscountAmount = group.First().DiscountAmount
                                     })
                                     .ToList();

            BindingList<Services.Models.TablesSaleDetails> bsalesd = new BindingList<Services.Models.TablesSaleDetails>(groupedSalesd);

            ug.DataSource = bsalesd;


            ug.Columns[0].Visible = false;
            ug.Columns[1].Visible = false;
            ug.Columns[4].Visible = false;
            ug.Columns[7].Visible = false;
            ug.Columns[8].Visible = false;
            ug.Columns[9].Visible = false;
            ug.Columns[10].Visible = false;
            ug.Columns[11].Visible = false;
            ug.Columns[13].Visible = false;
            ug.Columns[15].Visible = false;
            ug.Columns[16].Visible = false;
            ug.Columns[17].Visible = false;
            ug.Columns[18].Visible = false;
            ug.Columns[19].Visible = false;
            ug.Columns[21].Visible = false;
            ug.Columns[22].Visible = false;
            ug.Columns[23].Visible = false;
            ug.Columns[24].Visible = false;
            ug.Columns[25].Visible = false;
            ug.Columns[26].Visible = false;
            ug.Columns[27].Visible = false;
            ug.Columns[28].Visible = false;
            ug.Columns[29].Visible = false;
            ug.Columns[30].Visible = false;


            //ug.Columns[14].FillWeight = 50;
            //ug.Columns[20].Width = ug.Columns[14].Width;
            ug.Columns[3].FillWeight = 200;
            //ug.Columns[6].FillWeight = 50;
            //ug.Columns[12].FillWeight = 50;
            //ug.Columns[2].FillWeight = 50;

            ug.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ug.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ug.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ug.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ug.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            ug.Columns[2].ReadOnly = true;
            ug.Columns[3].ReadOnly = true;
            ug.Columns[20].ReadOnly = true;
            ug.Columns[14].ReadOnly = true;
            ug.Columns[5].ReadOnly = true;

            ug.Columns[20].HeaderText = "Totali";
            ug.Columns[14].HeaderText = "Çmimi";
            ug.Columns[12].HeaderText = "Zbritja";
            ug.Columns[3].HeaderText = "Emërtimi";
            ug.Columns[6].HeaderText = "Sasia";
            ug.Columns[2].HeaderText = "Nr.";
            ug.Columns[5].HeaderText = "Njësia";
            ug.Columns[24].HeaderText = "Për Kthim";


            if (sett.DiscountCol == 1)
            {
                ug.Columns[12].Visible = false;

            }
            else
            {
                ug.Columns[12].Visible = true;

            }
            if (sett.UnitCol == 1)
            {
                ug.Columns[5].Visible = false;

            }
            else
            {
                ug.Columns[5].Visible = true;

            }
            if (sett.AllowDiscount == "0")
            {
                ug.Columns[12].ReadOnly = true;
            }
            if (sett.ForReturn == 0)
            {
                ug.Columns[24].Visible = false;

            }
            else
            {
                ug.Columns[24].Visible = true;

            }

        }


        /// <summary>
        /// I pastrton fushat
        /// </summary>
        protected void ClearFields()
        {
            mSaleId = 0;

            //txtInoiceID.Text = "";
            txtsrch.Text = "";
            //numTotalPayed.Value = 0.0M;
            //numRetValue.Value = 0.0M;

            txtsrch.Focus();
            txtsrch.SelectAll();
            // txtDate.Value = DateTime.Now;
            txtsrch.Focus();

            inputstate = InputControlState.ShearchItem;
            CalculateGridColumns();
            ChangeInputControlState();
            pnlDrinks.Visible = false;
            //LoadData();
            mIsChanged = false;
            //totalSumOpenBalance += mTotalSum;
            txtTotalWVatSum.Text = "0.00";
            txtTotalSum.Text = "0.00";
            ug.Rows.Clear();

        }

        /// <summary>
        /// Kjo metode e ruan faturen. E mishkruan metoden baze 
        /// </summary>
        public void Save()
        {
            try
            {
                if (ug.Rows.Count > 0)
                {

                    // mPaymentDialog.TotalForPay = decimal.Parse(
                    //
                    //
                    //
                    //
                    // .Text);

                    DialogResult dialogResult = mPaymentDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        mSaleId = SaveSale();
                        //save sales details
                        int rows = SaveSaleDetails(mSaleId);
                        SavePayment();
                        //change sale status . Now sale is ready for sync
                        //Services.Sale.ChngStatus(mSaleId, 0);

                        if (rows > 0)
                        {
                            AutoClosingMessageBox.Show(paragraph_sale_save_successful.Text, "Info!", 1100);
                        }

                        ClearFields();
                    }
                }
                else
                {
                    MessageBox.Show(paragraph_invoice_without_item.Text);
                }
            }
            catch (Exception ex)
            {
                TrackError.ReportError(ex.Message);
                Error error = new Error();
                error.File = ex.StackTrace.ToString();
                error.Message = ex.Message;
                error.Line = ex.StackTrace.ToString();
                error.Company_Id = Globals.Settings.Id;
                error.Station_Id = Globals.Station.Id;
                error.Insert();
            }
        }

        protected void DeleteRow()
        {
            var selectedRow = ug.SelectedRows[0];
            if (selectedRow != null)
            {
                int rowNo = selectedRow.Index;
                ((BindingList<Services.Models.SaleDetails>)ug.DataSource).RemoveAt(rowNo);
            }
        }

        public void Delete()
        {
            //todo: te drejter per delte me. kontrollu ne settings
            if (mIsChanged || ug.Rows.Count > 0)
            {
                if (MessageBox.Show(paragraph_delete_invoice_question.Text, word_deleting_the_sales_invoice.Text, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    ClearFields();
                }
            }
            else
                ClearFields();

        }

        //private frmPayment mPaymentDialog = new frmPayment();

        public void Print()
        {

            PrintF();

        }

        protected void PrintF()
        {
            Random rnd = new Random();
            int num = rnd.Next();

            System.Data.DataTable dt = new System.Data.DataTable();

            foreach (DataGridViewColumn col in ug.Columns)
            {
                dt.Columns.Add(col.Name);   
            }

            foreach (DataGridViewRow row in ug.Rows)
            {
                if (Convert.ToInt32(row.Cells["Quantity"].Value) > Convert.ToInt32(row.Cells["PrintedFiscalQuantity"].Value))
                {
                    DataRow dRow = dt.NewRow();

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }

                    dt.Rows.Add(dRow);
                }
            }

            Services.Sale sale = Services.Sale.Get(mSaleId);
            //Shiko a eshte shtypur fatura ne printer fiskal?
            if (sale == null)
            {
                return;
            }
            decimal totalsum = Convert.ToDecimal(txtTotalSum.Text);//Convert.ToDecimal(txtDisplay1.Text);
            if (sale.Printed)
            {
                if (MessageBox.Show(report_invoici.Text + sale.SaleId + word_print_again_ask.Text,
                    word_print_the_coupon.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            if (ug.Rows.Count < 1)
            {

                MessageBox.Show(paragraph_no_item_invoice.Text);
                return;
            }

            if (Convert.ToDecimal(Convert.ToDecimal(txtTotalSum.Text)) == 0M)
            {
                MessageBox.Show(paragraph_fisc_with_zero.Text);
                return;
            }
            var printer = Printer.Get().Find(p => p.Id == Globals.DeviceId);
            var global = Services.Settings.Get();
            var withBank = 0;
            var clientPayed = mPaymentDialog.clientPayed;

            if (mPaymentDialog.TotalCreditCard > 0)
                withBank = 3;

            if (global.PosPrinter == "1")
            {
                if (printer.PrintTermal == "1")
                {
                    PrintThermal();
                }
                else
                {

                    if (printer.FiscalType == "Tremol")
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (TremolPrint.CreateReceipt(dt,clientPayed))
                            {
                                Services.SaleDetails.UpdatePrinted(mSaleId);
                            }

                            global.UpdateFC(lblFiscalCount.Text, Globals.Settings.Id);
                        }
                    }
                    else
                    {
                        if (printer.DatecsType == "FP-700")
                        {
                            if (dt.Rows.Count > 0)
                            {
                                FiscalPrinterHelper.GekosPrint(global.FiscalCount, num.ToString(), dt, mTotalSum, num, withBank,clientPayed);

                            }
                        }
                        else
                        {
                            if (dt.Rows.Count > 0)
                            {
                                FiscalPrinterHelper.GekosPrintOldV(global.FiscalCount, num.ToString(), dt, mTotalSum, num, withBank,clientPayed);
                            }
                        }
                        //LoadJson.DataTabletoJsonDatecs(dt);

                        int x = 0;


                        global.UpdateFC(lblFiscalCount.Text, Globals.Settings.Id);

                    }

                    //ketu vendoset funksioni per printer termal
                    if (global.ThermalPrinterName != null)
                    {
                        //PrintThermal();
                    }
                }
            }



            var globals = Services.Settings.Get();


            //AutoClosingMessageBox.Show(word_print_the_coupon.Text, "Info!", 1100);
        }
        public void DtToJson(System.Data.DataTable dt)
        {
            var global = Services.Settings.Get();

            LoadJson.DataTabletoJsonDatecs(dt);
            FiscalProperties(Convert.ToInt32(frmPayment.Kesh), countNumFiscal, Convert.ToInt32(mTotalSum), Convert.ToInt32(frmPayment.CreditCard));
            global.UpdateFC(lblFiscalCount.Text, Globals.Settings.Id);


        }
        public static void FiscalProperties(int frmcash, int countficsal, int mtotalsum, int frmcredit)
        {
            var global = Services.Settings.Get();
            Dictionary<string, int> values = new Dictionary<string, int>();
            values.Add("FrmPaymentKesh", frmcash);
            values.Add("countNumFiscal", countficsal);
            values.Add("mTotalSum", mtotalsum);
            values.Add("frmPaymentCredit", frmcredit);
            values.Add("totalSum", mtotalsum);

            string json = JsonConvert.SerializeObject(values);
            File.WriteAllText(global.ServerPath + @"\fiscalproperty.txt", json);

        }


        protected void Help()
        {
        }

        protected void SelectCustomer()
        {
            cbPartners.Visible = true;
            cbPartners.Enabled = true;
            //cbUsers.Visible = false;


        }

        protected void SelectUser()
        {
            //cbUsers.Visible = true;
            //cbUsers.Enabled = true;
            cbPartners.Visible = false;

        }

        public void New()
        {
            DeleteDataGridRows();
        }

        public void DeleteDataGridRows()
        {
            try
            {
                ug.Rows.Clear();
                mSaleId = 0;
                mIsChanged = false;
                //totalSumOpenBalance += mTotalSum;
                txtTotalWVatSum.Text = "0.00";
                txtDiscount.Text = "0.00";
                txtTotalSum.Text = "0.00";
                lblNameAndQuant.Text = "";


            }
            catch { }


        }


        /// <summary>
        /// Kerkon per artikullin ne datagrid ne baze te 
        /// barkodit, shifers apo emrit te artikullit
        /// </summary>

        protected void Search()
        {
            //filter mItems
            if (txtsrch.Text == "")
                mItems = mAllItems.ToList();
            //else
            //{

            //search barcode
            var foundItems = mAllItems.Where(p => p.Barcode == txtsrch.Text).ToList();
            if (ug.Columns.Contains(" ") == false)
            {
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Name = " ";
                ug.Columns.Add(col);
            }
            if (foundItems != null && foundItems.Count > 0)
            {
                if (ug.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in ug.Rows)
                    {
                        if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                        {


                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                            var totalPrice = Math.Round(foundItems.First().SalePrice + (foundItems.First().SalePrice * foundItems.First().Vat / 100), 2);

                            if ((decimal)row.Cells["Discount"].Value != 0)
                            {
                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);

                            }
                            else { row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2); }


                            var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                            var totalWVat = Convert.ToDecimal(row.Cells["Total"].Value);
                            mTotalSum = total;
                            mTotalSumWVat = totalWVat;
                            txtTotalSum.Text = mTotalSum.ToString();
                            txtTotalWVatSum.Text = mTotalSumWVat.ToString();
                            AdjustTblTotalColumnWidths();
                            txtsrch.Text = "";
                            return;

                        }


                    }
                }
                else
                {
                    //add found item.
                    if (txtsrch.Text == "")
                        return;
                    var item = foundItems.FirstOrDefault();
                    AddItem(item);

                }

            }
            else
            {
                //search for itemname
                foundItems = mAllItems.Where(p => (p.ItemName.ToLower().Contains(txtsrch.Text.ToLower()))).ToList();
                if (foundItems != null && foundItems.Count > 0)
                {
                    mItems = foundItems;
                }
            }



            LoadItems();

        }

        /// <summary>
        /// E nderron gjendje e kontrolles 
        /// </summary>
        protected void ChangeInputControlState()
        {
            if (inputstate == InputControlState.ShearchItem)
            {
                lblBarcode.Text = "Barkodi";
                txtsrch.SelectAll();
                lblBarcode.ForeColor = Color.Black;
                lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else if (inputstate == InputControlState.ChangeQuantity)
            {
                lblBarcode.Text = "Sasia";
                txtsrch.Text = "1";
                txtsrch.SelectAll();
                lblBarcode.ForeColor = Color.DarkBlue;
                lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else if (inputstate == InputControlState.Discount)
            {
                lblBarcode.Text = "Zbritja";
                txtsrch.Text = "1";
                txtsrch.SelectAll();
                lblBarcode.ForeColor = Color.SteelBlue;
                lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else if (inputstate == InputControlState.ChangePrice)
            {
                lblBarcode.Text = "Çmimi";
                txtsrch.Text = "0";
                txtsrch.SelectAll();
                lblBarcode.ForeColor = Color.Red;
                lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        protected int SaveSale()
        {
            Services.Sale sale = Services.Sale.Get(mSaleId);

            if (sale == null)
                sale = new Services.Sale();

            if (cbPartners.SelectedItem != null)
            {
                sale.PartnerId = (int)cbPartners.SelectedValue;
            }
            else
                sale.PartnerId = Globals.Settings.DefaultClientId;
            //DateTime currentDate = DateTime.Now.ToLocalTime();
            //DateTime saleDate = new DateTime(currentDate.Year, 9, 7, 0, 0, 0);

            //// Add 2 hours to the `sale.Date`
            //saleDate = saleDate.AddHours(2);
            //sale.Date = saleDate;
            sale.Date = DateTime.Now.ToLocalTime();


            // Assign the `sale.Date` to your `sale` object

            sale.PosId = Globals.Station.Id;
            sale.StationId = Globals.ParentStationId;
            var totals = 0.0m;

            //foreach (DataGridViewRow item in ug.Rows)
            //{
            //    if (Convert.ToInt32(item.Cells["ForReturn"].Value) == 0)
            //    {
            //        totals += Convert.ToDecimal(item.Cells["TotalWithVat"].Value);
            //    }
            //}
            sale.TotalSum = Math.Round(mTotalSum, 2);
            sale.VatSum = mVatSum;

            sale.Comment = "";

            int result = 0;

            if (mSaleId == 0)
            {
                //tipi i shitjes me POS kupon
                sale.SalesTypeId = 1;
                sale.CreatedAt = DateTime.Now.ToLocalTime();
                sale.CreatedBy = Globals.User.Name;
                sale.Status = -1;
                sale.id_saler = Globals.User.Id;

                //sale.SaleId = Sale.getAllSales().Count > 0 ? Sale.getAllSales().Where(p=>p.StationId==Globals.Station.Id).Last().SaleId + 1 : Globals.Station.LastInvoiceNumber + 1;
                if (Sale.getSalesCount() > 0)
                {
                    if (Sale.getSalesCountWithPosId(Globals.Station.Id.ToString()) > 0)
                    {
                        sale.SaleId = Sale.getAllSalesPosId(Globals.Station.Id.ToString()).Last().SaleId + 1;
                    }
                    else
                    {
                        sale.SaleId = Globals.Station.LastInvoiceNumber + 1;
                    }
                }
                else
                {
                    sale.SaleId = Globals.Station.LastInvoiceNumber + 1;

                }

                //while (result == 0)
                //{
                sale.InvoiceNo = Globals.Station.Id + "-" + sale.SaleId;

                //result = sale.Insert();
                //sale.SaleId++;

                //}


                //StationService.UpdateLastInvoiceNumber(sale.SaleId, Globals.Station.Id);

                //Services.Sale.IdSaler(sale.Id, Globals.User.Id);

                Globals.Station.LastInvoiceNumber++;
                DailyOpenFiscalCount += 1;
                var daily = new DailyOpenCloseBalance();
                var lastdaily = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(Globals.User.Id);
                totalSumOpenBalance = sale.TotalSum + lastdaily.TotalShitje;
                var totalcash = 0.0m;

                totalcash += lastdaily.TotalCash + frmPayment.Kesh;

                var totalcredit = mPaymentDialog.TotalCreditCard + lastdaily.TotalCreditCard;



                OverallObj overallObj = new OverallObj
                {
                    sale = sale,
                    LastInvoiceNumber = sale.SaleId,
                    stationId = Globals.Station.Id,
                    id_saler = Globals.User.Id,
                    saleId = sale.SaleId,
                    dailyId = lastdaily.Id,
                    DailyFiscalCount = DailyOpenFiscalCount,
                    TotalShitje = totalSumOpenBalance,
                    TotalCash = totalcash,
                    TotalCreditCard = totalcredit,
                    status = sale.Status.ToString()
                };
                result = overallObj.UpdateA();
                if (result > 0)
                    return overallObj.Id;
                else
                {
                    MessageBox.Show("Fatura nuk munde te ruhet! Ju lutem kontaktoni administratorin!");
                    return -1;
                }
                //daily.UpdateDFC(DailyOpenFiscalCount.ToString(), totalSumOpenBalance, totalcash, totalcredit, lastdaily.Id);

            }
            else
            {
                sale.ChangedAt = DateTime.Now;
                sale.ChangedBy = Globals.User.FirstName;
                result = sale.Update();

            }
            if (result > 0)
                return sale.Id;
            else
            {
                MessageBox.Show(paragraph_invoice_cannotbesaved_.Text);
                return -1;
            }
        }
        protected int SaveSaleInvoice()
        {
            Services.Sale sale = Services.Sale.Get(mSaleId);
            var partner = Services.Partner.Search("Status=0");
            var client = partner.Where(p => p.Id == (int)cbPartners.SelectedValue);
            if (sale == null)
                sale = new Services.Sale();

            if (cbPartners.SelectedItem != null)
            {
                if (client.First().PartnerType == 0)
                {
                    MessageBox.Show("Nuk lejohet qe personi fizik ti leshohet faturë!");

                    return -1;
                }
                sale.PartnerId = (int)cbPartners.SelectedValue;

            }
            else
                sale.PartnerId = Globals.Settings.DefaultClientId;

            sale.Date = DateTime.Now.ToLocalTime();
            sale.PosId = Globals.Station.Id;
            sale.StationId = Globals.ParentStationId;
            sale.TotalSum = Math.Round(mTotalSum, 2);
            sale.VatSum = mVatSum;

            sale.Comment = "";

            int result = 0;
            if (mSaleId == 0)
            {
                //tipi i shitjes me POS kupon
                sale.SalesTypeId = 2;
                sale.CreatedAt = DateTime.Now.ToLocalTime();
                sale.CreatedBy = Globals.User.Name;
                sale.Status = -1;
                sale.id_saler = Globals.User.Id;

                sale.CouponNo = 0;

                if (Sale.getSalesCount() > 0)
                {
                    if (Sale.getSalesCountWithPosId(Globals.Station.Id.ToString()) > 0)
                    {
                        sale.SaleId = Sale.getAllSalesPosId(Globals.Station.Id.ToString()).Last().SaleId + 1;
                    }
                    else
                    {
                        sale.SaleId = Globals.Station.LastInvoiceNumber + 1;
                    }
                }
                else
                {
                    sale.SaleId = Globals.Station.LastInvoiceNumber + 1;

                }

                //while (result == 0)
                //{
                //sale.InvoiceNo = Globals.Station.Id + "-" + sale.SaleId;

                //    result = sale.Insert();
                //    //duhet me e kqyr qita
                //    sale.SaleId++;

                //}

                //long lastInvoiceNumber = Globals.Station.LastInvoiceNumber + 1;

                //Services.StationService.UpdateLastInvoiceNumber(lastInvoiceNumber, Globals.Station.Id);


                sale.InvoiceNo = Globals.Station.Number + "-" + sale.SaleId;


                Globals.Station.LastInvoiceNumber++;
                DailyOpenFiscalCount += 1;
                var daily = new DailyOpenCloseBalance();
                var lastdaily = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(Globals.User.Id);
                totalSumOpenBalance = sale.TotalSum + lastdaily.TotalShitje;
                var totalcash = 0.0m;

                totalcash += lastdaily.TotalCash + frmPayment.Kesh;

                var totalcredit = mPaymentDialog.TotalCreditCard + lastdaily.TotalCreditCard;

                daily.UpdateDFC(DailyOpenFiscalCount.ToString(), totalSumOpenBalance, totalcash, totalcredit, lastdaily.Id);

                Globals.Station.LastInvoiceNumber++;
                DailyOpenFiscalCount += 1;

                OverallObj overallObj = new OverallObj
                {
                    sale = sale,
                    LastInvoiceNumber = sale.SaleId,
                    stationId = Globals.Station.Id,
                    id_saler = Globals.User.Id,
                    saleId = sale.SaleId,
                    dailyId = lastdaily.Id,
                    DailyFiscalCount = DailyOpenFiscalCount,
                    TotalShitje = totalSumOpenBalance,
                    TotalCash = totalcash,
                    TotalCreditCard = totalcredit,
                    status = sale.Status.ToString()
                };
                result = overallObj.UpdateA();
                if (result > 0)
                    return overallObj.Id;
                else
                {
                    MessageBox.Show("Fatura nuk munde te ruhet! Ju lutem kontaktoni administratorin!");
                    return -1;
                }

            }
            else
            {
                sale.ChangedAt = DateTime.Now;
                sale.ChangedBy = Globals.User.FirstName;
                result = sale.Update();

            }
            if (result > 0)
                return sale.Id;
            else
            {
                MessageBox.Show(paragraph_invoice_cannotbesaved_.Text);
                return -1;
            }
        }

        /// <summary>
        /// I fute detalet e faturen ne databaze
        /// </summary>
        /// <returns>Kthen numrin e rreshtave te futur</returns>
        protected int SaveSaleDetails(int SaleId)
        {
            List<Warehouse> wrh = new List<Warehouse>();
            List<Services.SaleDetails> sd = new List<Services.SaleDetails>();

            foreach (DataGridViewRow row in ug.Rows)
            {
                int detailsid = (int)row.Cells["id"].Value;

                //Services.SaleDetails details = (detailsid == 0) ? new Services.SaleDetails() : Services.SaleDetails.GetById(detailsid);
                Services.SaleDetails details = new Services.SaleDetails();
                details.SaleId = SaleId;
                details.ItemId = (int)row.Cells["ItemId"].Value;
                details.ItemNumber = row.Cells["ItemNumber"].Value.ToString();
                var warehouse = Services.Warehouse.GetbyId(details.ItemId);

                //details.ItemName = (string)row.Cells["ItemName"].Value;
                details.No = (int)row.Cells["No"].Value;
                decimal quantity = (decimal)row.Cells["Quantity"].Value;

                details.Quantity = quantity;
                details.Price = (decimal)row.Cells["Price"].Value;
                details.VAT = (int)row.Cells["Vat"].Value;
                details.Discount = (decimal)row.Cells["Discount"].Value;
                details.VatSum = (decimal)row.Cells["VatSum"].Value;
                details.CreatedAt = DateTime.Now.ToLocalTime();
                details.CreatedBy = Globals.User.FirstName;
                details.CreatedBy = Globals.User.FirstName;
                int status = (int)row.Cells["Status"].Value;
                decimal clientDiscount = (decimal)row.Cells["ClientDiscount"].Value;
                details.ForReturn = (bool)row.Cells["ForReturn"].Value;
                int printedQuantity = 0;
                //if (status == -1)
                //    //if(row.IsDeleted)
                //    details.Delete();
                //else
                //{
                //if (details.Id == 0)
                //{
                //    details.Insert();
                //    row.Cells["ID"].Value = details.Id;
                //}
                //else
                //    details.Update();


                var q = details.ForReturn == true ? -(details.Quantity) : details.Quantity;
                var CurrentStock = warehouse != null ? warehouse.InStock - q : 0 - q;
                //w.Id = details.ItemId;
                //w.InStock = CurrentStock;
                //w.StationId = Globals.ParentStationId;
                //w.Update();

                sd.Add(new Services.SaleDetails
                {
                    SaleId = SaleId,
                    ItemId = (int)row.Cells["ItemId"].Value,
                    No = (int)row.Cells["No"].Value,
                    Quantity = quantity,
                    Price = (decimal)row.Cells["Price"].Value,
                    VAT = (int)row.Cells["Vat"].Value,
                    Discount = (decimal)row.Cells["Discount"].Value,
                    VatSum = (decimal)row.Cells["VatSum"].Value,
                    CreatedAt = DateTime.Now.ToLocalTime(),
                    CreatedBy = Globals.User.FirstName,
                    ClientDiscount = clientDiscount,
                    PrintedQuantity = printedQuantity,
                    ForReturn = details.ForReturn,
                    ItemNumber = row.Cells["ItemNumber"].Value.ToString(),
                    DiscountAmount = row.Cells["DiscountAmount"].Value.ToString(),
                    PosId = Globals.DeviceId,
                    Printed = 0
                });
                wrh.Add(new Warehouse
                {
                    Id = details.ItemId,
                    StationId = Globals.ParentStationId,
                    InStock = CurrentStock,

                });


                //Services.Warehouse.CalculateStock(CurrentStock, details.ItemId, Globals.ParentStationId);

                //}

                //}


                //todo: MyNET.DAL.Item.CalculateStock(details.ItemId,Globals.UserSettings.WarehouseId,quantity, Globals.User.Identity.Name);


            }

            Warehouse.BatchUpdate(wrh);
            Services.SaleDetails.BatchInsert(sd);

            CalculateGridColumns();


            return ug.Rows.Count;


        }
        public static DataTable SaleDtoDataTable(IGrouping<int, Services.SaleDetails> saleDetails)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            DataColumn c = new DataColumn("Id");
            DataColumn c1 = new DataColumn("SaleId");
            DataColumn c2 = new DataColumn("ItemId");
            DataColumn c11 = new DataColumn("ItemNumber");
            DataColumn c8 = new DataColumn("ItemName");
            DataColumn c3 = new DataColumn("Quantity");
            DataColumn c10 = new DataColumn("Discount");
            DataColumn c4 = new DataColumn("Price");
            DataColumn c5 = new DataColumn("VAT");
            DataColumn c6 = new DataColumn("VATSum");
            DataColumn c7 = new DataColumn("Printed");

            dt.Columns.Add(c); dt.Columns.Add(c1); dt.Columns.Add(c2); dt.Columns.Add(c3); dt.Columns.Add(c8);
            dt.Columns.Add(c4); dt.Columns.Add(c5); dt.Columns.Add(c6); dt.Columns.Add(c7); dt.Columns.Add(c10); dt.Columns.Add(c11);

            foreach (var s in saleDetails)
            {
                DataRow r = dt.NewRow();
                var allitems = Services.Item.GetAllItem();
                var ad = allitems.Where(p => p.Id == s.ItemId);
                string itemname = ad.First().ItemName;
                r["Id"] = s.Id;
                r["SaleId"] = s.SaleId;
                r["ItemId"] = s.ItemId;
                r["ItemNumber"] = s.ItemNumber;
                r["ItemName"] = itemname;
                r["Quantity"] = s.Quantity;
                r["Price"] = s.Price;
                r["Discount"] = s.Discount;
                r["VAT"] = s.VAT;
                r["VATSum"] = s.VatSum;
                r["Printed"] = s.Printed;


                dt.Rows.Add(r);
            }


            return dt;
        }

        protected void CalculateGridColumns()
        {
            //var settings = Services.Settings.Get();
            decimal totalVat = 0.0M;
            decimal totalsum0 = 0;
            double totalsum8 = 0;
            double totalsum18 = 0;
            decimal totalsumWVat = 0;
            double pricePaVat0 = 0;
            double pricePaVat8 = 0;
            double pricePaVat18 = 0;
            decimal totalDiscount = 0.0M;

            decimal clientDiscount = Globals.Settings.AllowDiscount == "0" ? Convert.ToDecimal(Partner.Get(PartnerId).Discount / 100) : 0;
            int i = 1;
            var clientDiscountValue = 0m;
            int deletedrowscount = 0;
            decimal vatvalue = 0;

            BindingList<Services.Models.TablesSaleDetails> items = (BindingList<Services.Models.TablesSaleDetails>)ug.DataSource;

            foreach (DataGridViewRow row in ug.Rows)
            {
                var priceBase = Convert.ToDecimal(row.Cells["Total"].Value);
                var discount = Convert.ToDecimal(row.Cells["Discount"].Value) / 100;
                var amountDiscount = (priceBase * discount);
                var priceNovat = Convert.ToDecimal((row.Cells["Total"].Value)) - amountDiscount;
                var clientAmountDiscount = (priceNovat * clientDiscount);
                var priceNoVatAllDiscount = priceNovat - clientAmountDiscount;
                var patvsh = priceNoVatAllDiscount * Convert.ToDecimal(row.Cells["Quantity"].Value);
                var ta = Math.Round(patvsh * (1 + (Convert.ToDecimal(row.Cells["VAT"].Value) / 100)), 5);
                totalsum0 += ta;
                totalsumWVat += patvsh;
                //row.Cells["TotalWithVat"].Value = ta.ToString("N");
            }

            //totalsum = totalsum + (totalsum * (18 * 0.01));
            mTotalSum = Convert.ToDecimal(totalsum0);
            mVatSum = totalVat;
            mTotalSumWVat = Math.Round(Convert.ToDecimal(totalsumWVat), 5);

            foreach (DataGridViewRow row in ug.Rows)
            {
                if ((bool)row.Cells["ForReturn"].Value)
                {
                    mTotalSum -= 2 * Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                    mTotalSumWVat -= 2 * (Convert.ToDecimal(((Convert.ToDecimal(row.Cells["Total"].Value) * (1 - Convert.ToDecimal(row.Cells["Discount"].Value) / 100)) * (1 - clientDiscount)) * Convert.ToDecimal(row.Cells["Quantity"].Value)));
                }

            }

            txtTotalSum.Text = mTotalSum.ToString("N");
            txtTotalWVatSum.Text = mTotalSumWVat.ToString("N");
            txtDiscount.Text = totalDiscount.ToString("N");
            AdjustTblTotalColumnWidths();
        }

        /// <summary>
        /// Leviz neper grid lart
        /// </summary>


        /// <summary>
        /// Leviz neper grid posht
        /// </summary>

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var printedOrder = TablesSaleDetails.GetSaleDetailsBySaleId(Convert.ToInt32(tableId)).Where(p => p.Status == 0 && p.PrintedFiscalQuantity > 0 || p.PrintedQuantity > 0);

            if (printedOrder.Count() == 0)
            {
                if (Globals.Settings.PIN == "0" || Globals.Settings.PIN == null)
                {
                    if (ug.Columns.Contains(" ") == true)
                    {
                        ug.Columns.RemoveAt(27);

                    }
                    New();

                    Globals.NextStep = "Restaurant";

                    this.Close();
                }
                else
                {
                    EnterPin enter = new EnterPin();
                    enter.ShowDialog();
                    if (enter.flag == true)
                    {
                        if (ug.Columns.Contains(" ") == true)
                        {
                            ug.Columns.RemoveAt(27);

                        }

                        New();
                    }
                }
                Services.Tables.UpdateTablePos(0, tableId);
            }
            else
            {
                MessageBox.Show("Nuk mund ta anuloni porosine sepse eshte shtypur kuponi");
            }


            //txtDiscount.Text = "0.00";
            //txtTotalSum.Text = "0.00";
            //koment
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //frmSettings frm = new frmSettings();
            //frm.ShowDialog();
        }

        private void BtnClient_Click(object sender, EventArgs e)
        {
            try
            {
                SelectCustomer();
                cbPartners.DisplayMember = "Name";

            }
            catch
            {

            }
        }

        private void PosRestaurant_Resize(object sender, EventArgs e)
        {

        }

        private void btnLogedUser_Click(object sender, EventArgs e)
        {
            try
            {
                RestaurantOptions frm = new RestaurantOptions();
                timer2.Enabled = false;
                if (Globals.Settings.PIN == "0" || Globals.Settings.PIN == null)
                {
                    frm.Owner = this;
                    frm.ShowDialog();

                }
                else
                {
                    EnterPin enterPin = new EnterPin();
                    enterPin.ShowDialog();
                    frm.Owner = this;

                    if (enterPin.flag == true)
                    {
                        frm.Show();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }

        }

        private void PosRestaurant_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globals.NextStep = "Restaurant";


        }



        private void btnStaf_Click(object sender, EventArgs e)
        {
            SelectUser();
        }

        private void ug_DataSourceChanged(object sender, EventArgs e)
        {

            //var columns = ug.Columns;
            //try
            //{
            //    ug.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //    columns["Id"].Visible = false;
            //    columns["ItemId"].Visible = false;

            //    columns["QuantityNow"].Visible = false;
            //    columns[2].Resizable = DataGridViewTriState.False;
            //    columns[3].Resizable = DataGridViewTriState.False;
            //    columns[4].Resizable = DataGridViewTriState.False;
            //    columns[6].Resizable = DataGridViewTriState.False;
            //    columns[11].Resizable = DataGridViewTriState.False;
            //    columns[19].Resizable = DataGridViewTriState.False;




            //    //translate
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Kolona nuk ekziston:" + ex.Message);
            //}

        }

        private void ug_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var settings = Services.Settings.Get();

            decimal totalsumWVat = 0;
            decimal totalDiscount = 0;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var printedOrder = TablesSaleDetails.GetSaleDetailsBySaleId(Convert.ToInt32(tableId)).Where(p => p.Status == 0 && p.PrintedFiscalQuantity > 0);
                if (printedOrder.Count() == 0)
                {

                    if (Globals.Settings.PIN == "0" || Globals.Settings.PIN == null)
                    {
                        var clientDiscount = settings.AllowDiscount == "0" ? Partner.Get(PartnerId).Discount : 0;
                        decimal newtotalsum = Convert.ToDecimal(txtTotalSum.Text);
                        decimal newtotalsumWVat = Convert.ToDecimal(txtTotalWVatSum.Text);
                        decimal newtotaldiscount = Convert.ToDecimal(txtDiscount.Text);
                        decimal indexTotalSum = Convert.ToDecimal(ug.Rows[e.RowIndex].Cells["TotalWithVat"].Value);
                        decimal discount = Convert.ToDecimal(ug.Rows[e.RowIndex].Cells["Discount"].Value);
                        decimal quantity = Convert.ToDecimal(ug.Rows[e.RowIndex].Cells["Quantity"].Value);
                        decimal indexTotalSumWVat = Convert.ToDecimal(ug.Rows[e.RowIndex].Cells["Price"].Value);
                        decimal qmimi = Convert.ToDecimal(ug.Rows[e.RowIndex].Cells[14].Value);


                        if (clientDiscount > 0)
                        {
                            decimal pricePaVat = Math.Round((indexTotalSumWVat - (indexTotalSumWVat * discount / 100)) * quantity, 2);
                            totalsumWVat = pricePaVat - (pricePaVat * clientDiscount / 100);

                        }
                        else
                        {
                            if (quantity == 1 && discount > 0)
                            {
                                //duhet me u kontrollu kjo
                                decimal pricePaVat = Math.Round((indexTotalSumWVat - (indexTotalSumWVat * discount / 100)) * quantity, 2);
                                totalsumWVat = pricePaVat;

                            }
                            else
                            {
                                decimal pricePaVat = Math.Round((indexTotalSumWVat - (indexTotalSumWVat * discount / 100)) * quantity, 2);

                                totalsumWVat = pricePaVat;
                            }

                        }

                        decimal discountValue = (quantity * qmimi) * discount / 100;

                        var clientDiscountValue = ((qmimi * quantity) - discountValue) * clientDiscount / 100;

                        totalDiscount += discountValue + clientDiscountValue;

                        txtDiscount.Text = ug.Rows.Count > 1 ? (newtotaldiscount - totalDiscount).ToString("N") : "0.00";
                        txtTotalSum.Text = ug.Rows.Count > 1 ? (newtotalsum - indexTotalSum).ToString("N") : "0.00";
                        txtTotalWVatSum.Text = ug.Rows.Count > 1 ? Math.Round((newtotalsumWVat - totalsumWVat), 2).ToString("N") : "0.00";
                        ((BindingList<Services.Models.TablesSaleDetails>)ug.DataSource).RemoveAt(e.RowIndex);
                        CalculateGridColumns();

                        for (int i = 0; i < ug.Rows.Count; i++)
                        {
                            ug.Rows[i].Cells["No"].Value = i + 1;
                        }

                    }
                    else
                    {
                        EnterPin enter = new EnterPin();
                        enter.ShowDialog();
                        if (enter.flag == true)
                        {
                            var clientDiscount = settings.AllowDiscount == "0" ? Partner.Get(PartnerId).Discount : 0;
                            decimal newtotalsum = Convert.ToDecimal(txtTotalSum.Text);
                            decimal newtotalsumWVat = Convert.ToDecimal(txtTotalWVatSum.Text);
                            decimal newtotaldiscount = Convert.ToDecimal(txtDiscount.Text);
                            decimal indexTotalSum = Convert.ToDecimal(ug.Rows[e.RowIndex].Cells["TotalWithVat"].Value);
                            decimal discount = Convert.ToDecimal(ug.Rows[e.RowIndex].Cells["Discount"].Value);
                            decimal quantity = Convert.ToDecimal(ug.Rows[e.RowIndex].Cells["Quantity"].Value);
                            decimal indexTotalSumWVat = Convert.ToDecimal(ug.Rows[e.RowIndex].Cells["Price"].Value);
                            decimal qmimi = Convert.ToDecimal(ug.Rows[e.RowIndex].Cells[14].Value);


                            if (clientDiscount > 0)
                            {
                                decimal pricePaVat = Math.Round((indexTotalSumWVat - (indexTotalSumWVat * discount / 100)) * quantity, 2);
                                totalsumWVat = pricePaVat - (pricePaVat * clientDiscount / 100);

                            }
                            else
                            {
                                if (quantity == 1 && discount > 0)
                                {
                                    //duhet me u kontrollu kjo
                                    decimal pricePaVat = Math.Round((indexTotalSumWVat - (indexTotalSumWVat * discount / 100)) * quantity, 2);
                                    totalsumWVat = pricePaVat;

                                }
                                else
                                {
                                    decimal pricePaVat = Math.Round((indexTotalSumWVat - (indexTotalSumWVat * discount / 100)) * quantity, 2);

                                    totalsumWVat = pricePaVat;
                                }

                            }

                            decimal discountValue = (quantity * qmimi) * discount / 100;

                            var clientDiscountValue = ((qmimi * quantity) - discountValue) * clientDiscount / 100;

                            totalDiscount += discountValue + clientDiscountValue;

                            txtDiscount.Text = ug.Rows.Count > 1 ? (newtotaldiscount - totalDiscount).ToString("N") : "0.00";
                            txtTotalSum.Text = ug.Rows.Count > 1 ? (newtotalsum - indexTotalSum).ToString("N") : "0.00";
                            txtTotalWVatSum.Text = ug.Rows.Count > 1 ? Math.Round((newtotalsumWVat - totalsumWVat), 2).ToString("N") : "0.00";
                            ((BindingList<Services.Models.TablesSaleDetails>)ug.DataSource).RemoveAt(e.RowIndex);
                            mTotalSum = (newtotalsum - indexTotalSum);
                            mTotalSumWVat = (newtotalsumWVat - indexTotalSumWVat);

                            for (int i = 0; i < ug.Rows.Count; i++)
                            {
                                ug.Rows[i].Cells["No"].Value = i + 1;
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Artikulli nuk mund te fshihet sepse eshte shtypur ne kupon.");
                }

            }
            else if (senderGrid.Columns[e.ColumnIndex].Index == ug.Columns["ItemName"].Index && senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                int id = Convert.ToInt32(ug.Rows[e.RowIndex].Cells["ItemId"].Value);
                string name = (ug.Rows[e.RowIndex].Cells["ItemName"].Value).ToString();

                var item = Services.Item.GetById(id).First();

                if (settings.StockRibbon == 1 && settings.LocationRibbon == 1)
                {
                    lblNameAndQuant.Text = ug.Rows[e.RowIndex].Cells["ItemName"].Value.ToString() + " / Sasia e disponueshme: " + Warehouse.GetbyId(id).InStock + ((Globals.ItemLocation.Find(p => p.Id == item.Location)?.Name != null) ? " / Lokacioni: " + Globals.ItemLocation.Find(p => p.Id == item.Location).Name : "");
                }



            }
            else if (senderGrid.Columns[e.ColumnIndex].Index == ug.Columns["ForReturn"].Index && senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                if (ug.IsCurrentCellDirty)
                {// 
                    ug.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }

                if ((bool)ug[24, e.RowIndex].Value == true)
                {
                    var opt = MessageBox.Show($"A jeni te sigurt qe deshironi ta ktheni artikullin: {ug.Rows[e.RowIndex].Cells["ItemName"].Value.ToString()}", "Kthim", MessageBoxButtons.YesNo);
                    if (opt.ToString() == "Yes")
                    {
                        if (settings.FiscalPrinterType == "Tremol")
                        {
                            if (Convert.ToDecimal(ug[20, e.RowIndex].Value) <= Convert.ToDecimal(txtTotalSum.Text) - Convert.ToDecimal(ug[20, e.RowIndex].Value))
                            {
                                mTotalSum = Convert.ToDecimal(txtTotalSum.Text) - 2 * (Convert.ToDecimal(ug[20, e.RowIndex].Value));
                                txtTotalSum.Text = mTotalSum.ToString();
                                txtTotalWVatSum.Text = (Math.Round(Convert.ToDecimal(txtTotalWVatSum.Text) - 2 * ((Convert.ToDecimal(ug[19, e.RowIndex].Value)) * Convert.ToDecimal(ug[6, e.RowIndex].Value)), 2)).ToString();
                                //row.DefaultCellStyle.BackColor = Color.Brown;
                                //row.DefaultCellStyle.ForeColor = Color.White;
                            }
                            else
                            {
                                MessageBox.Show("Vlera e kthimit nuk duhet te jete me madhe sesa totali!");
                                ug[24, e.RowIndex].Value = 0;
                                ug.RefreshEdit();

                            }
                        }
                        else if (settings.FiscalPrinterType == "Datecs")
                        {
                            if (Convert.ToDecimal(ug[20, e.RowIndex].Value) < Convert.ToDecimal(txtTotalSum.Text) - Convert.ToDecimal(ug[20, e.RowIndex].Value))
                            {
                                mTotalSum = Convert.ToDecimal(txtTotalSum.Text) - 2 * (Convert.ToDecimal(ug[20, e.RowIndex].Value));
                                txtTotalSum.Text = mTotalSum.ToString();
                                txtTotalWVatSum.Text = (Math.Round(Convert.ToDecimal(txtTotalWVatSum.Text) - 2 * ((Convert.ToDecimal(ug[19, e.RowIndex].Value)) * Convert.ToDecimal(ug[6, e.RowIndex].Value)), 2)).ToString();
                                //row.DefaultCellStyle.BackColor = Color.Brown;
                                //row.DefaultCellStyle.ForeColor = Color.White;
                            }
                            else if (Convert.ToDecimal(ug[20, e.RowIndex].Value) == Convert.ToDecimal(txtTotalSum.Text) - Convert.ToDecimal(ug[20, e.RowIndex].Value))
                            {


                                mTotalSum = Convert.ToDecimal(txtTotalSum.Text) - 2 * (Convert.ToDecimal(ug[20, e.RowIndex].Value));

                                //mTotalSum += 0.01m;
                                txtTotalSum.Text = mTotalSum.ToString();
                                txtTotalWVatSum.Text = (Math.Round(Convert.ToDecimal(txtTotalWVatSum.Text) - 2 * ((Convert.ToDecimal(ug[19, e.RowIndex].Value)) * Convert.ToDecimal(ug[6, e.RowIndex].Value)), 2)).ToString();

                                //ktu duhet me e gjeneralizu per qdo kompani me e pas ni artikull me vler 0.01eur 
                                if (settings.BarcMode == 0)
                                {
                                    txtsrch.Text = "11";
                                    txtsrch.Focus(); SendKeys.Send("{ENTER}");
                                }
                                else
                                {
                                    txtsrchB.Text = "11";
                                    txtsrchB.Focus(); SendKeys.Send("{ENTER}");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Vlera e kthimit nuk duhet te jete me madhe sesa totali!");
                                ug[24, e.RowIndex].Value = 0;
                                ug.RefreshEdit();

                            }
                        }


                    }
                    else
                    {
                        ug[24, e.RowIndex].Value = 0;
                        ug.RefreshEdit();

                    }


                }
                else
                {

                    txtTotalSum.Text = (Convert.ToDecimal(txtTotalSum.Text) + 2 * (Convert.ToDecimal(ug[20, e.RowIndex].Value))).ToString();
                    txtTotalWVatSum.Text = (Math.Round(Convert.ToDecimal(txtTotalWVatSum.Text) + 2 * ((Convert.ToDecimal(ug[19, e.RowIndex].Value)) * Convert.ToDecimal(ug[6, e.RowIndex].Value)), 2)).ToString();
                    //row.DefaultCellStyle.BackColor = Color.White;
                    //row.DefaultCellStyle.ForeColor = Color.Black;

                }
            }

            if (ug.Rows.Count == 0)
            {
                lblNameAndQuant.Text = " ";
            }
            AdjustTblTotalColumnWidths();
        }

        private void txtTotalSum_TextChanged(object sender, EventArgs e)
        {
            mPaymentDialog.numToPayReal = mTotalSum;
            mPaymentDialog.numTotalForPayment.Text = totaltoPay.ToString();
            displayInfo.numTotalForPayment.Text = totaltoPay.ToString();

        }

        private void PosRestaurant_CursorChanged(object sender, EventArgs e)
        {
            //txtsrch.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLocalTime().ToString();

        }

        public void ReloadForm()
        {
            var settings = Services.Settings.Get();
            string tableID = this.tableId;
            if (ug.Columns.Contains(" ") == true)
            {
                ug.Columns.RemoveAt(27);
            }
            this.tableId = tableID;

            PosSales_Load(null, EventArgs.Empty);
        }
        public void ReOpenForm()
        {
            this.Close();

            Globals.NextStep = "RestaurantPos" + tableId;

        }
        int count = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {

            //if (Options.flag == true)
            //{
            //    timer2.Stop();

            //    Globals.NextStep = "PosRestaurant";
            //    this.Close();

            //    timer2.Start();
            //    Options.flag = false;
            //}

            Test_Click(null,null);
            count++;
        }

        private void btnDirectPay_Click(object sender, EventArgs e)
        {
            try
            {
                //Settings sett = Services.Settings.Get();

                if (cbPartners.SelectedItem != null)
                {
                    if (ug.Rows.Count > 0)
                    {

                        mSaleId = SaveDirectSales();
                        ////save sales details                     
                        int rows = SaveSaleDetails(mSaleId);
                        //List<Services.Payment> payments = new List<Services.Payment>();
                        Services.Payment pmt = new Services.Payment();
                        pmt.AmountPaid = mTotalSum;
                        pmt.SaleId = this.mSaleId;
                        List<Payment> pm = new List<Payment>();
                        pm.Add(new Services.Payment
                        {
                            SaleId = this.mSaleId,
                            BankId = pmt.BankId,
                            AmountPaid = pmt.AmountPaid
                        });
                        Payment.BatchInsert(pm);
                        //payments.Add(pmt);
                        //foreach (var payment in payments)
                        //{
                        //    payment.SaleId = this.mSaleId;
                        //    payment.Insert();
                        //}
                        //print invoice                        
                        PrintDirectPayF();
                        //change sale status . Now sale is ready for sync
                        Services.Sale.ChngStatus(mSaleId, 0);


                        if (ug.Columns.Contains(" ") == true)
                        {
                            ug.Columns.RemoveAt(27);
                        }

                        countNumFiscal++;
                        lblFiscalCount.Text = (Convert.ToInt32(lblFiscalCount.Text) + 1).ToString();
                        ClearFields();
                        txtDiscount.Text = "0.0";
                        txt.Text = "";
                        lblNameAndQuant.Text = "";


                    }
                    else
                    {
                        MessageBox.Show(paragraph_invoice_error.Text);
                    }
                }
                else
                {
                    MessageBox.Show(word_select_the_client.Text);
                }
                //if (Globals.Settings.StockWMinus == "0")
                //{
                //    mAllItems = Services.Item.GetItemsDiscount(Globals.Station.ParentId);

                //}
                //else
                //{
                //    mAllItems = Services.Item.GetAllItem();

                //}

            }
            catch (Exception ex)
            {
                TrackError.ReportError(ex.Message);

            }
        }
        public DailyOpenCloseBalance lastdaily = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(Globals.User.Id);

        public int SaveDirectSales()
        {
            var st = StationService.Get(Globals.Station.Id);
            Services.Sale sale = new Sale();

            if (cbPartners.SelectedItem != null)
                sale.PartnerId = (int)cbPartners.SelectedValue;
            else
                sale.PartnerId = Globals.Settings.DefaultClientId;

            sale.Date = DateTime.Now.ToLocalTime();
            sale.PosId = Globals.Station.Id;
            sale.StationId = Globals.ParentStationId;
            sale.TotalSum = Math.Round(mTotalSum, 2);
            sale.VatSum = mVatSum;

            sale.Comment = "";

            int result = 0;

            if (mSaleId == 0)
            {
                //tipi i shitjes me POS kupon
                sale.SalesTypeId = 1;
                sale.CreatedAt = DateTime.Now.ToLocalTime();
                sale.CreatedBy = Globals.User.Name;
                sale.Status = -1;
                sale.SaleId = Sale.getAllSales().Count > 0 ? Sale.getAllSales().Last().SaleId + 1 : Globals.Station.LastInvoiceNumber + 1;


                //while (result == 0)
                //{
                sale.InvoiceNo = Globals.Station.Id + "-" + sale.SaleId;


                //    result = sale.Insert();
                //    sale.SaleId++;

                //}


                //StationService.UpdateLastInvoiceNumber(sale.SaleId, Globals.Station.Id);

                //StationService.UpdateLastInvoiceNumber(sale.SaleId, Globals.Station.Id);

                //Services.Sale.IdSaler(sale.Id, Globals.User.Id);

                //Services.Sale.IdSaler(sale.Id, Globals.User.Id);
                sale.id_saler = Globals.User.Id;
                DailyOpenFiscalCount += 1;
                var daily = new DailyOpenCloseBalance();
                totalSumOpenBalance = sale.TotalSum + lastdaily.TotalShitje;
                var totalcash = 0.0m;

                totalcash += lastdaily.TotalCash + sale.TotalSum;

                var totalcredit = lastdaily.TotalCreditCard;
                OverallObj overallObj = new OverallObj
                {
                    sale = sale,
                    LastInvoiceNumber = sale.SaleId,
                    stationId = Globals.Station.Id,
                    id_saler = Globals.User.Id,
                    saleId = sale.SaleId,
                    dailyId = lastdaily.Id,
                    DailyFiscalCount = DailyOpenFiscalCount,
                    TotalShitje = totalSumOpenBalance,
                    TotalCash = totalcash,
                    TotalCreditCard = totalcredit,
                    status = sale.Status.ToString()
                };
                result = overallObj.UpdateA();
                if (result > 0)
                    return overallObj.Id;
                else
                {
                    MessageBox.Show("Fatura nuk munde te ruhet! Ju lutem kontaktoni administratorin!");
                    return -1;
                }
                //daily.UpdateDFC(DailyOpenFiscalCount.ToString(), totalSumOpenBalance, totalcash, totalcredit, lastdaily.Id);
            }
            else
            {
                sale.ChangedAt = DateTime.Now;
                sale.ChangedBy = Globals.User.FirstName;
                //result = sale.Update();

            }
            if (result > 0)
                return sale.Id;
            else
            {
                MessageBox.Show(paragraph_invoice_cannotbesaved_.Text);
                return -1;
            }
        }
        protected void PrintDirectPayF()
        {

            System.Data.DataTable dt = new System.Data.DataTable();
            foreach (DataGridViewColumn col in ug.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in ug.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            Services.Sale sale = Services.Sale.Get(mSaleId);
            //Shiko a eshte shtypur fatura ne printer fiskal?
            if (sale == null)
            {
                return;
            }
            decimal totalsum = Convert.ToDecimal(txtTotalSum.Text);//Convert.ToDecimal(txtDisplay1.Text);
            if (sale.Printed)
            {
                if (MessageBox.Show(report_invoici.Text + sale.SaleId + word_print_again_ask.Text,
                    word_print_the_coupon.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            if (ug.Rows.Count < 1)
            {
                MessageBox.Show(paragraph_no_item_invoice.Text);
                return;
            }

            if (Convert.ToDecimal(Convert.ToDecimal(txtTotalSum.Text)) == 0M)
            {
                MessageBox.Show(paragraph_fisc_with_zero.Text);
                return;
            }

            var withBank = 0;
            var clientPayed = mPaymentDialog.clientPayed;

            if (mPaymentDialog.TotalCreditCard > 0)
                withBank = 3;

            if (Globals.Settings.PosPrinter == "1")
            {
                if (Globals.Settings.PrintingType == "Termal")
                {
                    PrintThermal();
                }
                else
                {
                    if (Globals.Settings.FiscalPrinterType == "Tremol")
                    {
                        if (TremolPrint.CreateReceipt(dt, clientPayed))
                        {
                            Services.SaleDetails.UpdatePrinted(mSaleId);
                        }
                        Globals.Settings.UpdateFC(lblFiscalCount.Text, Globals.Settings.Id);

                    }
                    else
                    {
                        FiscalPrinterHelper.GekosPrint(sale.Id, sale.InvoiceNo, dt, mTotalSum, sale.SaleId, withBank,clientPayed);
                        //LoadJson.DataTabletoJsonDatecs(dt);

                        int x = 0;

                        Int32.TryParse(txtTotalSum.Text, out x);

                        //FiscalProperties(x, countNumFiscal, Convert.ToInt32(mTotalSum), 0);
                        Globals.Settings.UpdateFC(lblFiscalCount.Text, Globals.Settings.Id);

                    }
                    if (Globals.Settings.ThermalPrinterName != null)
                    {
                        PrintThermal();
                    }
                }


            }


        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            var ping = PingHost("planetaccounting.org");

            if (ping)
            {
                AddPartner addp = new AddPartner();

                addp.ShowDialog();

                ReloadForm();
            }
            else
            {
                MessageBox.Show("Duhet te kyqeni ne internet per te shtuar klient!");
            }

        }
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        private void btnnInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPartners.SelectedItem != null)
                {
                    if (ug.Rows.Count > 0)
                    {
                        DialogResult dialogResult = mPaymentDialog.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            foreach (DataGridViewColumn col in ug.Columns)
                            {
                                dt.Columns.Add(col.Name);
                            }

                            foreach (DataGridViewRow row in ug.Rows)
                            {
                                DataRow dRow = dt.NewRow();
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    dRow[cell.ColumnIndex] = cell.Value;
                                }
                                dt.Rows.Add(dRow);
                            }
                            mSaleId = SaveSaleInvoice();



                            if (mSaleId == -1)
                            {
                                if (ug.Columns.Contains(" ") == true)
                                {
                                    ug.Columns.RemoveAt(27);
                                }

                                countNumFiscal++;
                                ClearFields();
                                txtDiscount.Text = "0.0";
                                return;


                            }
                            else
                            {
                                Modules.Email emailF = new Modules.Email();
                                emailF.saleId = mSaleId;
                                emailF.ShowDialog();

                            }
                            //save sales details
                            int rows = SaveSaleDetails(mSaleId);
                            SavePayment();
                            //print invoice
                            PrintF();
                            //change sale status . Now sale is ready for sync
                            Services.Sale.ChngStatus(mSaleId, 0);

                            //if (rows > 0)
                            //{
                            //    //AutoClosingMessageBox.Show(paragraph_sale_saved_successfuly.Text, "Info!", 1100);
                            //}

                            if (ug.Columns.Contains(" ") == true)
                            {
                                ug.Columns.RemoveAt(27);
                            }

                            countNumFiscal++;
                            ClearFields();
                            txtDiscount.Text = "0.0";


                            data = dt;
                            AutoClosingMessageBox.Show("Shitja u ruaj me sukses!", "Success!", 1000);

                            Invoice invoice = new Invoice();
                            invoice.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Zgjedhni nje Klient!");

                        }

                    }
                    else
                    {
                        MessageBox.Show("Nuk mund te ruhet pa Artikuj!");

                    }


                }
            }
            catch (Exception ex)
            {

                Error error = new Error();
                error.File = ex.StackTrace.ToString();
                error.Message = ex.Message;
                error.Line = ex.StackTrace.ToString();
                error.Company_Id = Globals.Settings.Id;
                error.Station_Id = Globals.Station.Id;
                error.Insert();
            }

        }

        private void cbPartners_SelectedIndexChanged(object sender, EventArgs e)
        {
            var settings = Services.Settings.Get();
            try
            {
                if (cbPartners.SelectedValue != null)
                {
                    if (PartnerId != (int)cbPartners.SelectedValue)
                    {
                        PartnerId = (int)cbPartners.SelectedValue;
                        decimal clientDiscount = Partner.Get(PartnerId).Discount;
                        if (settings.AllowDiscount != "1")
                        {
                            if (clientDiscount > 0)
                            {
                                lblClientDisc.Visible = true;
                                lblClientDisc.Text = "Klienti ka " + clientDiscount.ToString() + " % zbritje totale!";

                            }
                            else
                            {
                                lblClientDisc.Text = "";

                            }
                        }


                        if (ug.Rows.Count > 0 && settings.AllowDiscount == "0")
                        {
                            RecalculateDgValues(clientDiscount);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void RecalculateDgValues(decimal discount)
        {
            var totalsum = 0.0m;
            var totalsumWVat = 0.0m;
            var totalDiscount = 0.0m;
            foreach (DataGridViewRow row in ug.Rows)
            {
                decimal total = (decimal)row.Cells["TotalWithVat"].Value;
                decimal totalV = (decimal)row.Cells["Total"].Value;
                decimal vatsum = (decimal)row.Cells["VatSum"].Value;
                decimal qmimi = (decimal)row.Cells[14].Value;
                decimal quantity = (decimal)row.Cells[6].Value;
                decimal itemDiscount = (decimal)row.Cells[12].Value;

                row.Cells["TotalWithVat"].Value = discount > 0 ? Math.Round(total - (total * discount / 100), 2) : Math.Round(((qmimi - (qmimi * itemDiscount / 100)) * quantity), 2);
                row.Cells["ClientDiscount"].Value = discount > 0 ? discount : 0;
                totalsum += (decimal)row.Cells["TotalWithVat"].Value;
                decimal pricePaVat = (totalV - (totalV * itemDiscount / 100)) * quantity;

                totalsumWVat += discount > 0 ? Math.Round((pricePaVat - (pricePaVat * discount / 100)), 2) : Math.Round((pricePaVat), 2);
                decimal discountValue = (quantity * qmimi) * itemDiscount / 100;
                var clientDiscountValue = ((qmimi * quantity) - discountValue) * discount / 100;
                totalDiscount += discountValue + clientDiscountValue;
            }
            txtTotalSum.Text = totalsum.ToString("N");
            txtTotalWVatSum.Text = totalsumWVat.ToString("N");
            txtDiscount.Text = totalDiscount.ToString("N");
        }

        private void txtsrchB_Enter(object sender, EventArgs e)
        {
            txtB.ForeColor = Color.Black;

            if (txtB.Text == "Emri,Çmimi,Shifra")
            {
                txtB.Text = "";
            }
        }

        private void txtSearchName_Enter(object sender, EventArgs e)
        {
            txt.ForeColor = Color.Black;

            if (txt.Text == "Emri,Çmimi,Shifra")
            {
                txt.Text = "";
            }

        }

        private void txtSearchName_Leave(object sender, EventArgs e)
        {
            txt.ForeColor = Color.Gray;

            if (txt.Text == "")
            {
                txt.Text = "Emri,Çmimi,Shifra";
            }

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            txtsearch.Cursor = Cursors.Arrow;

            if (txt.Text != "Emri,Çmimi,Shifra" && txt.Text != "")
            {
                if (ug.Columns.Contains(" ") == false)
                {
                    DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                    col.UseColumnTextForButtonValue = true;
                    col.Name = " ";
                    ug.Columns.Add(col);

                }
                try
                {
                    var item = Services.Item.GetItemWithName(txt.Text.ToLower()).ToList();

                    txtsearch.DataSource = item.Count > 0 ? item : null;
                    txtsearch.DisplayMember = "ItemName";
                    txtsearch.ValueMember = "Id";
                    AutosizeDropdown(txtsearch);
                    txtsearch.DroppedDown = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Nuk ka artikull me kete barkod!");
                }

                //BindComboboxAsync(txt.Text);
            }
        }
        private void AutosizeDropdown(System.Windows.Forms.ComboBox comboBox)
        {
            txtsearch.Cursor = Cursors.Arrow;

            int maxWidth = 0;

            if (comboBox.Items.Count > 0)
            {
                foreach (var item in comboBox.Items)
                {
                    var itemName = ((ItemsDiscount)item).ItemName;
                    int itemWidth = TextRenderer.MeasureText(itemName.ToString(), comboBox.Font).Width;
                    maxWidth = Math.Max(maxWidth, itemWidth);
                }

                comboBox.DropDownWidth = maxWidth;
            }

        }
        private async void BindComboboxAsync(string t)
        {
            var dataSource = await System.Threading.Tasks.Task.Run(() =>
            {
                // Load the data source here
                return GetDataSource(t);
            });

            txtsearch.DataSource = dataSource;
            txtsearch.DroppedDown = true;
            txtsearch.ValueMember = "Id";
        }

        private List<ItemsDiscount> GetDataSource(string text)
        {
            var item = mAllItems.Where(p => p.ItemName.ToLower().Contains(text.ToLower())).ToList();
            List<ItemsDiscount> element = new List<ItemsDiscount>();
            if (item.Count > 15)
            {
                for (int i = 0; i < 15; i++)
                {
                    element.Add(item[i]);
                }
            }
            else
            {
                element = item;
            }

            return element;
        }

        private void txtSearchName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var settings = Services.Settings.Get();
            try
            {
                var name = txtsearch.SelectedValue != null ? Services.Item.GetById((int)txtsearch.SelectedValue).First() : null;
                bool found = false;
                int searchValue = name.Id;

                var clientDiscount = Partner.Get(PartnerId).Discount;

                var itemAction = aksionet.Find(p => p.item_id == name.Id);
                var categoryAction = aksionet.Find(p => p.category_id == name.CategoryId);
                if (name.Service == 0)
                {


                    var availableStock = Globals.Settings.StockWMinus == "0" ? Warehouse.GetbyId(name.Id).InStock : 0;


                    if (itemAction != null && settings.AllowDiscount == "0")
                    {
                        var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                        var totalPrice = tp - (tp * clientDiscount / 100);
                        if (itemAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                        {
                                            if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                                row.Cells["Discount"].Value = itemAction.discount;
                                                txtsrch.Text = "";
                                            }
                                            else
                                            {
                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                txtsrch.Text = "";

                                            }
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                                            row.Cells["Discount"].Value = itemAction.discount;
                                                            txtsrch.Text = "";
                                                        }
                                                        else
                                                        {
                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txtsrch.Text = "";

                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}!");
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }


                                }
                                if (!found)
                                {
                                    name.Discount = itemAction.discount;
                                    AddItem(name);
                                    txtsrch.Text = "";
                                    CalculateGridColumns();


                                }
                            }
                            else
                            {
                                name.Discount = itemAction.discount;
                                AddItem(name);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                        {
                                            if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                                row.Cells["Discount"].Value = itemAction.discount;
                                                txtsrch.Text = "";


                                            }
                                            else
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                txtsrch.Text = "";

                                            }
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                                            row.Cells["Discount"].Value = itemAction.discount;
                                                            txtsrch.Text = "";


                                                        }
                                                        else
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txtsrch.Text = "";

                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}!");
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }

                                }
                                if (!found)
                                {
                                    AddItem(name);
                                    txtsrch.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                AddItem(name);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                    }



                    else if (categoryAction != null && settings.AllowDiscount == "0")
                    {
                        var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                        var totalPrice = tp - (tp * clientDiscount / 100);
                        if (categoryAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                        {
                                            if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                                row.Cells["Discount"].Value = categoryAction.discount;
                                                txtsrch.Text = "";

                                            }
                                            else
                                            {
                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                txtsrch.Text = "";

                                            }
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                                            row.Cells["Discount"].Value = categoryAction.discount;
                                                            txtsrch.Text = "";

                                                        }
                                                        else
                                                        {
                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txtsrch.Text = "";

                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}!");
                                            }
                                        }

                                        CalculateGridColumns();
                                        found = true;

                                    }

                                }
                                if (!found)
                                {
                                    name.Discount = categoryAction.discount;
                                    AddItem(name);
                                    txtsrch.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                name.Discount = categoryAction.discount;
                                AddItem(name);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                        {
                                            if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                                row.Cells["Discount"].Value = categoryAction.discount;
                                                txtsrch.Text = "";

                                            }
                                            else
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                txtsrch.Text = "";


                                            }
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                                            row.Cells["Discount"].Value = categoryAction.discount;
                                                            txtsrch.Text = "";

                                                        }
                                                        else
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txtsrch.Text = "";


                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}!");
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }


                                }
                                if (!found)
                                {
                                    AddItem(name);
                                    txtsrch.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                AddItem(name);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                    }
                    else
                    {
                        if (ug.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in ug.Rows)
                            {
                                if (row.Cells[3].Value.ToString() == name.ItemName)
                                {
                                    if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                    {
                                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                                        var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                                        var totalPrice = tp - (tp * clientDiscount / 100);

                                        if ((decimal)row.Cells["Discount"].Value != 0)
                                        {
                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);
                                            txtsrch.Text = "";


                                        }
                                        else
                                        {
                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                            txtsrch.Text = "";
                                        }

                                        var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                        var totalWVat = Convert.ToDecimal(row.Cells["Total"].Value);
                                        mTotalSum = total;
                                        mTotalSumWVat = totalWVat;
                                        txtTotalSum.Text = mTotalSum.ToString();
                                    }
                                    else
                                    {
                                        if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                        {
                                            if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                            {
                                                EnterPin enter = new EnterPin();
                                                enter.ShowDialog();
                                                if (enter.flag == true)
                                                {
                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                                                    var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                                                    var totalPrice = tp - (tp * clientDiscount / 100);

                                                    if ((decimal)row.Cells["Discount"].Value != 0)
                                                    {
                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);
                                                        txtsrch.Text = "";


                                                    }
                                                    else
                                                    {
                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                        txtsrch.Text = "";
                                                    }

                                                    var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                                    var totalWVat = Convert.ToDecimal(row.Cells["Total"].Value);
                                                    mTotalSum = total;
                                                    mTotalSumWVat = totalWVat;
                                                    txtTotalSum.Text = mTotalSum.ToString();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}!");
                                        }
                                    }


                                    found = true;
                                    CalculateGridColumns();
                                    AdjustTblTotalColumnWidths();
                                    return;
                                }

                            }
                            if (!found)
                            {
                                AddItem(name);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {
                            //add found item
                            var item = name;
                            AddItem(item);
                            txtsrch.Text = "";
                            CalculateGridColumns();


                        }
                    }
                    txt.Text = "";

                }
                else
                {
                    if (itemAction != null && settings.AllowDiscount == "0")
                    {
                        var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                        var totalPrice = tp - (tp * clientDiscount / 100);
                        if (itemAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                            row.Cells["Discount"].Value = itemAction.discount;
                                            txtsrch.Text = "";
                                        }
                                        else
                                        {
                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                            txtsrch.Text = "";

                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }


                                }
                                if (!found)
                                {
                                    name.Discount = itemAction.discount;
                                    AddItem(name);
                                    txtsrch.Text = "";
                                    CalculateGridColumns();


                                }
                            }
                            else
                            {
                                name.Discount = itemAction.discount;
                                AddItem(name);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                            row.Cells["Discount"].Value = itemAction.discount;
                                            txtsrch.Text = "";


                                        }
                                        else
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                            txtsrch.Text = "";

                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }

                                }
                                if (!found)
                                {
                                    AddItem(name);
                                    txtsrch.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                AddItem(name);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                    }



                    else if (categoryAction != null && settings.AllowDiscount == "0")
                    {
                        var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                        var totalPrice = tp - (tp * clientDiscount / 100);
                        if (categoryAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                            row.Cells["Discount"].Value = categoryAction.discount;
                                            txtsrch.Text = "";

                                        }
                                        else
                                        {
                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                            txtsrch.Text = "";

                                        }
                                        CalculateGridColumns();
                                        found = true;

                                    }

                                }
                                if (!found)
                                {
                                    name.Discount = categoryAction.discount;
                                    AddItem(name);
                                    txtsrch.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                name.Discount = categoryAction.discount;
                                AddItem(name);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                            row.Cells["Discount"].Value = categoryAction.discount;
                                            txtsrch.Text = "";

                                        }
                                        else
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                            txtsrch.Text = "";


                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }


                                }
                                if (!found)
                                {
                                    AddItem(name);
                                    txtsrch.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                AddItem(name);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                    }
                    else
                    {
                        if (ug.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in ug.Rows)
                            {
                                if (row.Cells[3].Value.ToString() == name.ItemName)
                                {
                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                                    var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                                    var totalPrice = tp - (tp * clientDiscount / 100);

                                    if ((decimal)row.Cells["Discount"].Value != 0)
                                    {
                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);
                                        txtsrch.Text = "";


                                    }
                                    else
                                    {
                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                        txtsrch.Text = "";
                                    }


                                    var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                    var totalWVat = Convert.ToDecimal(row.Cells["Total"].Value);
                                    mTotalSum = total;
                                    mTotalSumWVat = totalWVat;
                                    txtTotalSum.Text = mTotalSum.ToString();
                                    found = true;
                                    CalculateGridColumns();
                                    AdjustTblTotalColumnWidths();
                                    return;
                                }

                            }
                            if (!found)
                            {
                                AddItem(name);
                                txtsrch.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {
                            //add found item
                            var item = name;
                            AddItem(item);
                            txtsrch.Text = "";
                            CalculateGridColumns();


                        }
                    }
                    txt.Text = "";
                }
            }

            catch (Exception ex)
            {

            }

        }

        private void ug_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (ug.Columns[e.ColumnIndex].Name == "Quantity")
            {
                if (!double.TryParse(e.FormattedValue.ToString(), out double result))
                {
                    e.Cancel = true;
                    MessageBox.Show("Nuk mund te vendosni shkronja ne kolonen e Sasisë!");
                    //ug[e.ColumnIndex, e.RowIndex].Value = 1m;


                }
                else
                {
                    if (result % 1 == 0)
                    {
                        // Add "00" to the value
                        ug[e.ColumnIndex, e.RowIndex].Value = result.ToString() + ".00";
                    }
                }

                if (e.FormattedValue.ToString() == "0")
                {
                    e.Cancel = true;
                    MessageBox.Show("Nuk lejohet shitja e artikullit me Sasi zero!");
                }
            }
            if (ug.Columns[e.ColumnIndex].Name == "Discount")
            {
                double discount;
                if (!double.TryParse(e.FormattedValue.ToString(), out discount))
                {
                    e.Cancel = true;
                    MessageBox.Show("Nuk mund te vendosni shkronja ne kolonen e Zbritjes! ");
                }
                else if (Convert.ToDouble(e.FormattedValue) < 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("Nuk lejohet shitja e artikullit me zbritje negative!");
                }
            }
        }
        public void InsertOrderDetails()
        {
            foreach (DataGridViewRow item in ug.Rows)
            {


                Services.Models.TablesSaleDetails details = new Services.Models.TablesSaleDetails();
                details.ItemId = (int)item.Cells["ItemId"].Value;
                details.No = (int)item.Cells["No"].Value;
                details.tableId = Convert.ToInt32(tableId);
                details.ItemName = item.Cells["ItemName"].Value.ToString();
                details.Barcode = item.Cells["Barcode"].Value.ToString();
                details.Unit = item.Cells["Unit"].Value.ToString();
                details.QuantityNow = (decimal)item.Cells["QuantityNow"].Value;

                details.Quantity = (decimal)item.Cells["Quantity"].Value;
                details.Price = (decimal)item.Cells["Price"].Value;
                details.AvgPrice = (decimal)item.Cells["AvgPrice"].Value;
                details.Vat = (int)item.Cells["Vat"].Value;
                details.CategoryId = (decimal)item.Cells["CostOfGoods"].Value;
                details.Discount = (decimal)item.Cells["Discount"].Value;
                details.DiscountPrice = (decimal)item.Cells["DiscountPrice"].Value;
                details.DiscountPriceWithVat = (decimal)item.Cells["DiscountPriceWithVat"].Value;
                details.TotalWithVatAvg = (decimal)item.Cells["TotalWithVatAvg"].Value;
                details.VatSum = (decimal)item.Cells["VatSum"].Value;
                details.VatPrice = (decimal)item.Cells["VatPrice"].Value;
                details.Total = (decimal)item.Cells["Total"].Value;
                details.TotalWithVat = (decimal)item.Cells["TotalWithVat"].Value;
                int status = (int)item.Cells["Status"].Value;
                details.ClientDiscount = Partner.Get(PartnerId).Discount;
                details.Sale_Id = 0;
                //details.PrintedFiscalQuantity = (int)details.Quantity;

                var result = details.Insert();

                if (result == 0)
                {

                    details.UpdateTableItem(details.Quantity, details.Total, details.TotalWithVat, details.ItemName);
                }


            }
            Services.Tables.UpdateTotalInPos(mTotalSum.ToString(), tableId);
        }
        private void btnSignOut_Click(object sender, EventArgs e)
        {

            Globals.NextStep = "Restaurant";
            //Services.StationService.UnLockUserStation(Globals.User.Id, Globals.DeviceId);
            //Services.Tables.UpdateTablePos(0, tableName);
            InsertOrderDetails();

            if (Globals.Settings.PosPrinter == "1")
            {
                PrintRestaurantThermal();
                Services.Models.TablesSaleDetails.UpdateTableSDPrinted(1, tableId);

            }

            this.Close();
        }

        private void smlLogo_Click(object sender, EventArgs e)
        {
            if (Globals.Settings.PIN == "0" || Globals.Settings.PIN == null)
            {
                ReOpenForm();

            }
            else
            {
                EnterPin enter = new EnterPin();
                enter.ShowDialog();

                if (enter.flag == true)
                {
                    ReOpenForm();

                }
            }
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            txtsearchB.DroppedDown = false;

            txtsearchB.Cursor = Cursors.Arrow;
            List<ItemsDiscount> item = null;
            try
            {
                if (txtB.Text != "Emri,Çmimi,Shifra" && txtB.Text != "")
                {
                    if (ug.Columns.Contains(" ") == false)
                    {
                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.UseColumnTextForButtonValue = true;
                        col.Name = " ";
                        ug.Columns.Add(col);

                    }
                    if (Globals.Settings.BarcMode == 0)
                    {
                        item = mAllItems.Where(p => p.ItemName.ToLower().Contains(txtB.Text.ToLower()) || p.ProductNo.Contains(txtB.Text)).ToList();

                    }
                    else
                    {
                        item = Services.Item.GetItemWithName(txtB.Text.ToLower());
                    }

                    txtsearchB.DataSource = item;
                    txtsearchB.DisplayMember = "ItemName";
                    txtsearchB.ValueMember = "Id";
                    AutosizeDropdown(txtsearchB);
                    if (item.Count > 0)
                    {
                        txtsearchB.DroppedDown = true;

                    }
                    else
                    {
                        txtsearchB.DroppedDown = false;

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Nuk ka artikuj me kete emer!");
            }
        }

        private void txtB_Leave(object sender, EventArgs e)
        {
            txtB.ForeColor = Color.Gray;

            if (txtB.Text == "")
            {
                txtB.Text = "Emri,Çmimi,Shifra";
            }
        }

        private void txtsearchB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var clientDiscount = Partner.Get(PartnerId).Discount;
                var settings = Services.Settings.Get();
                ItemsDiscount name = null;
                //if (txtsearchB.Items.Count > 0)
                //{

                //    if (txtsearchB.SelectedValue != null)
                //    {
                if (settings.BarcMode == 0)
                {
                    name = mAllItems.Find(p => p.Id == (int)txtsearchB.SelectedValue);
                }
                else
                {
                    var currentIt = Services.Item.GetById((int)txtsearchB.SelectedValue);
                    name = currentIt.First();
                }
                bool found = false;
                int searchValue = name.Id;


                var itemAction = aksionet.Find(p => p.item_id == name.Id);
                var categoryAction = aksionet.Find(p => p.category_id == name.CategoryId);
                if (name.Service == 0)
                {


                    var availableStock = Globals.Settings.StockWMinus == "0" ? Warehouse.GetbyId(name.Id).InStock : 0;

                    if (itemAction != null && settings.AllowDiscount == "0")
                    {
                        var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                        var totalPrice = tp - (tp * clientDiscount / 100);
                        if (itemAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && settings.StockWMinus == "0")
                                        {
                                            if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                                row.Cells["Discount"].Value = itemAction.discount;
                                                txtsrchB.Text = "";
                                            }
                                            else
                                            {
                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                txtsrchB.Text = "";

                                            }
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                                            row.Cells["Discount"].Value = itemAction.discount;
                                                            txtsrchB.Text = "";
                                                        }
                                                        else
                                                        {
                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txtsrchB.Text = "";

                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}!");
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }


                                }
                                if (!found)
                                {
                                    name.Discount = itemAction.discount;
                                    AddItem(name);
                                    txtsrchB.Text = "";
                                    CalculateGridColumns();


                                }
                            }
                            else
                            {
                                name.Discount = itemAction.discount;
                                AddItem(name);
                                txtsrchB.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && settings.StockWMinus == "0")
                                        {
                                            if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                                row.Cells["Discount"].Value = itemAction.discount;
                                                txtsrchB.Text = "";


                                            }
                                            else
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                txtsrchB.Text = "";

                                            }
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                                            row.Cells["Discount"].Value = itemAction.discount;
                                                            txtsrchB.Text = "";


                                                        }
                                                        else
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txtsrchB.Text = "";

                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}!");
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }

                                }
                                if (!found)
                                {
                                    AddItem(name);
                                    txtsrchB.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                AddItem(name);
                                txtsrchB.Text = "";
                                CalculateGridColumns();

                            }
                        }
                    }



                    else if (categoryAction != null && settings.AllowDiscount == "0")
                    {
                        var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                        var totalPrice = tp - (tp * clientDiscount / 100);
                        if (categoryAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && settings.StockWMinus == "0")
                                        {
                                            if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                                row.Cells["Discount"].Value = categoryAction.discount;
                                                txtsrchB.Text = "";

                                            }
                                            else
                                            {
                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                txtsrchB.Text = "";

                                            }
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                                            row.Cells["Discount"].Value = categoryAction.discount;
                                                            txtsrchB.Text = "";

                                                        }
                                                        else
                                                        {
                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txtsrchB.Text = "";

                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}!");
                                            }
                                        }
                                        CalculateGridColumns();
                                        found = true;

                                    }

                                }
                                if (!found)
                                {
                                    name.Discount = categoryAction.discount;
                                    AddItem(name);
                                    txtsrchB.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                name.Discount = categoryAction.discount;
                                AddItem(name);
                                txtsrchB.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && settings.StockWMinus == "0")
                                        {
                                            if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                                row.Cells["Discount"].Value = categoryAction.discount;
                                                txtsrchB.Text = "";

                                            }
                                            else
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                txtsrchB.Text = "";


                                            }
                                        }
                                        else
                                        {
                                            if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                            {
                                                if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                {
                                                    EnterPin enter = new EnterPin();
                                                    enter.ShowDialog();
                                                    if (enter.flag == true)
                                                    {
                                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                                            row.Cells["Discount"].Value = categoryAction.discount;
                                                            txtsrchB.Text = "";

                                                        }
                                                        else
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                            txtsrchB.Text = "";


                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}!");
                                            }
                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }


                                }
                                if (!found)
                                {
                                    AddItem(name);
                                    txtsrchB.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                AddItem(name);
                                txtsrchB.Text = "";
                                CalculateGridColumns();

                            }
                        }
                    }
                    else
                    {
                        if (ug.Rows.Count > 0)
                        {
                            var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                            var totalPrice = tp - (tp * clientDiscount / 100);
                            foreach (DataGridViewRow row in ug.Rows)
                            {
                                if (row.Cells[3].Value.ToString() == name.ItemName)
                                {
                                    if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && settings.StockWMinus == "0")
                                    {
                                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;


                                        if ((decimal)row.Cells["Discount"].Value != 0)
                                        {
                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);
                                            txtsrchB.Text = "";


                                        }
                                        else
                                        {
                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                            txtsrchB.Text = "";
                                        }


                                        var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                        mTotalSum = total;
                                        txtTotalSum.Text = mTotalSum.ToString();
                                    }
                                    else
                                    {
                                        if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                        {
                                            if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                            {
                                                EnterPin enter = new EnterPin();
                                                enter.ShowDialog();
                                                if (enter.flag == true)
                                                {
                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;


                                                    if ((decimal)row.Cells["Discount"].Value != 0)
                                                    {
                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);
                                                        txtsrchB.Text = "";


                                                    }
                                                    else
                                                    {
                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                        txtsrchB.Text = "";
                                                    }


                                                    var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                                    mTotalSum = total;
                                                    txtTotalSum.Text = mTotalSum.ToString();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {name.ItemName}!");
                                        }
                                    }
                                    found = true;
                                    CalculateGridColumns();
                                    AdjustTblTotalColumnWidths();
                                    return;
                                }

                            }
                            if (!found)
                            {
                                AddItem(name);
                                txtsrchB.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {
                            //add found item
                            var item = name;
                            AddItem(item);
                            txtsrchB.Text = "";
                            CalculateGridColumns();


                        }
                    }
                    //    }
                    //}

                }
                else
                {

                    if (itemAction != null && settings.AllowDiscount == "0")
                    {
                        var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                        var totalPrice = tp - (tp * clientDiscount / 100);
                        if (itemAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                            row.Cells["Discount"].Value = itemAction.discount;
                                            txtsrchB.Text = "";
                                        }
                                        else
                                        {
                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                            txtsrchB.Text = "";

                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }


                                }
                                if (!found)
                                {
                                    name.Discount = itemAction.discount;
                                    AddItem(name);
                                    txtsrchB.Text = "";
                                    CalculateGridColumns();


                                }
                            }
                            else
                            {
                                name.Discount = itemAction.discount;
                                AddItem(name);
                                txtsrchB.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                            row.Cells["Discount"].Value = itemAction.discount;
                                            txtsrchB.Text = "";


                                        }
                                        else
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                            txtsrchB.Text = "";

                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }

                                }
                                if (!found)
                                {
                                    AddItem(name);
                                    txtsrchB.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                AddItem(name);
                                txtsrchB.Text = "";
                                CalculateGridColumns();

                            }
                        }
                    }



                    else if (categoryAction != null && settings.AllowDiscount == "0")
                    {
                        var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                        var totalPrice = tp - (tp * clientDiscount / 100);
                        if (categoryAction.quantity == 1)
                        {
                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                            row.Cells["Discount"].Value = categoryAction.discount;
                                            txtsrchB.Text = "";

                                        }
                                        else
                                        {
                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                            txtsrchB.Text = "";

                                        }
                                        CalculateGridColumns();
                                        found = true;

                                    }

                                }
                                if (!found)
                                {
                                    name.Discount = categoryAction.discount;
                                    AddItem(name);
                                    txtsrchB.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                name.Discount = categoryAction.discount;
                                AddItem(name);
                                txtsrchB.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {

                            if (ug.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in ug.Rows)
                                {
                                    if (row.Cells[3].Value.ToString() == name.ItemName)
                                    {
                                        if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                            row.Cells["Discount"].Value = categoryAction.discount;
                                            txtsrchB.Text = "";

                                        }
                                        else
                                        {
                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                            row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                            txtsrchB.Text = "";


                                        }
                                        found = true;
                                        CalculateGridColumns();

                                    }


                                }
                                if (!found)
                                {
                                    AddItem(name);
                                    txtsrchB.Text = "";
                                    CalculateGridColumns();

                                }
                            }
                            else
                            {
                                AddItem(name);
                                txtsrchB.Text = "";
                                CalculateGridColumns();

                            }
                        }
                    }
                    else
                    {
                        if (ug.Rows.Count > 0)
                        {
                            var tp = Math.Round(name.SalePrice + (name.SalePrice * name.Vat / 100), 2);
                            var totalPrice = tp - (tp * clientDiscount / 100);
                            foreach (DataGridViewRow row in ug.Rows)
                            {
                                if (row.Cells[3].Value.ToString() == name.ItemName)
                                {
                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;


                                    if ((decimal)row.Cells["Discount"].Value != 0)
                                    {
                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);
                                        txtsrchB.Text = "";


                                    }
                                    else
                                    {
                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                        txtsrchB.Text = "";
                                    }


                                    var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                    mTotalSum = total;
                                    txtTotalSum.Text = mTotalSum.ToString();
                                    found = true;
                                    CalculateGridColumns();
                                    AdjustTblTotalColumnWidths();
                                    return;
                                }

                            }
                            if (!found)
                            {
                                AddItem(name);
                                txtsrchB.Text = "";
                                CalculateGridColumns();

                            }
                        }
                        else
                        {
                            //add found item
                            var item = name;
                            AddItem(item);
                            txtsrchB.Text = "";
                            CalculateGridColumns();


                        }
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Nuk ka artikull me kete barkod!");
            }


        }
        private void txtsrchB_KeyPress(object sender, KeyPressEventArgs e)
        {
            var settings = Services.Settings.Get();

            var clientDiscount = Partner.Get(PartnerId).Discount;
            bool found = false;

            if (txtsrchB.Text != "")
            {
                var keyPressedEventArgs = e as KeyPressEventArgs;
                if (keyPressedEventArgs != null && keyPressedEventArgs.KeyChar == (char)Keys.Enter)
                {
                    ItemsDiscount foundItems = null;
                    if (settings.BarcMode == 0)
                    {
                        foundItems = mAllItems.Find(p => p.Barcode == txtsrchB.Text);

                    }
                    else
                    {
                        var currentI = Services.Item.GetItemWithBarcode(txtsrchB.Text);
                        foundItems = currentI.Count > 0 ? currentI.First() : null;

                    }


                    if (ug.Columns.Contains(" ") == false)
                    {
                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.UseColumnTextForButtonValue = true;
                        col.Name = " ";
                        ug.Columns.Add(col);
                    }



                    if (foundItems != null)
                    {
                        if (foundItems.Service == 0)
                        {


                            var itemAction = aksionet.Find(p => p.item_id == foundItems.Id);
                            var categoryAction = aksionet.Find(p => p.category_id == foundItems.CategoryId);
                            var availableStock = Globals.Settings.StockWMinus == "0" ? Warehouse.GetbyId(foundItems.Id).InStock : -1;

                            if (itemAction != null && settings.AllowDiscount == "0")
                            {
                                var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                var totalPrice = tp - (tp * clientDiscount / 100);

                                if (itemAction.quantity == 1)
                                {
                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            if (row.Cells[4].Value.ToString() == txtsrchB.Text && txtsrchB.Text != "")
                                            {
                                                if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && availableStock != -1)
                                                {
                                                    if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                    {
                                                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                                        row.Cells["Discount"].Value = itemAction.discount;
                                                        txtsrchB.Text = "";
                                                        CalculateGridColumns();
                                                    }
                                                    else
                                                    {
                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                        txtsrchB.Text = "";
                                                        CalculateGridColumns();

                                                    }
                                                }
                                                else
                                                {
                                                    if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                    {
                                                        if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                        {
                                                            EnterPin enter = new EnterPin();
                                                            enter.ShowDialog();
                                                            if (enter.flag == true)
                                                            {
                                                                if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                                {
                                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                                                    row.Cells["Discount"].Value = itemAction.discount;
                                                                    txtsrchB.Text = "";
                                                                    CalculateGridColumns();
                                                                }
                                                                else
                                                                {
                                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                    txtsrchB.Text = "";
                                                                    CalculateGridColumns();

                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                    }
                                                }
                                                found = true;
                                            }


                                        }
                                        if (!found)
                                        {
                                            foundItems.Discount = itemAction.discount;
                                            AddItem(foundItems);
                                            txtsrchB.Text = "";
                                            CalculateGridColumns();

                                        }
                                    }
                                    else
                                    {
                                        foundItems.Discount = itemAction.discount;
                                        AddItem(foundItems);
                                        txtsrchB.Text = "";
                                        CalculateGridColumns();

                                    }
                                }
                                else
                                {

                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            if (row.Cells[4].Value.ToString() == txtsrchB.Text && txtsrchB.Text != "")
                                            {
                                                if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && availableStock != -1)
                                                {
                                                    if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                    {
                                                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                                        row.Cells["Discount"].Value = itemAction.discount;
                                                        txtsrchB.Text = "";
                                                        CalculateGridColumns();


                                                    }
                                                    else
                                                    {
                                                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                        txtsrchB.Text = "";
                                                        CalculateGridColumns();

                                                    }
                                                }
                                                else
                                                {
                                                    if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                    {
                                                        if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                        {
                                                            EnterPin enter = new EnterPin();
                                                            enter.ShowDialog();
                                                            if (enter.flag == true)
                                                            {
                                                                if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                                {
                                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                                                    row.Cells["Discount"].Value = itemAction.discount;
                                                                    txtsrchB.Text = "";
                                                                    CalculateGridColumns();


                                                                }
                                                                else
                                                                {
                                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                    txtsrchB.Text = "";
                                                                    CalculateGridColumns();

                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                    }
                                                }
                                                found = true;

                                            }

                                        }
                                        if (!found)
                                        {
                                            AddItem(foundItems);
                                            txtsrchB.Text = "";
                                            CalculateGridColumns();

                                        }
                                    }
                                    else
                                    {
                                        AddItem(foundItems);
                                        txtsrchB.Text = "";
                                        CalculateGridColumns();

                                    }
                                }
                            }



                            else if (categoryAction != null && settings.AllowDiscount == "0")
                            {
                                var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                var totalPrice = tp - (tp * clientDiscount / 100);
                                if (categoryAction.quantity == 1)
                                {
                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            if (row.Cells[4].Value.ToString() == txtsrchB.Text && txtsrchB.Text != "")
                                            {
                                                if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && availableStock != -1)
                                                {
                                                    if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                    {
                                                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                                        row.Cells["Discount"].Value = categoryAction.discount;
                                                        txtsrchB.Text = "";
                                                        CalculateGridColumns();

                                                    }
                                                    else
                                                    {
                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                        txtsrchB.Text = "";
                                                        CalculateGridColumns();

                                                    }

                                                }
                                                else
                                                {
                                                    if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                    {
                                                        if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                        {
                                                            EnterPin enter = new EnterPin();
                                                            enter.ShowDialog();
                                                            if (enter.flag == true)
                                                            {
                                                                if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                                {
                                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                                                    row.Cells["Discount"].Value = categoryAction.discount;
                                                                    txtsrchB.Text = "";
                                                                    CalculateGridColumns();

                                                                }
                                                                else
                                                                {
                                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                    txtsrchB.Text = "";
                                                                    CalculateGridColumns();

                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                    }
                                                }
                                                found = true;

                                            }
                                        }
                                        if (!found)
                                        {
                                            foundItems.Discount = categoryAction.discount;
                                            AddItem(foundItems);
                                            txtsrchB.Text = "";
                                            CalculateGridColumns();

                                        }
                                    }
                                    else
                                    {
                                        foundItems.Discount = categoryAction.discount;
                                        AddItem(foundItems);
                                        txtsrchB.Text = "";
                                        CalculateGridColumns();

                                    }
                                }
                                else
                                {

                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            if (row.Cells[4].Value.ToString() == txtsrchB.Text && txtsrchB.Text != "")
                                            {
                                                if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && availableStock != -1)
                                                {
                                                    if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                    {
                                                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                                        row.Cells["Discount"].Value = categoryAction.discount;
                                                        txtsrchB.Text = "";
                                                        CalculateGridColumns();

                                                    }
                                                    else
                                                    {
                                                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                        row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                        txtsrchB.Text = "";
                                                        CalculateGridColumns();


                                                    }
                                                }
                                                else
                                                {
                                                    if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                    {
                                                        if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                        {
                                                            EnterPin enter = new EnterPin();
                                                            enter.ShowDialog();
                                                            if (enter.flag == true)
                                                            {
                                                                if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                                {
                                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                                                    row.Cells["Discount"].Value = categoryAction.discount;
                                                                    txtsrchB.Text = "";
                                                                    CalculateGridColumns();

                                                                }
                                                                else
                                                                {
                                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                    txtsrchB.Text = "";
                                                                    CalculateGridColumns();


                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                    }
                                                }
                                                found = true;
                                            }


                                        }
                                        if (!found)
                                        {
                                            AddItem(foundItems);
                                            txtsrchB.Text = "";
                                            CalculateGridColumns();

                                        }
                                    }
                                    else
                                    {
                                        AddItem(foundItems);
                                        txtsrchB.Text = "";
                                        CalculateGridColumns();

                                    }
                                }
                            }
                            else
                            {
                                if (ug.Rows.Count > 0)
                                {
                                    foreach (DataGridViewRow row in ug.Rows)
                                    {
                                        if (row.Cells[4].Value.ToString() == txtsrchB.Text && txtsrchB.Text != "")
                                        {
                                            if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 && availableStock != -1)
                                            {
                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                                                var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                                var totalPrice = tp - (tp * clientDiscount / 100);

                                                if ((decimal)row.Cells["Discount"].Value != 0)
                                                {
                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);
                                                    txtsrchB.Text = "";
                                                    CalculateGridColumns();


                                                }
                                                else
                                                {
                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                    txtsrchB.Text = "";
                                                    CalculateGridColumns();

                                                }
                                            }
                                            else
                                            {
                                                if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                {
                                                    if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                    {
                                                        EnterPin enter = new EnterPin();
                                                        enter.ShowDialog();
                                                        if (enter.flag == true)
                                                        {
                                                            row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                                                            var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                                            var totalPrice = tp - (tp * clientDiscount / 100);

                                                            if ((decimal)row.Cells["Discount"].Value != 0)
                                                            {
                                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * (decimal)row.Cells["Discount"].Value / 100)), 2);
                                                                txtsrchB.Text = "";
                                                                CalculateGridColumns();


                                                            }
                                                            else
                                                            {
                                                                row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                                txtsrchB.Text = "";
                                                                CalculateGridColumns();

                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                }
                                            }

                                            //var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                            //mTotalSum = total;
                                            //txtTotalSum.Text = mTotalSum.ToString();
                                            AdjustTblTotalColumnWidths();
                                            found = true;
                                            return;
                                        }

                                    }
                                    if (!found)
                                    {
                                        AddItem(foundItems);

                                        txtsrchB.Text = "";
                                        CalculateGridColumns();

                                    }
                                }
                                else
                                {
                                    //add found item.
                                    if (txtsrchB.Text == "")
                                        return;
                                    var item = foundItems;
                                    AddItem(item);
                                    txtsrchB.Text = "";
                                    CalculateGridColumns();


                                }
                            }
                        }
                        else
                        {
                            var itemAction = aksionet.Find(p => p.item_id == foundItems.Id);
                            var categoryAction = aksionet.Find(p => p.category_id == foundItems.CategoryId);

                            if (itemAction != null && settings.AllowDiscount == "0")
                            {
                                var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                var totalPrice = tp - (tp * clientDiscount / 100);

                                if (itemAction.quantity == 1)
                                {
                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            if (row.Cells[4].Value.ToString() == txtsrchB.Text && txtsrchB.Text != "")
                                            {
                                                if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                {
                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);
                                                    row.Cells["Discount"].Value = itemAction.discount;
                                                    txtsrchB.Text = "";
                                                    CalculateGridColumns();
                                                }
                                                else
                                                {
                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                    txtsrchB.Text = "";
                                                    CalculateGridColumns();

                                                }
                                                found = true;
                                            }


                                        }
                                        if (!found)
                                        {
                                            foundItems.Discount = itemAction.discount;
                                            AddItem(foundItems);
                                            txtsrchB.Text = "";
                                            CalculateGridColumns();

                                        }
                                    }
                                    else
                                    {
                                        foundItems.Discount = itemAction.discount;
                                        AddItem(foundItems);
                                        txtsrchB.Text = "";
                                        CalculateGridColumns();

                                    }
                                }
                                else
                                {

                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            if (row.Cells[4].Value.ToString() == txtsrchB.Text && txtsrchB.Text != "")
                                            {
                                                if (itemAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                {
                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * itemAction.discount / 100)), 2);

                                                    row.Cells["Discount"].Value = itemAction.discount;
                                                    txtsrchB.Text = "";
                                                    CalculateGridColumns();


                                                }
                                                else
                                                {
                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                    txtsrchB.Text = "";
                                                    CalculateGridColumns();

                                                }
                                                found = true;

                                            }

                                        }
                                        if (!found)
                                        {
                                            AddItem(foundItems);
                                            txtsrchB.Text = "";
                                            CalculateGridColumns();

                                        }
                                    }
                                    else
                                    {
                                        AddItem(foundItems);
                                        txtsrchB.Text = "";
                                        CalculateGridColumns();

                                    }
                                }
                            }



                            else if (categoryAction != null && settings.AllowDiscount == "0")
                            {
                                var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                var totalPrice = tp - (tp * clientDiscount / 100);
                                if (categoryAction.quantity == 1)
                                {
                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            if (row.Cells[4].Value.ToString() == txtsrchB.Text && txtsrchB.Text != "")
                                            {
                                                if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value)
                                                {
                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);
                                                    row.Cells["Discount"].Value = categoryAction.discount;
                                                    txtsrchB.Text = "";
                                                    CalculateGridColumns();

                                                }
                                                else
                                                {
                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                    txtsrchB.Text = "";
                                                    CalculateGridColumns();

                                                }

                                            }
                                            found = true;
                                        }
                                        if (!found)
                                        {
                                            foundItems.Discount = categoryAction.discount;
                                            AddItem(foundItems);
                                            txtsrchB.Text = "";
                                            CalculateGridColumns();

                                        }
                                    }
                                    else
                                    {
                                        foundItems.Discount = categoryAction.discount;
                                        AddItem(foundItems);
                                        txtsrchB.Text = "";
                                        CalculateGridColumns();

                                    }
                                }
                                else
                                {

                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            if (row.Cells[4].Value.ToString() == txtsrchB.Text && txtsrchB.Text != "")
                                            {
                                                if (categoryAction.quantity <= (decimal)row.Cells["Quantity"].Value + 1)
                                                {
                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * (totalPrice - (totalPrice * categoryAction.discount / 100)), 2);

                                                    row.Cells["Discount"].Value = categoryAction.discount;
                                                    txtsrchB.Text = "";
                                                    CalculateGridColumns();

                                                }
                                                else
                                                {
                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;

                                                    row.Cells["TotalWithVat"].Value = Math.Round((decimal)row.Cells["Quantity"].Value * totalPrice, 2);
                                                    txtsrchB.Text = "";
                                                    CalculateGridColumns();


                                                }
                                                found = true;
                                            }


                                        }
                                        if (!found)
                                        {
                                            AddItem(foundItems);
                                            txtsrchB.Text = "";
                                            CalculateGridColumns();

                                        }
                                    }
                                    else
                                    {
                                        AddItem(foundItems);
                                        txtsrchB.Text = "";
                                        CalculateGridColumns();

                                    }
                                }

                            }
                        }
                    }
                }
            }

        }
        private void txtsrchB_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 53, 65);
            foreach (System.Windows.Forms.Control item in this.Controls)
            {
                if (item is System.Windows.Forms.Panel)
                {
                    item.BackColor = Color.FromArgb(52, 53, 65);
                    foreach (System.Windows.Forms.Control innerControl in item.Controls)
                    {
                        innerControl.BackColor = Color.FromArgb(52, 53, 65);
                        innerControl.ForeColor = Color.Black;
                    }

                }
            }

        }

        private void PosRestaurant_KeyPress(object sender, KeyPressEventArgs e)
        {
            var settings = Services.Settings.Get();
            //if (settings.BarcMode == 0)
            //{
            //    if (ug.CurrentCell == null && txt.Focused == false && txtB.Focused == false)
            //    {
            //        if (!txtsrch.Focused) // check if the textbox doesn't have focus
            //        {
            //            txtsrch.Focus(); // give focus to the textbox
            //            txtsrch.Text = e.KeyChar.ToString(); // set the text of the textbox to the input character
            //            txtsrch.Select(txtsrch.Text.Length, 0); // move the cursor to the end of the textbox
            //            e.Handled = true; // mark the event as handled to prevent the character from being added to the form
            //        }
            //        else // if the textbox has focus, let the event pass through to the textbox
            //        {
            //            e.Handled = false;
            //        }
            //    }
            //    else
            //    {
            //        if (ug.CurrentCell == null && txt.Focused != false && txtB.Focused != false)
            //        {
            //            if (!txtsrchB.Focused)
            //            {
            //                txtsrchB.Focus();
            //                txtsrchB.Text = e.KeyChar.ToString();
            //                txtsrchB.Select(txtsrchB.Text.Length, 0);
            //                e.Handled = true;
            //            }
            //            else
            //            {
            //                e.Handled = false;
            //            }
            //        }
            //    }
            //}


        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Globals.Settings.PosPrinter == "1")
            {
                PrintThermal();

            }
            else
            {
                //Me e shiku per me i insertu per me e shtyp totalin
                //InsertOrderDetails();

                Services.Tables.UpdatePrintTotal(1, tableId);
            }
            this.Close();
            Globals.NextStep = "Restaurant";
        }

        private void word_print_the_coupon_Click(object sender, EventArgs e)
        {
            var printer = Printer.Get().Find(p => p.Id == Globals.DeviceId);
            var global = Services.Settings.Get();
            InsertOrderDetails();

            var withBank = 0;
            var clientPayed = mPaymentDialog.clientPayed;

            if (mPaymentDialog.TotalCreditCard > 0)
                withBank = 3;

            if (global.PosPrinter == "0")
            {
                Services.Models.TablesSaleDetails.UpdateTableSDFiscalPrinted(1, tableId);

            }
            else
            {

                Random rnd = new Random();
                int num = rnd.Next();

                System.Data.DataTable dt = new System.Data.DataTable();

                foreach (DataGridViewColumn col in ug.Columns)
                {
                    dt.Columns.Add(col.Name);
                }

                foreach (DataGridViewRow row in ug.Rows)
                {
                    if (Convert.ToInt32(row.Cells["Quantity"].Value) > Convert.ToInt32(row.Cells["PrintedFiscalQuantity"].Value))
                    {
                        DataRow dRow = dt.NewRow();

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dRow[cell.ColumnIndex] = cell.Value;
                        }

                        dt.Rows.Add(dRow);
                    }
                }


                if (printer.PrintTermal == "1")
                {
                    PrintThermal();
                }
                else
                {
                    if (printer.FiscalType == "Tremol")
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (TremolPrint.CreateReceipt(dt, clientPayed))
                            {
                                Services.SaleDetails.UpdatePrinted(mSaleId);
                            }

                            global.UpdateFC(lblFiscalCount.Text, Globals.Settings.Id);
                        }
                    }
                    else
                    {
                        if (printer.DatecsType == "FP-700")
                        {
                            if (dt.Rows.Count > 0)
                            {
                                FiscalPrinterHelper.GekosPrint(global.FiscalCount, num.ToString(), dt, mTotalSum, num, withBank,clientPayed);

                            }
                        }
                        else
                        {
                            if (dt.Rows.Count > 0)
                            {
                                FiscalPrinterHelper.GekosPrintOldV(global.FiscalCount, num.ToString(), dt, mTotalSum, num, withBank, clientPayed);
                            }
                        }
                        //LoadJson.DataTabletoJsonDatecs(dt);

                        int x = 0;


                        global.UpdateFC(lblFiscalCount.Text, Globals.Settings.Id);

                    }

                    //ketu vendoset funksioni per printer termal
                    if (global.ThermalPrinterName != null)
                    {
                        //PrintThermal();
                    }
                }

            }


            foreach (DataGridViewRow item in ug.Rows)
            {
                item.Cells["PrintedFiscalQuantity"].Value = item.Cells["Quantity"].Value;
            }
            this.Close();
            Globals.NextStep = "Restaurant";
        }

        private void txtsrch_KeyPress(object sender, KeyPressEventArgs e)
        {
            var settings = Services.Settings.Get();
            var clientDiscount = Partner.Get(PartnerId).Discount;
            bool found = false;
            if (txtsrch.Text != "")
            {
                var keyPressedEventArgs = e as KeyPressEventArgs;
                if (keyPressedEventArgs != null && keyPressedEventArgs.KeyChar == (char)Keys.Enter)
                {
                    var foundItems = mAllItems.Find(p => p.Barcode == txtsrch.Text);

                    if (ug.Columns.Contains(" ") == false)
                    {
                        DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                        col.UseColumnTextForButtonValue = true;
                        col.Name = " ";
                        ug.Columns.Add(col);
                    }

                    if (foundItems != null)
                    {
                        if (foundItems.Service == 0)
                        {


                            decimal shuma = (foundItems.SalePrice * (1 - foundItems.Discount / 100)) * (1 * (decimal)foundItems.Vat / 100.0M);

                            decimal shumatotale = Math.Round(shuma + foundItems.SalePrice, 2);
                            if (settings.AllowDiscount == "0" && clientDiscount > 0)
                            {
                                shumatotale = shumatotale - (shumatotale * clientDiscount / 100);

                            }
                            var availableStock = Globals.Settings.StockWMinus == "0" ? Warehouse.GetbyId(foundItems.Id).InStock : -1;

                            var itemAction = aksionet.Find(p => p.item_id == foundItems.Id);
                            var categoryAction = aksionet.Find(p => p.category_id == foundItems.CategoryId);
                            if (categoryAction != null && itemAction != null && settings.AllowDiscount == "0")
                            {
                                var action = itemAction;
                                if (ug.Rows.Count > 0)
                                {
                                    foreach (DataGridViewRow row in ug.Rows)
                                    {
                                        if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                        {
                                            if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                            {
                                                if (itemAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                                {
                                                    decimal discount = (itemAction.discount) / 100;
                                                    decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                    row.Cells["Quantity"].Value = quantity.ToString("N");

                                                    decimal totalwithvat = ((decimal)row.Cells["TotalWithVat"].Value + ((decimal)row.Cells["TotalWithVat"].Value * discount));
                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                    row.Cells["Discount"].Value = (discount * 100).ToString("N");

                                                }
                                                else
                                                {
                                                    if (decimal.Parse(row.Cells["Discount"].Value.ToString()) == 0 && action.discount == 0)
                                                    {
                                                        decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                        row.Cells["Quantity"].Value = quantity.ToString("N");
                                                        decimal totalwithvat = shumatotale * quantity;
                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                    }
                                                    else
                                                    {
                                                        decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;
                                                        decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                                        decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                {
                                                    if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                    {
                                                        EnterPin enter = new EnterPin();
                                                        enter.ShowDialog();
                                                        if (enter.flag == true)
                                                        {
                                                            if (itemAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                                            {
                                                                decimal discount = (itemAction.discount) / 100;
                                                                decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                decimal totalwithvat = ((decimal)row.Cells["TotalWithVat"].Value + ((decimal)row.Cells["TotalWithVat"].Value * discount));
                                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                                row.Cells["Discount"].Value = (discount * 100).ToString("N");

                                                            }
                                                            else
                                                            {
                                                                if (decimal.Parse(row.Cells["Discount"].Value.ToString()) == 0 && action.discount == 0)
                                                                {
                                                                    decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                                    row.Cells["Quantity"].Value = quantity.ToString("N");
                                                                    decimal totalwithvat = shumatotale * quantity;
                                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                                }
                                                                else
                                                                {
                                                                    decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;
                                                                    decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                                    row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                    decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                }
                                            }
                                            found = true;
                                            CalculateGridColumns();
                                        }

                                    }
                                    if (!found)
                                    {
                                        if (itemAction.discount == 1)
                                        {
                                            foundItems.Discount = itemAction.discount;
                                            AddItem(foundItems);
                                        }
                                        if (itemAction.discount == foundItems.Quantity + 1 || itemAction.discount > foundItems.Quantity + 1)
                                        {
                                            foundItems.Discount = itemAction.discount;
                                            AddItem(foundItems);
                                        }
                                        else
                                            AddItem(foundItems);


                                    }

                                }
                                else
                                {
                                    if (action.quantity == 1)
                                    {
                                        foundItems.Discount = action.discount;

                                    }
                                    AddItem(foundItems);
                                }
                            }

                            if (itemAction != null && settings.AllowDiscount == "0")
                            {
                                var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                var totalPrice = tp - (tp * clientDiscount / 100);

                                if (itemAction.quantity == 1)
                                {
                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {

                                            if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                            {
                                                if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                                {
                                                    decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;


                                                    row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                                                    var vat = Convert.ToDecimal(row.Cells["Vat"].Value) / 100;
                                                    var totalP = Math.Round((decimal)row.Cells["Price"].Value * vat + (decimal)row.Cells["Price"].Value, 2);
                                                    decimal totalwithvat = (totalP - (totalP * discount)) * (decimal)row.Cells["Quantity"].Value;
                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat - (totalwithvat * clientDiscount / 100), 2);
                                                }
                                                else
                                                {
                                                    if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                    {
                                                        if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                        {
                                                            EnterPin enter = new EnterPin();
                                                            enter.ShowDialog();
                                                            if (enter.flag == true)
                                                            {
                                                                decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;


                                                                row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                                                                var vat = Convert.ToDecimal(row.Cells["Vat"].Value) / 100;
                                                                var totalP = Math.Round((decimal)row.Cells["Price"].Value * vat + (decimal)row.Cells["Price"].Value, 2);
                                                                decimal totalwithvat = (totalP - (totalP * discount)) * (decimal)row.Cells["Quantity"].Value;
                                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat - (totalwithvat * clientDiscount / 100), 2);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                    }
                                                }
                                                txtsrch.Text = "";
                                                CalculateGridColumns();


                                                found = true;
                                            }

                                        }
                                        if (!found)
                                        {
                                            foundItems.Discount = itemAction.discount;
                                            AddItem(foundItems);
                                            txtsrch.Text = "";

                                        }
                                    }
                                    else
                                    {
                                        foundItems.Discount = itemAction.discount;
                                        AddItem(foundItems);
                                        txtsrch.Text = "";

                                    }
                                }
                                else
                                {

                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                            if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                            {
                                                if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                                {
                                                    if (itemAction.quantity == (decimal)row.Cells["Quantity"].Value + 1)
                                                    {
                                                        decimal itDiscount = (itemAction.discount) / 100;

                                                        decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                        row.Cells["Quantity"].Value = quantity.ToString("N");
                                                        decimal totalwithvat = (shumatotale - (shumatotale * discount)) * quantity;
                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                        row.Cells["Discount"].Value = (discount * 100).ToString("N");

                                                        txtsrch.Text = "";
                                                        CalculateGridColumns();


                                                    }
                                                    else
                                                    {
                                                        if (discount == 0)
                                                        {
                                                            decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                                            decimal totalwithvat = shumatotale * quantity;
                                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);


                                                        }
                                                        else
                                                        {
                                                            decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                                            decimal totalwithvat = (shumatotale * quantity) - (shumatotale * quantity) * discount;
                                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                    {
                                                        if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                        {
                                                            EnterPin enter = new EnterPin();
                                                            enter.ShowDialog();
                                                            if (enter.flag == true)
                                                            {
                                                                if (itemAction.quantity == (decimal)row.Cells["Quantity"].Value + 1)
                                                                {
                                                                    decimal itDiscount = (itemAction.discount) / 100;

                                                                    decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                                    row.Cells["Quantity"].Value = quantity.ToString("N");
                                                                    decimal totalwithvat = (shumatotale - (shumatotale * discount)) * quantity;
                                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                                    row.Cells["Discount"].Value = (discount * 100).ToString("N");

                                                                    txtsrch.Text = "";
                                                                    CalculateGridColumns();


                                                                }
                                                                else
                                                                {
                                                                    if (discount == 0)
                                                                    {
                                                                        decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                        decimal totalwithvat = shumatotale * quantity;
                                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);


                                                                    }
                                                                    else
                                                                    {
                                                                        decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                                                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                        decimal totalwithvat = (shumatotale * quantity) - (shumatotale * quantity) * discount;
                                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                    }
                                                }
                                                found = true;
                                                CalculateGridColumns();

                                            }

                                        }
                                        if (!found)
                                        {
                                            AddItem(foundItems);
                                            txtsrch.Text = "";

                                        }
                                    }
                                    else
                                    {
                                        AddItem(foundItems);
                                        txtsrch.Text = "";

                                    }
                                }
                            }



                            else if (categoryAction != null && settings.AllowDiscount == "0")
                            {
                                var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                                var totalPrice = tp - (tp * clientDiscount / 100);
                                if (categoryAction.quantity == 1)
                                {
                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                                            if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                            {
                                                if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                                {
                                                    decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                    var VatSum = (decimal)foundItems.Vat / 100;
                                                    row.Cells["Quantity"].Value = quantity.ToString("N");

                                                    var totalP = ((decimal)row.Cells["Price"].Value * VatSum + (decimal)row.Cells["Price"].Value) * discount;
                                                    decimal totalwithvat = totalP * quantity;
                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                }
                                                else
                                                {
                                                    if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                    {
                                                        if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                        {
                                                            EnterPin enter = new EnterPin();
                                                            enter.ShowDialog();
                                                            if (enter.flag == true)
                                                            {
                                                                decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                                var VatSum = (decimal)foundItems.Vat / 100;
                                                                row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                var totalP = ((decimal)row.Cells["Price"].Value * VatSum + (decimal)row.Cells["Price"].Value) * discount;
                                                                decimal totalwithvat = totalP * quantity;
                                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                    }
                                                }
                                                found = true;
                                                CalculateGridColumns();
                                            }
                                        }
                                        if (!found)
                                        {
                                            foundItems.Discount = categoryAction.discount;
                                            AddItem(foundItems);
                                            txtsrch.Text = "";

                                        }
                                    }
                                    else
                                    {
                                        foundItems.Discount = categoryAction.discount;
                                        AddItem(foundItems);
                                        txtsrch.Text = "";
                                        CalculateGridColumns();

                                    }
                                }
                                else
                                {

                                    if (ug.Rows.Count > 0)
                                    {
                                        foreach (DataGridViewRow row in ug.Rows)
                                        {
                                            if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                            {
                                                if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                                {
                                                    if (categoryAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                                    {

                                                        decimal discount = (decimal.Parse(row.Cells["Discount"].Value.ToString()) + categoryAction.discount) / 100;


                                                        decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                                        decimal totalwithvat = ((shumatotale * quantity) - (shumatotale * quantity * discount));
                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                        row.Cells["Discount"].Value = (discount * 100).ToString("N");


                                                    }
                                                    else
                                                    {
                                                        if (decimal.Parse(row.Cells["Discount"].Value.ToString()) == 0)
                                                        {


                                                            decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                                            decimal totalwithvat = shumatotale * quantity;
                                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);



                                                        }
                                                        else
                                                        {
                                                            decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;

                                                            decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                            row.Cells["Quantity"].Value = quantity.ToString("N");

                                                            decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                                                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                    {
                                                        if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                        {
                                                            EnterPin enter = new EnterPin();
                                                            enter.ShowDialog();
                                                            if (enter.flag == true)
                                                            {
                                                                if (categoryAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                                                                {

                                                                    decimal discount = (decimal.Parse(row.Cells["Discount"].Value.ToString()) + categoryAction.discount) / 100;


                                                                    decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                                    row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                    decimal totalwithvat = ((shumatotale * quantity) - (shumatotale * quantity * discount));
                                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                                    row.Cells["Discount"].Value = (discount * 100).ToString("N");


                                                                }
                                                                else
                                                                {
                                                                    if (decimal.Parse(row.Cells["Discount"].Value.ToString()) == 0)
                                                                    {


                                                                        decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                        decimal totalwithvat = shumatotale * quantity;
                                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);



                                                                    }
                                                                    else
                                                                    {
                                                                        decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;

                                                                        decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                                        row.Cells["Quantity"].Value = quantity.ToString("N");

                                                                        decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                                                                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                    }
                                                }
                                                found = true;
                                                CalculateGridColumns();
                                            }


                                        }
                                        if (!found)
                                        {
                                            AddItem(foundItems);
                                            txtsrch.Text = "";

                                        }
                                    }
                                    else
                                    {
                                        AddItem(foundItems);
                                        txtsrch.Text = "";

                                    }
                                }
                            }
                            else
                            {
                                if (ug.Rows.Count > 0)
                                {
                                    foreach (DataGridViewRow row in ug.Rows)
                                    {
                                        if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                                        {

                                            if (availableStock >= decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1 || settings.StockWMinus != "0")
                                            {
                                                if ((decimal)row.Cells["Discount"].Value != 0)
                                                {
                                                    decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                    row.Cells["Quantity"].Value = quantity.ToString("N");
                                                    decimal totalwithvat = shumatotale * quantity;
                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                                    txtsrch.Text = "";


                                                }
                                                else
                                                {
                                                    decimal discount = (decimal)row.Cells["Discount"].Value / 100;
                                                    decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                    row.Cells["Quantity"].Value = quantity.ToString("N");
                                                    decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                                                    row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                                    txtsrch.Text = "";

                                                }


                                                var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                                mTotalSum = total;
                                                txtTotalSum.Text = mTotalSum.ToString();
                                                AdjustTblTotalColumnWidths();
                                            }
                                            else
                                            {
                                                if (Globals.Settings.PIN != "0" || Globals.Settings.PIN == null)
                                                {
                                                    if (MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}! A deshironi te vazhdoni?", "Sasi me minus", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                                    {
                                                        EnterPin enter = new EnterPin();
                                                        enter.ShowDialog();
                                                        if (enter.flag == true)
                                                        {
                                                            if ((decimal)row.Cells["Discount"].Value != 0)
                                                            {
                                                                decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                                row.Cells["Quantity"].Value = quantity.ToString("N");
                                                                decimal totalwithvat = shumatotale * quantity;
                                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                                                txtsrch.Text = "";


                                                            }
                                                            else
                                                            {
                                                                decimal discount = (decimal)row.Cells["Discount"].Value / 100;
                                                                decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                                                                row.Cells["Quantity"].Value = quantity.ToString("N");
                                                                decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                                                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                                                                txtsrch.Text = "";

                                                            }


                                                            var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                                                            mTotalSum = total;
                                                            txtTotalSum.Text = mTotalSum.ToString();
                                                            AdjustTblTotalColumnWidths();
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show($"Nuk keni sasi te mjaftueshme per artikullin: {foundItems.ItemName}!");
                                                }
                                            }
                                            found = true;
                                            CalculateGridColumns();

                                            return;
                                        }

                                    }
                                    if (!found)
                                    {
                                        AddItem(foundItems);

                                        txtsrch.Text = "";
                                        CalculateGridColumns();

                                    }
                                }
                                else
                                {
                                    //add found item.
                                    if (txtsrch.Text == "")
                                        return;
                                    var item = foundItems;
                                    AddItem(item);
                                    txtsrch.Text = "";
                                    CalculateGridColumns();


                                }
                            }
                        }
                    }
                    //else
                    //{
                    //    decimal shuma = (foundItems.SalePrice * (1 - foundItems.Discount / 100)) * (1 * (decimal)foundItems.Vat / 100.0M);

                    //    decimal shumatotale = Math.Round(shuma + foundItems.SalePrice, 2);
                    //    if (settings.AllowDiscount == "0" && clientDiscount > 0)
                    //    {
                    //        shumatotale = shumatotale - (shumatotale * clientDiscount / 100);

                    //    }

                    //    var itemAction = aksionet.Find(p => p.item_id == foundItems.Id);
                    //    var categoryAction = aksionet.Find(p => p.category_id == foundItems.CategoryId);
                    //    if (categoryAction != null && itemAction != null && settings.AllowDiscount == "0")
                    //    {
                    //        var action = itemAction;
                    //        if (ug.Rows.Count > 0)
                    //        {
                    //            foreach (DataGridViewRow row in ug.Rows)
                    //            {
                    //                if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                    //                {
                    //                    if (itemAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                    //                    {
                    //                        decimal discount = (itemAction.discount) / 100;
                    //                        decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                    //                        row.Cells["Quantity"].Value = quantity.ToString("N");

                    //                        decimal totalwithvat = ((decimal)row.Cells["TotalWithVat"].Value + ((decimal)row.Cells["TotalWithVat"].Value * discount));
                    //                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                    //                        row.Cells["Discount"].Value = (discount * 100).ToString("N");

                    //                    }
                    //                    else
                    //                    {
                    //                        if (decimal.Parse(row.Cells["Discount"].Value.ToString()) == 0 && action.discount == 0)
                    //                        {
                    //                            decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                    //                            row.Cells["Quantity"].Value = quantity.ToString("N");
                    //                            decimal totalwithvat = shumatotale * quantity;
                    //                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                    //                        }
                    //                        else
                    //                        {
                    //                            decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;
                    //                            decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                    //                            row.Cells["Quantity"].Value = quantity.ToString("N");

                    //                            decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                    //                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                    //                        }
                    //                    }
                    //                    found = true;
                    //                    CalculateGridColumns();
                    //                }

                    //            }
                    //            if (!found)
                    //            {
                    //                if (itemAction.discount == 1)
                    //                {
                    //                    foundItems.Discount = itemAction.discount;
                    //                    AddItem(foundItems);
                    //                }
                    //                if (itemAction.discount == foundItems.Quantity + 1 || itemAction.discount > foundItems.Quantity + 1)
                    //                {
                    //                    foundItems.Discount = itemAction.discount;
                    //                    AddItem(foundItems);
                    //                }
                    //                else
                    //                    AddItem(foundItems);


                    //            }

                    //        }
                    //        else
                    //        {
                    //            if (action.quantity == 1)
                    //            {
                    //                foundItems.Discount = action.discount;

                    //            }
                    //            AddItem(foundItems);
                    //        }
                    //    }

                    //    if (itemAction != null && settings.AllowDiscount == "0")
                    //    {
                    //        var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                    //        var totalPrice = tp - (tp * clientDiscount / 100);

                    //        if (itemAction.quantity == 1)
                    //        {
                    //            if (ug.Rows.Count > 0)
                    //            {
                    //                foreach (DataGridViewRow row in ug.Rows)
                    //                {

                    //                    if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                    //                    {
                    //                        decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;


                    //                        row.Cells["Quantity"].Value = (decimal)row.Cells["Quantity"].Value + 1;
                    //                        var vat = Convert.ToDecimal(row.Cells["Vat"].Value) / 100;
                    //                        var totalP = Math.Round((decimal)row.Cells["Price"].Value * vat + (decimal)row.Cells["Price"].Value, 2);
                    //                        decimal totalwithvat = (totalP - (totalP * discount)) * (decimal)row.Cells["Quantity"].Value;
                    //                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat - (totalwithvat * clientDiscount / 100), 2);

                    //                        txtsrch.Text = "";
                    //                        CalculateGridColumns();


                    //                        found = true;
                    //                    }

                    //                }
                    //                if (!found)
                    //                {
                    //                    foundItems.Discount = itemAction.discount;
                    //                    AddItem(foundItems);
                    //                    txtsrch.Text = "";

                    //                }
                    //            }
                    //            else
                    //            {
                    //                foundItems.Discount = itemAction.discount;
                    //                AddItem(foundItems);
                    //                txtsrch.Text = "";

                    //            }
                    //        }
                    //        else
                    //        {

                    //            if (ug.Rows.Count > 0)
                    //            {
                    //                foreach (DataGridViewRow row in ug.Rows)
                    //                {
                    //                    decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                    //                    if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                    //                    {
                    //                        if (itemAction.quantity == (decimal)row.Cells["Quantity"].Value + 1)
                    //                        {
                    //                            decimal itDiscount = (itemAction.discount) / 100;

                    //                            decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                    //                            row.Cells["Quantity"].Value = quantity.ToString("N");
                    //                            decimal totalwithvat = (shumatotale - (shumatotale * discount)) * quantity;
                    //                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                    //                            row.Cells["Discount"].Value = (discount * 100).ToString("N");

                    //                            txtsrch.Text = "";
                    //                            CalculateGridColumns();


                    //                        }
                    //                        else
                    //                        {
                    //                            if (discount == 0)
                    //                            {
                    //                                decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                    //                                row.Cells["Quantity"].Value = quantity.ToString("N");

                    //                                decimal totalwithvat = shumatotale * quantity;
                    //                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);


                    //                            }
                    //                            else
                    //                            {
                    //                                decimal quantity = (decimal)row.Cells["Quantity"].Value + 1;
                    //                                row.Cells["Quantity"].Value = quantity.ToString("N");

                    //                                decimal totalwithvat = (shumatotale * quantity) - (shumatotale * quantity) * discount;
                    //                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                    //                            }
                    //                        }
                    //                        found = true;
                    //                        CalculateGridColumns();

                    //                    }

                    //                }
                    //                if (!found)
                    //                {
                    //                    AddItem(foundItems);
                    //                    txtsrch.Text = "";

                    //                }
                    //            }
                    //            else
                    //            {
                    //                AddItem(foundItems);
                    //                txtsrch.Text = "";

                    //            }
                    //        }
                    //    }



                    //    else if (categoryAction != null && settings.AllowDiscount == "0")
                    //    {
                    //        var tp = Math.Round(foundItems.SalePrice + (foundItems.SalePrice * foundItems.Vat / 100), 2);
                    //        var totalPrice = tp - (tp * clientDiscount / 100);
                    //        if (categoryAction.quantity == 1)
                    //        {
                    //            if (ug.Rows.Count > 0)
                    //            {
                    //                foreach (DataGridViewRow row in ug.Rows)
                    //                {
                    //                    decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString());

                    //                    if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                    //                    {

                    //                        decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                    //                        var VatSum = (decimal)foundItems.Vat / 100;
                    //                        row.Cells["Quantity"].Value = quantity.ToString("N");

                    //                        var totalP = ((decimal)row.Cells["Price"].Value * VatSum + (decimal)row.Cells["Price"].Value) * discount;
                    //                        decimal totalwithvat = totalP * quantity;
                    //                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                    //                        found = true;
                    //                        CalculateGridColumns();
                    //                    }
                    //                }
                    //                if (!found)
                    //                {
                    //                    foundItems.Discount = categoryAction.discount;
                    //                    AddItem(foundItems);
                    //                    txtsrch.Text = "";

                    //                }
                    //            }
                    //            else
                    //            {
                    //                foundItems.Discount = categoryAction.discount;
                    //                AddItem(foundItems);
                    //                txtsrch.Text = "";
                    //                CalculateGridColumns();

                    //            }
                    //        }
                    //        else
                    //        {

                    //            if (ug.Rows.Count > 0)
                    //            {
                    //                foreach (DataGridViewRow row in ug.Rows)
                    //                {
                    //                    if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                    //                    {
                    //                        if (categoryAction.quantity == decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1)
                    //                        {

                    //                            decimal discount = (decimal.Parse(row.Cells["Discount"].Value.ToString()) + categoryAction.discount) / 100;


                    //                            decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                    //                            row.Cells["Quantity"].Value = quantity.ToString("N");

                    //                            decimal totalwithvat = ((shumatotale * quantity) - (shumatotale * quantity * discount));
                    //                            row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                    //                            row.Cells["Discount"].Value = (discount * 100).ToString("N");


                    //                        }
                    //                        else
                    //                        {
                    //                            if (decimal.Parse(row.Cells["Discount"].Value.ToString()) == 0)
                    //                            {


                    //                                decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                    //                                row.Cells["Quantity"].Value = quantity.ToString("N");

                    //                                decimal totalwithvat = shumatotale * quantity;
                    //                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);



                    //                            }
                    //                            else
                    //                            {
                    //                                decimal discount = decimal.Parse(row.Cells["Discount"].Value.ToString()) / 100;

                    //                                decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                    //                                row.Cells["Quantity"].Value = quantity.ToString("N");

                    //                                decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                    //                                row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);
                    //                            }
                    //                        }
                    //                        found = true;
                    //                        CalculateGridColumns();
                    //                    }


                    //                }
                    //                if (!found)
                    //                {
                    //                    AddItem(foundItems);
                    //                    txtsrch.Text = "";

                    //                }
                    //            }
                    //            else
                    //            {
                    //                AddItem(foundItems);
                    //                txtsrch.Text = "";

                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (ug.Rows.Count > 0)
                    //        {
                    //            foreach (DataGridViewRow row in ug.Rows)
                    //            {
                    //                if (row.Cells[4].Value.ToString() == txtsrch.Text && txtsrch.Text != "")
                    //                {


                    //                    if ((decimal)row.Cells["Discount"].Value != 0)
                    //                    {
                    //                        decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                    //                        row.Cells["Quantity"].Value = quantity.ToString("N");
                    //                        decimal totalwithvat = shumatotale * quantity;
                    //                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                    //                        txtsrch.Text = "";


                    //                    }
                    //                    else
                    //                    {
                    //                        decimal discount = (decimal)row.Cells["Discount"].Value / 100;
                    //                        decimal quantity = decimal.Parse(row.Cells["Quantity"].Value.ToString()) + 1;
                    //                        row.Cells["Quantity"].Value = quantity.ToString("N");
                    //                        decimal totalwithvat = (decimal)row.Cells["TotalWithVat"].Value + (shumatotale - (shumatotale * discount));
                    //                        row.Cells["TotalWithVat"].Value = Math.Round(totalwithvat, 2);

                    //                        txtsrch.Text = "";

                    //                    }


                    //                    var total = Convert.ToDecimal(row.Cells["TotalWithVat"].Value);
                    //                    mTotalSum = total;
                    //                    txtTotalSum.Text = mTotalSum.ToString();
                    //                    AdjustTblTotalColumnWidths();
                    //                    found = true;
                    //                    CalculateGridColumns();

                    //                    return;
                    //                }

                    //            }
                    //            if (!found)
                    //            {
                    //                AddItem(foundItems);

                    //                txtsrch.Text = "";
                    //                CalculateGridColumns();

                    //            }
                    //        }
                    //        else
                    //        {
                    //            //add found item.
                    //            if (txtsrch.Text == "")
                    //                return;
                    //            var item = foundItems;
                    //            AddItem(item);
                    //            txtsrch.Text = "";
                    //            CalculateGridColumns();


                    //        }
                    //    }
                    //}
                }
            }
        }
    }
}


/*
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Fanta", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Shwepps", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Burger", Barcode = "111", Vat = 18, CategoryId = 2, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pomfrit", Barcode = "111", Vat = 18, CategoryId = 2, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule1", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe1", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate1", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });


           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule2", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe2", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate2", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });


           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule3", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe3", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate3", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule4", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe4", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate4", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule5", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe5", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate5", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule6", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe6", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate6", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule7", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe7", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate7", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule8", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe8", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate8", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule9", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe9", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate9", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule10", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe10", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate10", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule11", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe11", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate11", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });

           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Pule12", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 2, ItemName = "Supe12", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });
           mAllItems.Add(new Services.Models.ItemsDiscount() { Id = 1, ItemName = "Domate12", Barcode = "111", Vat = 18, CategoryId = 1, SalePrice = 2 });


          */ 