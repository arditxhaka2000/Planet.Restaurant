using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET
{
    public class Config
    {
        public static string RestUrl { get; set; }

        //public static string Database { get; set; }

        //public static string  Connectionstr()
        //{
        //    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //    strcon = strcon.Replace("dbname", Database);
        //    return strcon;
        //}

    }
}
