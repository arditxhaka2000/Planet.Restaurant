using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Connection
    {
        //public static string RestUrl { get; set; } = "http://localhost:1337/api";

        public static string Host { get; set; }
        public static int Port { get; set; }

        public static void SetLocalServerProperties(string host, int port)
        {
            Host = host;
            Port = port;
        }
        public static void SetLocalServerIp(string ipWithPort)
        {
            string[] parts = ipWithPort.Split(':');

            if (parts.Length == 2)
            {
                string host = parts[0];
                int port = int.Parse(parts[1]);

                Host = host;
                Port = port;

            }
            else
            {
                Console.WriteLine("Invalid IP format. It should be in the format: IP:Port");
            }
        }
        public static string GetActiveConnection()
        {
            string serverUrl = "http://" + Host + ":" + Port + "/api";
            return serverUrl;
        }
        public static string GetConnection()
        {
            string serverUrl = "http://" + Host + ":" + "1378";
            return serverUrl;
        }

    }
}
