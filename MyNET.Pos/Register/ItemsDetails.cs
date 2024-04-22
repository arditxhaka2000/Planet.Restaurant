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
using Infragistics.Win.UltraWinCalcManager;
using Infragistics.Win.UltraWinCalcManager.FormulaBuilder;
using Infragistics.Win.CalcEngine;
using Infragistics.Win.UltraWinEditors;
using System.IO;
using System.Drawing.Imaging;
using Infragistics.Win;

namespace T3.Pos
{
    public partial class ItemsDetails : Base
    {
        #region Clas members

        protected int mItemId = 0;
        protected int mItemsType = 0;
        
        #endregion

        #region Class Properties

        public int ItemId
        {
            get { return mItemId; }
            set { mItemId = value; }
        }
       

        #endregion

        #region Constructors

        public ItemsDetails()
        {
            InitializeComponent();

            EnableRefresh = false;
            gr1.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            gr2.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            grAssemblies.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            gr3.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            gr4.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            tabItems.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            //this.ug.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            //this.ug.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.ColumnChooserButton;
            //this.ug.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            //this.ug.DisplayLayout.Override.RowSelectorHeaderAppearance.ThemedElementAlpha = Alpha.Default;
            //this.ug.DisplayLayout.Override.RowSelectorHeaderAppearance.BackColor = Color.White;
        }

        public void LoadItems(int itemstype)
        {
            mItemsType = itemstype;

            if(mItemsType == 1)
            {
                cbItemsGoods.Checked = true;
                cbItemsGoods.Visible = true;
                lblItemsType.Text = "Artikull Mall";
                cbKontoA.Value = 31;
                cbKontoB.Value = 82;
                cbKontoC.Value = 77;
                gr3.Visible = false;
            }
            else if(mItemsType == 2)
            {
                cbService.Visible = true;
                lblItemsType.Text = "Artikull Shërbim";
                cbService.Checked = true;
                txtBarcode.Visible = false;
                lblBar.Visible = false;
                cbProducer.Visible = false;
                lblPro.Visible = false;
                lblFoto.Visible = false;
                btnShfleto.Visible = false;
                pbImagePath.Visible = false;
                pbFoto.Visible = false;
                gr3.Visible = false;
                tabItems.TabPages.Remove(tpImage);
            }
            else if (mItemsType == 3)
            {
                cbExpense.Visible = true;
                lblItemsType.Text = "Artikull Shpenzim";
                cbExpense.Checked = true;
                lblBar.Text = "Nr. Kontos";
                lblBar.Visible = false;
                cbProducer.Visible = false;
                lblPro.Visible = false;
                lblFoto.Visible = false;
                cbKontoC.Visible = false;
                btnShfleto.Visible = false;
                pbImagePath.Visible = false;
                pbFoto.Visible = false;
                cbOrigin.Visible = false;
                lblOrigin.Visible = false;
                lblquantity.Visible = false;
                numQuantity.Visible = false;
                lblavg.Visible = false;
                numAvgPrice.Visible = false;
                lblmazha.Visible = false;
                numMazha.Visible = false;
                lblretail.Visible = false;
                numRetailPrice.Visible = false;
                lblretailvat.Visible = false;
                numRetailPriceWithVat.Visible = false;
                lblMalli.Text = "Konto e Shpenzimeve";
                lblTehyrat.Text = "Konto e Shpenzimeve";
                lblTehyrat.Visible = false;
                lblKosto.Visible = false;
                gr3.Visible = false;
                tabItems.TabPages.Remove(tpImage);
            }
            else if (mItemsType == 4)
            {
                cbInventoryItem.Visible = true;
                lblItemsType.Text = "Mjet Themelor";
                cbInventoryItem.Checked = true;
                gr3.Visible = false;
                lbDevaluation.Visible = true;
                numDevaluation.Visible = true;
                tabItems.TabPages.Remove(tpImage);
            }
            else if (mItemsType == 5)
            {
                cbMaterial.Visible = true;
                lblItemsType.Text = "Lënd e parë";
                cbMaterial.Checked = true;
                cbItemsGoods.Checked = true;
                gr3.Visible = false;
                tabItems.TabPages.Remove(tpImage);
            }
            else if (mItemsType == 6)
            {
                cbProduction.Visible = true;
                lblItemsType.Text = "Artikull Prodhim";
                cbProduction.Checked = true;
                cbItemsGoods.Checked = true;
                tabItems.TabPages.Remove(tpImage);
            }
            else if (mItemsType == 7)
            {
                cbAssembled.Visible = true;
                lblItemsType.Text = "Artikull i montuar";
                cbAssembled.Checked = true;
                cbItemsGoods.Checked = true;
                tabItems.TabPages.Remove(tpImage);
            }
        }
        #endregion

