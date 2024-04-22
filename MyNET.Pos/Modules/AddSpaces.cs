using Services;
using Sprache;
using System;
using System.CodeDom;
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

    public partial class AddSpaces : Form
    {
        public int spaceId { get; set; }
        public AddSpaces()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Spaces spaces = new Spaces();
            spaces.Name = txtSpaceName.Text;
            spaces.station_id = Globals.Station.Id.ToString();
            spaces.Status = "0";
            spaces.toDelete = "0";
            var result = spaces.Insert();
            if (result > 0)
            {
                spaceId = spaces.Id;
            }

            this.Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
