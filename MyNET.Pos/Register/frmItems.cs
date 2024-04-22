using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNET.DAL;
using System.Collections;
using Infragistics.Win.UltraWinGrid;
//using Infragistics.Win.UltraWinCalcManager;
//using Infragistics.Win.UltraWinCalcManager.FormulaBuilder;
using Infragistics.Win.CalcEngine;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win;
using MyNET;
using MyNET.Shops;

namespace T3.Pos
{
    public partial class frmItems : Base
    {
        #region Clas members
        protected int mItemsType = 0;
        #endregion
        
        #region  Members

        //protected bool mIsRegistation = false;
        //protected string mUser = string.Empty;

        #endregion

        #region Properties

        //public bool IsRegistation
        //{
        //    get { return mIsRegistation; }
        //    set { mIsRegistation = value; }
        //}

        //public string User
        //{
        //    get { return mUser; }
        //    set { mUser = value; }
        //}

        #endregion

        #region Constructors

        public frmItems()
        {
            InitializeComponent();
              //EnableOpen = true;
            EnableDelete = true;
            EnableExportExcell = true;

            gr1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            gr2.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            gr3.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            ug.Dock = DockStyle.Fill;
            EnableNew = false;
            this.ug.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton;
            this.ug.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            this.ug.DisplayLayout.Override.RowSelectorHeaderAppearance.ThemedElementAlpha = Alpha.Default;
            this.ug.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = Color.White;
        }

        public void SelectItems(int itemstype)
        {
            mItemsType = itemstype;

            if (mItemsType == 0)
            {
                string where = " 1 = 1 ";
                ug.DataSource = MyNET.DAL.Item.SearchItems(where, "");
                
            }
            if(mItemsType == 1)
            {
                string where = " ItemGoods = 1 ";
                ug.DataSource = MyNET.DAL.Item.SearchItems(where, "");
                EnableNew = true;
                
            }
            if (mItemsType == 2)
            {
                string where = " Service = 1 ";
                ug.DataSource = MyNET.DAL.Item.SearchItems(where, "");
                EnableNew = true;
            }
            if (mItemsType == 3)
            {
                string where = " Expense = 1 ";
                ug.DataSource = MyNET.DAL.Item.SearchItems(where, "");
                EnableNew = true;
            }
            if (mItemsType == 4)
            {
                string where = " InventoryItem = 1 ";
                ug.DataSource = MyNET.DAL.Item.SearchItems(where, "");
                EnableNew = true;
            }
            if (mItemsType == 5)
            {
                string where = " Material = 1 ";
                ug.DataSource = MyNET.DAL.Item.SearchItems(where, "");
                EnableNew = true;
            }
            if (mItemsType == 6)
            {
                string where = " Production = 1 ";
                ug.DataSource = MyNET.DAL.Item.SearchItems(where, "");
                EnableNew = true;
            }
            if (mItemsType == 7)
            {
                string where = " Assembled = 1 ";
                ug.DataSource = MyNET.DAL.Item.SearchItems(where, "");
                EnableNew = true;
            }
        }

        #endregion

        #region Event handlers

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            Open();           
        }

        private void ug_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            var dg = ug.DisplayLayout.Bands[0];
            if (dg.Columns.Count > 0)
            {
                dg.Columns["ID"].Hidden = true;
                dg.Columns["CreatedAt"].Hidden = true;
                dg.Columns["CreatedBy"].Hidden = true;
                dg.Columns["ChangedAt"].Hidden = true;
                dg.Columns["ChangedBy"].Hidden = true;
                dg.Columns["Status"].Hidden = true;
                dg.Columns["CategoryId"].Hidden = true;
                dg.Columns["UnitId"].Hidden = true;
                dg.Columns["ProducerId"].Hidden = true;
            }

