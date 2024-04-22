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
    public partial class DailyReport : Form
    {
        public DailyReport()
        {
            InitializeComponent();
        }

        private void DailyReport_Load(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();

            //if (globals.Language == "Sq")
            //{
            //    var data = LoadJson.DataSq;
            //    foreach (var item in data.dataWords)
            //    {
            //        foreach (Control c in this.Controls)
            //        {
            //            if (c.Name == item.name)
            //            {
            //                c.Text = item.translate;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    var data = LoadJson.DataEn;
            //    foreach (var item in data.dataWords)
            //    {
            //        foreach (Control c in this.Controls)
            //        {
            //            if (c.Name == item.name)
            //            {
            //                c.Text = item.translate;
            //            }
            //        }
            //    }
            //}
            
            dtDate.Value = DateTime.Now;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            int stationId = Globals.Station.Id;
            var selectedDate = dtDate.Value;
            var date = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);


            var items = Services.DailyOpenCloseBalance.GetDailyBalance(stationId,date);
            int i = 1;
            decimal saleTotal = 0.0M;
            List<Services.Models.DailyBalance> rptItems = new List<Services.Models.DailyBalance>();
            if (items != null)
            {
                foreach (var item in items)
                {
                    item.No = i;
                    rptItems.Add((Services.Models.DailyBalance)item);
                    if (item.Status.ToLower() == "shitje")
                        saleTotal += item.Amount;
                    i++;
                }
            }

            dg.DataSource = items;
            dg.Columns[2].HeaderText = "Puntori";
            dg.Columns[4].HeaderText = "Shuma(€)";
            dg.Columns[6].Visible = false;
            dg.Columns[7].Visible = false;
            dg.Columns[8].Visible = false;
            dg.Columns[9].Visible = false;

            lblTotal.Text = saleTotal.ToString("N");
        }
    }
}
