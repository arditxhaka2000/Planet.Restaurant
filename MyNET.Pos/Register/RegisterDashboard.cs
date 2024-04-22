using MyNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3.Pos
{
    public partial class RegisterDashboard : Form
    {
        public RegisterDashboard()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void CloseAll()
        {
            var controlls = this.splitDashboard.Panel2.Controls;
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

        //private void BtnActive(object sender)
        //{
        //    Button b = (Button)sender;
        //    b.BackColor = Color.SteelBlue;

        //    foreach (Button bt in b.Parent.Controls.OfType<Button>())
        //    {
        //        if (bt != b && bt.BackColor == Color.DimGray)
        //            bt.BackColor = Color.DimGray;
        //        if (bt != b && bt.BackColor == Color.SteelBlue)
        //            bt.BackColor = Color.DimGray;
        //        if (bt != b && bt.BackColor == Color.FromArgb(64, 64, 64))
        //            bt.BackColor = Color.FromArgb(64, 64, 64);
        //    }
        //}
        private void btnPartneret_Click(object sender, EventArgs e)
        {
            CloseAll();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmPartnersList frm = new frmPartnersList();
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            splitDashboard.Panel2.Controls.Add(frm);
            frm.Show();
            ////BtnActive(sender);          
        }


        public void OpenItemsType(int itemstype)
        {
            CloseAll();
            //frmItems frm = new frmItems();
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //frm.TopLevel = false;
            //frm.Dock = DockStyle.Fill;
            //splitDashboard.Panel2.Controls.Add(frm);
            //frm.Show();
            //frm.SelectItems(itemstype);
        }
         
        


        private void btnArtikujt_Click(object sender, EventArgs e)
        {
            //OpenItemsType(0);
            //BtnActive(sender);
            if (btnItemsGoods.Visible == false)
            {
                btnAssemblies.Visible = true;
                btnProduction.Visible = true;
                btnMaterial.Visible = true;
                btnInventory.Visible = true;
                btnExpense.Visible = true;
                btnService.Visible = true;
                btnItemsGoods.Visible = true;
                
            }
            else
            {
                btnProduction.Visible = false;
                btnMaterial.Visible = false;
                btnInventory.Visible = false;
                btnExpense.Visible = false;
                btnService.Visible = false;
                btnItemsGoods.Visible = false;
                btnAssemblies.Visible = false;
            }
        }

        private void btnItemsGoods_Click(object sender, EventArgs e)
        {
            OpenItemsType(1);       
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            OpenItemsType(2);
        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            OpenItemsType(3);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            OpenItemsType(4);
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            OpenItemsType(5);
        }

        private void btnProduction_Click(object sender, EventArgs e)
        {
            OpenItemsType(6);
        }
        private void btnAssemblies_Click(object sender, EventArgs e)
        {
            OpenItemsType(7);
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            //ItemsDetails id = Application.OpenForms.OfType<ItemsDetails>().FirstOrDefault();
            //frmPartnersDetails pd = Application.OpenForms.OfType<frmPartnersDetails>().FirstOrDefault();
            //RegisterDashboard rg = Application.OpenForms.OfType<RegisterDashboard>().FirstOrDefault();
            //frmPartnersList pl = Application.OpenForms.OfType<frmPartnersList>().FirstOrDefault();
            //frmItems it = Application.OpenForms.OfType<frmItems>().FirstOrDefault();
            //frmItems frmi = new frmItems();
            //frmPartnersList frmp = new frmPartnersList();
            //if(id != null || it != null)
            //{
            //    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //    frmi.TopLevel = false;
            //    frmi.Dock = DockStyle.Fill;
            //    splitDashboard.Panel2.Controls.Add(frmi);
            //    frmi.Show();
            //}
            //else if(pd != null || pl != null)
            //{
            //    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //    frmp.TopLevel = false;
            //    frmp.Dock = DockStyle.Fill;
            //    splitDashboard.Panel2.Controls.Add(frmp);
            //    frmp.Show();
            //}
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (btnPartneret.Text == "Partnerët")
            {
                splitDashboard.SplitterDistance = 60;
                btnPartneret.Text = "P";
                btnArtikujt.Text = "A";
            }
            else
            {
                splitDashboard.SplitterDistance = 255;
                btnPartneret.Text = "Partnerët";
                btnArtikujt.Text = "Artikujt";
            }
        }

        private void btnSwitchAccounts_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterDashboard_Load(object sender, EventArgs e)
        {
            btnUser.Text = "Filiali: " + Globals.UserSettings.WarehouseName;
            btnWarehouse.Text = "Useri: " + Globals.User.Identity.Name;
        }

        private void RegisterDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            //PurchaseDetails pd = Application.OpenForms.OfType<PurchaseDetails>().FirstOrDefault();
            //if (pd != null)
            //{
            //    pd.ConfigureUltraDropDown();
            //}
        }

        
    }
}