            try
            {
                dg.Columns["ProductNo"].Header.Caption = "Shifra";
                dg.Columns["Barcode"].Header.Caption = "Barkodi";
                dg.Columns["Itemname"].Header.Caption = "Emërtimi";
                //dg.Columns["Unit"].Header.Caption = "Njësia";
                dg.Columns["Description"].Header.Caption = "Përshkrimi";
                dg.Columns["PurchasePrice"].Header.Caption = "Çmimi i blerjes";
                dg.Columns["RetailPrice"].Header.Caption = "Çmimi i shitjes";

                dg.Columns["Duty"].Header.Caption = "Dogana";
                dg.Columns["Vat"].Header.Caption = "Tvsh";
                dg.Columns["Expired"].Header.Caption = "I vjetruar";
            }
            catch (Exception ex)
            {
            }
        }

        private void ug_DoubleClick(object sender, EventArgs e)
        {
            Open();
        }

        private void ug_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            Open();
        }

        private void ug_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                //select row
                var row = ug.ActiveRow;
                row.Selected = true;
            }
        }

        private void frmItems_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        #endregion

        #region class methods
        public override void Print()
        {
            base.Print();
            try
            {
                var myDS = ug.DataSource;
                Dictionary<string, string> reportParameters = new Dictionary<string, string>();
                var dataSource = ug.DataSource;
                ViewReport rv = new ViewReport("ItemsBarcodes", @".\Reports\rptBarcodes.rdlc", dataSource, reportParameters);
                rv.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occured while printing.\n" + exc.Message, "Error printing",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Close1()
        {
            base.Close1();
            if (this.ParentForm != null)
                this.ParentForm.Close();
            else
                this.Close();            
        }
        
        public override void Open()
        {
            frmItems it = Application.OpenForms.OfType<frmItems>().FirstOrDefault();
            RegisterDashboard rg = Application.OpenForms.OfType<RegisterDashboard>().FirstOrDefault();
            if (ug.ActiveRow == null)
                MessageBox.Show("Ju lutem selektoni një artikull në listë për ta hapur");
            else
            {
                base.Open();
                int ItemId = (int)ug.ActiveRow.Cells[0].Value;
                ItemsDetails frmdetails = new ItemsDetails();
                frmdetails.Dock = DockStyle.Fill;
                frmdetails.TopLevel = false;
                rg.splitDashboard.Panel2.Controls.Add(frmdetails);
                frmdetails.ItemId = ItemId;
                //frmdetails.LoadItems(mItemsType);
                //frmdetails.LoadItems(selectitems);
                frmdetails.Show();
                LoadData();
                it.Close();
            }
         }

        protected override void LoadData()
        {           
            string where = "1=1";
            ug.DataSource = MyNET.DAL.Item.SearchItems(where, "");
           // base.LoadData();
        }

        public override void New()
        {
            base.New();
            ItemsDetails frm = new ItemsDetails();
            frmItems it = Application.OpenForms.OfType<frmItems>().FirstOrDefault();
            frmPartnersList pl = Application.OpenForms.OfType<frmPartnersList>().FirstOrDefault();
            RegisterDashboard rg = Application.OpenForms.OfType<RegisterDashboard>().FirstOrDefault();
            ItemsDetails form = Application.OpenForms.OfType<ItemsDetails>().FirstOrDefault();
            if (form == null)
            {
                frm.ItemId = 0;
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frm.Dock = DockStyle.Fill;
                frm.TopLevel = false;
                rg.splitDashboard.Panel2.Controls.Add(frm);
                frm.Show();
                if (mItemsType < 8)
                    frm.LoadItems(mItemsType);
            }
            if (it != null)
            {
                it.Close();
            }
            if (pl != null)
            {
                pl.Close();
            }
        }             
        
        public override void Delete()
        {
            if (ug.ActiveRow == null)
                MessageBox.Show("Ju lutem selektoni një artikull në listë për ta fshirë");
            else
            {
                int ItemId = (int)ug.ActiveRow.Cells[0].Value;
                if (MessageBox.Show("A jeni te sigurt që dëshironi ta fshini artikullin e selektuar?", "Fshi artikullin", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Item item = new Item(ItemId);
                    item.Delete();
                    base.Delete();
                }
                SelectItems(mItemsType);
                Search();
            }            
        }

        protected override void ExportExcell()
        {
            //MyNET.GridHelper.ExportExcel(ug);
        }

        #endregion
        
        private void txtKerko_KeyUp(object sender, KeyEventArgs e)
        {
            //var layout = ug.DisplayLayout.Bands[0];
            //string outputInfo = txtKerko.Text ;

            //foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ug.Rows)
            //{
            //    row.Hidden = false;
            //}

            //foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ug.Rows)
            //{
            //    bool filterRow = true;
            //    string productno = row.Cells["ProductNo"].Text.ToLower();
            //    string barcode = row.Cells["Barcode"].Text.ToLower();
            //    string category = row.Cells["Category"].Text.ToLower();
            //    string unit = row.Cells["Unit"].Text.ToLower();
            //    string itemname = row.Cells["ItemName"].Text.ToLower();
            //    string producers = row.Cells["Producers"].Text.ToLower();

            //    if (productno.Contains(outputInfo.ToLower()))
            //    {
            //        filterRow = false;
            //    }

            //    if (barcode.Contains(outputInfo.ToLower()))
            //    {
            //        filterRow = false;
            //    }
            //    if (category.Contains(outputInfo.ToLower()))
            //    {
            //        filterRow = false;
            //    }
            //    if (unit.Contains(outputInfo.ToLower()))
            //    {
            //        filterRow = false;
            //    }
            //    if (itemname.Contains(outputInfo.ToLower()))
            //    {
            //        filterRow = false;
            //    }
            //    if (producers.Contains(outputInfo.ToLower()))
            //    {
            //        filterRow = false;
            //    }
            //    row.Hidden = filterRow;
            //}


            Search();
        }

        protected void Search()
        {
            string outputInfo = "";
            string[] keyWords = txtKerko.Text.Split(' ');

            foreach (string word in keyWords)
            {
                if (outputInfo.Length == 0)
                {
                    outputInfo = "(I.ItemName LIKE '%" + word + "%' OR I.Barcode LIKE '%" +
                        // word + "%' OR C.FiscalNo LIKE '%" + word + "%' OR C.CompanyName LIKE '%" +
                        word + "%' OR I.ProductNo LIKE '%" + word + "%')";
                }
                else
                {
                    outputInfo += " AND (I.ItemName LIKE '%" + word + "%'  OR I.Barcode LIKE '%" +
                        //word + "%' OR C.FiscalNo LIKE '%" + word + "%' OR C.CompanyName LIKE '%" +
                        word + "%' OR I.ProductNo LIKE '%" + word + "%')";
                }
            }
            ug.DataSource = MyNET.DAL.Item.SearchItems(outputInfo, "");
        }
        private void ug_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            var band = ug.DisplayLayout.Bands[0];
            band.Columns["ID"].Hidden = true;
            band.Columns["CreatedAt"].Hidden = true;
            band.Columns["CreatedBy"].Hidden = true;
            band.Columns["ChangedAt"].Hidden = true;
            band.Columns["ChangedBy"].Hidden = true;
            band.Columns["Status"].Hidden = true;
            band.Columns["Description"].Hidden = true;
            band.Columns["ItemGoods"].Hidden = true;
            band.Columns["Service"].Hidden = true;
            band.Columns["Expense"].Hidden = true;
            band.Columns["InventoryItem"].Hidden = true;
            band.Columns["Material"].Hidden = true;
            band.Columns["Production"].Hidden = true;
            band.Columns["Akciza"].Hidden = true;
            ////band.Columns["RetailPrice"].Hidden = true;
            band.Columns["Duty"].Hidden = true;
            band.Columns["Category"].Hidden = true;
            band.Columns["Producers"].Hidden = true;

            band.Columns["ProductNo"].Header.Caption = "Numri i Produktit";
            band.Columns["Barcode"].Header.Caption = "Barkodi";
            band.Columns["Unit"].Header.Caption = "Njesia Matëse";
            band.Columns["ItemName"].Header.Caption = "Emri i Produktit";
            band.Columns["ItemName"].Width = 400;
            band.Columns["Barcode"].Width = 300;
            band.Columns["Vat"].Header.Caption = "Norma e TVSH %";
            band.Columns["RetailPrice"].Header.Caption = "Çmimi njësi";
            band.Columns["RetailPriceWithVat"].Header.Caption = "Çmimi me Tvsh";
            band.Columns["Expired"].Hidden = true;
            FormatGridCells();
            
        }

        protected string mCurrencyformat = Globals.GetCurrencyFormat();
        protected string mCurrencyformat1 = Globals.GetCurrencyFormat1();
        protected string mCurrencyformatmask = Globals.GetCurrencyFormatMask();

        //Format grid cells currencies
        protected void FormatGridCells()
        {
            
            ug.DisplayLayout.Bands[0].Columns["RetailPriceWithVat"].Format = this.mCurrencyformat;
            ug.DisplayLayout.Bands[0].Columns["RetailPrice"].Format = this.mCurrencyformat;

        }

    }
}