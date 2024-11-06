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
using ExtendedXmlSerializer;

namespace MyNET.Pos.Modules.BonusCard
{
    public partial class BonusCardList : Form
    {
        public BonusCardList()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            dg_BonusCardList.Rows.Clear();
            if(e.KeyCode == Keys.Enter) 
            {
                List<Services.BonusCard> bonus = new List<Services.BonusCard>();
                var encodedSearchStr = System.Web.HttpUtility.UrlEncode(txt_bonusCardSrch.Text);

                var partner =Partner.GetPartnersWithNameOrPhone(txt_bonusCardSrch.Text);
                if(partner != null && partner.Count>0)
                {
                    foreach (var item in partner)
                    {
                        var bonusc = Services.BonusCard.Search($"&PartnerId={item.Id.ToString()}");
                        foreach (var i in bonusc)
                        {
                            bonus.Add(i);
                          dg_BonusCardList.Rows.Add(Partner.Get(i.PartnerId).Name,i.Number,i.Type,i.CurrentPoints,i.CurrentPointsValue);

                        }

                    }

                }
                
            }
        }
    }
}