        #region Class Methods

        private void CloseAll()
        {
            RegisterDashboard rg = Application.OpenForms.OfType<RegisterDashboard>().FirstOrDefault();
            var controlls = rg.splitDashboard.Panel2.Controls;
            if (controlls != null && controlls.Count > 0)
            {
                foreach (Control cnt in controlls)
                {
                    if (cnt is Form)
                    {
                        ((Form)cnt).Close();
                    }
                }
            }
        }

        protected override void Close1()
        {
            this.Close();
            CloseAll();
            RegisterDashboard rg = Application.OpenForms.OfType<RegisterDashboard>().FirstOrDefault();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmItems frm = new frmItems();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            rg.splitDashboard.Panel2.Controls.Add(frm);
            frm.Show();

            PurchaseDetails pd = Application.OpenForms.OfType<PurchaseDetails>().FirstOrDefault();
            if (pd != null)
            {
                pd.ConfigureUltraDropDown();
            }
        }

        protected override void SaveClose()
        {
            base.SaveClose();           
            if (CheckFields())
            {
                Save();
                Close1();
            }         
        }

        private bool CheckFields()
        {
            bool retvalue = true;
            errprov.Clear();

            if (txtProductNo.Text == string.Empty)
            {
                errprov.SetError(txtProductNo, "Ju lutem shënoni shifren e Artikullit!");
                txtProductNo.BackColor = Color.LightYellow;
                retvalue = false;
            }
            if (txtItemName.Text == "")
            {
                errprov.SetError(txtItemName, "Ju lutem shenoni Emrin e Artikullit!");
                txtItemName.BackColor = Color.LightYellow;
                retvalue = false;
            }
            if (cbUnits.Value == null || cbUnits.Text == "")
            {
                errprov.SetError(cbUnits, "Ju lutem zgjedhni njesine matese!");
                cbUnits.BackColor = Color.LightYellow;
                retvalue = false;
            }
            return retvalue;
        }

        public override void Save()
        {
            base.Save();
            if (CheckFields())
            {
                try
                {
                    mItemId = SaveItems();
                    if(pbImagePath.Text != "")
                    {
                        SaveBlob(mItemId);
                    }
                    
                    if (mItemId > 0 && ug.Rows.Count < 1 && ugAssemblies.Rows.Count < 1)
                    {                        
                        AutoClosingMessageBox.Show("Artikulli është ruajtur me sukses!", "Info!", 900);
                        base.Save();
                        New();
                        return;
                    }
                    else if (mItemId > 0 && ug.Rows.Count > 0 || mItemId > 0 && ugAssemblies.Rows.Count > 0)
                    {
                        int rows = SaveWholeItems(mItemId);
                        int rows1 = SaveAssemblies(mItemId);
                        if (rows  > 0)
                        {
                            mIsChanged = false;
                            //txtID.Text = mSaleId.ToString();
                            AutoClosingMessageBox.Show("Artikulli është ruajtur me sukses!", "Info!", 900);
                            base.Save();
                        }
                        if (rows1 > 0)
                        {
                            mIsChanged = false;
                            //txtID.Text = mSaleId.ToString();
                            AutoClosingMessageBox.Show("Artikulli është ruajtur me sukses!", "Info!", 900);
                            base.Save();
                        }
                        else
                        {
                            MessageBox.Show("Pozicionet e fatures nuk jane ruajtur");
                            TrackError.ReportError(new Exception("SaleDetails.cs Date: " + DateTime.Now + " SaleId = " + mItemId +
                                " SalesDetails rowcounts=" + ug.Rows.Count));
                        }
                    }
                    else
                        MessageBox.Show("Fatura nuk eshte ruajtur!");
                }
                catch (Exception ex)
                {
                    TrackError.ReportError(ex);
                }
            }
        }

        protected int SaveItems()
        {
            Item item = new Item(mItemId);
            item = FillObject(item);
            int result = 0;
            if (mItemId == 0)
            {
                item.CreatedBy = "Admin";
                item.CreatedAt = DateTime.Now;
                result = item.Insert();
            }
            else
            {
                result = item.Update();
                item.ChangedBy = "Admin";
                item.ChangedAt = DateTime.Now;
            }
                
            if (result > 0)
                return item.Id;
            else
            {
                MessageBox.Show("Shitja nuk munde te ruhet! Ju lutem kontaktoni administratorin!");
                return -1;
            }
        }

