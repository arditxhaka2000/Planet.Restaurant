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
