using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyNET.DAL
{
    public class Settings
    {
        #region Class members

        protected int mId;
        protected string mCompanyName = String.Empty;
        protected string mBusinessNumber = String.Empty;
        protected string mFiscalNumber = String.Empty;
        protected string mVatNumber = String.Empty;        
        protected string mAddress = String.Empty;
        protected string mCity = String.Empty;
        protected string mCountry = String.Empty;
        protected string mPhoneNo = String.Empty;
        protected string mFiscalPrinterPath = String.Empty;
        protected bool mWithVat = false;
        protected string mInvoiceIdFormat = String.Empty;
        protected int mInvoiceIdGenerationMethod = 1;
        protected bool mHideOrShowLackItems;
        protected bool mAllowLackItems;
        protected string mClientId;
        protected int mCompanyBranchId;
        protected string mAccNo;
        protected int mDefaultPartner;
        protected byte[] mImage;

        ///Conection to database
        protected SqlConnection cnn = new SqlConnection(Constants.Connectionstr());
        ///Staric member connection
        protected static SqlConnection statcnn = new SqlConnection(Constants.Connectionstr());

        #endregion
        
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Settings()
        {
            string strquery = "select * from settings";

            SqlCommand cmd = new SqlCommand(strquery, cnn);

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
        /// Contructor by entity object
        /// </summary>
        public Settings(MyNET.DAL.Settings obj)
        {
            mId = obj.mId;
            mCompanyName = obj.mCompanyName;
            mBusinessNumber = obj.mBusinessNumber;
            mFiscalNumber = obj.FiscalNumber;
            mVatNumber = obj.VatNumber;
            mAddress = obj.mAddress;
            mCity = obj.mCity;
            mCountry = obj.mCountry;
            mPhoneNo = obj.mPhoneNo;
            mFiscalPrinterPath = obj.FiscalPrinterPath;
            mWithVat = obj.mWithVat;
            mHideOrShowLackItems = obj.HideOrShowLackItems;
            mAllowLackItems = obj.AllowLackItems;
            mInvoiceIdFormat = obj.mInvoiceIdFormat;
            mInvoiceIdGenerationMethod = obj.mInvoiceIdGenerationMethod;
            mCompanyBranchId = obj.CompanyBranchId;
            mClientId = obj.ClientId;
            mDefaultPartner = obj.DefaultPartner;
            mImage = obj.Image;
            mAccNo = obj.AccNo;
        }

        /// <summary>
        /// Load object from reader 
        /// </summary>
        /// <param CompanyName="dr">DataReader object</param>		
        private void LoadFromReader(SqlDataReader dr)
        {
            if (dr != null && !dr.IsClosed)
            {
                this.Id = dr.GetInt32(0);
                if (!dr.IsDBNull(dr.GetOrdinal("CompanyName"))) this.CompanyName = dr.GetString(dr.GetOrdinal("CompanyName"));
                if (!dr.IsDBNull(dr.GetOrdinal("BusinessNumber"))) this.BusinessNumber = dr.GetString(dr.GetOrdinal("BusinessNumber"));
                if (!dr.IsDBNull(dr.GetOrdinal("FiscalNumber"))) this.FiscalNumber = dr.GetString(dr.GetOrdinal("FiscalNumber"));
                if (!dr.IsDBNull(dr.GetOrdinal("VatNumber"))) this.VatNumber = dr.GetString(dr.GetOrdinal("VatNumber"));
                if (!dr.IsDBNull(dr.GetOrdinal("Address"))) this.Address = dr.GetString(dr.GetOrdinal("Address"));
                if (!dr.IsDBNull(dr.GetOrdinal("City"))) this.City = dr.GetString(dr.GetOrdinal("City"));
                if (!dr.IsDBNull(dr.GetOrdinal("Country"))) this.Country = dr.GetString(dr.GetOrdinal("Country"));
                if (!dr.IsDBNull(dr.GetOrdinal("PhoneNo"))) this.PhoneNo = dr.GetString(dr.GetOrdinal("PhoneNo"));
                if (!dr.IsDBNull(dr.GetOrdinal("FiscalPrinterPath"))) this.FiscalPrinterPath = dr.GetString(dr.GetOrdinal("FiscalPrinterPath"));
                if (!dr.IsDBNull(dr.GetOrdinal("WithVat"))) this.mWithVat = dr.GetBoolean(dr.GetOrdinal("WithVat"));
                if (!dr.IsDBNull(dr.GetOrdinal("InvoiceIdFormat"))) this.InvoiceIdFormat = dr.GetString(dr.GetOrdinal("InvoiceIdFormat"));
                if (!dr.IsDBNull(dr.GetOrdinal("InvoiceIdGenerationMethod"))) this.InvoiceIdGenerationMethod = dr.GetInt32(dr.GetOrdinal("InvoiceIdGenerationMethod"));
                if (!dr.IsDBNull(dr.GetOrdinal("HideOrShowLackItems"))) this.HideOrShowLackItems = dr.GetBoolean(dr.GetOrdinal("HideOrShowLackItems"));
                if (!dr.IsDBNull(dr.GetOrdinal("AllowLackItems"))) this.AllowLackItems = dr.GetBoolean(dr.GetOrdinal("AllowLackItems"));
                if (!dr.IsDBNull(dr.GetOrdinal("CompanyBranchId"))) this.CompanyBranchId = dr.GetInt32(dr.GetOrdinal("CompanyBranchId"));
                if (!dr.IsDBNull(dr.GetOrdinal("ClientId"))) this.ClientId = dr.GetString(dr.GetOrdinal("ClientId"));
                if (!dr.IsDBNull(dr.GetOrdinal("Image"))) this.Image = (byte[])dr[dr.GetOrdinal("Image")];
                if (!dr.IsDBNull(dr.GetOrdinal("AccNo"))) this.AccNo = dr.GetString(dr.GetOrdinal("AccNo"));
                if (!dr.IsDBNull(dr.GetOrdinal("DefaultPartner"))) this.DefaultPartner = dr.GetInt32(dr.GetOrdinal("DefaultPartner"));
            }
        }

        #endregion

        #region Public Properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        /// <summary>
        /// Client unique id on server
        /// </summary>
        public string ClientId
        {
            get { return mClientId; }
            set { mClientId = value; }
        }

        public int CompanyBrachId
        {
            get { return mCompanyBranchId; }
            set { mCompanyBranchId = value; }
        }
        public string AccNo
        {
            get { return mAccNo; }
            set { mAccNo = value; }
        }
        public int CompanyBranchId
        {
            get { return mCompanyBranchId; }
            set { mCompanyBranchId = value; }
        }
        

        public string CompanyName
        {
            get { return mCompanyName; }
            set { mCompanyName = value; }
        }

        /// <summary>
        /// Numri i biznesit
        /// </summary>
        public string BusinessNumber
        {
            get { return mBusinessNumber; }
            set { mBusinessNumber = value; }
        }

        /// <summary>
        /// Numri fiskal
        /// </summary>
        public string FiscalNumber
        {
            get { return mFiscalNumber; }
            set { mFiscalNumber = value; }
        }

        /// <summary>
        /// Numri i TVSH-se
        /// </summary>
        public string VatNumber
        {
            get { return mVatNumber; }
            set { mVatNumber = value; }
        }

        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }

        public string City
        {
            get { return mCity; }
            set { mCity = value; }
        }

        public string Country
        {
            get { return mCountry; }
            set { mCountry = value; }
        }

        public string PhoneNo
        {
            get { return mPhoneNo; }
            set { mPhoneNo = value; }
        }

        public string FiscalPrinterPath
        {
            get { return mFiscalPrinterPath; }
            set { mFiscalPrinterPath = value; }
        }

        /// <summary>
        /// Nese eshte true kompania eshte subjek i tvsh-se
        /// </summary>
        public bool WithVat
        {
            get { return  mWithVat; }
            set { mWithVat = value; }
        }
       
        public bool HideOrShowLackItems
        {
            get { return mHideOrShowLackItems; }
            set { mHideOrShowLackItems = value; }
        }
        public bool AllowLackItems
        {
            get { return mAllowLackItems; }
            set { mAllowLackItems = value; }
        }
        public string InvoiceIdFormat
        {
            get { return mInvoiceIdFormat; }
            set { mInvoiceIdFormat = value; }
        }

        public int InvoiceIdGenerationMethod
        {
            get { return mInvoiceIdGenerationMethod; }
            set { mInvoiceIdGenerationMethod = value; }
        }

        public byte[] Image
        {
            get { return mImage; }
            set { mImage = value; }
        }

        public int DefaultPartner
        {
            get { return mDefaultPartner; }
            set { mDefaultPartner = value; }
        }

        #endregion

        #region public static Get Methods

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static Settings Get()
        {
            return new Settings();
        }

        #endregion

        #region Update
                
        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            string strquery = "Update settings set " +
            "CompanyName = @CompanyName," +
            "BusinessNumber = @BusinessNumber," +
            "FiscalNumber = @FiscalNumber," +
            "VatNumber = @VatNumber," +
            "Address = @Address," +
            "City = @City," +
            "Country = @Country," +
            "PhoneNo = @PhoneNo," +
            "FiscalPrinterPath = @FiscalPrinterPath," +
            "WithVat = @WithVat," +
            "HideOrShowLackItems = @HideOrShowLackItems," +
            "AllowLackItems = @AllowLackItems," +
            "InvoiceIdFormat = @InvoiceIdFormat," +
            "InvoiceIdGenerationMethod = @InvoiceIdGenerationMethod," +
            "Image = @Image," +
            "ClientId = @ClientId," +
            "CompanyBranchId = @CompanyBranchId," +
            "DefaultPartner = @DefaultPartner," +
            "AccNo = @AccNo";            
            cnn = new SqlConnection(Constants.Connectionstr());

            SqlCommand cmd = new SqlCommand(strquery, cnn);
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar,50).Value = mCompanyName;
            cmd.Parameters.Add("@BusinessNumber", SqlDbType.VarChar, 50).Value = mBusinessNumber;
            cmd.Parameters.Add("@FiscalNumber", SqlDbType.VarChar, 50).Value = mFiscalNumber;
            cmd.Parameters.Add("@VatNumber", SqlDbType.VarChar, 50).Value = mVatNumber;            
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = mAddress;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = mCity;
            cmd.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = mCountry;
            cmd.Parameters.Add("@PhoneNo", SqlDbType.VarChar, 50).Value = mPhoneNo;
            cmd.Parameters.Add("@FiscalPrinterPath", SqlDbType.VarChar, 250).Value = mFiscalPrinterPath;
            cmd.Parameters.Add("@WithVat", SqlDbType.Bit).Value = mWithVat;
            
            cmd.Parameters.Add("@HideOrShowLackItems", SqlDbType.Bit).Value = mHideOrShowLackItems;
            cmd.Parameters.Add("@AllowLackItems", SqlDbType.Bit).Value = mAllowLackItems;
            cmd.Parameters.Add("@InvoiceIdFormat", SqlDbType.VarChar,50).Value = mInvoiceIdFormat;
            cmd.Parameters.Add("@InvoiceIdGenerationMethod", SqlDbType.Int).Value = mInvoiceIdGenerationMethod;
            cmd.Parameters.Add("@ClientID", SqlDbType.VarChar, 50).Value = mClientId;
            cmd.Parameters.Add("@CompanyBranchId", SqlDbType.Int).Value = mCompanyBranchId;
            cmd.Parameters.Add("@DefaultPartner", SqlDbType.Int).Value = mDefaultPartner;
            cmd.Parameters.Add("@AccNo", SqlDbType.VarChar).Value = mAccNo;
            if (mImage != null)
            cmd.Parameters.Add("@Image", SqlDbType.Image).Value = mImage;
            else
                cmd.Parameters.Add("@Image", SqlDbType.Image).Value = DBNull.Value;
            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
           int retval = cmd.ExecuteNonQuery();

           if (cnn.State == System.Data.ConnectionState.Open) cnn.Close(); ;

            return retval;
        }
                
        #endregion
    }
}
