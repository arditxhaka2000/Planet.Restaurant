﻿using System;
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
    public partial class PosIsRunning : Form
    {
        public PosIsRunning()
        {
            InitializeComponent();
        }
        public void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
