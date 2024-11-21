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
                var dateT = "";
                if (date.Days > 0)
                {
                    if (date.Hours > 0)
                    {
                        dateT = date.Days + " ditë " + date.Hours + " orë " + date.Minutes + " minuta";

                    }
                    else
                    {
                        dateT = date.Days + " ditë " + date.Minutes + " minuta";

                    }
                }
                else if (date.Hours>0)
                {
                    dateT = date.Hours + " orë " + date.Minutes + " minuta"; 
                }
                else
                {
                    dateT = date.Minutes == 1 ? date.Minutes + " minut" : date.Minutes + " minuta";
                }

                dg_openTables.Rows.Add(table.Id,table.Name, User.Get(table.Emp_id).Name ,table.inPosTotal, dateT);

            }
        }
        Image mbyll = Properties.Resources.close;
        Image hap = Properties.Resources.open1;
        private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = 23;
                var h = 23;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top - 2 + (e.CellBounds.Height - h) / 2;
                var rect = new System.Drawing.Rectangle(x, y, w, h);
                //using (var brush = new SolidBrush(Color.IndianRed))
                //    e.Graphics.FillRectangle(brush,e.CellBounds.X,e.CellBounds.Y,e.CellBounds.Width,e.CellBounds.Height - 2);
                e.Graphics.DrawImage(mbyll, rect);
                e.Handled = true;
            }
            if (e.ColumnIndex == 6)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = 23;
                var h = 23;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top - 2 + (e.CellBounds.Height - h) / 2;
                var rect = new System.Drawing.Rectangle(x, y, w, h);
                //using (var brush = new SolidBrush(Color.IndianRed))
                //    e.Graphics.FillRectangle(brush,e.CellBounds.X,e.CellBounds.Y,e.CellBounds.Width,e.CellBounds.Height - 2);
                e.Graphics.DrawImage(hap, rect);
                e.Handled = true;
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
