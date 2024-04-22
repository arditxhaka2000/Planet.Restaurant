

#region Unit BLL

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.DAL
{

    /// <summary>
    /// This object represents the properties and methods of a Unit.
    /// </summary>
    public class Station : MyNET.Entities.Station
    {
        #region Class members

        
     
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Station()
        {

        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public Station(MyNET.Entities.Station obj)
        {
            mId = obj.Id;
            mName = obj.Name;
            mParentId = obj.ParentId;
            mCreatedAt = obj.CreatedAt;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            mStatus = obj.Status;
        }
           

        public Station(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("Name"))) this.Name = dr.GetString(dr.GetOrdinal("Name"));
                if (!dr.IsDBNull(dr.GetOrdinal("ParentId"))) this.ParentId = dr.GetInt32(dr.GetOrdinal("ParentId"));
            }
        }

        #endregion

        #region public static Get Methods

        public static Station Get(int id)
        {
            string strquery = "SELECT * FROM Stations WHERE Id = @Id";
            ///Conection to database
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.AddWithValue("@Id", id);

            Station retobj = null;
            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                retobj = new Station(dr);
            }

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();
            dr.Dispose();
            return retobj;
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        /// 

        public static List<Station> Get()
        {
            string strquery = "SELECT * FROM Stations";
            ///Conection to database
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            
            List<Station> retobjs = new List<Station>();

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var retobj = new Station(dr);    
                retobjs.Add(retobj);
            }

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();

            dr.Dispose();

            if (retobjs.Count == 0)
                return null;
            else
                return retobjs;
        }

        public static List<Station> GetByType(string type)
        {
            string strquery = "SELECT * FROM Stations where Type = @Type";
            ///Conection to database
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.AddWithValue("@Type", type);
            List<Station> retobjs = new List<Station>();

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var retobj = new Station(dr);
                retobjs.Add(retobj);
            }

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();

            dr.Dispose();

            if (retobjs.Count == 0)
                return null;
            else
                return retobjs;
        }
        #endregion
    }
}
#endregion

