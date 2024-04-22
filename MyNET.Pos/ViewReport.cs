using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace MyNET.Shops
{
    public partial class ViewReport : Form
    {
        public ViewReport()
        {
            InitializeComponent();
        }

        public ViewReport(string datasetName, string reportPath, object reportdata, Dictionary<String, string> reportparameter)
        {
            InitializeComponent();

            this.DataSetName = datasetName;
            this.ReportPath = reportPath;
            this.ReporData = reportdata;
            this.ReportParameters = reportparameter;
        }

        public object ReporData { get; set; }
        public string DataSetName { get; set; }
        public string ReportPath { get; set; }
        public Dictionary<String,string> ReportParameters { get; set; }
        
        private void ViewReport_Load(object sender, EventArgs e)
        {
            rv.Dock = DockStyle.Fill;                       
            var myRDS = new ReportDataSource(DataSetName, ReporData);
            //bbb
            // Clear out default datasource and add new one (with same structure).
            rv.LocalReport.DataSources.Clear();
            rv.LocalReport.DataSources.Add(myRDS);
            rv.LocalReport.ReportPath = ReportPath;
            //* Show report automatically at form load

            var parameters = new List<ReportParameter>();
            foreach (var item in ReportParameters)
            {
                ReportParameter par = new ReportParameter(item.Key, item.Value);
                parameters.Add(par);
            }       
           
            rv.LocalReport.SetParameters(parameters);

            this.rv.RefreshReport();           
        }
    }
}
