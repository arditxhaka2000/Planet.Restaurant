using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Services
{
    public static class NetworkService
    {
        public static bool PingHost(string hostNameOrIpAddress)
        {
            if (string.IsNullOrEmpty(hostNameOrIpAddress))
            {
                throw new Exception("Error: empty host name or Ip address");                
            }

            bool pingable = false;
            Ping pinger = null;
            string ipOrHost = hostNameOrIpAddress.Replace("http://", "").Replace("https://", "");

            //remove port part
            string[] parts = ipOrHost.Split(new char[] { ':' });
            if (parts.Length > 0)
            {
                ipOrHost = parts[0];
            }
            else
            {
                throw new Exception("Invalid host name or Ip address!");
            }

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(ipOrHost);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                // Discard PingExceptions and return false;
                throw ex;                
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


        public static bool CheckHostPort(string host, int remotePort)
        {
            bool retValue = false;

            try
            {
                IPAddress[] addresses = Dns.GetHostAddresses(host);

                foreach (IPAddress address in addresses)
                {
                    try
                    {
                        using (TcpClient tcpClient = new TcpClient())
                        {
                            if (tcpClient.ConnectAsync(address, remotePort).Wait(3000))
                            {
                                retValue = true;
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception, if needed
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, if needed
            }

            return retValue;
        }



    }
}
