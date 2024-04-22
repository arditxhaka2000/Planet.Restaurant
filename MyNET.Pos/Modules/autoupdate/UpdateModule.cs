using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace MyNET.Shops
{
    public static class UpdateModule
    {
        public static string AppName { get; set; }

        public static void CheckForUpdates()
        {
            string restUrl = ConfigurationManager.AppSettings["RestUrl"];
            Config.RestUrl = restUrl;

            AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            //AppName = "planetpos";

            //http://t3-ks.com/update.api/
            Uri myUri = new Uri(restUrl);
            string hostOrIp = myUri.Host;
            int port = myUri.Port;

            

            if (CheckHostPort(hostOrIp, port))
            {
                if (!IsUptoDate())
                {
                    Application.Run(new UpdateDialog());
                }
            }
        }
        private static bool IsUptoDate()
        {
            //Version appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //string strVer = appVersion.ToString();

            string versionFile = GetVersion();

            string strVer = "1.0.0.0";
            if (System.IO.File.Exists(versionFile))
            {
                strVer = System.IO.File.ReadAllText(versionFile);
            }

            try
            {
                ///Shiko se a i ka aplikacioni update-t e fundit ne server.
                return UpdateService.IsUptoDate(AppName, strVer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nuk munde te kyqeni ne qendren e update-ve! Ju lutem provoni me vone."
                + "\nMesazhi i gabimit:" + ex.Message);

                //nese nuk mundesh te kyqes ateher kthe true. D.m.th. aplikacionu eshte uptodate
                return true;
            }
        }

        public static string GetVersion()
        {
            string path= Application.StartupPath + "\\Version";
            string version = System.IO.File.ReadAllText(path);
            return version;
        }

        private static bool CheckHostPort(string host, int remotePort)
        {
            bool retValue = false;

            bool pingHost = PingHost(host);
            if (pingHost)
            {
                try
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        var client = new TcpClient();
                        //wait 3 seconds
                        if (client.ConnectAsync(host, remotePort).Wait(3000))
                        {
                            retValue = true;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return retValue;
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

    }
}
