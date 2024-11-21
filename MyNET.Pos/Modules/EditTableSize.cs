using ExtendedXmlSerializer.ExtensionModel.Types.Sources;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class EditTableSize : Form
    {
        public int Id;
        bool isResizingWidth = false;
        bool isResizingHeight = false;
        int initialWidth;
        int initialHeight;
        Point initialMousePosition;
        int initialDiameter;

        public EditTableSize()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tables.UpdateTableSize(btnTable.Width.ToString(), btnTable.Height.ToString(), Id.ToString());
            this.Close();
        }

        private void EditTableSize_Load(object sender, EventArgs e)
        {
            var table = Tables.GetTables().Where(p => p.Id == Id).First();

            btnTable.Size = new System.Drawing.Size(Convert.ToInt16(table.Width), Convert.ToInt16(table.Height));
            btnTable.Text = table.Name;

        }
        private void btnTable_MouseDown(object sender, MouseEventArgs e)
        {
            // Enable resizing for width if near the right edge
            if (e.Button == MouseButtons.Left && e.X >= btnTable.Width - 10)
            {
                isResizingWidth = true;
                initialWidth = btnTable.Width;
                initialMousePosition = e.Location;
            }

            // Enable resizing for height if near the bottom edge
            if (e.Button == MouseButtons.Left && e.Y >= btnTable.Height - 10)
            {
                isResizingHeight = true;
                initialHeight = btnTable.Height;
                initialMousePosition = e.Location;
            }
        }

        private void btnTable_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the cursor style
            if (e.X >= btnTable.Width - 10 && !isResizingHeight)
            {
                btnTable.Cursor = Cursors.SizeWE; // Horizontal resize cursor
            }
            else if (e.Y >= btnTable.Height - 10 && !isResizingWidth)
            {
                btnTable.Cursor = Cursors.SizeNS; // Vertical resize cursor
            }
            else
            {
                btnTable.Cursor = Cursors.Default;
            }

            // Resize width
            if (isResizingWidth)
            {
                int newWidth = initialWidth + (e.X - initialMousePosition.X);
                btnTable.Width = Math.Max(newWidth, 30); // Enforce a minimum width
            }

            // Resize height
            if (isResizingHeight)
            {
                int newHeight = initialHeight + (e.Y - initialMousePosition.Y);
                btnTable.Height = Math.Max(newHeight, 30); // Enforce a minimum height
            }
        }

        private void btnTable_MouseUp(object sender, MouseEventArgs e)
        {
            // Stop resizing
            isResizingWidth = false;
            isResizingHeight = false;
            btnTable.Cursor = Cursors.Default;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
