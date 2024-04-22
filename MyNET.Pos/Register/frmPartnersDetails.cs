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
using MyNET;

namespace T3.Pos
{
    public partial class frmPartnersDetails : Base
    {
        int mPartnerId = 0;

        public int PartnerId
        {
            get { return mPartnerId; }
            set { mPartnerId = value; }
        }

        public frmPartnersDetails()
        {
            InitializeComponent();
            
            gr1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
        }

        public frmPartnersDetails(int PartnerId)
        {
            InitializeComponent();
            mPartnerId = PartnerId;

            cbCountry.ValueMember = "ID";
            cbCountry.DisplayMember = "Name";
            //cbCountry.DataSource = MyNET.DAL.Country.Get();
            //cbCountry.Items.Insert(0, null);

           

            GetData(mPartnerId);
        }
        public override void New()
        {
            base.New();
            ClearFields();
            mPartnerId = 0;
        }
        protected void ClearFields()
        {
            txtSaveAs.Text = "";
            cbPartnerType.Text = "";
            txtCompany.Text = "";
            txtFiscalNo.Text = "";
            txtBusinessNo.Text = "";
            txtVatNo.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            cbBleres.Checked = false;
            cbFurnitor.Checked = false;
            cbBlFu.Checked = false;
            txtPhone.Text = "";
            txtMobilePhone.Text = "";
            txtAddress.Text = "";
            txtComment.Text = "";
            txtBorgji.Text = "";
            txtLimitBorgji.Text = "";
            cbCountry.Text = "";
            cbCity.Text = "";
            cbPOrigin.Text = "";
        }
        private bool CheckFields()
        {
            bool retvalue = true;
            errprov.Clear();

            if (!cbBleres.Checked && !cbFurnitor.Checked && !cbBlFu.Checked)
            {
                errprov.SetError(cbBlFu, "Ju lutem zgjedhni tipin e Partnerit!");
                retvalue = false;
            }

            if (txtCompany.Text == string.Empty)
            {
                errprov.SetError(txtCompany, "Ju lutem shënoni emrin e kompanise");
                txtCompany.BackColor = Color.LightYellow;
                retvalue = false;
            }
            if (txtSaveAs.Text == "")
            {
                errprov.SetError(txtSaveAs, "Ju lutem shenoni emrin e kompanise ne fushen 'Ruaj Si'!");
                txtSaveAs.BackColor = Color.LightYellow;
                retvalue = false;
            }
            if (txtFiscalNo.Text == "")
            {
                errprov.SetError(txtFiscalNo, "Ju lutem shenoni numrin fiskal!");
                txtSaveAs.BackColor = Color.LightYellow;
                retvalue = false;
            }
            return retvalue;
        }                  

        protected Partner FillObject(Partner cs)
        {
            try
            {
                cs.Id = mPartnerId;
                cs.Name = txtName.Text;
                cs.Surname = txtSurname.Text;
                cs.CompanyName = txtCompany.Text;
                cs.SaveAs = txtSaveAs.Text;
                cs.PartnerType = (int)cbPartnerType.Value;
                //cs.PartnerOrigin = (int)cbPOrigin.Value;
                cs.Phone = txtPhone.Text.Trim();
                cs.MobilePhone = txtMobilePhone.Text.Trim();
                cs.Address = txtAddress.Text.Trim();
                cs.Country = (cbCountry.Value != null) ?  (int?) cbCountry.Value : null;
                cs.City = (int)cbCity.Value;//(cbCity.Value != null) ? (int?) cbCity.Value : null;

                cs.Supplier = cbFurnitor.Checked;
                cs.Customer = cbBleres.Checked;
                //cs.Inactive = cbInactive.Checked;

                cs.CreatedBy = Globals.User.Identity.Name;
                cs.ChangedBy = Globals.User.Identity.Name;

                if (cbBlFu.Checked)
                {
                    cs.Supplier = cbBlFu.Checked;
                    cs.Customer = cbBlFu.Checked;
                }

                cs.BusinessNo = txtBusinessNo.Text.Trim();
                cs.FiscalNo = txtFiscalNo.Text.Trim();
                cs.VatNo = txtVatNo.Text.Trim();
                cs.Comment = txtComment.Text;
                cs.Discount = Convert.ToDecimal(numDiscount.Value);
                cs.PaymentTypeId = (int)cbPaymentType.Value;
                cs.ImportOrLocal = false;//(bool)cbImportOrLocal.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cs;
        }
        
        private void GetData(int customerid)
        {
            Partner partner = Partner.Get(customerid);
            if (partner == null)
                return;

            txtName.Text = partner.Name;
            txtSurname.Text = partner.Surname;
            txtCompany.Text = partner.CompanyName;
            txtSaveAs.Text = partner.SaveAs;
           
            txtPhone.Text = partner.Phone;
            txtMobilePhone.Text = partner.MobilePhone;
            cbPartnerType.Value = partner.PartnerType;
            cbPOrigin.Value = partner.PartnerOrigin;
            txtAddress.Text = partner.Address;
            cbCountry.Value = partner.Country;
            cbCity.Value = partner.City;
            cbBleres.Checked = partner.Customer;
            cbFurnitor.Checked = partner.Supplier;
            //cbInactive.Checked = partner.Inactive;

            if (cbBleres.Checked & cbFurnitor.Checked)
            {
                cbBlFu.Checked = partner.Customer;
                cbBlFu.Checked = partner.Supplier;
            }
             

            txtBusinessNo.Text = partner.BusinessNo;
            txtFiscalNo.Text = partner.FiscalNo;
            txtVatNo.Text = partner.VatNo;
            
            txtComment.Text = partner.Comment;
            numDiscount.Value = partner.Discount;
            cbPaymentType.Value = partner.PaymentTypeId;
            cbImportOrLocal.Value = partner.ImportOrLocal;
            EnableSave = true;
            EnableDelete = true;

        }
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
            frmPartnersList frm = new frmPartnersList();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            rg.splitDashboard.Panel2.Controls.Add(frm);
            frm.Show();
        }


