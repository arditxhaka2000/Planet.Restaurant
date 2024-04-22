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

namespace MyNET.Pos.Modules
{
    public partial class BonusCardForm : Form
    {
        public Services.BonusCard BonusCard { get; set; }
        public bool isClicked = false;
        public BonusCardForm()
        {
            InitializeComponent();
        }
        private void txtbonusCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                var bonusCard = Services.BonusCard.GetWithName(txt_bonuscard.Text);
                if (bonusCard != null)
                {
                    BonusCard = bonusCard;

                    this.Close();
                }
                else
                {
                    var partner = Partner.GetPartnersWithNameOrPhone(txt_bonuscard.Text);
                    if (partner != null && partner.Count > 0)
                    {
                        var bonusc = Services.BonusCard.Search($"&PartnerId={partner.First().Id}");
                        if (bonusc.Count > 0)
                        {
                            BonusCard = bonusc.First();

                            this.Close();

                        }
                    }
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

        private void chckDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chckDiscount.Checked)
            {
                var bonusCard = Services.BonusCard.GetWithName(txt_bonuscard.Text);
                if (bonusCard != null)
                {
                    BonusCard = bonusCard;

                    this.Close();
                }
                else
                {
                    var partner = Partner.GetPartnersWithNameOrPhone(txt_bonuscard.Text);
                    if (partner != null && partner.Count > 0)
                    {
                        var bonusc = Services.BonusCard.Search($"&PartnerId={partner.First().Id}");
                        if (bonusc.Count > 0)
                        {
                            BonusCard = bonusc.First();

                            this.Close();

                        }
                    }
                }
            }
        }
    }
}
