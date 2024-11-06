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
    public partial class Add_BonusCard : Form
    {
        public Add_BonusCard()
        {
            InitializeComponent();
        }

        private void Add_BonusCard_Load(object sender, EventArgs e)
        {
            //cmb_partners.DataSource = Partner.Search("Status=0");
            //cmb_partners.DisplayMember = "Name";
            //cmb_partners.ValueMember = "Id";
        }

        private void btn_saveBonusCard_Click(object sender, EventArgs e)
        {
            BonusCardTemplate bonusCard = new BonusCardTemplate();
            var r = 0;
            if (txt_bonusCDiscount.Text != "" || txt_bonusCPoints.Text != "" || txt_PetrolDiscount.Text!="")
            {
                bonusCard.Type = cmb_BonusCardType.SelectedItem.ToString();
                if (bonusCard.Type == "Pikë")
                {
                    bonusCard.Points = Convert.ToDecimal(txt_bonusCPoints.Text);
                    bonusCard.PointsToEur = Convert.ToDecimal(txt_pointValue.Text);
                    r = bonusCard.checkBonusCardTemplateP(bonusCard.Points, bonusCard.Type);

                }
                else if(bonusCard.Type == "Zbritje")
                {
                    bonusCard.Discount = Convert.ToDecimal(txt_bonusCDiscount.Text);
                    r = bonusCard.checkBonusCardTemplateD(bonusCard.Discount, bonusCard.Type);

                }
                else
                {
                    bonusCard.DiscountP = Convert.ToDecimal(txt_PetrolDiscount.Text);
                    r = bonusCard.checkBonusCardTemplateD(bonusCard.DiscountP, bonusCard.Type);
                }
                if (r == 0)
                {
                    var result = bonusCard.Insert();
                    if (result == 1)
                    {
                        MessageBox.Show($"Bonus kartela u shtue me sukses!");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show($"Egziston nje kartelë e tipit {bonusCard.Type} per kete klient!");
                }
            }
            else
            {
                MessageBox.Show("Plotesoni textin per vlerë!");
            }

        }

        private void cmb_BonusCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_BonusCardType.SelectedIndex == 0)
            {
                txt_bonusCDiscount.Enabled = false;
                txt_PetrolDiscount.Enabled = false;
                txt_bonusCPoints.Enabled = true;
                txt_pointValue.Enabled = true;

            }
            else if(cmb_BonusCardType.SelectedIndex == 1)
            {
                txt_bonusCPoints.Enabled = false;
                txt_PetrolDiscount.Enabled = false;
                txt_bonusCDiscount.Enabled = true;
                txt_pointValue.Enabled = false;

            }
            else
            {
                txt_bonusCPoints.Enabled = false;
                txt_bonusCDiscount.Enabled = false;
                txt_PetrolDiscount.Enabled = true;
                txt_pointValue.Enabled = false;

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
