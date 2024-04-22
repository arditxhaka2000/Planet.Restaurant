using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using MyNET;
using System.Configuration;

namespace ServerManifest
{
    public partial class Main : Form
    {
        #region webservises members
        /// <summary>
        /// Instanc  e servisit Faturimi
        /// </summary>

        //private static BKUpdates.Service BKService;

        /// <summary>
        /// Objekti per authentikim ne Servisin e faturimit
        /// </summary>
        //private static BKUpdates.Credentials BKCredentials = new BKUpdates.Credentials();

        #endregion

        public Main()
        {
            InitializeComponent();           
        }

        private List<string> CreateList(string strPath)
        {
            DirectoryInfo ofs = new DirectoryInfo(strPath + "\\");
            List<string> listoflises = new List<string>();

            listoflises = FilesinDirectory("",ofs, listoflises);

            return listoflises;
        }

        private List<string> FilesinDirectory(string parentfolder,DirectoryInfo directory,List<string> listofiles)
        {
            //futi fajllat e ketije folderi
            foreach (FileInfo oFile in directory.GetFiles())
            {
                lblStatus.Text = "Reading file " + oFile.Name;
                Application.DoEvents();

                if (!oFile.Name.EndsWith(".pdb") && !oFile.Name.EndsWith(".config") && (oFile.Name != "AutoUpdate.exe"))
                {
                    listofiles.Add(parentfolder + "/"+ oFile.Name);
                }
            }

            foreach (DirectoryInfo subdirectory in directory.GetDirectories())
                listofiles = FilesinDirectory(parentfolder + "/" + subdirectory.Name, subdirectory, listofiles);
            return listofiles;
        }

        /// <summary>
        /// E shton nje element ne funde te listes
        /// </summary>
        /// <param name="item"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        //private List<string> AddItemToList(string item, List<string> list)
        //{
        //    List<string> retlist = new List<string>();
        //    ///Shiko se pari mos lista e ka gjatesin 0
        //    // nese po ateher kthe false
        //    if (list.Length == 0)
        //    {
        //        retlist[0] = item;
        //    }
        //    else
        //    {
        //        retlist = new string[list.Length + 1];
        //        list.CopyTo(retlist, 0);
        //        retlist[list.Length] = item;
        //    }
        //    return retlist;
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            Config.RestUrl = ConfigurationManager.AppSettings["RestUrl"];
            txtAppName.Text = ConfigurationManager.AppSettings["AppName"];
            txtVersion.Text = UpdateService.GetLastVerion(txtAppName.Text);
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = FolderBrowserDialog1.SelectedPath;
                lblStatus.Text = "";
            }
        }

        private void btnCreateList_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                MessageBox.Show("Ju lutem zgjidhni folderin per upload");
                return;
            }
            
            ///Create listen of files to upload
            List<string> list = CreateList(txtPath.Text);
            lb.DataSource = list;
        }

        private void InitProgress(long lMax)
        {
            pb.Value = 0;
            pb.Maximum = (int)lMax;
        }

        private void IncrementProgress()
        {
            {
                if (pb.Value < pb.Maximum)
                    pb.Value = pb.Value + 1;
                Application.DoEvents();
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {           
            pb.Visible = true;
            if (txtPath.Text == "")
            {
                MessageBox.Show("Ju lutem zgjidhni fajllat");
                return;
            }

            if (txtNewVersion.Text == "")
            {
                MessageBox.Show("Ju lutem sheno versioni  e ri");
                return;
            }

            try
            {
                ///get folder name where updates are stored
                string UpdateDirectoryName = Path.GetFileName(txtPath.Text);

                ///Create listen of files to upload
                List<string> list = CreateList(txtPath.Text);

                InitProgress(list.Count);

                string strlist = string.Empty; //list o files converted to string
                int count = 0;
                //Uplodo files to server
                foreach (string fileinlist in list)
                {
                    lblStatus.Text = "Uploding file " + fileinlist;
                    string path = txtPath.Text + fileinlist;
                    FileStream stream = new FileStream(path, FileMode.Open);

                    byte[] filestream = new byte[Convert.ToInt32(stream.Length)];

                    stream.Read(filestream, 0, filestream.Length); 

                    UpdateService.UploadFileParts(filestream, txtAppName.Text, txtNewVersion.Text, fileinlist);
                    strlist += fileinlist;
                    count++;
                    if (count < list.Count)
                        strlist += "|";
                    lblStatus.Text = "....";
                    IncrementProgress();
                    stream.Close();

                }

                MyNET.Models.Update update = new MyNET.Models.Update()
                { id = 0, applicationName = txtAppName.Text, version = txtNewVersion.Text, description = txtDescription.Text, createdBy = "admin" };

                //Ad recorde of update to udates table
                UpdateService.AddUpdate(update);
                lblStatus.Text = "Lista e updateve eshte ruajtur ne server!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}