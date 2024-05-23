using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNET;
using MyNET.Pos.Modules;
using System.Security.Cryptography;
using MyNET.Shops;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using System.IO;
using System.Net;
using Services.Models;
using Services;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Reflection;

namespace MyNET.Pos
{
    public partial class LoginForm : Form
    {
        #region  Members
        public string mUserName = "";
        public string mNum = "";
        public int PosType;
        #endregion
        public LoginForm()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }


        private void LoadUsers()
        {
            Modules.CreateButtons MakeButtons = new Modules.CreateButtons()
            {
                ParentControl = tP,
                Base = 5,
                ButtonColor = Color.FromArgb(248, 249, 250),
                ButtonBaseName = "btnUsers_",
                BaseAddition = 110,
                ButtonSize = new Size(220, 180),
                ButtonText = new Font("", 15, FontStyle.Bold),
                ButtonFlat = FlatStyle.Flat,
                BordersButton = ButtonBorderStyle.None,
                ButtonDock = DockStyle.Fill,
                ImageAlignButton = TextImageRelation.TextAboveImage
            };

            MakeButtons.ClickedHandler += button_Clicker;

            var users = Services.User.GetByStation(Globals.Station.Id);

            MakeButtons.CreateButtonsFromList(users);
        }

        private void button_Clicker(object sender, IdentifierButtonEventArgs e)
        {
            int userId = e.Identifier;
            var users = Services.User.Get(userId);
            mUserName = users.Id.ToString();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();
            Globals.LoadSettings();

            lblCompany.Text = globals.CompanyName;
             btnLoginMtd.Text = globals.EmpLoginMethod == "0" ? "Me kartelë" : "Me Buton";

            if (globals.EmpLoginMethod == "1")
            {
                tableLayoutPanel1.Visible = false;
                tableLayoutPanel3.Visible = false;
                splitContainer1.Visible = false;
                splitContainer2.Visible = false;
                this.BackgroundImage = Properties.Resources.planet_accounting_logo_;
                this.BackgroundImageLayout = ImageLayout.Center;

                txtCodeScan.Visible = true; 
                txtCodeScan.Size = new Size(350, 50);
                txtCodeScan.Location = new Point(this.Width / 2 - 200, this.ClientSize.Width / 2 - 125);
                txtCodeScan.Anchor = AnchorStyles.Bottom;
                txtCodeScan.TabIndex = 0;  
                txtCodeScan.Focus();
            }

            Station.UpdateStationStatus(1, Globals.Station.Id.ToString());

            LoadUsers();

            DeleteAnyCurrentUser();

        }
        public void DeleteAnyCurrentUser()
        {
            if (Services.StationService.GetUserStationsByDeviceId(Globals.DeviceId))
            {
                Services.StationService.DeleteCurrentUser(Globals.DeviceId);

            }
        }

        #region numBtn
        protected void textNum()
        {

            if (string.IsNullOrEmpty(mUserName))
            {
                MessageBox.Show("Ju lutem zgjidheni një Përdorues!");
                return;
            }

            if (txt1.Text == "")
            {
                txt1.Text = mNum;
            }
            else if (txt2.Text == "")
            {
                txt2.Text = mNum;
            }
            else if (txt3.Text == "")
            {
                txt3.Text = mNum;
            }
            else if (txt4.Text == "")
            {
                txt4.Text = mNum;
                
                if (CheckUser())
                {
                    //nese pini eshte ne rregull logohu 
                    AfterLoginCheck();
                    
                    AdjustButtonImageSize();

                }
                else
                {
                    MessageBox.Show("Emri apo fjalëkamlimi janë gabim!");
                    txt4.Text = ""; txt3.Text = ""; txt2.Text = ""; txt1.Text = "";
                }
            }
        }

