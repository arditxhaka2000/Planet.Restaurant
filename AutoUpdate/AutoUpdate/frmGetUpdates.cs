using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using MyNET;
using MyNET.Models;
using System.IO.Compression;

namespace AutoUpdate
{
    public partial class frmGetUpdates : Form
    {
        // Aplication version to update
        public string ClientAppVersion { get; set; }

        //public string ExeFile { get; set; }

        public string AppName { get; set; }

        public frmGetUpdates()
        {
            InitializeComponent();
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                startTimer.Enabled = false;
                Program.KillAppExe();

                Label1.Text = "Checking for application update, please wait!...";

                //update client application
                ProcessClientUpdate(ClientAppVersion);
                
                ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\" + AppName + ".exe");
                Process.Start(startInfo);

                this.Close();               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ka ndodhe nje gabim! Mesazhi i gabimit: " + ex.Message);
                this.Close();
            }
        }
        
        private void InitProgress(long lMax)
        {
            this.pb.Value = 0;
            this.pb.Maximum = (int)lMax;
            Application.DoEvents();
        }

        private  void IncrementProgress()
        {
            {
                if (this.pb.Value < this.pb.Maximum)
                    this.pb.Value = this.pb.Value + 1;
                Application.DoEvents();
            }
        }


        /// <summary>
        /// Metoda qe i bene BK client-in update
        /// </summary>       
        private UpdateDetails mUpdates = new UpdateDetails();
        
        public void DownloadUpdateFiles(string verion)
        {
            try
            {
                Label2.Text = "Stat downloading list of files to be updated ...";

                mUpdates = UpdateService.GetListOfFilesToUpdate(AppName, verion);
                
                if (mUpdates.listoffiles.Count == 0)
                {
                    MessageBox.Show("List of files is empty");
                    return;
                }

                //Init progressbar 
                InitProgress(mUpdates.listoffiles.Count);

                //Loop for each file
                foreach (FilesDetails listItem in mUpdates.listoffiles)
                {
                    //Dowload file from server
                    //Path of file in server
                    string downloadUrl = listItem.baseFolder + listItem.fileWithoutBaseFolder;
                    byte[] dowloadedarray = UpdateService.DownLoadFile(downloadUrl);
                    string upateFolder = Path.GetFileName(listItem.baseFolder);
                    string localFilePath = Application.StartupPath + "\\updates\\" + upateFolder + listItem.fileWithoutBaseFolder;

                    string localFolder = Path.GetDirectoryName(localFilePath);

                    if (!Directory.Exists(localFolder))
                        Directory.CreateDirectory(localFolder);

                    FileStream localpfile = new FileStream(localFilePath, FileMode.Create);

                    //write array to file
                    localpfile.Write(dowloadedarray, 0, dowloadedarray.Length);
                    localpfile.Close();

                    IncrementProgress();
                }

                Label2.Text = "Download is done ... ";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ProcessClientUpdate(string version)
        {
            DownloadUpdateFiles(version);

            try
            {
                Label2.Text = "Installing updates ...";
                //Init progressbar 
                InitProgress(0);

                //Loop for each file
                foreach (FilesDetails listItem in mUpdates.listoffiles)
                {
                    //Get the fileName Element Value
                    string fileName = Path.GetFileName(listItem.fileWithoutBaseFolder);
                    string upateFolder = Path.GetFileName(listItem.baseFolder);
                    string localFileName = Application.StartupPath + listItem.fileWithoutBaseFolder;

                    Label2.Text = "Update file " + fileName + " ...";

                    string updateFile = Application.StartupPath + "\\updates\\" + upateFolder + listItem.fileWithoutBaseFolder;

                    string directory = Path.GetDirectoryName(localFileName);
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);

                    string extension = Path.GetExtension(updateFile);
                    if (extension == ".zip")
                    {
                        string tempFolder = Application.StartupPath + "\\temp\\";
                        if (Directory.Exists(tempFolder))
                            Directory.Delete(tempFolder,true);

                        Directory.CreateDirectory(tempFolder);

                        ZipFile.ExtractToDirectory(updateFile,tempFolder);

                        var files = Directory.EnumerateFiles(tempFolder);

                        //now compy to app folder
                        foreach(string file in files)
                        {
                            string fileName2 = Path.GetFileName(file);
                            string fileToCopy = Application.StartupPath + "\\" + fileName2;
                            File.Copy(file, fileToCopy, true);
                        }

                    }
                    else
                    {
                        File.Copy(updateFile, localFileName, true);
                    }

                    IncrementProgress();
                }

                Label1.Text = "Application update completed!";

                string newVerion = mUpdates.update.GetVerion();

                //write last update version
                System.IO.File.WriteAllText(Application.StartupPath + "\\Version", newVerion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}