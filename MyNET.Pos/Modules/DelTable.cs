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
using System.Xml;

namespace MyNET.Pos.Modules
{
    public partial class DelTable : Form
    {
        public bool flag = false;
        public int spaceIdToDelete = 0;
        public DelTable()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Spaces space = new Spaces();
            Tables table = new Tables();

            space.Id = (int)cmbSpaces.SelectedValue;


            if (chckTable.Checked)
            {
                if (cmbTable.Text != "")
                {
                    var tid = Tables.GetTables().Where(p => p.Name == cmbTable.Text).First().Id;
                    table.Id = tid;
                    table.Space_id = space.Id;
                    table.Name = cmbTable.Text.ToString();
                    table.station_id = Globals.Station.Id.ToString();
                    table.toDelete = "1";
                    table.Status = 1;
                    table.Update();
                }
                else
                {
                    MessageBox.Show("Ju lutem zgjedhni tavolinen qe deshironi ta fshini!");
                }


            }
            else
            {
                space.Name = cmbSpaces.Text.ToString();
                space.station_id = Globals.Station.Id.ToString();
                space.toDelete = "1";
                space.Status = "1";
                space.Update();
            }

            this.Close();

        }

        private void DelTable_Load(object sender, EventArgs e)
        {
            cmbSpaces.DataSource = Spaces.GetSpaces();
            cmbSpaces.DisplayMember = "Name";
            cmbSpaces.ValueMember = "Id";

        }

        private void chckTable_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTable.Checked)
            {
                label3.Visible = true;
                cmbTable.Visible = true;
            }
            else
            {
                label3.Visible = false;
                cmbTable.Visible = false;

            }
        }

        private void cmbSpaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSpace = cmbSpaces.SelectedItem as Spaces;
            if (selectedSpace != null)
            {
                spaceIdToDelete = selectedSpace.Id;
                var tables = Tables.GetTablesBySpaceId(spaceIdToDelete);
                if (tables.Count != 0)
                {
                    cmbTable.DataSource = tables;
                    cmbTable.DisplayMember = "Name";
                    cmbTable.ValueMember = "Id";

                }
                else
                {
                    cmbTable.Text = "";
                    cmbTable.DataSource = null;
                }
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label4.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBox2.Visible = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Spaces space = new Spaces();
            Tables table = new Tables();

            space.Id = (int)cmbSpaces.SelectedValue;


            if (chckTable.Checked)
            {
                if (cmbTable.Text != "")
                {
                    var t = Tables.GetTables().Where(p => p.Name == cmbTable.Text).First();
                    table.Id = t.Id;
                    table.Space_id = space.Id;
                    table.Name = textBox2.Text.ToString();
                    table.station_id = Globals.Station.Id.ToString();
                    table.LocationX = t.LocationX;
                    table.LocationY = t.LocationY;
                    table.toUpdate = "1";
                    table.Status = 1;
                    table.Update();
                }
                else
                {
                    MessageBox.Show("Ju lutem zgjedhni tavolinen qe deshironi ta fshini!");
                }

                this.Close();

            }
            else
            {
                space.Name = textBox2.Text.ToString();
                space.station_id = Globals.Station.Id.ToString();
                space.toUpdate = "1";
                space.Status = "1";
                space.Update();
            }

        }
    }
}
