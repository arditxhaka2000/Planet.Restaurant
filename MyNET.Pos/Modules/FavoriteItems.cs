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
    public partial class FavoriteItems : Form
    {
        public System.Collections.Generic.List<Services.Item> items = Services.Item.GetFav(0);


        public FavoriteItems()
        {
            InitializeComponent();
        }

        private void FavoriteItems_Load(object sender, EventArgs e)
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
            
            dg.DataSource = Services.Item.GetFav(0);
            dataGridView1.DataSource = Services.Item.GetFav(1);

            dg.DefaultCellStyle.Font = new Font("Lato", 11);
            for(int i = 1; i < 30; i++)
            {
                dg.Columns[i].Visible = false;
            }


            dataGridView1.DefaultCellStyle.Font = new Font("Lato", 11);
            for (int i = 1; i < 30; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }

            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "Favorite";
            dg.Columns.Add(dgvCmb);

            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.ValueType = typeof(bool);
            col.Name = "DelCol";
            col.HeaderText = "Fshij";
            dataGridView1.Columns.Add(col);

        }

        private void RuajFavorite_Click(object sender, EventArgs e)
        {
            var favItems = Services.Item.GetFav(1);
            dataGridView1.DataSource = favItems;

            Services.Item itemss = new Services.Item();


            foreach (DataGridViewRow row in dg.Rows)
            {
                foreach (var item in Services.Item.GetFav(0))
                {
                    if (item.ItemName == row.Cells[8].Value.ToString())
                    {
                        if (Convert.ToBoolean(row.Cells[32].Value))
                        {
                            itemss.Favorite = Convert.ToInt32(row.Cells[32].Value);
                            itemss.Id = Convert.ToInt32(row.Cells[0].Value);
                            //DatabaseConnect.UpdateFavItems(itemss.Id);
                        }
                    }

                }
            }

            dg.DataSource = Services.Item.GetFav(0);
            FavoriteItems favoriteItems = new FavoriteItems();
            favoriteItems.Show();
            favoriteItems.TopMost = true;
            favoriteItems.Location = new Point(50, 100);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fav = Services.Item.GetFav(1);

            dg.DataSource = Services.Item.GetFav(0);
            Services.Item itemss = new Services.Item();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (var item in fav)
                {
                    if (item.ItemName == row.Cells[8].Value.ToString())
                    {
                        if (Convert.ToBoolean(row.Cells[32].Value))
                        {
                            itemss.Favorite = 0;
                            itemss.Id = Convert.ToInt32(row.Cells[0].Value);
                            //itemss.UpdateFav(itemss.Favorite, itemss.Id);
                        }
                    }

                }
            }

            dataGridView1.DataSource = Services.Item.GetFav(1);
            FavoriteItems favoriteItems = new FavoriteItems();
            favoriteItems.Show();
            favoriteItems.TopMost = true;
            favoriteItems.Location = new Point(50, 100);
            this.Close();

        }

        private void allFavItem_CheckedChanged(object sender, EventArgs e)
        {
            if (word_choose_all.Checked)
            {
                foreach(DataGridViewRow row in dg.Rows)
                {
                    row.Cells[32].Value = Convert.ToBoolean(row.Cells[32].Value) == false ? true : false;
                }
            }
        }        
    }
}
