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
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace MyNET.Pos.Modules
{
    public partial class Manage_Tables : Form
    {
        public bool toOpen = false;
        public static bool closeTable = false;
        public Manage_Tables()
        {
            InitializeComponent();
        }

        private void Manage_Tables_Load(object sender, EventArgs e)
        {
            dg_openTables.Rows.Clear();

            var tables = Tables.GetTables().Where(p=>p.inPos==1);

            foreach (var table in tables)
            {
                var date = DateTime.Now - Convert.ToDateTime(table.Date);
                var dateT = (date).Minutes >1?date.Minutes + " minuta": date.Minutes + " minut";
                dg_openTables.Rows.Add(table.Id,table.Name, table.inPosTotal, dateT);

            }
        }

        private void dg_openTables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = dg_openTables.Rows[e.RowIndex].Cells[0].Value;

                if (dg_openTables.Columns[e.ColumnIndex].Name == "colCloseTable")
                {
                    closeTable = true;
                    Globals.NextStep = "RestaurantPos" + id;
                    toOpen = true;

                    this.Close();

                }
                else if (dg_openTables.Columns[e.ColumnIndex].Name == "colOpenTable")
                {

                    Globals.NextStep = "RestaurantPos" + id;
                    toOpen = true;
                    this.Close();
                }
            }
        }
    }
}
