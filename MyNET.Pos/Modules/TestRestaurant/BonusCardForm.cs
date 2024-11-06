using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class BonusCardForm : Form
    {
        public Services.BonusCard BonusCard { get; set; }
        public bool isClicked = false;
        private bool isProgrammaticChange = false;
        public BonusCardForm()
        {
            InitializeComponent();
        }
        private void txtbonusCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bonusCard = Services.BonusCard.GetBonusCardWithNumberOrPartner(txt_bonusCard.Text);
                if (bonusCard.Count > 0)
                {
                    txt_bonusCard.Cursor = Cursors.Arrow;

                    if (bonusCard.Count == 1 && bonusCard.First().Number == txt_bonusCard.Text)
                    {

                        BonusCard = bonusCard.First();
                        var m = MessageBox.Show("Apliko zbritje?", "Zbritje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (m == DialogResult.Yes)
                        {
                            isClicked = true;

                        }
                        this.Close();
                    }
                    else
                    {
                        cmbBonuscard.Visible = true;
                        cmbBonuscard.DataSource = bonusCard;
                        cmbBonuscard.DisplayMember = "Type";
                        cmbBonuscard.ValueMember = "Id";

                    }
                    cmbBonuscard.DroppedDown = true;
                    cmbBonuscard.Focus();
                }
                else
                {
                    MessageBox.Show("Nuk u gjet asnjë kartelë me të dhënat e shënuara!", "Not Found");
                    cmbBonuscard.Visible = false;

                }
            }

        }

        private void chckDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chckDiscount.Checked)
            {
                isClicked = true;
            }
            else
            {
                isClicked = false;
            }
        }



        private void cmbBonuscard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BonusCard = (Services.BonusCard)cmbBonuscard.SelectedItem;

            var m = MessageBox.Show("Apliko zbritje?", "Zbritje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (m == DialogResult.Yes)
            {
                isClicked = true;

            }

            this.Close();
        }

        private void cmbBonuscard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (cmbBonuscard.SelectedIndex > 0)
                {
                    cmbBonuscard.SelectedIndex--;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (cmbBonuscard.SelectedIndex < cmbBonuscard.Items.Count - 1)
                {
                    cmbBonuscard.SelectedIndex++;
                }
            }
        }
    }
}