        protected override void LoadData()
        {
            base.LoadData();
            //List<PartnerOrigin> partnerorigin = MyNET.DAL.PartnerOrigin.Get();
            //if (partnerorigin == null)
            //    partnerorigin = new List<PartnerOrigin>();
            //partnerorigin.Insert(0, new PartnerOrigin(0, ""));
            //cbPOrigin.DataSource = partnerorigin;
            //cbPOrigin.DisplayMember = "Name";
            //cbPOrigin.ValueMember = "ID";

            List<PartnerType> partnertype = MyNET.DAL.PartnerType.Get();
            if (partnertype == null)
                partnertype = new List<PartnerType>();
            partnertype.Insert(0, new PartnerType(0, ""));
            cbPartnerType.DataSource = partnertype;
            cbPartnerType.DisplayMember = "Name";
            cbPartnerType.ValueMember = "ID";

            //ArrayList countries = MyNET.DAL.Country.Get();
            //if (countries == null)
            //    countries = new ArrayList();
            //countries.Insert(0, new MyNET.DAL.Country());
            //cbCountry.DataSource = countries;
            //cbCountry.DisplayMember = "Name";
            //cbCountry.ValueMember = "ID";

            //ArrayList cities = MyNET.DAL.City.Get();
            //if (cities == null)
            //    cities = new ArrayList();
            //cities.Insert(0, new MyNET.DAL.City());
            //cbCity.DataSource = cities;
            //cbCity.DisplayMember = "Name";
            //cbCity.ValueMember = "ID";

            List<PaymentMethod> paymentmethod = MyNET.DAL.PaymentMethod.Get();
            if (paymentmethod == null)
                paymentmethod = new List<PaymentMethod>();
            paymentmethod.Insert(0, new PaymentMethod(0, ""));
            cbPaymentType.DataSource = paymentmethod;
            cbPaymentType.DisplayMember = "Name";
            cbPaymentType.ValueMember = "Id";

            //cbImportOrLocal.DataSource = MyNET.MyNET.Helper.ImportOrLocal();
            //cbImportOrLocal.DisplayMember = "Name";
            //cbImportOrLocal.ValueMember = "ID";
            //cbImportOrLocal.Value = false;

        }

        protected override void SaveClose()
        {
            base.SaveClose();
            Save();
            if (CheckFields())
            {
                Close1();
            }

        }
        public override void Save()
        {
            base.Save();
            if (CheckFields())
            {
                try
                {
                    Partner cl = new Partner(mPartnerId);
                    cl = FillObject(cl);
                    int nres = 0;
                    if (cl.Id == 0)
                        nres = cl.Insert();
                    else nres = cl.Update();
                    if (nres > 0)
                    {
                        AutoClosingMessageBox.Show("Shenimet janë ruajtur me sukses!", "Info!", 900);
                        this.DialogResult = DialogResult.OK;
                        New();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gabim gjatë ruajtjes së shënimeve: \n" + ex.ToString());
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtSaveAs.Text = txtName.Text + " " + txtSurname.Text + " " + txtCompany.Text;
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            txtSaveAs.Text = txtName.Text + " " + txtSurname.Text + " " + txtCompany.Text;
        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            txtSaveAs.Text = txtCompany.Text;// + " " + txtSurname.Text + " " + txtCompany.Text;
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int countryid = (cbCountry.Value != null) ? (int)cbCountry.Value : 0;
            //cbCity.DataSource = MyNET.DAL.City.GetCitiesByCountryId(countryid);
            //cbCity.ValueMember = "ID";
            //cbCity.DisplayMember = "Name";
        }

        private void frmCustomerDetails_Load(object sender, EventArgs e)
        {
           
        }

        private void cbBlFu_Click(object sender, EventArgs e)
        {
            cbBleres.Checked = false;
            cbFurnitor.Checked = false;
        }

        private void cbPartnerType_ValueChanged(object sender, EventArgs e)
        {
            //if((int)cbPartnerType.Value == 2)
            //{
            //    txtName.Visible = true;
            //    txtSurname.Visible = true;
            //    lblName.Visible = true;
            //    lblSurname.Visible = true;
            //}
            //else
            //{
            //    txtName.Visible = false;
            //    txtSurname.Visible = false;
            //    lblName.Visible = false;
            //    lblSurname.Visible = false;
            //}
        }
    }
}
