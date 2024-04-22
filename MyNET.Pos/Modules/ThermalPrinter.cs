using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public partial class ThermalPrinter : Form
    {
        public ThermalPrinter()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Printer printer = new Printer();

           printer.UpdatePaperWidth(textBox1.Text, Globals.DeviceId);
           printer.UpdateTermalName(comboBox2.SelectedItem.ToString(), Globals.DeviceId);

            AutoClosingMessageBox.Show("Jane ruajtur me sukses te dhenat", "Sukses", 800);
            this.Close();
        }

        private void ThermalPrinter_Load(object sender, EventArgs e)
        {
            var printer =  Services.Printer.Get().Find(p=>p.Id == Globals.DeviceId);
            comboBox2.Text = printer.TermalName!=null? printer.TermalName:"";
            textBox1.Text = printer.TermalPaperWidth != null? printer.TermalPaperWidth:"";

            foreach (string printers in PrinterSettings.InstalledPrinters)
            {
                comboBox2.Items.Add(printers);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
