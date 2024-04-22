using System;
using System.Windows.Forms;
using System.Collections;
using Services.Models;

namespace MyNET.Pos
{
    public partial class SelectStation : Form
    {
        public SelectStation()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cbStations.SelectedItem != null)
            {
                MyNET.Globals.Station = (Services.Models.Station)cbStations.SelectedItem;
                MyNET.Globals.ParentStationId = MyNET.Globals.Station.ParentId;

                var config = Globals.GetConfig();
                config.StationId = MyNET.Globals.Station.Id;
                config.ParentStationId = MyNET.Globals.Station.ParentId;
                config.DeviceId = (string.IsNullOrEmpty(config.DeviceId)) ? Guid.NewGuid().ToString() : config.DeviceId;
                Globals.DeviceId = config.DeviceId;

                Globals.SaveConfig(config);
                Globals.LoadSettings();
                Station.UpdateStationStatus(1, config.StationId.ToString());


                this.Close();
            }
            else
            {
                MessageBox.Show(paragraph_please_choose_warehouse.Text);
            }
        }

        private void SelectStation_Load(object sender, EventArgs e)
        {
            try
            {

                var config = Globals.GetConfig();
                if (config.DeviceId == "")
                {
                    //first time opennig
                    config.DeviceId = Guid.NewGuid().ToString();
                    Globals.SaveConfig(config);

                }

                Globals.DeviceId = config.DeviceId;

                var stations = Services.StationService.GetByType();
                if (stations != null)
                {
                    cbStations.DataSource = stations;
                    cbStations.DisplayMember = "Name";
                    cbStations.ValueMember = "Id";
                }

                cbStations.SelectedValue = config.StationId;

                if (cbStations.SelectedValue != null)
                {
                    MyNET.Globals.Station = (Services.Models.Station)cbStations.SelectedItem;
                    MyNET.Globals.ParentStationId = MyNET.Globals.Station.ParentId;

                    Globals.NextStep = "LoginForm";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MyNET.TrackError.ReportError(ex.Message, ex.ToString());
                word_continue.Enabled = false;
                MessageBox.Show(paragraph_error_while_connected.Text);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Globals.NextStep = "ConnectToServer";
            var config = Globals.GetConfig();
            config.LocalServerHost = "";
            Globals.SaveConfig(config);
            this.Close();
        }



        private void btnClosee_Click(object sender, EventArgs e)
        {
            Globals.NextStep = "Exit";
            this.Close();
        }


    }
}
