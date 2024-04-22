using iText.Layout.Element;
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
    public partial class TransferOrderDetails : Form
    {
        public static string CtableId;
        public static string DtableId;

        public TransferOrderDetails()
        {
            InitializeComponent();
            cmbCTables.SelectedIndexChanged += CTableSelected;
            cmbDTables.SelectedIndexChanged += DTableSelected;
        }

        private void TransferOrderDetails_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            cmbCTables.DataSource = Services.Tables.GetTables();
            cmbCTables.DisplayMember = "Name";
            cmbCTables.ValueMember = "Id";

            // Initially filter destination tables based on 'inPos'
            cmbDTables.DataSource = Services.Tables.GetTables().Where(p => p.inPos == 0).ToList();
            cmbDTables.DisplayMember = "Name";
            cmbDTables.ValueMember = "Id";

            cmbCTables.SelectedIndex = -1;
        }
        private void DTableSelected(object sender, EventArgs e)
        {
            button1.Enabled = cmbCTables.SelectedIndex != -1;
        }
        private void CTableSelected(object sender, EventArgs e)
        {
            string selectedTableId = cmbCTables.SelectedValue != null ? cmbCTables.SelectedValue.ToString() : "";

            // Filter destination tables, excluding the selected table
            List<Tables> filteredTables = Services.Tables.GetTables().Where(p => p.Id.ToString() != selectedTableId && p.inPos==0).ToList();
            cmbDTables.DataSource = filteredTables;
            cmbDTables.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var currentTable = Services.Tables.GetTables().Where(p => p.Id.ToString() == cmbCTables.SelectedValue.ToString()).First();
            CtableId = currentTable.Id.ToString();

            var newTable = Services.Tables.GetTables().Where(p => p.Id.ToString() == cmbDTables.SelectedValue.ToString()).First();
            DtableId = newTable.Id.ToString();
            this.Close();
        }
    }

}
