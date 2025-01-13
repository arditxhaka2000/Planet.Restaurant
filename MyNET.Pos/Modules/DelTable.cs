using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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
                    var tid = Tables.GetTables().Where(p => p.Name == cmbTable.Text).First();
                    table.Id = tid.Id;
                    table.Space_id = space.Id;
                    table.Name = cmbTable.Text.ToString();
                    table.station_id = Globals.Station.Id.ToString();
                    table.Width = tid.Width;
                    table.Height = tid.Height;
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
            var settings = Services.Settings.Get();

            if (settings.Theme == "dark")
            {
                this.BackColor = Color.FromArgb(49, 50, 55);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                txtTableName.BackColor = Color.FromArgb(49, 50, 55);
                txtTableName.ForeColor = Color.White;
                cmbSpaces.BackColor = Color.FromArgb(49, 50, 55);
                cmbSpaces.ForeColor = Color.White; 
                textBox2.BackColor = Color.FromArgb(49, 50, 55);
                textBox2.ForeColor = Color.White;
                chckTable.ForeColor = Color.White;
                checkBox1.ForeColor = Color.White;


            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                txtTableName.BackColor = Color.White;
                txtTableName.ForeColor = Color.FromArgb(49, 50, 55);
                cmbSpaces.BackColor = Color.White;
                cmbSpaces.ForeColor = Color.FromArgb(49, 50, 55);
                textBox2.BackColor = Color.White;
                textBox2.ForeColor = Color.FromArgb(49, 50, 55);
                chckTable.ForeColor = Color.Black;
                checkBox1.ForeColor = Color.Black;


            }

        }

        private void chckTable_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTable.Checked)
            {
                label3.Visible = true;
                cmbTable.Visible = true;
                button2.Visible = true;
                label5.Visible = true;
                cmbTableShape.Visible = true;

            }
            else
            {
                label3.Visible = false;
                cmbTable.Visible = false;
                button2.Visible = false;
                cmbTableShape.Visible = false;
                label5.Visible = false;

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
                    table.Name = cmbTable.Text.ToString()!=""? cmbTable.Text.ToString():table.Name;  
                    table.inPosTotal = "0";
                    table.station_id = Globals.Station.Id.ToString();
                    table.Shape = cmbTableShape.Text;
                    table.LocationX = t.LocationX;
                    table.Width = table.Width;
                    table.Height = table.Height;
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

        private void button2_Click(object sender, EventArgs e)
        {
            EditTableSize edit = new EditTableSize();
            edit.Id = Convert.ToInt16(cmbTable.SelectedValue);
            edit.ShowDialog(); 
        }

        private void cmbTableShape_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
