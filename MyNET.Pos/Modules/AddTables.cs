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
            
            if(settings.Theme == "dark")
            {
                this.BackColor = Color.FromArgb(49, 50, 55);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                txtTableName.BackColor = Color.FromArgb(49, 50, 55);
                txtTableName.ForeColor = Color.White;
                cmbSpace.BackColor = Color.FromArgb(49, 50, 55);
                cmbSpace.ForeColor = Color.White;

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
    }
}
