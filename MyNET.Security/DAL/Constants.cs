using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;


namespace MyNET.Security
{
    public class Constants
    {
        protected static string mDatabase;
        protected static string mServer;


        public static string Database
        {
            get { return mDatabase; }
            set { mDatabase = value; }
        }

        public static string Server
        {
            get { return mServer; }
            set { mServer = value; }
        }

        public Constants()
        {
            //
            // TODO: AddWithValue Constructor Logic here
            //
        }

        public static string Connectionstr()
        {
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            strcon = strcon.Replace("dbname", mDatabase);
            strcon = strcon.Replace("server", mServer);
            return strcon;

            //string strcnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //return strcnnString;
            //string cnnstr = @"server=DELL\SQLExpress;database=ppcit;user=sa;pwd=sonata";
            //return cnnstr;
        }

        public static void TestConnection()
        {
            SqlConnection cnn = new SqlConnection(Connectionstr());
            cnn.Open();
        }

       
    }
}
