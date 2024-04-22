using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNET.Pos.Modules
{
    public class CreateButtons
    {

        public Size ButtonSize { get; set; }

        public Font ButtonText { get; set; }
        public string ButtonT { get; set; }

        public FlatStyle ButtonFlat { get; set; }

        public ButtonBorderStyle BordersButton { get; set; }

        public DockStyle ButtonDock { get; set; }
        public AnchorStyles ButtonAnchor { get; set; }

        public Image CreateImage { get; set; }

        public Size imgSize { get; set; }

        public Color ButtonColor { get; set; }

        public Color TextColor { get; set; }

        public ImageLayout imgLayout { get; set; }

        public TextImageRelation ImageAlignButton { get; set; }

        public List<Button> Buttons { get; set; }

        public string ButtonBaseName { get; set; }
        public int Base { get; set; }
        public int BaseAddition { get; set; }

        public int ButtonCount { get; set; }
        public int y { get; set; }
        public int CatId { get; set; }

        public Control ParentControl { get; set; }

        public EventHandler<IdentifierButtonEventArgs> ClickedHandler;
        /// <summary>
        /// constructor for CreateButtonsFromTable
        /// </summary>
        /// <param name="ParentControl"></param>
        /// <param name="BaseName"></param>

        public CreateButtons(Control ParentControl, string BaseName)
        {
            this.ParentControl = ParentControl;
            this.ButtonBaseName = BaseName;
        }

        /// <summary>
        /// Creates buttons with their names taken from fieldName with a prefix of Me.ButtonBaseName
        /// and sets the tag of each button from Identifier which would be the primary key of a DataRow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Identifier">used to set tag for each button</param>
        /// <param name="fieldName">used to set button text and button name</param> 
        /// 

        public static Bitmap ByteToImage(byte[] blob)
        {
            Bitmap bm = null;
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            if (pData != null)
            {
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                bm = new Bitmap(mStream, false);
                mStream.Dispose();
            }
            return bm;

        }

        public void CreateButtonsFromList(IEnumerable<Services.Models.INamedObj> sender)
        {
            ParentControl.Controls.Clear();
            Buttons = new List<Button>();

            if (sender == null)
                return;

            ButtonCount = sender.Count() - 1;
            int i = 0;
            foreach (var item in sender)
            {

                Button b = new Button
                {
                    Name = string.Concat(ButtonBaseName, item.Id),
                    Text = item.Name,
                    Tag = item.Id,
                    Size = ButtonSize,
                    Font = ButtonText,
                    //Dock = ButtonDock,
                    //F = ButtonBorder,
                    FlatStyle = ButtonFlat,
                    TextImageRelation = ImageAlignButton,
                    BackColor = ButtonColor,
                    ForeColor = TextColor,
                    //Location = new Point(5, this.Base),
                    Location = new Point(i * ButtonSize.Width + 10, 0),
                    Parent = ParentControl,
                    Visible = true
                };

                //b.Image = (item.BlobData != null) ? ByteToImage(item.BlobData) : null;

                b.Click += (object s, EventArgs e) =>
                {
                    ClickedHandler(s, new IdentifierButtonEventArgs(Convert.ToInt32(((Button)s).Tag)));
                };

                //var tblCategories = (TableLayoutPanel)ParentControl;                
                //tblCategories.Controls.Add(b,i,0);
                ParentControl.Controls.Add(b);

                i++;
                Buttons.Add(b);
                //Base += BaseAddition;
            }
        }
        public void CreateButtonsFromLists(IEnumerable<Services.Models.INamedObj> sender)
        {
            try
            {
                ParentControl.Controls.Clear();
                Buttons = new List<Button>();

                if (sender == null)
                    return;

                ButtonCount = sender.Count() - 1;

                int i = 10;

                foreach (var item in sender)
                {
                    string path = Path.GetFullPath(Application.StartupPath + @"\ImagesPath" + Globals.Settings.Id.ToString() + "\\" + item.Id.ToString() + ".jpg");
                    if (item.Name.Length > 10)
                    {
                        ButtonT = item.Name.Substring(0, 10) + "...";
                    }
                    else
                    {
                        ButtonT = item.Name;
                    }
                    if (File.Exists(path))
                    {

                        Button b = new Button
                        {
                            Name = string.Concat(ButtonBaseName, item.Id),

                            Text = ButtonT + "\n" + item.TotalPrice + "EUR",

                            Tag = item.Id,
                            Size = ButtonSize,
                            Font = ButtonText,
                            //Dock = ButtonDock,
                            //F = ButtonBorder,
                            //FlatStyle = ButtonFlat,
                            TextImageRelation = ImageAlignButton,
                            TextAlign = ContentAlignment.BottomCenter,
                            Image = Image.FromFile(Path.GetFullPath(Application.StartupPath + @"\ImagesPath" + Globals.Settings.Id.ToString()) + "\\" + item.Id.ToString() + ".jpg"),
                            ImageAlign = ContentAlignment.TopCenter,
                            BackColor = Color.White,
                            ForeColor = TextColor,
                            //Location = new Point(5, this.Base),
                            Location = new Point(i * (ButtonSize.Width + 10), 10),
                            Parent = ParentControl,
                            Visible = true,
                            Margin = new Padding(10)

                        };

                        //b.Image = (item.BlobData != null) ? ByteToImage(item.BlobData) : null;

                        b.Click += (object s, EventArgs e) =>
                        {
                            ClickedHandler(s, new IdentifierButtonEventArgs(Convert.ToInt32(((Button)s).Tag)));
                        };
                        b.MouseHover += (s, e) =>
                        {
                            if (b.Tag != null && item.Name.Length > 10)
                            {
                                b.Text = item.Name.ToString() + "\n" + item.TotalPrice + "EUR";

                            }
                        };
                        b.MouseLeave += (s, e) =>
                        {
                            if (item.Name.Length > 10)
                            {
                                b.Text = item.Name.Substring(0, 10) + "\n" + item.TotalPrice + "EUR";

                            }

                        };

                        //var tblCategories = (TableLayoutPanel)ParentControl;                
                        //tblCategories.Controls.Add(b,i,0);
                        ParentControl.Controls.Add(b);
                        i++;
                        Buttons.Add(b);
                        //Base += BaseAddition;
                    }
                    else
                    {
                        Button b = new Button
                        {
                            Name = string.Concat(ButtonBaseName, item.Id),
                            Text = ButtonT + "\n" + item.TotalPrice + "EUR",

                            Tag = item.Id,
                            Size = ButtonSize,
                            Font = ButtonText,
                            TextImageRelation = ImageAlignButton,
                            TextAlign = ContentAlignment.BottomCenter,
                            ImageAlign = ContentAlignment.TopCenter,
                            BackColor = Color.White,
                            ForeColor = TextColor,
                            Location = new Point(i * (ButtonSize.Width + 10), 10),
                            Parent = ParentControl,
                            Visible = true,
                            Margin = new Padding(10)
                        };

                        //b.Image = (item.BlobData != null) ? ByteToImage(item.BlobData) : null;

                        b.Click += (object s, EventArgs e) =>
                        {
                            ClickedHandler(s, new IdentifierButtonEventArgs(Convert.ToInt32(((Button)s).Tag)));
                        };
                        b.MouseHover += (s, e) =>
                        {
                            if (b.Tag != null && item.Name.Length > 10)
                            {
                                b.Text = item.Name.ToString() + "\n" + item.TotalPrice + "EUR";

                            }
                        };
                        b.MouseLeave += (s, e) =>
                        {
                            if (item.Name.Length > 10)
                            {
                                b.Text = item.Name.Substring(0, 10) + "\n" + item.TotalPrice + "EUR";

                            }

                        };

                        //var tblCategories = (TableLayoutPanel)ParentControl;                
                        //tblCategories.Controls.Add(b,i,0);
                        ParentControl.Controls.Add(b);
                        i++;
                        Buttons.Add(b);
                        //Base += BaseAddition;
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
        public void CreateTeGjitha()
        {
            ParentControl.Controls.Clear();

            Button b = new Button
            {
                Name = string.Concat(ButtonBaseName),
                Text = "Favorite",
                Tag = CatId,
                Size = ButtonSize,
                Font = ButtonText,
                //Anchor = ButtonAnchor,
                //Dock = ButtonDock,
                //F = ButtonBorder,
                //FlatStyle = ButtonFlat,
                TextImageRelation = ImageAlignButton,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(0, 175, 240),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                //Location = new Point(5, this.Base),
                Location = new Point(0, 0),
                Parent = ParentControl,
                Visible = true
            };

            //b.Image = (item.BlobData != null) ? ByteToImage(item.BlobData) : null;

            b.Click += (object s, EventArgs e) =>
            {
                ClickedHandler(s, new IdentifierButtonEventArgs(Convert.ToInt32(((Button)s).Tag)));
            };

            //var tblCategories = (TableLayoutPanel)ParentControl;                
            //tblCategories.Controls.Add(b,i,0);
            ParentControl.Controls.Add(b);
            //Base += BaseAddition;



        }
        public void CreateCatfromList(IEnumerable<Services.Models.INamedObj> sender)
        {
            //ParentControl.Controls.Clear();
            Buttons = new List<Button>();

            if (sender == null)
                return;

            ButtonCount = sender.Count() - 1;
            int i = 1;
            foreach (var item in sender)
            {

                Button b = new Button
                {
                    Name = string.Concat(ButtonBaseName, item.Id),
                    Text = item.Name,

                    Tag = item.Id,
                    Size = ButtonSize,
                    Font = ButtonText,
                    Anchor = ButtonAnchor,
                    //F = ButtonBorder,
                    FlatStyle = ButtonFlat,
                    TextImageRelation = ImageAlignButton,
                    BackColor = ButtonColor,
                    ForeColor = TextColor,
                    //Location = new Point(5, this.Base),
                    Location = new Point(i * ButtonSize.Width, 0),
                    Parent = ParentControl,
                    Visible = true

                };

                if (b.Name.Contains("btnSubCat") == true)
                {
                    b.AutoSize = true;

                    b.Width = (int)(b.CreateGraphics().MeasureString(b.Text, b.Font).Width + 0.5f);

                    b.Width += 10;

                }

                //b.Image = (item.BlobData != null) ? ByteToImage(item.BlobData) : null;

                b.Click += (object s, EventArgs e) =>
                {
                    ClickedHandler(s, new IdentifierButtonEventArgs(Convert.ToInt32(((Button)s).Tag)));
                };

                //var tblCategories = (TableLayoutPanel)ParentControl;                
                //tblCategories.Controls.Add(b,i,0);
                ParentControl.Controls.Add(b);

                i++;
                Buttons.Add(b);
                //Base += BaseAddition;
            }
        }

        /// <summary>
        /// Create buttons based on Me.ButtonCount
        /// </summary>
        public CreateButtons()
        {

        }


    }

}