        protected int SaveWholeItems(int ItemId)
        {
            //Futi detalet
            foreach (UltraGridRow row in ug.Rows.All)
            {
                int detailsid = (int)row.Cells["ID"].Value;
                UnitMultiples details = new UnitMultiples(detailsid);
                details.ItemId = ItemId;
                details.Pcs = (decimal)row.Cells["Pcs"].Value;
                details.MultipleId = (int)row.Cells["MultipleId"].Value;
                details.Price = (decimal)row.Cells["Price"].Value;
                int status = (int)row.Cells["Status"].Value;
                if (status == -1)
                {
                    //if(row.IsDeleted)
                    details.Delete();
                    row.Delete(false);
                }
                else
                {
                    if (details.Id == 0)
                    {
                        details.Insert();
                        row.Cells["ID"].Value = details.Id;
                    }
                    else
                        details.Update();
                }

            }

            //CalculateGridColumns();

            return ug.Rows.Count;
        }

        protected int SaveAssemblies(int ItemId)
        {
            //Futi detalet
            foreach (UltraGridRow row in ugAssemblies.Rows.All)
            {
                int detailsid = (int)row.Cells["ID"].Value;
                Assemblies details = new Assemblies(detailsid);
                details.ItemId = ItemId;
                details.ParentId = (int)row.Cells["ParentId"].Value;
                details.Quantity = (decimal)row.Cells["Quantity"].Value;
                int status = (int)row.Cells["Status"].Value;
                if (status == -1)
                {
                    //if(row.IsDeleted)
                    details.Delete();
                    row.Delete(false);
                }
                else
                {
                    if (details.Id == 0)
                    {
                        details.Insert();
                        row.Cells["ID"].Value = details.Id;
                    }
                    else
                        details.Update();
                }

            }

            //CalculateGridColumns();

            return ugAssemblies.Rows.Count;
        }

        protected int SaveBlob(int mItemId)
        {
            ItemsBlobs blob = new ItemsBlobs(mItemId);
            FillObject(blob);
            int result = 0;
            int ImageId = int.Parse(txtImageID.Text);
            if (ImageId == 0)
            {
                result = blob.InsertImage();
            }
            else 
            {
                result = blob.UpdateImage();
            }
            if (result > 0)
                return blob.ImageId;
            else
            {
                //MessageBox.Show("Shenimet nuk janë ruajtur me sukses!");
                return -1;
            }
        }

        public override void New()
        {
            base.New();
            ClearFields();
            mItemId = 0;
            EnableDelete = false;
        }

