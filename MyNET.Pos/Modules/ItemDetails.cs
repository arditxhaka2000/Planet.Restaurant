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

namespace MyNET.Pos.Modules
{
    public partial class ItemDetails : Form
    {
        List<ItemsDiscount> mAllItems = new List<ItemsDiscount>();

        public ItemDetails()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgItemsDetails.Rows.Clear();
            if (Globals.Settings.BarcMode == 0)
            {
                //if (Globals.Settings.StockWMinus == "0")
                //{
                //    mAllItems = Services.Item.GetItemsDiscount(Globals.Station.ParentId);

                //}
                //else
                //{
                //    mAllItems = Services.Item.GetAllItemDetails();

                //}

                var item = Services.Item.GetItemWithNameOrBarcodeV1(textBox1.Text);

                foreach (var i in item)
                {
                    var stock = Services.Warehouse.GetbyId(i.Id); 
                    var quantityStck = stock != null ? stock.InStock : 0;
                    var qmimi = Math.Round(i.RetailPrice+(i.RetailPrice* (decimal)(i.Vat*0.01)),2);
                    var status = i.Status==1?true:false; 
                    dgItemsDetails.Rows.Add(i.ItemName, i.Barcode, quantityStck, qmimi,status);
                }
            }
            else
            {
                var item = Services.Item.GetItemWithNameOrBarcodeV1(textBox1.Text);
                //if (item.Any())
                //{
                //    var stock = Services.Warehouse.GetbyId(item.First().Id);
                //    var quantityStck = stock != null ? stock.InStock : 0;
                //    dgItemsDetails.Rows.Add(item.First().ItemName, item.First().Barcode, quantityStck);
                //}
                //else
                //    dgItemsDetails.Rows.Clear();

                foreach (var i in item)
                {
                    var stock = Services.Warehouse.GetbyId(i.Id);
                    var quantityStck = stock != null ? stock.InStock : 0;
                    var qmimi = Math.Round(i.RetailPrice+(i.RetailPrice* (decimal)(i.Vat*0.01)),2);
                    var status = i.Status;
                    dgItemsDetails.Rows.Add(i.ItemName, i.Barcode, quantityStck, qmimi,status);
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgItemsDetails.Rows.Clear();
            if (Globals.Settings.BarcMode == 0)
            {
                if (Globals.Settings.StockWMinus == "0")
                {
                    mAllItems = Services.Item.GetItemsDiscount(Globals.Station.ParentId);

                }
                else
                {
                    mAllItems = Services.Item.GetAllItemDetails();

                }

                var item = mAllItems.Where(p => p.ItemName.ToLower().Contains(textBox1.Text.ToLower()) || p.ProductNo.Contains(textBox1.Text)).ToList();
                foreach (var i in item)
                {
                    var quantityStck = Services.Warehouse.GetbyId(i.Id);
                    var status = i.Status;
                    dgItemsDetails.Rows.Add(i.ItemName, i.Barcode, quantityStck.InStock, status);
                }
            }
            else
            {
                var item = Services.Item.GetItemWithName(textBox1.Text);
                //if (item.Any())
                //{
                //    var stock = Services.Warehouse.GetbyId(item.First().Id);
                //    var quantityStck = stock != null ? stock.InStock : 0;
                //    dgItemsDetails.Rows.Add(item.First().ItemName, item.First().Barcode, quantityStck);
                //}
                //else
                //    dgItemsDetails.Rows.Clear();

                foreach (var i in item)
                {
                    var stock = Services.Warehouse.GetbyId(i.Id);
                    var quantityStck = stock != null ? stock.InStock : 0;
                    dgItemsDetails.Rows.Add(i.ItemName, i.Barcode, quantityStck,i.Status);
                }
            }
           

           
        }

        private void ItemDetails_Load(object sender, EventArgs e)
        {
            
                dgItemsDetails.Columns[0].ReadOnly = true;
                dgItemsDetails.Columns[1].ReadOnly = true;
                dgItemsDetails.Columns[2].ReadOnly = true;
                dgItemsDetails.Columns[3].ReadOnly = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null,null);
                e.SuppressKeyPress = true; // Suppress the Enter key from being processed by the control
            }
        }

        private void dgItemsDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgItemsDetails.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgItemsDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgItemsDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgItemsDetails.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                bool isChecked = (bool)dgItemsDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                var item = Item.GetItemWithName(dgItemsDetails.Rows[e.RowIndex].Cells[0].Value.ToString()).First();
                if (isChecked)
                {
                    Services.Item.UpdateActiveItem(1, item.Id.ToString());

                    MessageBox.Show("Artikulli eshte bere pasiv me sukses!");
                }
                else
                {
                    Services.Item.UpdateActiveItem(0, item.Id.ToString());
                    MessageBox.Show("Artikulli eshte bere aktiv me sukses!");

                }
            }
        }
    }
}
