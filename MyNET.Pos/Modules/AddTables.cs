using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Data;
using Microsoft.Office.Interop.Word;
using Services;
using System.Linq;

namespace MyNET.Pos.Modules
{
    public partial class AddTables : Form
    {
        public static int spaceid;
        public AddTables()
        {
            InitializeComponent();

        }
        private void Save_Click(object sender, EventArgs e)
        {
            Services.Tables tables = new Services.Tables();

            var t = Services.Tables.GetTables();

            tables.Space_id = Convert.ToInt32(cmbSpace.SelectedValue);
            tables.Name = txtTableName.Text;
            tables.station_id = Globals.Station.Id.ToString();
            tables.Shape = cmbTableShape.SelectedItem.ToString();
            tables.Width = "120";
            tables.Height = "120";
            if (tables.Space_id != 0)
            {


                if (txtAutoGenerateTables.Text != "")
                {
                    if (Convert.ToInt16(txtAutoGenerateTables.Text) > 0)
                    {
                        GenerateTables(Convert.ToInt16(txtAutoGenerateTables.Text));
                    }
                    this.Close();
                    return;
                }



                Random random = new Random();
                int randomX, randomY;
                bool isDuplicateLocation;

                do
                {
                    randomX = random.Next(1, 95);
                    randomY = random.Next(4, 80);

                    isDuplicateLocation = t.Any(table => table.LocationX == randomX.ToString() && table.LocationY == randomY.ToString());
                }
                while (isDuplicateLocation);

                tables.LocationX = randomX.ToString();
                tables.LocationY = randomY.ToString();

                tables.Status = 0;
                tables.PrintTotal = 0;
                tables.PrintFiscal = 0;
                tables.inPosTotal = "0";
                var result = tables.Insert();

                if (result == 0)
                {
                    MessageBox.Show("Egziton nje tavoline me kete emer!");
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Ju lutem zgjedhni nje Hapsire!");
            }
        }
        public void GenerateTables(int number)
        {

            Services.Tables tables = new Services.Tables();

            int n = 1;

            int tableWidth = 10;
            int tableHeight = 10;
            int screenWidth = 95; 
            int currentX = 2;
            int currentY = 15;

            while (number > 0)
            {
                tables.Space_id = Convert.ToInt32(cmbSpace.SelectedValue);
                tables.Name = n.ToString();
                tables.station_id = Globals.Station.Id.ToString();
                tables.Shape = cmbTableShape.SelectedItem.ToString();
                tables.Width = "120";
                tables.Height = "120";
                // Set table location
                tables.LocationX = currentX.ToString();
                tables.LocationY = currentY.ToString();

                currentX += tableWidth;

                if (currentX + tableWidth > screenWidth + tableWidth)
                {
                    currentX = 2;
                    currentY += tableHeight + 5;
                }

                tables.Status = 0;
                tables.PrintTotal = 0;
                tables.PrintFiscal = 0;
                tables.inPosTotal = "0";
                var result = tables.Insert();

                while (result == 0)
                {
                    n++;
                    tables.Name = n.ToString();
                    result = tables.Insert();

                }
                n++;
                number--;
            }
        }
        private void AddTables_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globals.NextStep = "Exit";

        }

        private void AddTables_Load(object sender, EventArgs e)
        {
            var settings = Settings.Get();
            cmbSpace.DataSource = Spaces.GetSpaces();
            cmbSpace.DisplayMember = "Name";
            cmbSpace.ValueMember = "Id";

            if (settings.Theme == "dark")
            {
                this.BackColor = Color.FromArgb(49, 50, 55);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                txtTableName.BackColor = Color.FromArgb(49, 50, 55);
                txtTableName.ForeColor = Color.White;
                cmbSpace.BackColor = Color.FromArgb(49, 50, 55);
                cmbSpace.ForeColor = Color.White;
                cmbTableShape.BackColor = Color.FromArgb(49, 50, 55);
                cmbTableShape.ForeColor = Color.White;
                txtAutoGenerateTables.BackColor = Color.FromArgb(49, 50, 55);
                txtAutoGenerateTables.ForeColor = Color.White;


            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                txtTableName.BackColor = Color.White;
                txtTableName.ForeColor = Color.FromArgb(49, 50, 55);
                cmbSpace.BackColor = Color.White;
                cmbSpace.ForeColor = Color.FromArgb(49, 50, 55);

            }
        }

        private void txtAutoGenerateTables_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
