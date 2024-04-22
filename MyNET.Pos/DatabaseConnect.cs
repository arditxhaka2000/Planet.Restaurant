using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using MyNET.Pos.Modules;
using System.Windows.Forms;
using Dapper;
namespace MyNET.Pos
{
    public class DatabaseConnect
    {
        public SQLiteConnection conn;
        public SQLiteDataAdapter adapter;
        public DataSet dataSet;
        public SQLiteCommandBuilder sQ;
        public static Services.Settings settings = Services.Settings.Get();


        public DatabaseConnect()
        {
            conn = new SQLiteConnection("Data Source =table.db");
            if (!File.Exists("./table.db"))
            {
                SQLiteConnection.CreateFile("table.db");
            }
        }
        public void SaveTableInfo(string name, int posx, int posy)
        {
            string query = "INSERT INTO RestaurantTables('TableName','PositionX','PositionY') VALUES (@TableName, @PositionX, @PositionY)";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@TableName", name);
            cmd.Parameters.AddWithValue("@PositionX", posx);
            cmd.Parameters.AddWithValue("@PositionY", posy);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void SaveSpaces(string name)
        {
            string query = "INSERT INTO Spaces (SpaceName) VALUES (@SpaceName)";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@SpaceName", name);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void SaveTableName(string name)
        {
            string query = "INSERT INTO RestaurantTables ('TableName') VALUES (@TableName)";
            using (SQLiteConnection con = new SQLiteConnection("Data Source = ./table.db"))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@TableName", name);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public int NumberOfSpaces()
        {
            string query = "SELECT * from Spaces";
            dataSet = new DataSet();
            adapter = new SQLiteDataAdapter(query, conn);
            adapter.Fill(dataSet);
            sQ = new SQLiteCommandBuilder(adapter);
            int count = dataSet.Tables[0].Rows.Count;
            return count;
        }

        public int NumberOfTables()
        {
            string query = "SELECT * from RestaurantTables";
            dataSet = new DataSet();
            adapter = new SQLiteDataAdapter(query, conn);
            adapter.Fill(dataSet);
            sQ = new SQLiteCommandBuilder(adapter);
            int count = dataSet.Tables[0].Rows.Count;
            return count;
        }

        public bool TableExists(string tablename)
        {
            bool flag = false;
            string query = "SELECT EXISTS(SELECT TableName from RestaurantTables WHERE TableName='" + tablename + "')";
            using (SQLiteConnection con = new SQLiteConnection("Data Source = ./table.db"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                object obj = cmd.ExecuteScalar();
                if (Convert.ToInt32(obj) > 0)
                {
                    flag = true;
                }


            }
            return flag;
        }

        public void TableUpdate(string tablename, int posX, int posY)
        {
            string query = "UPDATE RestaurantTables SET PositionX = '" + posX + "', PositionY = '" + posY + "' WHERE TableName = '" + tablename + "'";
            using (SQLiteConnection con = new SQLiteConnection("Data Source = ./table.db"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void TableDelete(string tablename)
        {
            string query = "DELETE FROM RestaurantTables WHERE TableName = '" + tablename + "'";
            using (SQLiteConnection con = new SQLiteConnection($"Data Source = {settings.ServerPath}\\planet.rest\\database\\planet.db"))
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        } 
        public static void UpdateFavItems(List<Services.Item> items)
        {

            //string query = "Update Items set Favorite = 1 where id = '" + id + "'";
            SQLiteConnection con = new SQLiteConnection($"Data Source = {settings.ServerPath}\\planet.rest\\database\\planet.db");
            //{
            //    con.Open();
            //    SQLiteCommand cmd = new SQLiteCommand(query, con);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //}

            string UpdateQuery = @"UPDATE Items SET Favorite = 1 WHERE id = @itemId";
            var update = new SQLiteCommand(UpdateQuery, con);
            update.Parameters.Add("@itemId",DbType.Int32);

            con.Open();
            foreach (var item in items)
            {
                update.Parameters[0].Value = item.Id;
                update.ExecuteNonQuery();
            }
            con.Close();

        }
       

        public List<String> TableNames()
        {
            List<String> stringArr = new List<String>();
            string query = "SELECT * from RestaurantTables";
            using (SQLiteConnection con = new SQLiteConnection("Data Source = ./table.db"))
            {
                con.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(dr);
                            for (int a = 0; a < dt.Rows.Count; a++)
                            {
                                stringArr.Add(dt.Rows[a]["TableName"].ToString());
                            }
                        }
                    }
                }
            }
            return stringArr;
        }

        public List<int> TablePositionX()
        {
            List<int> x = new List<int>();
            string query = "SELECT * from RestaurantTables";
            using (SQLiteConnection con = new SQLiteConnection("Data Source = ./table.db"))
            {
                con.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(dr);
                            for (int a = 0; a < dt.Rows.Count; a++)
                            {
                                x.Add(Convert.ToInt32(dt.Rows[a]["PositionX"]));
                            }
                        }
                    }
                }
            }
            return x;

        }

        public List<int> TablePositionY()
        {
            List<int> y = new List<int>();
            string query = "SELECT * from RestaurantTables";
            using (SQLiteConnection con = new SQLiteConnection("Data Source = ./table.db"))
            {
                con.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        using (DataTable dt = new DataTable())
                        {
                            dt.Load(dr);
                            for (int a = 0; a < dt.Rows.Count; a++)
                            {
                                y.Add(Convert.ToInt32(dt.Rows[a]["PositionY"]));
                            }
                        }
                    }
                }

            }
            return y;
        }
       