        public override void Delete()
        {
            base.Delete();
            if (MessageBox.Show("A jeni të sigurt që dëshironi ta fshini artikullin?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //if (Warehouse.GetQuantity(mItemId,DateTime.Now) > 0)
                //{
                //    MessageBox.Show("Artikulla nuk mundë të fshihet! Sasia ne stoqe eshte me e madhe se 0.");
                //        return;
                //}
                try
                {
                    Item obj = new Item(mItemId);
                    if (obj == null)
                        MessageBox.Show("Categoia me id=" + mItemId + " nuk eksiston");
                    else
                    {
                        int result = obj.Delete();
                        if (result == -1)
                            MessageBox.Show("Artikulli është bere pasiv!");
                        else
                            MessageBox.Show("Artikulli është fshi me sukses!");
                        LoadData();
                        ClearFields();
                        mItemId = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Artikulli nuk mundë të fshihet. Mesazhi i gabimit:" + ex.Message);
                }
            }
        }

        protected override void LoadData()
        {
            //base.LoadData();

            List<VatLevel> puchasestypes = MyNET.DAL.VatLevel.Get();
            cbVatLevel.DataSource = puchasestypes;
            cbVatLevel.DisplayMember = "Value";
            cbVatLevel.ValueMember = "Value";

            numDevaluation.DataSource = MyNET.Helper.Devaluation();
            numDevaluation.DisplayMember = "Name";
            numDevaluation.ValueMember = "ID";

            ArrayList categorie = MyNET.DAL.Categorie.Get();
            if (categorie == null)
                categorie = new ArrayList();
            categorie.Insert(0, new MyNET.DAL.Categorie());
            cbCategories.DataSource = categorie;
            cbCategories.DisplayMember = "Name";
            cbCategories.ValueMember = "ID";

            ArrayList producer = MyNET.DAL.Producer.Get();
            if (producer == null)
                producer = new ArrayList();
            producer.Insert(0, new MyNET.DAL.Producer());
            cbProducer.DataSource = producer;
            cbProducer.DisplayMember = "Name";
            cbProducer.ValueMember = "ID";

            ArrayList unit = MyNET.DAL.Unit.Get();
            if (unit == null)
                unit = new ArrayList();
            unit.Insert(0, new MyNET.DAL.Unit());
            cbUnits.DataSource = unit;
            cbUnits.DisplayMember = "Name";
            cbUnits.ValueMember = "ID";

            ArrayList account = MyNET.DAL.Account.Get();
            if (account == null)
                account = new ArrayList();
            account.Insert(0, new MyNET.DAL.Account());
            cbKontoA.DataSource = account;
            cbKontoA.DisplayMember = "Name";
            cbKontoA.ValueMember = "ID";
            cbKontoB.DataSource = account;
            cbKontoB.DisplayMember = "Name";
            cbKontoB.ValueMember = "ID";
            cbKontoC.DataSource = account;
            cbKontoC.DisplayMember = "Name";
            cbKontoC.ValueMember = "ID";

            //cbItemsGoods.Checked = true;
            //if (mItemId != 0)
            //    FillControls();
            ConfigureUltraDropDown();
            FormatCurrency();
            Item item = new Item(mItemId);
            FillControls(item);
        }

        public override void Refresh()
        {
            base.Refresh();
            LoadData();
        }

        protected void FormatCurrency()
        {
            numRetailPriceWithVat.FormatString = Globals.GetCurrencyFormat();
            numRetailPriceWithVat.MaskInput = Globals.GetCurrencyFormatMask();
            numRetailPrice.FormatString = Globals.GetCurrencyFormat();
            numRetailPrice.MaskInput = Globals.GetCurrencyFormatMask();
        }

        #endregion

        #region Protected methods

        protected void ClearFields()
        {
            txtID.Text = "";
            txtProductNo.Text = "";
            txtBarcode.Text = "";
            txtItemName.Text = "";
            txtDescription.Text = "";
            cbUnits.Text = "";
            cbCategories.Text = "";
            cbProducer.Text = "";
            chkExpired.Checked = false;
            numAvgPrice.Value = 0.00M;
            numQuantity.Value = 0.00M;
            numRetailPrice.Value = 0.00M;
            numAvgPrice.Value = 0.00M;
            numRetailPriceWithVat.Value = 0.00M;
        }

        protected void ChangeControlsColor()
        {
            foreach (Control cnt in gr1.Controls)
            {
                if (cnt is TextBox)
                {
                    ((TextBox)cnt).BackColor = Color.LightGreen;
                }
            }
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            Bitmap bm = null;
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            if (pData != null)
            {
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                bm = new Bitmap(mStream, false);
                mStream.Dispose();
            }
            return bm;

        }

        protected void FillBlob(int ImageId)
        {
            ItemsBlobs art = new ItemsBlobs(mItemId);
            pbImagePath.Text = art.Name;
            pbFoto.Image = ByteToImage(art.BlobData);
            txtImageID.Text = art.ImageId.ToString();
        }

        protected void FillControls(Item art)
        {
            //Item art = new Item(mItemId);
            Warehouse wItem = new Warehouse(mItemId, DateTime.Now.Year);
            if (art != null)
            {
                
                pbImagePath.Text = art.Name;
                txtID.Text = art.Id.ToString();
                cbKontoA.Value = art.AccountA;
                cbKontoB.Value = art.AccountB;
                cbKontoC.Value = art.AccountC;
                txtProductNo.Text = art.ProductNo;
                txtBarcode.Text = art.Barcode;
                txtItemName.Text = art.ItemName;
                numQuantity.Value = wItem.InStock;
                cbVatLevel.Value = art.Vat;

                numRetailPrice.Value = art.RetailPrice;
                numAvgPrice.Value = wItem.AvgPrice;
                
                chkExpired.Checked = art.Expired;
                cbItemsGoods.Checked = art.ItemGoods;
                cbService.Checked = art.Service;
                cbExpense.Checked = art.Expense;
                cbInventoryItem.Checked = art.InventoryItem;
                cbMaterial.Checked = art.Material;
                cbProduction.Checked = art.Production;
                cbAssembled.Checked = art.Assembled;
                decimal price = art.RetailPrice;
                int vat = int.Parse(cbVatLevel.Text);
                //decimal priceWithVat = price * (1 + vat / 100);
                //numRetailPriceWithVat.Value = priceWithVat;
                cbProducer.Value = art.ProducerId;
                cbCategories.Value = art.CategoryId;
                cbUnits.Value = art.UnitId;
                if (cbItemsGoods.Checked)
                {
                    cbItemsGoods.Visible = true;
                    lblItemsType.Text = "Artikull Mall";
                }
                if (cbService.Checked)
                {
                    cbService.Visible = true;
                    lblItemsType.Text = "Artikull Shërbim";
                }
                if (cbExpense.Checked)
                {
                    cbExpense.Visible = true;
                    lblItemsType.Text = "Artikull Shpenzim";
                }
                if (cbInventoryItem.Checked)
                {
                    cbInventoryItem.Visible = true;
                    lblItemsType.Text = "Mjet Themelor";
                }
                if (cbMaterial.Checked)
                {
                    cbMaterial.Visible = true;
                    lblItemsType.Text = "Lënd e parë";
                }
                if (cbProduction.Checked)
                {
                    cbProduction.Visible = true;
                    lblItemsType.Text = "Artikull Prodhim";
                }
                if (cbAssembled.Checked)
                {
                    cbAssembled.Visible = true;
                    lblItemsType.Text = "Artikull i montuar";
                }
            }
            else
                MessageBox.Show("Artikulli me id " + mItemId + " nuk ekziston");
            FillBlob(art.Id);
            LoadWholeItems(art.Id);
        }

        protected ItemsBlobs FillObject(ItemsBlobs art)
        {
            try
            {
                art.ItemId = mItemId;
                MemoryStream ms = new MemoryStream();
                pbFoto.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                art.BlobData = photo_aray;
                art.Name = pbImagePath.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return art;
        }

        protected Item FillObject(Item art)
        {
            try
            {
                art.AccountA = (cbKontoA.Value == null) ? 0 : (int)cbKontoA.Value;
                art.AccountB = (cbKontoB.Value == null) ? 0 : (int)cbKontoB.Value;
                art.AccountC = (cbKontoC.Value == null) ? 0 : (int)cbKontoC.Value;
                art.ProductNo = txtProductNo.Text;
                art.Barcode = txtBarcode.Text;
                art.ItemName = txtItemName.Text;
                art.Expired = chkExpired.Checked;
                art.InventoryItem = cbInventoryItem.Checked;
                art.Material = cbMaterial.Checked;
                art.Production = cbProduction.Checked;
                art.ItemGoods = cbItemsGoods.Checked;
                art.Service = cbService.Checked;
                art.Expense = cbExpense.Checked;
                art.Assembled = cbAssembled.Checked;
                art.CreatedBy = Globals.User.Identity.Name;
                art.ChangedBy = Globals.User.Identity.Name;
                art.RetailPrice = Convert.ToDecimal(numRetailPrice.Value);
                //art.Devaluation = Convert.ToDecimal(numDevaluation.Value);
                art.Vat = (cbVatLevel.Value == null) ? 0 : (int)cbVatLevel.Value;
                art.ProducerId = (cbProducer.Value == null) ? 0 : (int)cbProducer.Value;
                art.CategoryId = (cbCategories.Value == null) ? 0 : (int)cbCategories.Value;
                art.UnitId = (cbUnits.Value == null) ? 0 : (int)cbUnits.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return art;
        }

        #endregion

        #region Calculate Price

        private void PriceChange()
        {
            try
            {
                numRetailPriceWithVat.ValueChanged -= new EventHandler(numRetailPriceWithVat_ValueChanged);

                decimal price = Convert.ToDecimal(numRetailPrice.Value);
                decimal vat = Convert.ToDecimal(cbVatLevel.Value);
                decimal priceWithVat = price * (1 + vat / 100);
                numRetailPriceWithVat.Value = priceWithVat;

                numRetailPriceWithVat.ValueChanged += new EventHandler(numRetailPriceWithVat_ValueChanged);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VatPriceChange()
        {
            try
            {
                numRetailPrice.ValueChanged -= new EventHandler(numRetailPrice_ValueChanged);

                decimal priceWithVat = Convert.ToDecimal(numRetailPriceWithVat.Value);
                decimal vat = Convert.ToDecimal(cbVatLevel.Value);
                decimal price = priceWithVat / (1 + vat / 100);
                numRetailPrice.Value = price;

                numRetailPrice.ValueChanged += new EventHandler(numRetailPrice_ValueChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbVatLevel_ValueChanged(object sender, EventArgs e)
        {
            VatPriceChange();
        }

        private void numRetailPriceWithVat_ValueChanged(object sender, EventArgs e)
        {
            VatPriceChange();
        }

        private void numRetailPrice_ValueChanged(object sender, EventArgs e)
        {
            PriceChange();
        }

        #endregion

        #region Event handlers

        private void cbCategories_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (e.Button.Key == "btnAdd")
            {
                frmCategories frm = new frmCategories();
                frm.ShowDialog();
                LoadData();
            }
        }

        private void cbUnits_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (e.Button.Key == "btnAdd")
            {
               frmUnits frm = new frmUnits();
                frm.ShowDialog();
                LoadData();
            }
        }

        private void cbProducer_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (e.Button.Key == "btnAdd")
            {
                frmProducers frm = new frmProducers();
                frm.ShowDialog();
                LoadData();
            }
        }

        private void cbService_CheckedChanged(object sender, EventArgs e)
        {
            txtBarcode.Visible = false;
            lblBar.Visible = false;
            cbProducer.Visible = false;
            lblPro.Visible = false;
            lblFoto.Visible = false;
            btnShfleto.Visible = false;
            pbImagePath.Visible = false;
            pbFoto.Visible = false;
        }

        private void cbExpense_CheckedChanged(object sender, EventArgs e)
        {
            cbExpense.Checked = true;
            txtBarcode.Visible = false;
            lblBar.Visible = false;
            cbProducer.Visible = false;
            lblPro.Visible = false;
            lblFoto.Visible = false;
            cbKontoC.Visible = false;
            btnShfleto.Visible = false;
            pbImagePath.Visible = false;
            pbFoto.Visible = false;
            cbOrigin.Visible = false;
            lblOrigin.Visible = false;
            lblquantity.Visible = false;
            numQuantity.Visible = false;
            lblavg.Visible = false;
            numAvgPrice.Visible = false;
            lblmazha.Visible = false;
            numMazha.Visible = false;
            lblretail.Visible = false;
            numRetailPrice.Visible = false;
            lblretailvat.Visible = false;
            numRetailPriceWithVat.Visible = false;
        }

        #endregion

        #region images

        private void btnShfleto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "images files|*.jpg;*.png;*.gif";
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.Cancel)
                return;

            pbFoto.Image = Image.FromFile(ofd.FileName);
            pbImagePath.Text = ofd.FileName;
        }

        #endregion

        #region Kontotot

        private void cbKonto_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band1 = cbKontoA.DisplayLayout.Bands[0];
            band1.Columns["ID"].Hidden = true;
            band1.Columns["GroupID"].Hidden = true;
            band1.Columns["PID"].Hidden = true;

            band1.Columns["AccountNumber"].Width = 88;
            band1.Columns["Name"].Width = 215;
            band1.Columns["AccountNumber"].Header.Caption = "Konto";
            band1.Columns["Name"].Header.Caption = "Emertimi";
        }

        private void cbKonto1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band1 = cbKontoB.DisplayLayout.Bands[0];
            band1.Columns["ID"].Hidden = true;
            band1.Columns["GroupID"].Hidden = true;
            band1.Columns["PID"].Hidden = true;

            band1.Columns["AccountNumber"].Width = 88;
            band1.Columns["Name"].Width = 215;
            band1.Columns["AccountNumber"].Header.Caption = "Konto";
            band1.Columns["Name"].Header.Caption = "Emertimi";
        }

        private void cbKonto2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band1 = cbKontoC.DisplayLayout.Bands[0];
            band1.Columns["ID"].Hidden = true;
            band1.Columns["GroupID"].Hidden = true;
            band1.Columns["PID"].Hidden = true;

            band1.Columns["AccountNumber"].Width = 88;
            band1.Columns["Name"].Width = 215;
            band1.Columns["AccountNumber"].Header.Caption = "Konto";
            band1.Columns["Name"].Header.Caption = "Emertimi";
        }

        private void cbKontoA_KeyUp(object sender, KeyEventArgs e)
        {
            var layout = cbKontoA.DisplayLayout.Bands[0];
            string outputInfo = cbKontoA.Text;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in cbKontoA.Rows)
            {
                row.Hidden = false;
            }

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in cbKontoA.Rows)
            {
                bool filterRow = true;
                string name = row.Cells["Name"].Text.ToLower();
                string nr = row.Cells["AccountNumber"].Text.ToLower();
                if (name.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }

                if (nr.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }

                row.Hidden = filterRow;
            }
        }

