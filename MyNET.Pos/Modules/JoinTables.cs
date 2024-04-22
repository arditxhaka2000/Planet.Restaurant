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
    public partial class JoinTables : Form
    {
        public static string CtableId;
        public static string DtableId;
        public JoinTables()
        {
            InitializeComponent();
            cmbCTables.SelectedIndexChanged += CTableSelected;
            cmbDTables.SelectedIndexChanged += DTableSelected;
        }
        private void JoinTables_Load(object sender, EventArgs e)
        {
            cmbCTables.DataSource = Services.Tables.GetTables();
            cmbCTables.DisplayMember = "Name";
            cmbCTables.ValueMember = "Id";

            cmbDTables.DataSource = Services.Tables.GetTables();
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
            List<Tables> filteredTables = Services.Tables.GetTables().Where(p => p.Id.ToString() != selectedTableId).ToList();
            cmbDTables.DataSource = filteredTables;
            cmbDTables.Refresh(); // Refresh to update the displayed items
        }
        private void button1_Click(object sender, EventArgs e)
        {
             var currentTable = Services.Tables.GetTables().Where(p=>p.Id.ToString()==cmbCTables.SelectedValue.ToString()).First();
            CtableId = currentTable.Id.ToString();
            
            var newTable = Services.Tables.GetTables().Where(p=>p.Id.ToString()==cmbDTables.SelectedValue.ToString()).First();
            DtableId = newTable.Id.ToString();
            this.Close();
        }

        private void cmbCTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDTables.DataSource = Services.Tables.GetTables();
            cmbDTables.Items.Remove(cmbCTables.SelectedItem);
        }
    }
}
