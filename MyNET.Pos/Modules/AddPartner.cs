using Microsoft.Office.Interop.Word;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyNET.Pos.Modules
{
    public partial class AddPartner : Form
    {
        public AddPartner()
        {
            InitializeComponent();
        }

        private void AddPartner_Load(object sender, EventArgs e)
        {
            //panel1.Size = new Size(781,378);
            //this.Size = new Size(794, 513);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //panel1.Size = new Size(781, 713);
            //this.Size = new Size(794, 834);

        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPartners_Click(object sender, EventArgs e)
        {
            try
            {
                Services.Partner partner = new Services.Partner();
                var p = Partner.GetLastIdPartner();
                int lastId = p.First().Id;
                partner.Id = lastId + 1;

                partner.Name = txtSaveAsName.Text;
                partner.Surname = "";
                partner.CompanyName = txtSaveAsName.Text;
                partner.SaveAs = txtSaveAsName.Text;
                partner.Address = txtAddress.Text;
                partner.Comment = txtComment.Text;
                partner.VatNo = txtVATNr.Text;
                partner.BusinessNo = txtBusinessId.Text;
                partner.FiscalNo = txtFiscalId.Text;
                partner.City = txtCity.Text;
                partner.Email = txtEmail.Text;
                partner.Phone = txtPhone.Text;
                partner.MobilePhone = txtPhone.Text;
                //partner.Discount = txtDiscount.Text;
                partner.Country = countryCmb.SelectedItem != null ? countryCmb.SelectedItem.ToString() : "";
                partner.PartnerType = chckIsCompany.Checked == true ? partner.PartnerType = 0 : partner.PartnerType = 1;
                partner.CreatedAt = DateTime.Now;
                partner.CreatedBy = Globals.User.Name;
                partner.ChangedAt = DateTime.Now;
                partner.ChangedBy = "";
                partner.Status = 0;

                if (txtSaveAsName.Text != "")
                {
                    var a = partner.Insert();


                    if (a == 1)
                    {
                        AutoClosingMessageBox.Show("Eshte krijuar Klienti me suskes!", "Success", 1000);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ka deshtuar krijimi i Klientit! Klienti me kete emer egziston!");
                    }
                }
                else
                {
                    MessageBox.Show("Emri i klientit eshte i detyruar te shenohet!");

                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (!txtPhone.Text.StartsWith("+383"))
            {
                txtPhone.Text = "+383";
                txtPhone.SelectionStart = txtPhone.Text.Length;
            }
        }
    }
}