        protected void delNum()
        {
            if (txt4.Text != "")
            {
                txt4.Text = "";
            }
            else if (txt3.Text != "")
            {
                txt3.Text = "";
            }
            else if (txt2.Text != "")
            {
                txt2.Text = "";
            }
            else if (txt1.Text != "")
            {
                txt1.Text = "";
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            mNum = ((Button)sender).Text;
            textNum();
        }


        private void btnDel_Click(object sender, EventArgs e)
        {
            //int i = txtPassword.Text.Length;
            //txtPassword.Text = txtPassword.Text.Substring(0, i - 1);
            delNum();
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {


            // Services.StationService.Get(10);

            if (string.IsNullOrEmpty(mUserName))
            {
                MessageBox.Show("Ju lutem zgjidheni një Përdorues!");
                return;
            }

            if (CheckUser())
            {
                AfterLoginCheck();

            }
            else
            {
                //nese useri ose pasi eshte gabim provo prap
                //trego mesazhin e gabimit
                MessageBox.Show("Emri apo fjalëkamlimi janë gabim!");
                txt4.Text = ""; txt3.Text = ""; txt2.Text = ""; txt1.Text = "";

            }
        }

        protected void AfterLoginCheck()
        {
            bool ifLocked = false;
            bool isLocked = Services.StationService.IsStationLocked(Globals.User.Id, Globals.DeviceId);
            if (!isLocked)
            {
                if (OpenMain())
                {
                    while (ifLocked == false)
                    {
                        ifLocked = Services.StationService.LockUserStation(Globals.User.Id, Globals.DeviceId,PosType);
                    }
                    //if (UserStation.Get(Globals.User.Id).PosType == 0)
                    //{
                    //    Globals.NextStep = "PosRestaurant";

                    //}
                    //else
                    //{
                    //    Globals.NextStep = "Restaurant";

                    //}
                    Globals.NextStep = "Restaurant";

                    Globals.CashBoxStatus = "Open";
                    this.Close();
                }

               

            }
            else
            {
                MessageBox.Show("Nuk mund te kyqeni me kete puntor.Puntori: " + Globals.User.Name + " eshte i kyqur!");

                txt4.Text = ""; txt3.Text = ""; txt2.Text = ""; txt1.Text = "";
                txtCodeScan.Text = "";

            }
        }

        private bool OpenMain()
        {

            int stationId = Globals.Station.Id;
            int userId = Globals.User.Id;
            var dailyOpenCloseBalance = Services.DailyOpenCloseBalance.GetLastDailyBalanceByEmployee(userId);

            if (dailyOpenCloseBalance == null || dailyOpenCloseBalance.Status.ToLower() == "close")
            {
                OpenChashbox frm = new OpenChashbox();
                DialogResult dr = frm.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    Globals.NextStep = "Exit";
                    this.Close();
                    return false;
                }
            }

            //Nese useri eshte authentiku mbylle kete dritare
            

            return true;
        }

        private bool CheckUser()
        {
            var settings = Services.Settings.Get();
            Services.User user = new Services.User();
            if (settings.EmpLoginMethod == "0")
            {
                string pwd = txt1.Text + txt2.Text + txt3.Text + txt4.Text; // TPA.CryptographyHelper.GetHashedPass(txtPassword.Text);
                user = Services.User.ValidateLogin(mUserName, pwd);
            }
            else
            {
                var users = Services.User.GetByStation(Globals.Station.Id);
                int c = users.Where(p => p.Pos_Token == txtCodeScan.Text).Count();
                if (c > 0)
                {
                    user = users.Where(p => p.Pos_Token == txtCodeScan.Text).First();
                }
                else
                {
                    txtCodeScan.Text = " ";
                    return false;
                }
            }


            if (user == null)
            {
                return false;
            }
            else
            {
                Globals.User = user;

                Services.Printer.InsertId(Globals.DeviceId,Globals.Station.Id);

                return true;
            }
        }


        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globals.NextStep == "LoginForm")
            {
                Globals.NextStep = "Exit";
            }
        }

        private void btnChangeStation_Click(object sender, EventArgs e)
        {
            var config = Globals.GetConfig();
            config.StationId = 0;
            try
            {
                var user = Services.User.GetByStation(Globals.Station.Id);
                Globals.SaveConfig(config);
                Services.StationService.UnLockUserStation(user.First().Id, Globals.DeviceId);
                Globals.NextStep = "SelectStation";
                this.Close();
            }
            catch (Exception)
            {
                Globals.NextStep = "SelectStation";
                this.Close();
            }
            this.ActiveControl = null;

        }

        private void btnLoginMtd_Click(object sender, EventArgs e)
        {
            var settings = Services.Settings.Get();
            bool clicked = settings.EmpLoginMethod == "0" ? true : false;

            if (clicked)
            {
                Services.Settings.updateEmpLoginMethod(settings.Id, "1");

                LoginForm_Load(null, null);
                clicked = true;
                btnLoginMtd.Text = "Me Buton";

            }
            else
            {
                Services.Settings.updateEmpLoginMethod(settings.Id, "0");

                tableLayoutPanel1.Visible = true;
                tableLayoutPanel3.Visible = true;
                splitContainer1.Visible = true;
                splitContainer2.Visible = true;
                this.BackgroundImage = null;
                this.BackgroundImageLayout = ImageLayout.Center;
                txtCodeScan.Visible = false;

                LoginForm_Load(null, null);
                clicked = false;
                btnLoginMtd.Text = "Me Kartelë";

            }
            this.ActiveControl = null;
        }

        private void txtCodeScan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CheckUser())
                {
                    AfterLoginCheck();
                }
            }
        }

        private void txtCodeScan_TextChanged(object sender, EventArgs e)
        {

        }
        private void AdjustButtonImageSize()
        {
            var items = new List<ItemsDiscount>();
            var sett = Services.Settings.Get();
            if (sett.BarcMode == 0)
            {
                if (sett.StockWMinus == "0")
                {
                    items = Services.Item.GetItemsDiscount(Globals.Station.ParentId);

                }
                else
                {
                    //me recorde mbi 10000 shkon shum kadal
                    items = Services.Item.GetAllItem();

                }
                foreach (var item in items)
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\ImagesPath" + sett.Id);

                    string subPath = Path.GetFullPath(Application.StartupPath + @"\ImagesPath" + sett.Id);
                    //Me ja bo skip fotove

                    string fullPath = subPath + "\\" + item.Id + ".jpg";
                    if (item.Cover != "noimage.jpg")
                    {
                        if (!File.Exists(fullPath))
                        {
                            string s = "https://planetaccountingwebdata.s3.eu-central-1.amazonaws.com/companies/" + "company_" + sett.Id + "/t_" + item.Cover;

                            try
                            {
                                var img = DownloadRemoteImageFile(s);
                                using (var ms = new MemoryStream(img))
                                using (var original = Image.FromStream(ms))
                                {
                                    var newHeight = 140;
                                    var newWidth = ScaleWidth(original.Height, newHeight, original.Width);
                                    using (var newPic = new Bitmap(newWidth, newHeight))
                                    using (var gr = Graphics.FromImage(newPic))
                                    {
                                        gr.DrawImage(original, 0, 0, newWidth, newHeight);
                                        newPic.Save(fullPath);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }

                }
                if (sett.Logo != "")
                {
                    string assemblyPath = Application.StartupPath + $"\\ImagesPath{sett.Id}";


                    // Define relative path to the image (assuming "myImage.jpg" is in Resources)
                    string imageRelativePath = $"Logo.jpg";

                    // Combine assembly path and relative path
                    string imagePath = Path.Combine(assemblyPath, imageRelativePath);

                    if (!File.Exists(imagePath))
                    {
                        string s = sett.Logo;
                    

                        try
                        {
                            var img = DownloadRemoteImageFile(s);
                            using (var ms = new MemoryStream(img))
                            using (var original = Image.FromStream(ms))
                            {
                                var newHeight = 140;
                                var newWidth = ScaleWidth(original.Height, newHeight, original.Width);

                                Directory.CreateDirectory(Path.GetDirectoryName(imagePath));

                                using (var newPic = new Bitmap(newWidth, newHeight))
                                using (var gr = Graphics.FromImage(newPic))
                                {
                                    gr.DrawImage(original, 0, 0, newWidth, newHeight);
                                    newPic.Save(imagePath);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            

        }
        private static byte[] DownloadRemoteImageFile(string uri)
        {
            byte[] content;
            var request = (HttpWebRequest)WebRequest.Create(uri);

            using (var response = request.GetResponse())
            using (var reader = new BinaryReader(response.GetResponseStream()))
            {
                content = reader.ReadBytes(100000);
            }

            return content;
        }
        private static int ScaleWidth(int originalHeight, int newHeight, int originalWidth)
        {
            var scale = Convert.ToDouble(newHeight) / Convert.ToDouble(originalHeight);

            return Convert.ToInt32(originalWidth * scale);
        }

        private void LoginForm_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!txtCodeScan.Focused) // check if the textbox doesn't have focus
            {
                txtCodeScan.Visible = true; // make the textbox visible
                txtCodeScan.Focus(); // give focus to the textbox
                txtCodeScan.Text = e.KeyChar.ToString(); // set the text of the textbox to the input character
                txtCodeScan.Select(txtCodeScan.Text.Length, 0); // move the cursor to the end of the textbox
                e.Handled = true; // mark the event as handled to prevent the character from being added to the form
            }
            else // if the textbox has focus, let the event pass through to the textbox
            {
                e.Handled = false;
            }

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRestaurantEnable_Click(object sender, EventArgs e)
        {
            PosType = 1;
        }
    }
}
