using Microsoft.Office.Interop.Word;
using Services;
using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TremolZFP;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace MyNET.Pos.Modules
{

    public partial class Shitjet_e_Fundit : Form
    {
        List<Sale> allSales = new List<Sale>();
        public int sIdd;
        public System.Data.DataTable data = new System.Data.DataTable();
        public static DataGridView dg = new DataGridView();
        public Shitjet_e_Fundit()
        {
            InitializeComponent();
        }

        private void txtSaleInvoiceNo_TextChanged(object sender, EventArgs e)
        {
           
            //dgSales.DataSource = filteredProducts;

        }

        private void Shitjet_e_Fundit_Load(object sender, EventArgs e)
        {
            cmb_client.DataSource= Services.Partner.Search("Status=0");
            cmb_client.DisplayMember = "Name";
            cmb_client.ValueMember = "Id";

            if (dgSales.Columns.Contains(" "))
            {
                dgSales.Columns.RemoveAt(6);
            }
            allSales = Services.Sale.getAllSales().Where(p=>p.SalesTypeId == 1 && p.ConvertBill == 0).ToList();
            Loads();
        }

        private void dgSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            data.Clear();
            if (e.ColumnIndex == dgSales.Columns[" "].Index && e.RowIndex >= 0)
            {
                ComboBox cmbClient = new ComboBox();
                cmbClient.Size = new Size(200, 30);
                cmbClient.Location = new System.Drawing.Point((this.ClientSize.Width - cmbClient.Width) / 2, (this.ClientSize.Height - cmbClient.Height) / 2);
                cmbClient.DataSource = Services.Partner.Search("Status=0");
                cmbClient.ValueMember = "Id";
                cmbClient.DisplayMember = "Name";
                cmbClient.Visible = true;
                cmbClient.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                this.Controls.Add(cmbClient);
                cmbClient.Focus();
                dgSales.Visible = false;

                PosRestaurant.lastInvNumber = dgSales.Rows[e.RowIndex].Cells[5].Value.ToString();

                int sid = Convert.ToInt32(dgSales.Rows[e.RowIndex].Cells["Id"].Value);
                sIdd = sid;

                var items = Services.SaleDetails.GetSaleDetailsBySaleId(sid);
                dataGridView1.DataSource = items;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (!data.Columns.Contains(col.Name))
                        data.Columns.Add(col.Name);
                }
                data.PrimaryKey = new DataColumn[] { data.Columns[0] };

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataRow dRow = data.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }

                    data.Rows.Add(dRow);
                }

                PosRestaurant.data = data;


            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;


            PosRestaurant.PartnerId = (int)comboBox.SelectedValue;
            comboBox.Visible = false;
            dgSales.Visible = true;
            Invoice invoice = new Invoice();
            invoice.flags = true;
            invoice.saleId = sIdd;
            invoice.ShowDialog();
        }

        private void Loads()
        {
            var sales = allSales.Where(p => p.CouponNo.ToString().Contains(txtSaleInvoiceNo.Text.ToLower()) && p.PosId==Globals.Station.Id).ToList();

            dgSales.DataSource = sales;
            dgSales.Columns[2].Visible = false;
            dgSales.Columns[3].Visible = false;
            dgSales.Columns[4].Visible = false;
            dgSales.Columns[6].Visible = false;
            dgSales.Columns[7].Visible = false;
            dgSales.Columns[8].Visible = false;
            dgSales.Columns[9].Visible = false;
            dgSales.Columns[10].Visible = false;
            dgSales.Columns[11].Visible = false;
            //dgSales.Columns[12].Visible = false;
            dgSales.Columns[13].Visible = false;
            dgSales.Columns[14].Visible = false;
            dgSales.Columns[15].Visible = false;
            dgSales.Columns[16].Visible = false;
            dgSales.Columns[17].Visible = false;
            dgSales.Columns[18].Visible = false;
            dgSales.Columns[19].Visible = false;
            dgSales.Columns[20].Visible = false;
            dgSales.Columns[21].Visible = false;
            dgSales.Columns[22].Visible = false;
            dgSales.Columns[23].Visible = false;

            dgSales.Columns[15].ReadOnly = true;


            if (dgSales.Columns.Contains(" ") == false)
            {
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Name = " ";
                col.FillWeight = 70;
                dgSales.Columns.Add(col);

            }

            foreach (DataGridViewRow row in dgSales.Rows)
            {
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)row.Cells[" "];
                buttonCell.UseColumnTextForButtonValue = false;
                buttonCell.Value = "Konverto";

            }

            dgSales.Columns[0].HeaderText = "Nr.";
            dgSales.Columns[1].HeaderText = "Data";
            dgSales.Columns[5].HeaderText = "Nr. i Faturës";
            //dgSales.Columns[15].HeaderText = "E Shtypur";
            dgSales.Columns[12].HeaderText = "Shuma";


        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            var selectedFromDate = dateTimePicker1.Value;

            string date = selectedFromDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
            var partnerId = Partner.Get(Convert.ToInt32(cmb_client.SelectedValue.ToString())).Id;
            var filteredProducts = Sale.getSalesWithParams(txtSaleInvoiceNo.Text,date);
            filteredProducts = filteredProducts.Where(p => p.PosId == Globals.Station.Id).ToList();
            dgSales.DataSource= filteredProducts;
        }
    }
}