        private void cbKontoB_KeyUp(object sender, KeyEventArgs e)
        {
            var layout = cbKontoB.DisplayLayout.Bands[0];
            string outputInfo = cbKontoB.Text;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in cbKontoB.Rows)
            {
                row.Hidden = false;
            }

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in cbKontoB.Rows)
            {
                bool filterRow = true;
                string name = row.Cells["Name"].Text.ToLower();
                string nr = row.Cells["AccountNumber"].Text.ToLower();
                if (name.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }

                if (nr.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }

                row.Hidden = filterRow;
            }
        }

        private void cbKontoC_KeyUp(object sender, KeyEventArgs e)
        {
            var layout = cbKontoC.DisplayLayout.Bands[0];
            string outputInfo = cbKontoC.Text;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in cbKontoC.Rows)
            {
                row.Hidden = false;
            }

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in cbKontoC.Rows)
            {
                bool filterRow = true;
                string name = row.Cells["Name"].Text.ToLower();
                string nr = row.Cells["AccountNumber"].Text.ToLower();
                if (name.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }

                if (nr.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }

                row.Hidden = filterRow;
            }
        }

        #endregion

        private void cbOrigin_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            if (e.Button.Key == "btnAdd")
            {
                frmItemsOrigin frm = new frmItemsOrigin();
                frm.ShowDialog();
                LoadData();
            }
        }
        protected void LoadWholeItems(int ItemId)
        {
            DataTable itemid = UnitMultiples.GetMultiplesByItemId(mItemId);
            ug.DataSource = itemid;
            DataTable assemblies = Assemblies.GetAssembliesByItemId(mItemId);
            ugAssemblies.DataSource = assemblies;
        }
        private void ConfigureUltraDropDown()
        {
            try
            {
                DataTable dt = MyNET.DAL.Item.GetItemsFromStock(DateTime.Now, Globals.UserSettings.WarehouseId, (bool)Globals.Settings.HideOrShowLackItems, 0);
                DataTable pr = MyNET.DAL.Project.GetProjects();

                uddItemsNames.DisplayMember = "ItemName";             
                uddItemsNames.ValueMember = "ID";
                

                if (dt == null)
                    return;
                // DataSource:
                DataTable dtItemsName = dt.Copy();

                DataView dvBarcode = dt.DefaultView;
                DataView dvItemsName = dtItemsName.DefaultView;
                
                dvItemsName.Sort = "ItemName";

                uddItemsNames.DataSource = dt;

                dvItemsName = null;               

                var _with2 = uddItemsNames.DisplayLayout.Bands[0];
                _with2.Columns["ID"].Hidden = true;
                _with2.Columns["ItemId"].Hidden = true;
                _with2.Columns["ProductNo"].Hidden = true;
                _with2.Columns["Purchases"].Hidden = true;
                _with2.Columns["Sales"].Hidden = true;
                _with2.Columns["AvgPrice"].Hidden = true;
                _with2.Columns["Vat"].Hidden = true;
                _with2.Columns["SalePrice"].Hidden = true;
                _with2.Columns["Total"].Hidden = true;
                _with2.Columns["Status"].Hidden = true;

                _with2.Columns["Unit"].Hidden = true;
                _with2.Columns["Nr"].Width = 30;
                _with2.Columns["Barcode"].Width = 100;
                _with2.Columns["ItemName"].Width = 250;
                _with2.Columns["Barcode"].Header.Caption = "Barkodi";
                _with2.Columns["ItemName"].Header.Caption = "Emri i Artikullit";
                _with2.Columns["Unit"].Header.Caption = "Njesia";
                _with2.Columns["Quantity"].Hidden = true;
                _with2.Columns["PriceWithVat"].Header.Caption = "Çmimi i Shitjes";
                _with2.Columns["Quantity"].Format = this.mCurrencyformat1;
                _with2.Columns["PriceWithVat"].Format = this.mCurrencyformat;
          

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void AddNewRowAssemblies()
        {
            ugAssemblies.EventManager.SetEnabled(GridEventIds.AfterCellUpdate, false);
            ugAssemblies.EventManager.SetEnabled(GridEventIds.CellListSelect, false);

            UltraGridRow row = ugAssemblies.DisplayLayout.Bands[0].AddNew();
            row.Cells["Id"].Value = 0.0M;
            row.Cells["ItemId"].Value = 0;
            row.Cells["ParentId"].Value = 0.0D;
            row.Cells["Quantity"].Value = 0.00;
            row.Cells["Status"].Value = 0;

            ugAssemblies.PerformAction(UltraGridAction.EnterEditMode);
            //row.Cells["ProductNo"].Activate();

            ugAssemblies.EventManager.SetEnabled(GridEventIds.AfterCellUpdate, true);
            ugAssemblies.EventManager.SetEnabled(GridEventIds.CellListSelect, true);
        }

        protected void AddNewRow()
        {
            ug.EventManager.SetEnabled(GridEventIds.AfterCellUpdate, false);
            ug.EventManager.SetEnabled(GridEventIds.CellListSelect, false);

            UltraGridRow row = ug.DisplayLayout.Bands[0].AddNew();
            row.Cells["Id"].Value = 0.0M;
            row.Cells["Price"].Value = 0;
            row.Cells["Pcs"].Value = 0.0D;
            row.Cells["MultipleId"].Value = 1;
            //row.Cells["Status"].Value = 0;

            ug.PerformAction(UltraGridAction.EnterEditMode);
            //row.Cells["ProductNo"].Activate();

            ug.EventManager.SetEnabled(GridEventIds.AfterCellUpdate, true);
            ug.EventManager.SetEnabled(GridEventIds.CellListSelect, true);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
            ug.PerformAction(UltraGridAction.EnterEditMode);
        }

        private void ug_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band1 = ug.DisplayLayout.Bands[0];
            band1.Columns["Id"].Hidden = true;
            band1.Columns["ItemId"].Hidden = true;
            ug.DisplayLayout.Bands[0].Columns["Pcs"].Header.Caption = "Copë";
            ug.DisplayLayout.Bands[0].Columns["MultipleId"].Header.Caption = "Shumëfishi";
            ug.DisplayLayout.Bands[0].Columns["Price"].Header.Caption = "Cmimi i Pakos";
            FormatGridCells();
        }
        protected string mCurrencyformat1 = Globals.GetCurrencyFormat1();
        protected string mCurrencyformat = Globals.GetCurrencyFormat();
        protected void FormatGridCells()
        {
            ug.DisplayLayout.Bands[0].Columns["Pcs"].Format = this.mCurrencyformat1;
            ug.DisplayLayout.Bands[0].Columns["Price"].Format = this.mCurrencyformat;
        }

        private void ItemsDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnProduction_Click(object sender, EventArgs e)
        {
            AddNewRowAssemblies();
        }

        private void ugAssemblies_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band1 = ugAssemblies.DisplayLayout.Bands[0];
            band1.Columns["Id"].Hidden = true;
            band1.Columns["ItemId"].Hidden = true;
            band1.Columns["Status"].Hidden = true;
            band1.Columns["ParentId"].ValueList = uddItemsNames;
            band1.Columns["ParentId"].Header.Caption = "Artikulli";
            band1.Columns["Quantity"].Header.Caption = "Sasia";
        }

        protected void DeleteAssemblies()
        {
            if (ugAssemblies.ActiveRow != null)
            {
                int index = ugAssemblies.ActiveRow.Index;
                int id = 0;
                if (ugAssemblies.ActiveRow.Cells["ID"].Value.ToString() != string.Empty)
                    id = (int)ugAssemblies.ActiveRow.Cells["ID"].Value;
                if (id == 0)
                    ugAssemblies.ActiveRow.Delete();
                else
                {
                    UltraGridRow row = ugAssemblies.ActiveRow;
                    row.Hidden = true;
                    row.Cells["Status"].Value = -1;
                    mIsChanged = true;
                }
                if (index > 0)
                    ugAssemblies.Rows[index - 1].Activate();              
            }
        }

        protected void DeletePackage()
        {
            if (ug.ActiveRow != null)
            {
                int index = ug.ActiveRow.Index;
                int id = 0;
                if (ug.ActiveRow.Cells["ID"].Value.ToString() != string.Empty)
                    id = (int)ug.ActiveRow.Cells["ID"].Value;
                if (id == 0)
                    ug.ActiveRow.Delete();
                else
                {
                    UltraGridRow row = ug.ActiveRow;
                    row.Hidden = true;
                    row.Cells["Status"].Value = -1;
                    mIsChanged = true;
                }
                if (index > 0)
                    ug.Rows[index - 1].Activate();
            }
        }

        private void btnRemoveAssemblies_Click(object sender, EventArgs e)
        {
            DeleteAssemblies();
        }

        private void btnRemovePackage_Click(object sender, EventArgs e)
        {
            DeletePackage();
        }

        private void ugAssemblies_KeyUp(object sender, KeyEventArgs e)
        {
            if (Globals.UserSettings.SearchStatus != true)
            {
                return;
            }
            else
            {
                var layout = uddItemsNames.DisplayLayout.Bands[0];
                string outputInfo = ugAssemblies.ActiveCell.Text;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in uddItemsNames.Rows)
                {
                    row.Hidden = false;
                }

                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in uddItemsNames.Rows)
                {
                    bool filterRow = true;
                    string itemname = row.Cells["ItemName"].Text.ToLower();
                    //string barcode = row.Cells["Barcode"].Text.ToLower();

                    if (itemname.Contains(outputInfo.ToLower()))
                    {
                        filterRow = false;
                    }
                    //if (barcode.Contains(outputInfo.ToLower()))
                    //{
                    //    filterRow = false;
                    //}
                    row.Hidden = filterRow;
                }
                string[] keyWords = uddItemsNames.Text.Split(' ');
            }
        }

    }
}
