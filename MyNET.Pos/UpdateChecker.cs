﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNET.Pos
{
    public class UpdateChecker
    {
        public static bool CheckForUpdates()
        {
            string url = "http://devplanetaccounting.com/pos/pos_download";
            string updateZipFileName = "Planet.POS.exe";

            WebClient client = new WebClient();
            string pageContent = client.DownloadString(url);

            if (pageContent.Contains(updateZipFileName))
            {
                Console.WriteLine("Update found!");

                return true;
            }
            else
            {
                Console.WriteLine("No update found.");
                return false;
            }
        }

        public static void ExtractZip()
        {

            string url = "https://localhost:7234/";
            string downloadDirectory = null;

            using (WebClient client = new WebClient())
            {
                string html = client.DownloadString(url);

                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);

                foreach (HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]"))
                {
                    string href = link.GetAttributeValue("href", string.Empty);

                    if (href.EndsWith("Planet.POS.exe"))
                    {
                        downloadDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string fileName = href.Split('/').Last();
                        string fileUrl = url + "/zip/" + fileName;
                        string downloadPath = downloadDirectory + "\\" + fileName;

                        client.DownloadFile(fileUrl, downloadPath);
                        var m = MessageBox.Show("Versioni i fundit eshte downloaduar me sukses! A deshironi ta instaloni tani?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (m == DialogResult.Yes)
                        {
                            OpenSetup(downloadPath);

                        }
                        return;
                    }
                }

                Console.WriteLine("File not found.");
            }

        }

        public static void OpenSetup(string extractpath)
        {
            string rarPath = extractpath;
            string extractPath = extractpath;
            string arguments = $"e {rarPath} {extractPath}";

            Process process = new Process();
            process.StartInfo.FileName = rarPath;
            process.StartInfo.Arguments = arguments;
            process.Start();
            process.WaitForExit();

        }

    }
}
