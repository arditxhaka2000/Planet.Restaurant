using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyNET.DAL
{
    public class ClientDatabases 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastSyncDate { get; set; }

        public static List<ClientDatabases> Get()
        {
            string strquery = "SELECT Id,Name FROM Databases ORDER BY Name";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr2());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            SqlDataReader dr = null;
            ClientDatabases retobj;
            List<ClientDatabases> retobjs = new List<ClientDatabases>();
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    retobj = new ClientDatabases();
                    retobj.Id = dr.GetInt32(0);
                    retobj.Name = dr.GetString(1);
                    //if (!dr.IsDBNull(dr.GetOrdinal("LastSyncDate"))) retobj.LastSyncDate = dr.GetDateTime(dr.GetOrdinal("LastSyncDate"));
                    retobjs.Add(retobj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
                dr.Dispose();
            }
            if (retobjs.Count == 0)
                return null;
            else
                return retobjs;
        }

        public static ClientDatabases Get(string name)
        {
            string strquery = "select Id,Name,LastSyncDate from Databases where @name";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr2());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.AddWithValue("@name", name);

            SqlDataReader dr = null;
            ClientDatabases retobj = null;
            
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    retobj = new ClientDatabases();
                    retobj.Id = dr.GetInt32(0);
                    retobj.Name = dr.GetString(1);
                    if (!dr.IsDBNull(dr.GetOrdinal("LastSyncDate"))) retobj.LastSyncDate = dr.GetDateTime(dr.GetOrdinal("LastSyncDate"));                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
                dr.Dispose();
            }            
            return retobj;
        }

        public static int Insert(string name)
        {
            string strquery = "INSERT INTO ClientDatabases(Name) Values (@Name) ";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            
            cmd.Parameters.Add("@Name", SqlDbType.VarChar,50).Value = name;
            int rowaff = 0;

            try
            {

                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                rowaff = cmd.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
            }
            return rowaff;
        }

        public static int Update(string name, DateTime lastSyncDate)
        {
            string strquery = "UPDATE ClientDatabases SET LastSyncDate = @LastSyncDate ";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);

            cmd.Parameters.Add("@LastSyncDate", SqlDbType.DateTime).Value = lastSyncDate;
            int rowaff = 0;

            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                rowaff = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                    cnn.Close();
            }
            return rowaff;
        }
    }
}