        public static void InsertInvoice(DataTable dt)
        {
            string query = "Insert into Invoice ('ItemId','ItemName','Quantity','Discount','TotalWithVat','Vat') values(@ItemId, @ItemName, @Quantity, @Discount, @TotalWithVat, @Vat)";
            using (SQLiteConnection con = new SQLiteConnection($"Data Source = {settings.ServerPath}\\planet.rest\\database\\planet.db"))
            {
                con.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        cmd.Parameters.AddWithValue("@ItemId", row["ItemId"].ToString());
                        cmd.Parameters.AddWithValue("@ItemName", row["ItemName"].ToString());
                        cmd.Parameters.AddWithValue("@Quantity", row["Quantity"].ToString());
                        cmd.Parameters.AddWithValue("@Discount", row["Discount"].ToString());
                        cmd.Parameters.AddWithValue("@TotalWithVat", row["TotalWithVat"].ToString());
                        cmd.Parameters.AddWithValue("@Vat", row["Vat"].ToString());
                        cmd.ExecuteNonQuery();
                    }
                   
                    con.Close();
                }

            }
        }
        public static List<IEnumerable<IGrouping<int, Services.SaleDetails>>> GetUnPrintedInvoice()
        {
            List <Services.SaleDetails> saleDetails = new List<Services.SaleDetails>();
            List<IEnumerable<IGrouping<int, Services.SaleDetails>>> sales = new List<IEnumerable<IGrouping<int, Services.SaleDetails>>>();
            using (SQLiteConnection con = new SQLiteConnection($"Data Source = {settings.ServerPath}\\planet.rest\\database\\planet.db"))
            {
                con.Open();

                saleDetails = con.Query<Services.SaleDetails>("select * from saledetails where Printed = 0").ToList();

                con.Close();
                var grouped = saleDetails.GroupBy(x => new { x.SaleId })
  .Select(g => g.GroupBy(x=> x.SaleId))
  .ToList();
                sales = grouped;
            }

            return sales;
        }
        
        public static int InsertPartner(string name, string cName, string sA, string phone, string comment, string bN, int pT, string fN, string vN, string discount, string address, string city, string country, DateTime date, string createdBy, int status)
        {
            var result=0;
            string query = "insert into Partners(Name,CompanyName,SaveAs,Phone,Comment,BusinessNo,PartnerType,FiscalNo,VatNo,Discount,Address,City,Country,CreatedAt,CreatedBy,Status) Select @Name,@CompanyName,@SaveAs,@Phone,@Comment,@BusinessNo,@PartnerType,@FiscalNo,@VatNo,@Discount,@Address,@City,@Country,@CreatedAt,@CreatedBy,@Status WHERE NOT EXISTS (SELECT 1 FROM Partners WHERE SaveAs = @SaveAs)";
            using (SQLiteConnection con = new SQLiteConnection($"Data Source = {settings.ServerPath}\\planet.rest\\database\\planet.db"))
            {
                con.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name",name);
                    cmd.Parameters.AddWithValue("@CompanyName", cName);
                    cmd.Parameters.AddWithValue("@SaveAs", sA);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Comment", comment);
                    cmd.Parameters.AddWithValue("@BusinessNo", bN);
                    cmd.Parameters.AddWithValue("@PartnerType", pT);
                    cmd.Parameters.AddWithValue("@FiscalNo", fN);
                    cmd.Parameters.AddWithValue("@VatNo", vN);
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@CreatedAt", date);
                    cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                    cmd.Parameters.AddWithValue("@Status", status);

                    result=cmd.ExecuteNonQuery();
                }
                con.Close();

            }

            return result;
        }
    }
   
}  
