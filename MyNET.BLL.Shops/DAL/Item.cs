using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MyNET.Models;
using System.Collections.Generic;

namespace MyNET.DAL
{

    /// <summary>
    /// This object represents the properties and methods of a Item.
    /// </summary>
    public class Item: MyNET.Entities.Item
    {
        #region Class members

        ///Conection to database
        protected SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
        ///Staric member connection
        protected static SqlConnection statcnn = new SqlConnection(Constants.Connectionstr());


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Item()
        {

        }

        /// <summary>
        /// Contructor by entity object
        /// </summary>
        public Item(MyNET.Entities.Item obj)
        {
            mId = obj.Id;
            mProductNo = obj.ProductNo;
            mBarcode = obj.Barcode;
            mCategoryId = obj.CategoryId;
            mUnit = obj.Unit;
            mProducerId = obj.ProducerId;
            mItemName = obj.ItemName;
            mDescription = obj.Description;
            mPurchasePrice = obj.PurchasePrice;
            mRetailPrice = obj.RetailPrice;
            mDuty = obj.Duty;
            mVat = obj.Vat;
            mAkciza = obj.Akciza;
            mItemGoods = obj.ItemGoods;
            mService = obj.Service;
            mExpense = obj.Expense;
            mInventoryItem = obj.InventoryItem;
            mMaterial = obj.Material;
            mProduction = obj.Production;
            mAssembled = obj.Assembled;
            mExpired = obj.Expired;
            mAccountA = obj.AccountA;
            mAccountB = obj.AccountB;
            mAccountC = obj.AccountC;
            mAmountPaid = obj.AmountPaid;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            mStatus = obj.Status;
            //mImage = obj.Image;

            mImageId = obj.ImageId;
            mItemId = obj.ItemId;
            mName = obj.Name;
            mBlobData = obj.BlobData;

        }

