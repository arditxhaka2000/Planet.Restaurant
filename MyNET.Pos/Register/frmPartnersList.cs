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

namespace T3.Pos
{
    public partial class frmPartnersList : Base
    {
        public frmPartnersList()
        {
            InitializeComponent();
            EnableNew = true;
            //EnableOpen = true;
            EnableDelete = true;
            EnableRefresh = true;
            grSearch.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            grUg.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            grChart.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            ug.Dock = DockStyle.Fill;            
        }

        private void frmPartnerList_Load(object sender, EventArgs e)
        {
            LoadData();
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        protected override void ExportExcell()
        {
            base.ExportExcell();
            //MyNET.GridHelper.ExportExcel(ug);
        }

        protected override void Close1()
        {
            if (this.ParentForm != null)
                this.ParentForm.Close();
            else
                this.Close();
        }
        public override void New()
        {
            frmPartnersDetails frm = new frmPartnersDetails();
            frmPartnersList pl = Application.OpenForms.OfType<frmPartnersList>().FirstOrDefault();
            //frmItems it = Application.OpenForms.OfType<frmItems>().FirstOrDefault();
            RegisterDashboard rg = Application.OpenForms.OfType<RegisterDashboard>().FirstOrDefault();
            frmPartnersDetails form = Application.OpenForms.OfType<frmPartnersDetails>().FirstOrDefault();
            if (form == null)
            {
                
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frm.Dock = DockStyle.Fill;
                frm.TopLevel = false;
                rg.splitDashboard.Panel2.Controls.Add(frm);
                frm.Show();
               
            }
            if(pl != null)
            {
                pl.Close();
            }
            //if (it != null)
            //{
            //    it.Close();
            //}
        }

       

        protected override void LoadData()
        {
            CustomerSearch();
            string where = " 1 = 1 ";
            ug.DataSource = MyNET.DAL.Partner.Search(where, "");
        }

        public override void Delete()
        {
            if (MessageBox.Show("A deshironi ta fshini shitjen?", "Fshi shitjen", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                return;
            if (ug.ActiveRow == null)
            {
                MessageBox.Show("Ju lutem zgjedhe një blerës për të fshirë!");
                return;
            }
            int id = (int)ug.ActiveRow.Cells["ID"].Value;
            MyNET.DAL.Partner sale = new MyNET.DAL.Partner(id);
            int result = 0;
            if (sale.Id != 0)
                result = sale.Delete();
            if (result > 0)
            {
                MessageBox.Show("Blerësi është fshi me sukses!");
                LoadData();
            }            
        } 
       
        public override void Open()
        {            
            if (ug.ActiveRow == null)
                return;
            else
            {
                frmPartnersList pl = Application.OpenForms.OfType<frmPartnersList>().FirstOrDefault();
                RegisterDashboard rg = Application.OpenForms.OfType<RegisterDashboard>().FirstOrDefault();

                int id = (int) ug.ActiveRow.Cells["ID"].Value;
                frmPartnersDetails frm = new frmPartnersDetails(id);
                frm.Dock = DockStyle.Fill;
                frm.TopLevel = false;
                rg.splitDashboard.Panel2.Controls.Add(frm);
                pl.Close();
                frm.PartnerId = id;
                frm.Show();
            }
        }

        private void ug_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            var with1 = ug.DisplayLayout.Bands[0];
            with1.Columns["ID"].Hidden = true;
            with1.Columns["Name"].Width = 100;
            with1.Columns["Surname"].Width = 100;
            with1.Columns["SaveAs"].Width = 250;
            with1.Columns["CompanyName"].Width = 200;

        }
        public void CustomerSearch()
        {
            if (cbCustomer.Checked == true && cbSupplier.Checked == false)
            {               
                ug.DataSource = Partner.Search(" Customer = 1 ", "");
            }
            else if (cbSupplier.Checked == true && cbCustomer.Checked == false)
            {              
                ug.DataSource = Partner.Search(" Supplier = 1 ", "");
            }
            if (cbCusSup.Checked == true )
            {
                ug.DataSource = Partner.Search(" Supplier = 1 OR Customer = 1 ", "");
            }            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CustomerSearch();   
        }

        private void cbCustomer_Click(object sender, EventArgs e)
        {
            cbCusSup.Checked = false;
            cbSupplier.Checked = false;
            CustomerSearch();
        }

        private void cbSupplier_Click(object sender, EventArgs e)
        {
            cbCustomer.Checked = false;
            cbCusSup.Checked = false;
            CustomerSearch();            
        }

        private void cbCusSup_Click(object sender, EventArgs e)
        {
            cbSupplier.Checked = false;
            cbCustomer.Checked = false;
            CustomerSearch();           
        }

        private void txtFiscal_KeyUp(object sender, KeyEventArgs e)
        {
            var layout = ug.DisplayLayout.Bands[0];
            string outputInfo = txtFiscal.Text;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ug.Rows)
            {
                row.Hidden = false;
            }

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ug.Rows)
            {
                bool filterRow = true;
                string companyname = row.Cells["CompanyName"].Text.ToLower();
                string vatno = row.Cells["VatNo"].Text.ToLower();
                string fiscalno = row.Cells["FiscalNo"].Text.ToLower();
                string businessno = row.Cells["BusinessNo"].Text.ToLower();
                string address = row.Cells["Address"].Text.ToLower();
                string city = row.Cells["City"].Text.ToLower();
                string phone = row.Cells["Phone"].Text.ToLower();

                if (companyname.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }
                if (vatno.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }
                if (fiscalno.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }
                if (businessno.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }
                if (address.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }
                if (city.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }
                if (phone.Contains(outputInfo.ToLower()))
                {
                    filterRow = false;
                }
                row.Hidden = filterRow;
            }
        }

        private void ug_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            var band = ug.DisplayLayout.Bands[0];
            band.Columns["ID"].Hidden = true;
            band.Columns["MobilePhone"].Hidden = true;
            band.Columns["Country"].Hidden = true;
            band.Columns["CreatedAt"].Hidden = true;
            band.Columns["CreatedBy"].Hidden = true;
            band.Columns["ChangedAt"].Hidden = true;
            band.Columns["ChangedBy"].Hidden = true;
            band.Columns["Status"].Hidden = true;
            //band.Columns["Name"].Hidden = true;
            //band.Columns["Surname"].Hidden = true;
            //band.Columns["SaveAs"].Hidden = true;

            band.Columns["VatNo"].Header.Caption = "Numri i TVSH";
            band.Columns["CompanyName"].Header.Caption = "Emri i Kompanis";
            band.Columns["Phone"].Header.Caption = "Telefoni";
            band.Columns["BusinessNo"].Header.Caption = "Numri i Biznesit";
            band.Columns["FiscalNo"].Header.Caption = "Numri Fiskal";
            band.Columns["Address"].Header.Caption = "Adresa";
            band.Columns["City"].Header.Caption = "Qyteti";
            band.Columns["Customer"].Header.Caption = "Blerës";
            band.Columns["Supplier"].Header.Caption = "Furnitorë";
            //band.Columns["Comment"].Hidden = true;
        }

        
    }
}
