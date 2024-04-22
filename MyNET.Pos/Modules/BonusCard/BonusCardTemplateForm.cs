using Microsoft.Office.Interop.Word;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using MyNET.Pos.Modules.BonusCard;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class BonusCardTemplateForm : Form
    {
        public int ClientId = 0;
        public BonusCardTemplateForm()
        {
            InitializeComponent();
        }

        private void BonusCardTemplates_Load(object sender, EventArgs e)
        {
            //cmb_partners.DataSource = Partner.Search("Status=0");
            //cmb_partners.DisplayMember = "Name";
            //cmb_partners.ValueMember = "Id";

            //splitContainer1.Panel2.Enabled = false;
            dg_bonusCardTemplate.DataSource = BonusCardTemplate.Search("");

            if (!ColumnExists("Zgjedh Shabllonin") && !ColumnExists("Fshij Shabllonin"))
            {
                DataGridViewButtonColumn selectButtonColumn = new DataGridViewButtonColumn();
                selectButtonColumn.HeaderText = "Zgjedh Shabllonin";
                selectButtonColumn.Name = "Zgjedh Shabllonin";
                selectButtonColumn.Text = "";
                selectButtonColumn.UseColumnTextForButtonValue = true;
                dg_bonusCardTemplate.Columns.Add(selectButtonColumn);

                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
                deleteButtonColumn.HeaderText = "Fshij Shabllonin";
                deleteButtonColumn.Name = "Fshij Shabllonin";
                deleteButtonColumn.Text = "";
                deleteButtonColumn.UseColumnTextForButtonValue = true;
                dg_bonusCardTemplate.Columns.Add(deleteButtonColumn);
            }
           
        }
        public bool ColumnExists(string columnName)
        {
            foreach (DataGridViewColumn column in dg_bonusCardTemplate.Columns)
            {
                if (column.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientId = Convert.ToInt32(cmb_partners.SelectedValue.ToString());
            //if(ClientId > 0) 
            //{
            //    splitContainer1.Panel2.Enabled = true;

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ping = PingHost("planetaccounting.org");

            if (ping)
            {
                AddPartner addp = new AddPartner();

                addp.ShowDialog();

                BonusCardTemplates_Load(null, null);

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

        private void button4_Click(object sender, EventArgs e)
        {
            Add_BonusCard bonusCard = new Add_BonusCard();
            bonusCard.ShowDialog();
            BonusCardTemplates_Load(null,null);
        }

        private void cmb_partners_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClientId = Convert.ToInt32(cmb_partners.SelectedValue.ToString());
            if (ClientId > 0)
            {
                splitContainer1.Panel2.Enabled = true;

            }
        }

        private void dg_bonusCardTemplate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BonusCardTemplate cardTemplate = new BonusCardTemplate();
            Services.BonusCard bonus = new Services.BonusCard();

            if (e.ColumnIndex == dg_bonusCardTemplate.Columns["Fshij Shabllonin"].Index && e.RowIndex >= 0)
            {
                int idToDelete = Convert.ToInt32(dg_bonusCardTemplate.Rows[e.RowIndex].Cells["Id"].Value);
                //dg_bonusCardTemplate.Rows.RemoveAt(e.RowIndex);

                cardTemplate.Delete(idToDelete);
                BonusCardTemplates_Load(null, null);
            }
            else if (e.ColumnIndex == dg_bonusCardTemplate.Columns["Zgjedh Shabllonin"].Index && e.RowIndex >= 0)
            {
                if (ClientId > 0)
                {
                    // Perform selection operation when select button is clicked
                    dg_bonusCardTemplate.Rows[e.RowIndex].Selected = true;

                    bonus.PartnerId = ClientId;
                    bonus.TotalPoints = Convert.ToDecimal(dg_bonusCardTemplate.Rows[e.RowIndex].Cells["Points"].Value);
                    bonus.CurrentPoints = Convert.ToDecimal(dg_bonusCardTemplate.Rows[e.RowIndex].Cells["Points"].Value);
                    bonus.PointsToEur = Convert.ToDecimal(dg_bonusCardTemplate.Rows[e.RowIndex].Cells["PointsToEur"].Value);
                    bonus.Discount = Convert.ToDecimal(dg_bonusCardTemplate.Rows[e.RowIndex].Cells["Discount"].Value);
                    bonus.Type = dg_bonusCardTemplate.Rows[e.RowIndex].Cells["Type"].Value.ToString();
                    bonus.Number = Services.BonusCard.GenerateRandomString(10);

                    var check = bonus.checkBonusCard(bonus.PartnerId);

                    if (check == 0)
                    {
                        var r = bonus.Insert();
                        if (r > 0)
                        {
                            MessageBox.Show($"Bonus kartela u shtua me sukses!");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Egziston nje kartelë per kete klient!");

                    }
                }
                else
                {
                    MessageBox.Show($"Zgjedhni nje klient!");

                }



            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            BonusCardList b = new BonusCardList();
            b.ShowDialog();
        }

        private void cmb_partners_Click(object sender, EventArgs e)
        {

            cmb_partners.DataSource = Partner.Search("Status=0");
            cmb_partners.DisplayMember = "Name";
            cmb_partners.ValueMember = "Id";
        }
    }
}
