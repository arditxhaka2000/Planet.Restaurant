using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class SavePOS : Form
    {
        public SavePOS()
        {
            InitializeComponent();
        }

        private void SavePOS_Load(object sender, EventArgs e)
        {
           var item = Services.SavedPOS.GetAllSavedPOS().Where(p=>p.StationId == Globals.Station.Id).ToList();

            dataGridView1.DataSource = item;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Shuma";
            dataGridView1.Columns[3].HeaderText = "Nr. i Artikujve";

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();

            buttonColumn.HeaderText = "Vazhdo";  // Set the header text
            buttonColumn.Text = "Vazhdo";        // Set the default button text
            buttonColumn.Name = "VazhdoColumn";  // Optional: Set a name for the column
            dataGridView1.Columns.Add(buttonColumn);

            buttonColumn1.HeaderText = "Fshij";  // Set the header text
            buttonColumn1.Text = "";        // Set the default button text
            buttonColumn1.Name = "FshijColumn";
            buttonColumn1.DefaultCellStyle.BackColor = Color.Red;
            dataGridView1.Columns.Add(buttonColumn1);
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 5)  // Check if the clicked cell is in the button column
            {
                // Access the object associated with the clicked row:
                SavedPOS clickedObject = (SavedPOS)dataGridView1.Rows[e.RowIndex].DataBoundItem;


                this.Close();
                PosRestaurant posRestaurant = new PosRestaurant();

                posRestaurant.Show();
                posRestaurant.savedPOSId = clickedObject.Id;
                posRestaurant.GenerateItems(Services.SavedPOSItems.GetWithPOSId(clickedObject.Id));
            }
            if (e.ColumnIndex == 6)
            {
                SavedPOS clickedObject = (SavedPOS)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                SavedPOS.DeleteSavedPOS(clickedObject.Id.ToString());
                var item = Services.SavedPOS.GetAllSavedPOS().Where(p => p.StationId == Globals.Station.Id).ToList();

                dataGridView1.DataSource = item;
            }
        }
       

    }
}
