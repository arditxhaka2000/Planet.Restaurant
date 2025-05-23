﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using Services.Models;
using Services;
using SocketIOClient;
using System.Security.Policy;
using MyNET.Models;
using System.Net.Sockets;
using Newtonsoft.Json;
using Microsoft.Office.Interop.Word;
using System.Timers;
using System.Threading.Tasks;
using Point = System.Drawing.Point;
using SocketClient;
using Sprache;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using MyNET.Shops;
using System.IO;
using System.Text.RegularExpressions;
using iText.StyledXmlParser.Jsoup.Parser;
using System.Runtime.InteropServices;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using Microsoft.Web.WebView2.Core;
using Quobject.SocketIoClientDotNet.Client;
using System.Windows.Markup;
using Microsoft.AspNet.SignalR;
using MyNET.Pos.Helper;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace MyNET.Pos.Modules
{
    [ComVisible(true)]
    public partial class Restaurant : Form
    {
        AddTables tables = new AddTables();
        private Point MouseDownLocation;
        private bool isMouseDown = false;
        private int currentSpaceId;
        private decimal totalPos;
        protected static SocketIO socket;
        public static decimal openAmount;
        public static int tblWidth;
        public static int tblHeight;
        public static int TotalFontSize;
        public static int FSize;
        public static int gap;
        protected string options = "";
        public string bashko1 = "";
        public string bashko2 = "";
        public delegate void CustomDataReceivedEventHandler(string data);
        public static string toUpdateTableId;
        public event CustomDataReceivedEventHandler CustomDataReceived;
        private readonly SynchronizationContext syncContext;
        public Restaurant()
        {
            InitializeComponent();
            InitializeWebView();
            syncContext = SynchronizationContext.Current;
        }
        private async void Restaurant_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async();

            socket = new SocketIO(Services.Connection.GetConnection());
            socket.On("connect", (server) =>
            {
                MessageBox.Show("Connected to server");
            });

            socket.On("table info", (data) =>
            {
                Console.WriteLine($"Received query response: {data}");

                dynamic responseObj = JsonConvert.DeserializeObject(data.ToString());
                int inPos = responseObj[0].inPos;
                string id = responseObj[0].Id;
                string color = inPos == 0 ? "green" : "red";
                string shape = Services.Tables.GetTables().Find(p => p.Id.ToString() == id).Shape;
                UpdateTableColor(id, color,shape);


            });
            socket.On("PosTotal", (data) =>
            {
                Console.WriteLine($"Received query response: {data}");
                dynamic responseObj = JsonConvert.DeserializeObject(data.ToString());
                string total = responseObj[0].inPosTotal;
                string id = responseObj[0].Id;

                UpdateTableTotal(id, total);

            });

            pictureBox1.Tag = Settings.Get().Theme;

            if (pictureBox1.Tag.ToString() == "dark")
            {
                pictureBox1.Image = Properties.Resources.light;

            }
            else
            {
                pictureBox1.Image = Properties.Resources.dark;

            }

            await socket.ConnectAsync();




        }
        private async void InitializeWebView()
        {
            await webView21.EnsureCoreWebView2Async();
            // Send data from C# to JavaScript
            webView21.CoreWebView2.WebMessageReceived += CoreWebView2_AddWebMessageReceived;
            webView21.CoreWebView2.DOMContentLoaded += WebView_DOMContentLoaded;
            webView21.CoreWebView2.Navigate(System.Windows.Forms.Application.StartupPath + "\\index.html");

        }
        private void WebView_DOMContentLoaded(object sender, CoreWebView2DOMContentLoadedEventArgs e)
        {
            var spaces = Services.Spaces.GetSpaces();


            if (spaces.Count > 0)
            {
                SendSpacesToJavaScript(spaces);

                SendTablesToJavaScript(Services.Tables.GetTablesBySpaceId(spaces.First().Id));

            }
            PassTheme(pictureBox1.Tag.ToString());

        }

        private async void CoreWebView2_AddWebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)     
        {
            // Receive messages sent from JavaScript
            string message = e.TryGetWebMessageAsString();
            if (message == "POS")
            {
                var id = await webView21.CoreWebView2.ExecuteScriptAsync("openPos()");
                var tbl = Services.Tables.GetTables().Where(p => p.Id.ToString() == id.ToString()).First();

                if (tbl.inPos == 0)
                {
                    Services.Tables.UpdateTablePos(1, id);
                    Services.Tables.UpdateTableEmpId(Globals.User.Id.ToString(), id);
                    Services.Tables.UpdateDate(DateTime.Now.ToString(), id);
                    Globals.NextStep = "RestaurantPos" + id;
                    if (!IsDisposed && !Disposing)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (!IsDisposed && !Disposing)
                            {
                                this.Close();
                            }
                        });
                    }

                }
                else
                {
                    if (tbl.JoinId == 0)
                    {

                        if (tbl.Emp_id == Globals.User.Id || Globals.User.Role == "1")
                        {
                            Services.Tables.UpdateTablePos(1, id);

                            Globals.NextStep = "RestaurantPos" + id;
                            if (!IsDisposed && !Disposing)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    if (!IsDisposed && !Disposing)
                                    {
                                        this.Close();
                                    }
                                });
                            }
                        }
                        else
                        {
                            if ((Globals.Settings.PIN != "0" || Globals.Settings.PIN != null) && Globals.User.Role=="0")
                            {
                                EnterPin enterPin = new EnterPin();
                                enterPin.ShowDialog();
                                if (enterPin.flag == true)
                                {
                                    Services.Tables.UpdateTablePos(1, id);

                                    Globals.NextStep = "RestaurantPos" + id;
                                    if (!IsDisposed && !Disposing)
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            if (!IsDisposed && !Disposing)
                                            {
                                                this.Close();
                                            }
                                        });
                                    }
                                }
                            }
                            //MessageBox.Show("Tavolina eshte hap nga puntori :" + User.Get(tbl.Emp_id).Name);
                        }

                    }
                    else
                    {
                        MessageBox.Show($"Tavolina e bashkuar me tavolinen: {Services.Tables.GetTables().Where(p => p.Id == tbl.JoinId).First().Name}.");
                    }

                }
            }
            else
            {
                var tables = Services.Tables.GetTablesBySpaceId(Convert.ToInt32(message));
                SendTablesToJavaScript(tables);
                webView21.Refresh();
            }

        }
        private async void SendTablesToJavaScript(List<Services.Tables> tables)
        {
            var filteredTables = tables.Where(t => t.toDelete != "1").ToList();

            string jsonTables = JsonConvert.SerializeObject(filteredTables);

            jsonTables = jsonTables.Replace("'", "\\'");

            await webView21.CoreWebView2.ExecuteScriptAsync($"receiveTables('{jsonTables}')");
        }
        private async void SendSpacesToJavaScript(List<Services.Spaces> spaces)
        {
            string jsonSpaces = JsonConvert.SerializeObject(spaces);

            jsonSpaces = jsonSpaces.Replace("'", "\\'");

            await webView21.CoreWebView2.ExecuteScriptAsync($"receiveSpaces('{jsonSpaces}')");

        }
        private async void PassStringToJavaScript(string message)
        {
            await webView21.ExecuteScriptAsync($"functionOptionsRestaurant('{message}')");
            webView21.Refresh();
        }
        private async void PassTheme(string message)
        {
            await webView21.ExecuteScriptAsync($"changeTheme('{message}')");
            webView21.Refresh();
        }
        private void UpdateTableColor(string id, string color,string shape)
        {
            syncContext.Post(async _ =>
            {
                if (webView21.IsDisposed || !webView21.IsHandleCreated)
                {
                    return;
                }

                try
                {
                    await webView21.ExecuteScriptAsync($"changeTableColor('{id}', '{color}','{shape}')");
                }
                catch (Exception ex)
                {
                    // Handle or log the exception here
                    Console.WriteLine("Error executing script: " + ex.Message);
                }
            }, null);
        }       
        private void UpdateTableTotal(string id, string total)
        {
            syncContext.Post(async _ =>
            {
                if (webView21.IsDisposed || !webView21.IsHandleCreated)
                {
                    return;
                }

                try
                {
                    await webView21.ExecuteScriptAsync($"changeTableTotal('{id}', '{total}')");
                }
                catch (Exception ex)
                {
                    // Handle or log the exception here
                    Console.WriteLine("Error executing script: " + ex.Message);
                }
            }, null);
        }



        private void AdjustTableSize()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width;

            if (Screen.PrimaryScreen.WorkingArea.Width == 1920f)
            {
                tblWidth = 140;
                tblHeight = 100;
                FSize = 11;
                TotalFontSize = 14;
                gap = 0;
            }
            else if (x >= 1400 && x <= 1680)
            {
                tblWidth = 130;
                tblHeight = 90;
                FSize = 11;
                TotalFontSize = 14;
            }
            else if (x >= 1280 && x <= 1366)
            {
                tblWidth = 100;
                tblHeight = 60;
                FSize = 7;
                TotalFontSize = 9;
                gap = 5;

            }
            else
            {
                tblWidth = 70;
                tblHeight = 20;
                FSize = 6;
                TotalFontSize = 9;
                gap = 7;

            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int spaceId = (int)button.Tag;
                //foreach (var item in panel2.Controls.OfType<Button>())
                //{
                //    if (item.Tag.ToString() == spaceId.ToString())
                //    {
                //        item.BackColor = Color.FromArgb(122, 111, 190);
                //    }
                //    else
                //    {
                //        item.BackColor = Color.FromArgb(55, 67, 82);
                //    }
                //}
                var tables = Services.Tables.GetTablesBySpaceId(spaceId).Where(p => p.toDelete != "1");
                currentSpaceId = spaceId;
                panel1.Controls.Clear();



                foreach (var table in tables)
                {
                    Panel panel = new Panel();
                    panel.Width = tblWidth;
                    panel.Height = tblHeight + 20; // Height of PictureBox + Label 
                    int pixelX = (int)(Convert.ToDecimal(table.LocationX) * this.Width / 100);
                    int pixelY = (int)(Convert.ToDecimal(table.LocationY) * this.Height / 100);
                    panel.Top = pixelY;
                    panel.Left = pixelX;
                    panel.Click += button_Click;
                    panel.Tag = table.Id;
                    panel.BackColor = Color.Transparent;
                    panel.BackgroundImage = table.inPos == 0 ? Properties.Resources.free : Properties.Resources.taken;
                    panel.BackgroundImageLayout = ImageLayout.Zoom;
                    //Me vone me link me api, puntorve ju caktohen tavolinat
                    //panel.Enabled = table.inPos == 0? true : false;
                    panel.Name = table.Name;
                    panel.BorderStyle = BorderStyle.None; // Add border to panel for visual representation
                    panel1.Controls.Add(panel);

                    Label label = new Label();
                    label.Text = table.Name;
                    label.Name = table.Name;
                    label.Font = new System.Drawing.Font("Lato", FSize, FontStyle.Regular);
                    //label.BackColor = table.inPos == 0 ? Color.FromArgb(80, 80, 80) : Color.FromArgb(112, 44, 44);
                    label.ForeColor = table.inPos == 0 ? Color.White : Color.White;
                    label.AutoSize = false;
                    label.Width = tblWidth;
                    label.Click += button_Click;
                    label.Height = 20;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Location = new Point(panel.Width / 2 - label.Width / 2, label.Height);
                    label.Tag = table.Id;
                    panel.Controls.Add(label); // Add Label to the panel

                    Label lblTotal = new Label();
                    Label lblFiscalCount = new Label();

                    lblFiscalCount.Text = Services.Tables.GetTables().Where(p => p.Id == Convert.ToInt32(table.Id)).First().FiscalCount > 0 ? "Porosia :" + Services.Tables.GetTables().Where(p => p.Id == Convert.ToInt32(table.Id)).First().FiscalCount.ToString() : "Porosia :";
                    lblFiscalCount.Width = tblWidth;
                    lblFiscalCount.Height = 20;
                    lblFiscalCount.ForeColor = table.inPos == 0 ? Color.White : Color.White;
                    //lblFiscalCount.BackColor = table.inPos == 0 ? Color.FromArgb(80, 80, 80) : Color.FromArgb(112, 44, 44);
                    lblFiscalCount.Click += button_Click;
                    lblFiscalCount.Font = new System.Drawing.Font(lblTotal.Font.FontFamily, FSize);
                    lblFiscalCount.TextAlign = ContentAlignment.MiddleCenter;
                    lblFiscalCount.Tag = table.Id + "fc";
                    lblFiscalCount.Location = new Point(panel.Width / 2 - lblFiscalCount.Width / 2, panel.Width / 3);
                    var tot = table.inPosTotal != "0" ? Convert.ToDecimal(table.inPosTotal) : 0;
                    lblTotal.Text = /*table.inPosTotal!="0"|| */ tot > 0 ? table.inPosTotal + "€" : "";
                    lblTotal.Width = tblWidth;
                    lblTotal.Height = 20;
                    lblTotal.ForeColor = Color.White;
                    //lblTotal.BackColor = table.inPos == 0 ? Color.FromArgb(80, 80, 80) : Color.FromArgb(112, 44, 44);
                    lblTotal.Click += button_Click;
                    lblTotal.Font = new System.Drawing.Font(lblTotal.Font.FontFamily, TotalFontSize);
                    lblTotal.TextAlign = ContentAlignment.MiddleCenter;
                    lblTotal.Location = new Point(panel.Width / 2 - lblTotal.Width / 2, lblFiscalCount.Bottom - gap);
                    lblTotal.Tag = table.Id + "t";

                    panel.Controls.Add(lblFiscalCount);
                    panel.Controls.Add(lblTotal);

                }
            }
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            //me e hap posin per cdo tavoline

        }

        private void Edito_Click(object sender, EventArgs e)
        {
            ////btn_Fshij.Visible = true;
            ////ShtoTavolina.Visible = true;
            ///
            Ruaj.Visible = true;
            ////btnAddSpace.Visible = true;

            //foreach (Panel button in this.panel1.Controls.OfType<Panel>())
            //{
            //    foreach (Control item in button.Controls)
            //    {
            //        item.MouseDown += button_MouseDown;
            //        item.MouseMove += button_MouseMove;
            //        item.Click -= button_Click;
            //    }

            //}

            PassStringToJavaScript("Lokacioni");

        }
        private async void Ruaj_Click(object sender, EventArgs e)
        {
            //btn_Fshij.Visible = false;
            //ShtoTavolina.Visible = false;
            Ruaj.Visible = false;
            //btnAddSpace.Visible = false;

            if (options == "Lokacionet")
            {
                await GetLocationFromJs();

            }
            else if (options == "Bashko Tavolinat")
            {

                await GetBashkoTavolinat();
            }
            else if (options == "Transfero Tavolinen")
            {
                await GetTransferoTavolinat();
            }

            comboBox1.Text = "";

            webView21.Reload();

        }
        public async System.Threading.Tasks.Task GetLocationFromJs()
        {
            var result = await webView21.CoreWebView2.ExecuteScriptAsync("getDivLocations()");

            var dataArray = JsonConvert.DeserializeObject<Services.Tables[]>(result);

            foreach (var item in dataArray)
            {
                decimal x = Convert.ToDecimal(item.LocationX) * 100 / this.Width;
                decimal y = Convert.ToDecimal(item.LocationY) * 100 / this.Height;
                string id = item.Id.ToString();

                Services.Tables.UpdateTableLocation(x, y, id);
                Services.Tables.UpdateToUpdate(id);
            }


        }
        public async System.Threading.Tasks.Task GetBashkoTavolinat()
        {
            var result = await webView21.CoreWebView2.ExecuteScriptAsync("sendBashko()");

            var dataArray = JsonConvert.DeserializeObject<int[]>(result);
            if (dataArray.Length > 0)
            {
                bashko1 = dataArray[0].ToString();
                bashko2 = dataArray[1].ToString();
            }
            btnJoinTables_Click(null, null);

        }
        public async System.Threading.Tasks.Task GetTransferoTavolinat()
        {
            var result = await webView21.CoreWebView2.ExecuteScriptAsync("sendBashko()");

            var dataArray = JsonConvert.DeserializeObject<int[]>(result);
            if (dataArray.Length > 0)
            {
                bashko1 = dataArray[0].ToString();
                bashko2 = dataArray[1].ToString();
            }
            btnTransferTables_Click(null, null);

        }
        private void AdjustTableLocation(int x, int y, int id)
        {
            var button = panel1.Controls.OfType<Panel>().FirstOrDefault(b => b.Tag.ToString() == id.ToString());

            if (button != null)
            {
                int newX = (int)(x * this.Width / 100);
                int newY = (int)(y * this.Height / 100);

                this.Invoke((MethodInvoker)delegate
                {
                    button.Location = new Point(newX, newY);
                });
            }

        }
        private void AdjustTableColor(int inPos, string id)
        {
            var button = panel1.Controls.OfType<Panel>().FirstOrDefault(b => b.Tag.ToString() == id);

            if (button != null)
            {
                //var lblTotal = button.Controls.OfType<Label>().FirstOrDefault(b => b.Tag != null && b.Tag.ToString() == id + "t");
                //var lblFiscCount = button.Controls.OfType<Label>().FirstOrDefault(b => b.Tag != null && b.Tag.ToString() == id + "fc");
                //var lbl = button.Controls.OfType<Label>().FirstOrDefault(b => b.Tag != null && b.Tag.ToString() == id);
                button.BackgroundImage = inPos == 0 ? Properties.Resources.free : Properties.Resources.taken;


            }

        }
        private void AdjustTableTotal(string total, string id)
        {
            var button = panel1.Controls.OfType<Panel>().FirstOrDefault(b => b.Tag.ToString() == id);

            if (button != null)
            {
                var lblTotal = button.Controls.OfType<Label>().FirstOrDefault(b => b.Tag != null && b.Tag.ToString() == id + "t");
                //var lblFiscCount = button.Controls.OfType<Label>().FirstOrDefault(b => b.Tag != null && b.Tag.ToString() == id + "fc");
                if (lblTotal != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblTotal.Text = Convert.ToDecimal(total) > 0 ? total + "€" : "";
                    });
                }
                //lbl.Text = total;
            }


        }

        private void ShtoTavolina_Click(object sender, EventArgs e)
        {
            AddTables tables = new AddTables();
            tables.ShowDialog();
            webView21.Reload();

        }



        public void button_Click(object sender, EventArgs e)
        {
            var button = (Control)sender;
            string tag = "";

            if (button != null)
            {
                tag = Regex.Replace(button.Tag.ToString(), "[^0-9]", "");
                var tbl = Services.Tables.GetTables().Where(p => p.Id.ToString() == tag.ToString()).First();
                if (tbl.inPos == 0)
                {
                    Services.Tables.UpdateTablePos(1, tag);
                    Services.Tables.UpdateTableEmpId(Globals.User.Id.ToString(), tag);
                    Globals.NextStep = "RestaurantPos" + tag;
                    if (!IsDisposed && !Disposing)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (!IsDisposed && !Disposing)
                            {
                                this.Close();
                            }
                        });
                    }

                }
                else
                {
                    if (tbl.Emp_id == Globals.User.Id)
                    {
                        Services.Tables.UpdateTablePos(1, tag);

                        Globals.NextStep = "RestaurantPos" + tag;
                        if (!IsDisposed && !Disposing)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                if (!IsDisposed && !Disposing)
                                {
                                    this.Close();
                                }
                            });
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Tavolina eshte hap nga puntori :" + User.Get(tbl.Emp_id).Name);
                    }
                }
            }
        }


        public void button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
            }

        }
        public void button_MouseMove(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            if (control != null)
            {
                if (control is Panel || control is Label)
                {

                    if (e.Button == MouseButtons.Left)
                    {
                        Control parentControl = control.Parent;
                        if (parentControl != null && parentControl is Panel)
                        {
                            Panel panel = parentControl as Panel;
                            panel.Left += e.X - (panel.Width / 2);
                            panel.Top += e.Y - (panel.Height / 2);
                        }
                    }

                }
            }
        }

        private void Restaurant_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!Globals.NextStep.StartsWith("RestaurantPos"))
            {
                Services.StationService.UnLockUserStation(Globals.User.Id, Globals.DeviceId);
                Globals.NextStep = "Exit";
            }

        }

        private void btnAddSpace_Click(object sender, EventArgs e)
        {
            AddSpaces spaces = new AddSpaces();
            spaces.ShowDialog();
            webView21.Reload();

        }
        public void ReloadForm()
        {
            this.Invoke((MethodInvoker)delegate
            {
                Restaurant_Load(null, EventArgs.Empty);
            });

        }

        private void btn_Fshij_Click(object sender, EventArgs e)
        {
            DelTable del = new DelTable();

            del.ShowDialog();

            //if (del.spaceIdToDelete != 0)
            //{
            //HideSpace(del.spaceIdToDelete);
            //}
            webView21.Reload();
        }


        private void button1_Click(object sender, EventArgs e)
        {
                CloseCashboxRestaurant close = new CloseCashboxRestaurant();
                close.Owner = this;
                close.ShowDialog();

        }

        private void btnZRaport_Click(object sender, EventArgs e)
        {
            var globals = Services.Settings.Get();

            try
            {
                //shtyp raportin Z
                string path = "";
                if (globals != null)
                {
                    path = Globals.Settings.FiscalPrinterPath;

                }
                else
                {

                    MessageBox.Show("Nuk eshte i lidhur printeri!");
                }

                if (globals.FiscalPrinterType == "Tremol")
                {
                    if (globals.PosPrinter == "1")
                    {
                        TremolPrint.PrintZReport();

                    }
                }
                else
                {
                    var myUniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".inp";

                    string zReport = "E,1, ______,_,__; Planetaccounting.org;@Z,1,______,_,__;" + Environment.NewLine;
                    zReport = zReport.Replace("@", "\n");

                    File.WriteAllText(Path.Combine(path, myUniqueFileName), zReport);
                }
            }
            catch
            {

            }


            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Tag.ToString() == "dark")
            {
                pictureBox1.Image = Properties.Resources.dark;
                pictureBox1.Tag = "light";
            }
            else
            {
                pictureBox1.Image = Properties.Resources.light;
                pictureBox1.Tag = "dark";

            }
            PassTheme(pictureBox1.Tag.ToString());
            Settings.UpdateThemePreference(pictureBox1.Tag.ToString(), Globals.Settings.Id);
            Globals.LoadSettings();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ruaj.Visible == false)
            {
                if ((Globals.Settings.PIN != "0" || Globals.Settings.PIN != null) && Globals.User.Role=="0")
                {
                    EnterPin enterPin = new EnterPin();
                    enterPin.ShowDialog();
                    if (enterPin.flag == true)
                    {


                        string selectedItem = comboBox1.SelectedItem.ToString();
                        options = selectedItem;
                        switch (selectedItem)
                        {
                            case "Mbyll Ditën":
                                button1_Click(sender, null);
                                break;

                            case "Shiko Tavolinat":
                                ManageTables();
                                break;

                            case "Edito":
                                btn_Fshij_Click(sender, null);
                                break;

                            case "Shto Tavolinë":
                                ShtoTavolina_Click(sender, null);
                                break;

                            case "Shto Hapsirë":
                                btnAddSpace_Click(sender, null);
                                break;

                            case "Lokacionet":
                                Edito_Click(sender, null);
                                break;

                            case "Opsionet":
                                Raportet_Click(sender, null);
                                break;

                            case "Transfero Tavolinen":
                                Ruaj.Visible = true;
                                PassStringToJavaScript("Transfero");
                                break;
                            case "Bashko Tavolinat":
                                Ruaj.Visible = true;
                                PassStringToJavaScript("Bashko");
                                break;

                            case "Dil":
                                Dil_Click(sender, null);
                                break;

                            case "Shiko Artikujt":
                                ItemDetails_Click(sender, null);
                                break;

                            default:
                                // Handle other cases if needed
                                break;
                        }
                    }

                }
                else
                {

                    string selectedItem = comboBox1.SelectedItem.ToString();
                    options = selectedItem;
                    switch (selectedItem)
                    {
                        case "Mbyll Ditën":
                            button1_Click(sender, null);
                            break;

                        case "Shiko Tavolinat":
                            ManageTables();
                            break;

                        case "Edito":
                            btn_Fshij_Click(sender, null);
                            break;

                        case "Shto Tavolinë":
                            ShtoTavolina_Click(sender, null);
                            break;

                        case "Shto Hapsirë":
                            btnAddSpace_Click(sender, null);
                            break;

                        case "Lokacionet":
                            Edito_Click(sender, null);
                            break;

                        case "Opsionet":
                            Raportet_Click(sender, null);
                            break;

                        case "Transfero Tavolinen":
                            Ruaj.Visible = true;
                            PassStringToJavaScript("Transfero");
                            break;
                        case "Bashko Tavolinat":
                            Ruaj.Visible = true;
                            PassStringToJavaScript("Bashko");
                            break;

                        case "Dil":
                            Dil_Click(sender, null);
                            break;

                        case "Shiko Artikujt":
                            ItemDetails_Click(sender, null);
                            break;

                        default:
                            // Handle other cases if needed
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ruani ndryshimet!");
            }
        }

        private void Dil_Click(object sender, EventArgs value)
        {
             Globals.NextStep = "LoginForm";
            Globals.CashBoxStatus = "Locked";
            Services.StationService.UnLockUserStation(Globals.User.Id, Globals.DeviceId);
            this.Close();
            Globals.NextStep = "LoginForm";

        }
        private void btnTransferOrder_Click(object sender, EventArgs e)
        {
            //TransferOrderDetails transfer = new TransferOrderDetails();
            //transfer.Owner = this;

            //transfer.ShowDialog();
            try
            {

                var currentTable = bashko1;
                var newTable = bashko2;

                Services.Tables.UpdateTablePos(0, currentTable);
                Services.Tables.UpdateTablePos(1, newTable);
                var ts = TableSaleDetails.GetTS();
                foreach (var item in ts)
                {
                    if (item.tableId.ToString() == currentTable)
                    {
                        Services.TableSaleDetails.UpdateTSTableId(newTable, item.Id.ToString());

                    }
                }
                Services.Tables.UpdateTableEmpId("0", currentTable);
                Services.Tables.UpdateTableEmpId(Globals.User.Id.ToString(), newTable);
                var cTotal = Services.Tables.GetTables().Where(p => p.Id.ToString() == currentTable).First().inPosTotal;
                Services.Tables.UpdateTotalInPos(cTotal, newTable);
                Services.Tables.UpdateTotalInPos("0", currentTable);
                webView21.Reload();

                Ruaj.Visible = false;


            }
            catch (Exception)
            {

                throw;
            }

        }
        private void btnJoinTables_Click(object sender, EventArgs e)
        {

            //JoinTables transfer = new JoinTables();
            //transfer.Owner = this;

            //transfer.ShowDialog();
            try
            {

                var currentTable = bashko1;
                var newTable = bashko2;

                var TableIdCurrent = Services.Tables.GetTables().Where(p => p.Id.ToString() == currentTable).First();
                var TableIdNew = Services.Tables.GetTables().Where(p => p.Id.ToString() == newTable).First();
                var checkIfExistsCurrent = Services.Tables.GetTables().Where(p => p.JoinId.ToString() == currentTable).ToList();
                var checkIfExistsNew = Services.Tables.GetTables().Where(p => p.JoinId.ToString() == newTable).ToList();

                if (TableIdCurrent.JoinId == 0 && TableIdNew.JoinId == 0 && checkIfExistsCurrent.Count == 0 && checkIfExistsNew.Count == 0)
                {

                    Services.Tables.UpdateTableJoinId(newTable, currentTable);
                    if (TableIdCurrent.Date == null)
                    {
                        Services.Tables.UpdateDate(DateTime.Now.ToString(), currentTable);

                    }
                    if (TableIdNew.Date == null)
                    {
                        Services.Tables.UpdateDate(DateTime.Now.ToString(), newTable);

                    }

                    Services.Tables.UpdateTablePos(1, newTable);

                    var ts = TableSaleDetails.GetTS();
                    foreach (var item in ts)
                    {
                        if (item.tableId.ToString() == currentTable)
                        {
                            // Check if an item with the same ID exists in the new table
                            var existingItem = ts.Where(i => i.tableId.ToString() == newTable && i.ItemId == item.ItemId && i.Status == 0);

                            if (existingItem != null && existingItem.Count() > 0)
                            {
                                // Update the quantity of the existing item
                                Services.TableSaleDetails.UpdateTSQuantity(newTable, item.ItemId.ToString(), (existingItem.First().Quantity + item.Quantity).ToString(), (existingItem.First().TotalWithVat + item.TotalWithVat).ToString());
                                Services.TableSaleDetails.DeleteTableSaleWithId(item.Id.ToString());
                            }
                            else
                            {
                                // If the item doesn't exist in the new table, add it with quantity 1
                                Services.TableSaleDetails.UpdateTSTableId(newTable, item.Id.ToString());
                            }
                        }

                        //if (item.tableId.ToString() == currentTable)
                        //{
                        //    Services.TableSaleDetails.UpdateTSTableId(newTable, item.Id.ToString());

                        //}

                    }
                    //Services.Tables.UpdateTableEmpId("0", currentTable);
                    Services.Tables.UpdateTableEmpId(Globals.User.Id.ToString(), newTable);
                    var cTotal = Services.Tables.GetTables().Where(p => p.Id.ToString() == currentTable).First().inPosTotal;
                    var dTotal = Services.Tables.GetTables().Where(p => p.Id.ToString() == newTable).First().inPosTotal;
                    var total = Convert.ToDecimal(cTotal) + Convert.ToDecimal(dTotal);
                    Services.Tables.UpdateTotalInPos(total.ToString(), newTable);
                    Services.Tables.UpdateTotalInPos("0", currentTable);

                    var button = panel1.Controls.OfType<Panel>().FirstOrDefault(b => b.Tag.ToString() == currentTable);
                    //var oldlblFCount = button.Controls.OfType<Label>().FirstOrDefault(b => b.Tag != null && b.Tag.ToString() == currentTable + "fc");
                    //oldlblFCount.Text = "";
                    Ruaj.Visible = false;
                }
                else
                {
                    MessageBox.Show("Tavolinat janë te bashkuara");
                }

            }
            catch (Exception)
            {


            }

        }
        private void btnTransferTables_Click(object sender, EventArgs e)
        {

            //JoinTables transfer = new JoinTables();
            //transfer.Owner = this;

            //transfer.ShowDialog();
            try
            {

                var currentTable = bashko1;
                var newTable = bashko2;

                var TableIdCurrent = Services.Tables.GetTables().Where(p => p.Id.ToString() == currentTable).First();
                var TableIdNew = Services.Tables.GetTables().Where(p => p.Id.ToString() == newTable).First();
                var checkIfExistsCurrent = Services.Tables.GetTables().Where(p => p.JoinId.ToString() == currentTable).ToList();
                var checkIfExistsNew = Services.Tables.GetTables().Where(p => p.JoinId.ToString() == newTable).ToList();

                if (TableIdCurrent.JoinId == 0 && TableIdNew.JoinId == 0 && checkIfExistsCurrent.Count == 0 && checkIfExistsNew.Count == 0)
                {

                    if (TableIdCurrent.Date == null)
                    {
                        Services.Tables.UpdateDate(DateTime.Now.ToString(), currentTable);

                    }
                    if (TableIdNew.Date == null)
                    {
                        Services.Tables.UpdateDate(DateTime.Now.ToString(), newTable);

                    }

                    Services.Tables.UpdateTablePos(1, newTable);
                    Services.Tables.UpdateTablePos(0,currentTable);

                    var ts = TableSaleDetails.GetTS();
                    foreach (var item in ts)
                    {
                        if (item.tableId.ToString() == currentTable)
                        {
                            // Check if an item with the same ID exists in the new table
                            var existingItem = ts.Where(i => i.tableId.ToString() == newTable && i.ItemId == item.ItemId && i.Status == 0);

                            if (existingItem != null && existingItem.Count() > 0)
                            {
                                // Update the quantity of the existing item
                                Services.TableSaleDetails.UpdateTSQuantity(newTable, item.ItemId.ToString(), (existingItem.First().Quantity + item.Quantity).ToString(), (existingItem.First().TotalWithVat + item.TotalWithVat).ToString());
                                Services.TableSaleDetails.DeleteTableSaleWithId(item.Id.ToString());
                            }
                            else
                            {
                                // If the item doesn't exist in the new table, add it with quantity 1
                                Services.TableSaleDetails.UpdateTSTableId(newTable, item.Id.ToString());
                            }
                        }

                        //if (item.tableId.ToString() == currentTable)
                        //{
                        //    Services.TableSaleDetails.UpdateTSTableId(newTable, item.Id.ToString());

                        //}

                    }
                    //Services.Tables.UpdateTableEmpId("0", currentTable);
                    Services.Tables.UpdateTableEmpId(Globals.User.Id.ToString(), newTable);
                    var cTotal = Services.Tables.GetTables().Where(p => p.Id.ToString() == currentTable).First().inPosTotal;
                    var dTotal = Services.Tables.GetTables().Where(p => p.Id.ToString() == newTable).First().inPosTotal;
                    var total = Convert.ToDecimal(cTotal) + Convert.ToDecimal(dTotal);
                    Services.Tables.UpdateTotalInPos(total.ToString(), newTable);
                    Services.Tables.UpdateTotalInPos("0", currentTable);

                    var button = panel1.Controls.OfType<Panel>().FirstOrDefault(b => b.Tag.ToString() == currentTable);
                    //var oldlblFCount = button.Controls.OfType<Label>().FirstOrDefault(b => b.Tag != null && b.Tag.ToString() == currentTable + "fc");
                    //oldlblFCount.Text = "";
                    Ruaj.Visible = false;
                }
                else
                {
                    MessageBox.Show("Tavolinat janë te bashkuara");
                }

            }
            catch (Exception)
            {


            }

        }
        private void Raportet_Click(object sender, EventArgs value)
        {
            ReportRestaurant report = new ReportRestaurant();
            report.Owner = this;
            report.ShowDialog();
        }
        private void ItemDetails_Click(object sender, EventArgs value)
        {
            ItemDetails details = new ItemDetails();
            details.Owner = this;
            details.ShowDialog();
        }
        public void ReOpenForm()
        {
            this.Close();

            Globals.NextStep = "Restaurant";

        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Dil_Click(sender, null);

        }
        private void ManageTables()
        {
            Manage_Tables manage_ = new Manage_Tables();
            manage_.ShowDialog();
            if (manage_.toOpen == true)
            {
                this.Close();
            }
        }
    }
}