        private Item(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("ProductNo"))) this.ProductNo = dr.GetString(dr.GetOrdinal("ProductNo"));
                if (!dr.IsDBNull(dr.GetOrdinal("Barcode"))) this.Barcode = dr.GetString(dr.GetOrdinal("Barcode"));
                if (!dr.IsDBNull(dr.GetOrdinal("Unit"))) this.Unit = dr.GetString(dr.GetOrdinal("Unit"));
                if (!dr.IsDBNull(dr.GetOrdinal("CategoryId"))) this.CategoryId = dr.GetInt32(dr.GetOrdinal("CategoryId"));
                if (!dr.IsDBNull(dr.GetOrdinal("ProducerId"))) this.ProducerId = dr.GetInt32(dr.GetOrdinal("ProducerId"));
                if (!dr.IsDBNull(dr.GetOrdinal("ItemName"))) this.ItemName = dr.GetString(dr.GetOrdinal("ItemName"));
                if (!dr.IsDBNull(dr.GetOrdinal("Description"))) this.Description = dr.GetString(dr.GetOrdinal("Description"));
                if (!dr.IsDBNull(dr.GetOrdinal("RetailPrice"))) this.RetailPrice = dr.GetDecimal(dr.GetOrdinal("RetailPrice"));
                if (!dr.IsDBNull(dr.GetOrdinal("Duty"))) this.Duty = dr.GetInt32(dr.GetOrdinal("Duty"));
                if (!dr.IsDBNull(dr.GetOrdinal("Vat"))) this.Vat = dr.GetInt32(dr.GetOrdinal("Vat"));
                if (!dr.IsDBNull(dr.GetOrdinal("Akciza"))) this.Akciza = dr.GetDecimal(dr.GetOrdinal("Akciza"));
                if (!dr.IsDBNull(dr.GetOrdinal("ItemGoods"))) this.ItemGoods = dr.GetBoolean(dr.GetOrdinal("ItemGoods"));
                if (!dr.IsDBNull(dr.GetOrdinal("Service"))) this.Service = dr.GetBoolean(dr.GetOrdinal("Service"));
                if (!dr.IsDBNull(dr.GetOrdinal("Expense"))) this.Expense = dr.GetBoolean(dr.GetOrdinal("Expense"));
                if (!dr.IsDBNull(dr.GetOrdinal("InventoryItem"))) this.InventoryItem = dr.GetBoolean(dr.GetOrdinal("InventoryItem"));
                if (!dr.IsDBNull(dr.GetOrdinal("Material"))) this.Material = dr.GetBoolean(dr.GetOrdinal("Material"));
                if (!dr.IsDBNull(dr.GetOrdinal("Production"))) this.Production = dr.GetBoolean(dr.GetOrdinal("Production"));
                if (!dr.IsDBNull(dr.GetOrdinal("Assembled"))) this.Assembled = dr.GetBoolean(dr.GetOrdinal("Assembled"));
                if (!dr.IsDBNull(dr.GetOrdinal("Expired"))) this.Expired = dr.GetBoolean(dr.GetOrdinal("Expired"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountA"))) this.AccountA = dr.GetInt32(dr.GetOrdinal("AccountA"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountB"))) this.AccountB = dr.GetInt32(dr.GetOrdinal("AccountB"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountC"))) this.AccountC = dr.GetInt32(dr.GetOrdinal("AccountC"));
                if (!dr.IsDBNull(dr.GetOrdinal("AmountPaid"))) this.AmountPaid = dr.GetDateTime(dr.GetOrdinal("AmountPaid"));
                if (!dr.IsDBNull(dr.GetOrdinal("CreatedBy"))) this.CreatedBy = dr.GetString(dr.GetOrdinal("CreatedBy"));
                if (!dr.IsDBNull(dr.GetOrdinal("ChangedAt"))) this.ChangedAt = dr.GetDateTime(dr.GetOrdinal("ChangedAt"));
                if (!dr.IsDBNull(dr.GetOrdinal("ChangedBy"))) this.ChangedBy = dr.GetString(dr.GetOrdinal("ChangedBy"));
                if (!dr.IsDBNull(dr.GetOrdinal("Status"))) this.Status = dr.GetInt32(dr.GetOrdinal("Status"));
                if (!dr.IsDBNull(dr.GetOrdinal("Discount"))) this.Discount = dr.GetDecimal(dr.GetOrdinal("Discount"));
                //if (!dr.IsDBNull(dr.GetOrdinal("InStock"))) this.InStock = dr.GetDecimal(dr.GetOrdinal("InStock"));
            }
           
        }

        /// <summary>
        /// Contructor by primarykey
        /// </summary>
        public Item(int Id)
        {
            string strquery = "GetItem";

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                LoadFromReader(dr);

            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();

            dr.Dispose();
        }

        /// <summary>
        /// Load object from reader 
        /// </summary>
        /// <param name="dr">DataReader object</param>		
        private void LoadFromReader(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("ProductNo"))) this.ProductNo = dr.GetString(dr.GetOrdinal("ProductNo"));
                if (!dr.IsDBNull(dr.GetOrdinal("Barcode"))) this.Barcode = dr.GetString(dr.GetOrdinal("Barcode"));
                if (!dr.IsDBNull(dr.GetOrdinal("Unit"))) this.Unit = dr.GetString(dr.GetOrdinal("Unit"));
                if (!dr.IsDBNull(dr.GetOrdinal("CategoryId"))) this.CategoryId = dr.GetInt32(dr.GetOrdinal("CategoryId"));
                if (!dr.IsDBNull(dr.GetOrdinal("ProducerId"))) this.ProducerId = dr.GetInt32(dr.GetOrdinal("ProducerId"));
                if (!dr.IsDBNull(dr.GetOrdinal("ItemName"))) this.ItemName = dr.GetString(dr.GetOrdinal("ItemName"));
                if (!dr.IsDBNull(dr.GetOrdinal("Description"))) this.Description = dr.GetString(dr.GetOrdinal("Description"));
                if (!dr.IsDBNull(dr.GetOrdinal("RetailPrice"))) this.RetailPrice = dr.GetDecimal(dr.GetOrdinal("RetailPrice"));
                if (!dr.IsDBNull(dr.GetOrdinal("Duty"))) this.Duty = dr.GetInt32(dr.GetOrdinal("Duty"));
                if (!dr.IsDBNull(dr.GetOrdinal("Vat"))) this.Vat = dr.GetInt32(dr.GetOrdinal("Vat"));
                if (!dr.IsDBNull(dr.GetOrdinal("Akciza"))) this.Akciza = dr.GetDecimal(dr.GetOrdinal("Akciza"));
                if (!dr.IsDBNull(dr.GetOrdinal("ItemGoods"))) this.ItemGoods = dr.GetBoolean(dr.GetOrdinal("ItemGoods"));
                if (!dr.IsDBNull(dr.GetOrdinal("Service"))) this.Service = dr.GetBoolean(dr.GetOrdinal("Service"));
                if (!dr.IsDBNull(dr.GetOrdinal("Expense"))) this.Expense = dr.GetBoolean(dr.GetOrdinal("Expense"));
                if (!dr.IsDBNull(dr.GetOrdinal("InventoryItem"))) this.InventoryItem = dr.GetBoolean(dr.GetOrdinal("InventoryItem"));
                if (!dr.IsDBNull(dr.GetOrdinal("Material"))) this.Material = dr.GetBoolean(dr.GetOrdinal("Material"));
                if (!dr.IsDBNull(dr.GetOrdinal("Production"))) this.Production = dr.GetBoolean(dr.GetOrdinal("Production"));
                if (!dr.IsDBNull(dr.GetOrdinal("Assembled"))) this.Assembled = dr.GetBoolean(dr.GetOrdinal("Assembled"));
                if (!dr.IsDBNull(dr.GetOrdinal("Expired"))) this.Expired = dr.GetBoolean(dr.GetOrdinal("Expired"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountA"))) this.AccountA = dr.GetInt32(dr.GetOrdinal("AccountA"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountB"))) this.AccountB = dr.GetInt32(dr.GetOrdinal("AccountB"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountC"))) this.AccountC = dr.GetInt32(dr.GetOrdinal("AccountC"));
                //if (!dr.IsDBNull(dr.GetOrdinal("AmountPaid"))) this.AmountPaid = dr.GetDateTime(dr.GetOrdinal("AmountPaid"));
                if (!dr.IsDBNull(dr.GetOrdinal("CreatedBy"))) this.CreatedBy = dr.GetString(dr.GetOrdinal("CreatedBy"));
                if (!dr.IsDBNull(dr.GetOrdinal("ChangedAt"))) this.ChangedAt = dr.GetDateTime(dr.GetOrdinal("ChangedAt"));
                if (!dr.IsDBNull(dr.GetOrdinal("ChangedBy"))) this.ChangedBy = dr.GetString(dr.GetOrdinal("ChangedBy"));
                if (!dr.IsDBNull(dr.GetOrdinal("Status"))) this.Status = dr.GetInt32(dr.GetOrdinal("Status"));
                //if (!dr.IsDBNull(dr.GetOrdinal("ImageId"))) this.ImageId = dr.GetInt32(dr.GetOrdinal("ImageId"));
                //if (!dr.IsDBNull(18)) this.Image = (byte[])dr[18];

            }
        }

        /// <summary>
        /// Load from reader. Static method
        /// </summary>
        /// <param name="dr">DataReader object</param>
        /// <returns>Return object</returns>
        private static MyNET.Entities.Item LoadObjectFromReader(SqlDataReader dr)
        {
            MyNET.Entities.Item retobj = new MyNET.Entities.Item();
            if (dr != null && !dr.IsClosed)
            {
                retobj.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("ProductNo"))) retobj.ProductNo = dr.GetString(dr.GetOrdinal("ProductNo"));
                if (!dr.IsDBNull(dr.GetOrdinal("Barcode"))) retobj.Barcode = dr.GetString(dr.GetOrdinal("Barcode"));
                if (!dr.IsDBNull(dr.GetOrdinal("Unit"))) retobj.Unit = dr.GetString(dr.GetOrdinal("Unit"));
                if (!dr.IsDBNull(dr.GetOrdinal("CategoryId"))) retobj.CategoryId = dr.GetInt32(dr.GetOrdinal("CategoryId"));
                if (!dr.IsDBNull(dr.GetOrdinal("ProducerId"))) retobj.ProducerId = dr.GetInt32(dr.GetOrdinal("ProducerId"));
                if (!dr.IsDBNull(dr.GetOrdinal("ItemName"))) retobj.ItemName = dr.GetString(dr.GetOrdinal("ItemName"));
                if (!dr.IsDBNull(dr.GetOrdinal("Description"))) retobj.Description = dr.GetString(dr.GetOrdinal("Description"));
                if (!dr.IsDBNull(dr.GetOrdinal("RetailPrice"))) retobj.RetailPrice = dr.GetDecimal(dr.GetOrdinal("RetailPrice"));
                if (!dr.IsDBNull(dr.GetOrdinal("Duty"))) retobj.Duty = dr.GetInt32(dr.GetOrdinal("Duty"));
                if (!dr.IsDBNull(dr.GetOrdinal("Vat"))) retobj.Vat = dr.GetInt32(dr.GetOrdinal("Vat"));
                if (!dr.IsDBNull(dr.GetOrdinal("Akciza"))) retobj.Akciza = dr.GetDecimal(dr.GetOrdinal("Akciza"));
                if (!dr.IsDBNull(dr.GetOrdinal("ItemGoods"))) retobj.ItemGoods = dr.GetBoolean(dr.GetOrdinal("ItemGoods"));
                if (!dr.IsDBNull(dr.GetOrdinal("Service"))) retobj.Service = dr.GetBoolean(dr.GetOrdinal("Service"));
                if (!dr.IsDBNull(dr.GetOrdinal("Expense"))) retobj.Expense = dr.GetBoolean(dr.GetOrdinal("Expense"));
                if (!dr.IsDBNull(dr.GetOrdinal("InventoryItem"))) retobj.InventoryItem = dr.GetBoolean(dr.GetOrdinal("InventoryItem"));
                if (!dr.IsDBNull(dr.GetOrdinal("Material"))) retobj.Material = dr.GetBoolean(dr.GetOrdinal("Material"));
                if (!dr.IsDBNull(dr.GetOrdinal("Production"))) retobj.Production = dr.GetBoolean(dr.GetOrdinal("Production"));
                if (!dr.IsDBNull(dr.GetOrdinal("Assembled"))) retobj.Assembled = dr.GetBoolean(dr.GetOrdinal("Assembled"));
                if (!dr.IsDBNull(dr.GetOrdinal("Expired"))) retobj.Expired = dr.GetBoolean(dr.GetOrdinal("Expired"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountA"))) retobj.AccountA = dr.GetInt32(dr.GetOrdinal("AccountA"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountB"))) retobj.AccountB = dr.GetInt32(dr.GetOrdinal("AccountB"));
                if (!dr.IsDBNull(dr.GetOrdinal("AccountC"))) retobj.AccountC = dr.GetInt32(dr.GetOrdinal("AccountC"));
                if (!dr.IsDBNull(dr.GetOrdinal("AmountPaid"))) retobj.AmountPaid = dr.GetDateTime(dr.GetOrdinal("AmountPaid"));
                if (!dr.IsDBNull(dr.GetOrdinal("CreatedBy"))) retobj.CreatedBy = dr.GetString(dr.GetOrdinal("CreatedBy"));
                if (!dr.IsDBNull(dr.GetOrdinal("ChangedAt"))) retobj.ChangedAt = dr.GetDateTime(dr.GetOrdinal("ChangedAt"));
                if (!dr.IsDBNull(dr.GetOrdinal("ChangedBy"))) retobj.ChangedBy = dr.GetString(dr.GetOrdinal("ChangedBy"));
                if (!dr.IsDBNull(dr.GetOrdinal("Status"))) retobj.Status = dr.GetInt32(dr.GetOrdinal("Status"));
                return retobj;
            }
            else return retobj;
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static MyNET.Entities.Item Get(int Id)
        {
            return new Item(Id);
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>

        public static ArrayList Get()
        {
            string strquery = "GetItems";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            MyNET.Entities.Item retobj;

            ArrayList retobjs = new ArrayList();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                retobj = new Item();
                retobj = LoadObjectFromReader(dr);

                retobjs.Add(retobj);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

            if (retobjs.Count == 0)
                return null;
            else
                return retobjs;
        }

        public static ArrayList GetItemsGoods()
        {
            string strquery = "SELECT * from Items where Expense != 1 ";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            MyNET.Entities.Item retobj;

            ArrayList retobjs = new ArrayList();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                retobj = new Item();
                retobj = LoadObjectFromReader(dr);

                retobjs.Add(retobj);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

            if (retobjs.Count == 0)
                return null;
            else
                return retobjs;
        }

        public static List<Item> GetItemWithBlob()
        {
            string strquery = "GetItemsBlob";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;


            List<Item> retobjs = new List<Item>();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                Item retobj = new Item(dr);

                var itemblob = ItemsBlobs.Get(retobj.Id);
                retobj.BlobData = itemblob.BlobData;
                retobjs.Add(retobj);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

            return retobjs;
        }

        public static List<ItemsDiscount> GetItemsDiscount(int partnerid,DateTime date, int warehouse, bool lackitems)
        {
            string strquery = "GetItemsDiscount";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = partnerid;
            cmd.Parameters.Add("@DateIn", SqlDbType.DateTime).Value = date;
            cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouse;
            cmd.Parameters.Add("@LackItems", SqlDbType.Int).Value = lackitems;
            cmd.CommandType = CommandType.StoredProcedure;


            List<ItemsDiscount> retobjs = new List<ItemsDiscount>();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            { 
                ItemsDiscount idis = new ItemsDiscount();
                //Item retobj = new Item(dr);
                idis.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                //idis.No = dr.GetInt32(dr.GetOrdinal("No"));
                idis.Barcode = dr.GetString(dr.GetOrdinal("Barcode"));
                idis.ItemName = dr.GetString(dr.GetOrdinal("ItemName"));
                idis.Unit = dr.GetString(dr.GetOrdinal("Unit"));
                idis.Quantity = dr.GetDecimal(dr.GetOrdinal("Quantity"));
                idis.SalePrice = dr.GetDecimal(dr.GetOrdinal("SalePrice"));
                idis.PriceWithVat = dr.GetDecimal(dr.GetOrdinal("PriceWithVat"));
                idis.Discount = dr.GetDecimal(dr.GetOrdinal("Discount"));
                idis.Vat = dr.GetInt32(dr.GetOrdinal("Vat"));
                //idis.CategoryId = dr.GetInt32(dr.GetOrdinal("CategoryId"));
                //idis.Status = dr.GetByte(dr.GetOrdinal("Status"));
                //var discount = DiscountItemsDetails.Get(idis.Id); 
                //idis.Discount = discount.Discount;

                var itemblob = ItemsBlobs.Get(idis.Id);
                idis.BlobData = itemblob.BlobData;

                //retobj.BlobData = itemblob.BlobData;
                retobjs.Add(idis);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

            return retobjs;
        }

        public static DataTable GetDiscountItems(int partnerid,DateTime date, int warehouse, bool lackitems)
        {
            string strquery = "GetItemsDiscount";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = partnerid;
            cmd.Parameters.Add("@DateIn", SqlDbType.DateTime).Value = date;
            cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouse;
            cmd.Parameters.Add("@LackItems", SqlDbType.Bit).Value = lackitems;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static DataTable GetDiscountItems1()
        {
            string strquery = "GetItemsDiscount1";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static List<Item> GetTables()
        {
            string strquery = "GetTables";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;


            List<Item> retobjs = new List<Item>();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                Item retobj = new Item(dr);

                //var itemblob = ItemsBlobs.Get(retobj.Id);
                //retobj.RetailPrice = itemblob.
                //retobj.BlobData = itemblob.BlobData;
                retobjs.Add(retobj);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

            return retobjs;
        }

        public static DataTable GetTable()
        {
            string strquery = "SELECT * from Items ";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static DataTable GetItemsList()
        {
            string strquery = "GetItemsList";  

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static DataTable GetItemsHistory(DateTime? datein, DateTime? dateout, int itemid, int warehouse)
        {
            string strquery = "GetItemDetailsHistory";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = datein;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dateout;
            cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = itemid;
            cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouse;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static DataTable GetExpenseHistory(DateTime? datein, DateTime? dateout, int account, int warehouse)
        {
            string strquery = "GetExpenseDetailsHistory";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = datein;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dateout;
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = account;
            cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouse;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static DataTable GetAccountHistory(int partner, int account, DateTime? datein, DateTime? dateout, int warehouse, int projectid, int ptype, int stype, bool allpurchase, bool allsale)
        {
            string strquery = "GetAccountHistory";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = partner;
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = account;
            cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = datein;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = dateout;
            
            cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouse;
            cmd.Parameters.Add("@Project", SqlDbType.Int).Value = projectid;
            cmd.Parameters.Add("@PType", SqlDbType.Int).Value = ptype;
            cmd.Parameters.Add("@SType", SqlDbType.Int).Value = stype;
            cmd.Parameters.Add("@AllPurchase", SqlDbType.Bit).Value = allpurchase;
            cmd.Parameters.Add("@AllSale", SqlDbType.Bit).Value = allsale;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static DataTable GetRevenues(int account, DateTime? datein, DateTime? dateout)
        {
            string strquery = "RptRevenues";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@AccountId", SqlDbType.Int).Value = account;
            cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = datein;
            cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = dateout;

            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static List<WarehouseItems> GetItemsinStock(DateTime datein, int warehouseId, bool lackitems)
        {
            string strquery = "GetItemsinStock";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);           
            cmd.Parameters.Add("@DateIn", SqlDbType.DateTime).Value = datein;
            cmd.Parameters.Add("@warehouseId", SqlDbType.Int).Value = warehouseId;
            cmd.Parameters.Add("@LackItems", SqlDbType.Bit).Value = lackitems;

            cmd.CommandType = CommandType.StoredProcedure;

            List<WarehouseItems> retobjs = new List<WarehouseItems>();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                WarehouseItems retobj = new WarehouseItems();
               
                retobj.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                retobj.ProductNo = dr.GetString(dr.GetOrdinal("ProductNo"));
                retobj.Barcode = dr.GetString(dr.GetOrdinal("Barcode"));
                retobj.ItemName = dr.GetString(dr.GetOrdinal("ItemName"));
               // retobj.Unit = dr.GetString(dr.GetOrdinal("Unit"));

                retobj.Quantity = dr.GetDecimal(dr.GetOrdinal("Quantity"));
                retobj.Purchases = dr.GetDecimal(dr.GetOrdinal("Purchases"));
                retobj.Sales = dr.GetDecimal(dr.GetOrdinal("Sales"));
                retobj.AvgPrice = dr.GetDecimal(dr.GetOrdinal("AvgPrice"));
                retobj.SalePrice = dr.GetDecimal(dr.GetOrdinal("SalePrice"));
                retobj.Total = dr.GetDecimal(dr.GetOrdinal("Total"));

                retobjs.Add(retobj);

            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            return retobjs;
        }

        public static DataTable AvgPricePerItems(DateTime datein, int warehouseId, bool showCostofItems)
        {
            string strquery = "AvgPricePerItems";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@DateIn", SqlDbType.DateTime).Value = datein;
            cmd.Parameters.Add("@warehouseId", SqlDbType.Int).Value = warehouseId;
            cmd.Parameters.Add("@ShowCostOfItems", SqlDbType.Bit).Value = showCostofItems;

            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }


        public static DataTable GetItemsFromStock(DateTime datein, int warehouseId, bool lackitems, int itemtype)
        {
            string strquery = "GetItemsFromStock";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@DateIn", SqlDbType.DateTime).Value = datein;
            cmd.Parameters.Add("@warehouseId", SqlDbType.Int).Value = warehouseId;
            cmd.Parameters.Add("@LackItems", SqlDbType.Bit).Value = lackitems;
            cmd.Parameters.Add("@ItemType", SqlDbType.Int).Value = itemtype;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static List<InsertStock> InsertStock(DateTime datein, int warehouseId, bool lackitems)
        {
            string strquery = "InsertStock";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.Parameters.Add("@DateIn", SqlDbType.DateTime).Value = datein;
            cmd.Parameters.Add("@warehouseId", SqlDbType.Int).Value = warehouseId;
            cmd.Parameters.Add("@LackItems", SqlDbType.Bit).Value = lackitems;

            cmd.CommandType = CommandType.StoredProcedure;

            List<InsertStock> retobjs = new List<InsertStock>();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                InsertStock retobj = new InsertStock();

                retobj.Id = dr.GetInt32(dr.GetOrdinal("Id"));
                retobj.ItemId = dr.GetInt32(dr.GetOrdinal("ItemId"));
                retobj.Barcode = dr.GetString(dr.GetOrdinal("Barcode"));
                retobj.ItemName = dr.GetString(dr.GetOrdinal("ItemName"));
                retobj.Unit = dr.GetString(dr.GetOrdinal("Unit"));

                retobj.Quantity = dr.GetDecimal(dr.GetOrdinal("Quantity"));
                retobj.Price = dr.GetDecimal(dr.GetOrdinal("Price"));
                retobj.Vat = dr.GetInt32(dr.GetOrdinal("Vat"));
                retobj.Duty = dr.GetInt32(dr.GetOrdinal("Duty"));
                //retobj.SalePrice = dr.GetDecimal(dr.GetOrdinal("SalePrice"));
                retobj.Total = dr.GetDecimal(dr.GetOrdinal("Total"));

                retobjs.Add(retobj);

            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            return retobjs;
        }


        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        /// 
        public static DataTable GetUnits()
        {
            string strquery = "GetUnits";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@InYear", SqlDbType.Int).Value = inyear;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static DataTable GetAccount()
        {
            string strquery = "GetPlanet";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Parameters.Add("@InYear", SqlDbType.Int).Value = inyear;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }

        public static DataTable GetItemsinStock(int inyear)
        {
            string strquery = "GetItemsinStockNow";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@InYear", SqlDbType.Int).Value = inyear;
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable retobj = new DataTable();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            da.Fill(retobj);

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            da.Dispose();

            if (retobj.Rows.Count == 0)
                return null;
            else
                return retobj;
        }
        //public static DataTable GetItemsinStockByPartnerId(int partnerid)
        //{
        //    string strquery = "GetItemsinStockNowByPartner";

        //    SqlCommand cmd = new SqlCommand(strquery, statcnn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    cmd.Parameters.Add("@PartnerId", SqlDbType.Int).Value = partnerid;
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    DataTable retobj = new DataTable();

        //    if (statcnn.State == System.Data.ConnectionState.Closed)
        //        statcnn.Open();

        //    da.Fill(retobj);

        //    if (statcnn.State == System.Data.ConnectionState.Open)
        //        statcnn.Close();

        //    da.Dispose();

        //    if (retobj.Rows.Count == 0)
        //        return null;
        //    else
        //        return retobj;
        //}
        //public static DataTable GetItemsinStockWithoutMinus(int inyear)
        //{
        //    string strquery = "GetItemsinStockWithoutMinus";

        //    SqlCommand cmd = new SqlCommand(strquery, statcnn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    cmd.Parameters.Add("@InYear", SqlDbType.Int).Value = inyear;
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    DataTable retobj = new DataTable();

        //    if (statcnn.State == System.Data.ConnectionState.Closed)
        //        statcnn.Open();

        //    da.Fill(retobj);

        //    if (statcnn.State == System.Data.ConnectionState.Open)
        //        statcnn.Close();

        //    da.Dispose();

        //    if (retobj.Rows.Count == 0)
        //        return null;
        //    else
        //        return retobj;
        //}


        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static MyNET.Entities.Item Get(string barcode)
        {
            string strquery = "GetItemsbyBarcode";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Barcode", SqlDbType.VarChar,100).Value = barcode;

            MyNET.Entities.Item retobj = new MyNET.Entities.Item();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                retobj = LoadObjectFromReader(dr);
            else
                retobj = null;

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

            return retobj;
        }

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static ArrayList GetByCategory(int categoryId)
        {
            string strquery = "GetItemsbyCategory";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;

            MyNET.Entities.Item retobj;

            ArrayList retobjs = new ArrayList();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                retobj = new MyNET.Entities.Item();
                retobj = LoadObjectFromReader(dr);

                retobjs.Add(retobj);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

            if (retobjs.Count == 0)
                return null;
            else
                return retobjs;
        }

        /// <summary>
        /// Search object in table
        /// </summary>
        /// <param name="WhereCondition">Where conditions</param>
        /// <param name="OrderByExpression">Order by</param>
        /// <returns>List of objects</returns>
        public static ArrayList Search(string WhereCondition, string OrderByExpression)
        {
            string strquery = "SearchItems";

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("WhereCondition", SqlDbType.VarChar).Value = WhereCondition;
            cmd.Parameters.Add("OrderByExpression", SqlDbType.VarChar).Value = OrderByExpression;

            MyNET.Entities.Item retobj;

            ArrayList retobjs = new ArrayList();

            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                retobj = new MyNET.Entities.Item();
                retobj = LoadObjectFromReader(dr);

                retobjs.Add(retobj);
            }

            if (statcnn.State == System.Data.ConnectionState.Open)
                statcnn.Close();

            dr.Dispose();

            if (retobjs.Count == 0)
                return null;
            else
                return retobjs;
        }

        public static DataTable SearchItems(string WhereCondition, string OrderByExpression)
        {
            string strquery = "SearchItems";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("WhereCondition", SqlDbType.VarChar).Value = WhereCondition;
            cmd.Parameters.Add("OrderByExpression", SqlDbType.VarChar).Value = OrderByExpression;
            DataTable retobjs = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(retobjs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return retobjs;
        }


        public static DataTable SearchItemsinStockNow(string WhereCondition, string OrderByExpression)
        {
            string strquery = "SearchItemsinStockNow";
            string connstr = Constants.Connectionstr();
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("WhereCondition", SqlDbType.VarChar).Value = WhereCondition;
            cmd.Parameters.Add("OrderByExpression", SqlDbType.VarChar).Value = OrderByExpression;
            DataTable retobjs = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                da.Fill(retobjs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return retobjs;
        }
        #endregion

        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
            string strquery = "InsertItem";

            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            int retval = 0;
            SqlParameter Id = new SqlParameter("@Id", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(Id);
            cmd.Parameters.Add("@ProductNo", SqlDbType.VarChar).Value = ProductNo;
            cmd.Parameters.Add("@Barcode", SqlDbType.VarChar).Value = Barcode;
            cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
            cmd.Parameters.Add("@Unit", SqlDbType.Int).Value = Unit;
            cmd.Parameters.Add("@ProducerId", SqlDbType.Int).Value = ProducerId;
            cmd.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = ItemName;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
            cmd.Parameters.Add("@RetailPrice", SqlDbType.Decimal).Value = RetailPrice;
            cmd.Parameters.Add("@Duty", SqlDbType.Int).Value = Duty;
            cmd.Parameters.Add("@Vat", SqlDbType.Int).Value = Vat;            
            cmd.Parameters.Add("@Akciza", SqlDbType.Decimal).Value = Akciza;
            cmd.Parameters.Add("@ItemGoods", SqlDbType.Bit).Value = ItemGoods;
            cmd.Parameters.Add("@Service", SqlDbType.Bit).Value = Service;
            cmd.Parameters.Add("@Expense", SqlDbType.Bit).Value = Expense;
            cmd.Parameters.Add("@InventoryItem", SqlDbType.Bit).Value = InventoryItem;
            cmd.Parameters.Add("@Material", SqlDbType.Bit).Value = Material;
            cmd.Parameters.Add("@Production", SqlDbType.Bit).Value = Production;
            cmd.Parameters.Add("@Assembled", SqlDbType.Bit).Value = Assembled;
            cmd.Parameters.Add("@Expired", SqlDbType.Bit).Value = Expired;
            cmd.Parameters.Add("@AccountA", SqlDbType.Int).Value = AccountA;
            cmd.Parameters.Add("@AccountB", SqlDbType.Int).Value = AccountB;
            cmd.Parameters.Add("@AccountC", SqlDbType.Int).Value = AccountC;
            cmd.Parameters.Add("@AmountPaid", SqlDbType.DateTime).Value = AmountPaid = DateTime.Now;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
            //cmd.Parameters.Add("@Image", SqlDbType.Image).Value = Image;

            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);
             


             try
             {

                 if (cnn.State == System.Data.ConnectionState.Closed)
                     cnn.Open();
                 cmd.ExecuteNonQuery();
                 retval = (int)rowsaffected.Value;
                 this.Id = (int)Id.Value;
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
             return retval;

        }

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            string strquery = "UpdateItem";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductNo", SqlDbType.VarChar).Value = ProductNo;
            cmd.Parameters.Add("@Barcode", SqlDbType.VarChar).Value = Barcode;
            cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
            cmd.Parameters.Add("@Unit", SqlDbType.Int).Value = Unit;
            cmd.Parameters.Add("@ProducerId", SqlDbType.Int).Value = ProducerId;
            cmd.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = ItemName;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = Description;
            cmd.Parameters.Add("@RetailPrice", SqlDbType.Decimal).Value = RetailPrice;
            cmd.Parameters.Add("@Duty", SqlDbType.Int).Value = Duty;
            cmd.Parameters.Add("@Vat", SqlDbType.Int).Value = Vat;
            cmd.Parameters.Add("@Akciza", SqlDbType.Decimal).Value = Akciza;
            cmd.Parameters.Add("@ItemGoods", SqlDbType.Bit).Value = ItemGoods;
            cmd.Parameters.Add("@Service", SqlDbType.Bit).Value = Service;
            cmd.Parameters.Add("@Expense", SqlDbType.Bit).Value = Expense;
            cmd.Parameters.Add("@AccountA", SqlDbType.Int).Value = AccountA;
            cmd.Parameters.Add("@AccountB", SqlDbType.Int).Value = AccountB;
            cmd.Parameters.Add("@AccountC", SqlDbType.Int).Value = AccountC;
            cmd.Parameters.Add("@InventoryItem", SqlDbType.Bit).Value = InventoryItem;
            cmd.Parameters.Add("@Material", SqlDbType.Bit).Value = Material;
            cmd.Parameters.Add("@Production", SqlDbType.Bit).Value = Production;
            cmd.Parameters.Add("@Assembled", SqlDbType.Bit).Value = Assembled;
            cmd.Parameters.Add("@Expired", SqlDbType.Bit).Value = Expired;
            cmd.Parameters.Add("@ChangedAt", SqlDbType.DateTime).Value = ChangedAt = DateTime.Now;
            cmd.Parameters.Add("@ChangedBy", SqlDbType.NVarChar).Value = ChangedBy;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;

            //cmd.Parameters.Add("@Image", SqlDbType.Image).Value = Image;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);

            int retval = 0;
            try
            {

                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                cmd.ExecuteNonQuery();

                retval = (int)rowsaffected.Value;

                if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;
            }
            catch (Exception ex)
            {
                throw ex;
                //switch (ex.ErrorCode)
                //{
                //    case -2146232060: throw new Exception("Nuk lejohet futja e artikullit me barkode ose emër të njetë"); 
                //    default: throw;
                //}
            }

            return retval;
        }

        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            string strquery = "DeleteItem";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;


            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();

            int retval = (int)rowsaffected.Value;

            if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;

            return retval;
        }
        public int AddImage()
        {
            //if (this.IsinRole(roleId))
            //    return 0;

            string strquery = "Insert into ItemsBlobs(ItemsId,Name,BlobData) values (@ItemsId,@Name,@BlobData); SELECT @ImageId = @@IdENTITY";
            SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
            SqlCommand cmd = new SqlCommand(strquery, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Id = new SqlParameter("@ImageId", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Id);

            //cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ImageId;
            cmd.Parameters.Add("@ItemsId", SqlDbType.Int).Value = this.Id;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@BlobData", SqlDbType.Image).Value = BlobData;

            int retval = 0;
            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                    cnn.Open();
                retval = cmd.ExecuteNonQuery();
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
            return retval;
        }
        public int UpdateImage()
        {
            string strquery = "Update ItemsBlobs set ItemsId = @ItemsId,Name = @Name,BlobData = @BlobData where ImageId = @ImageId; Set @rowsaffected = @@Rowcount";

            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.Add("@ItemsId", SqlDbType.Int).Value = this.Id;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Name;
            cmd.Parameters.Add("@BlobData", SqlDbType.Image).Value = BlobData;

            cmd.Parameters.Add("@ImageId", SqlDbType.Int).Value = ImageId;


            SqlParameter rowsaffected = new SqlParameter("@rowsaffected", SqlDbType.Int);
            rowsaffected.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(rowsaffected);

            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();

            int retval = (int)rowsaffected.Value;

            if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;

            return retval;
        }

        /// <summary>
        /// E rikalkulon  sasin depo per artikullin e dhene
        /// dhe cmimin mesatare
        /// </summary>
        public static int CalculateStock(int itemId, int warehouseid,decimal quantity, string user)
        {
            string strquery = "CalculateStock";
            statcnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, statcnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ItemId", SqlDbType.Int).Value = itemId;
            cmd.Parameters.Add("@UserId", SqlDbType.VarChar, 100).Value = user;
            cmd.Parameters.Add("@warehouseid", SqlDbType.Int).Value = warehouseid;
            cmd.Parameters.Add("@Quantity", SqlDbType.Decimal).Value = quantity;
            if (statcnn.State == System.Data.ConnectionState.Closed)
                statcnn.Open();
            int retval = cmd.ExecuteNonQuery();
            if (statcnn.State == System.Data.ConnectionState.Open) statcnn.Close();
            return retval;
        }

        #endregion

    }
}
