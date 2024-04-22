using System;
using System.Collections;

namespace MyNET.Entities
{

    /// <summary>
    /// This object represents the properties and methods of a Customer.
    /// </summary>
    public class Partner
    {
        #region Class Members

        protected int mId;
        protected string mName = String.Empty;
        protected string mSurname = String.Empty;
        protected string mCompanyName = String.Empty;
        protected string mSaveAs = String.Empty;
        protected string mPhone = String.Empty;
        protected string mMobilePhone = String.Empty;
        protected string mComment = String.Empty;
        protected string mBusinessNo = String.Empty;
        protected string mFiscalNo = String.Empty;
        protected string mVatNo = String.Empty;
        protected string mAddress = String.Empty;
        protected int mCity;
        protected int? mCountry = null;
        protected bool mCustomer; 
        protected bool mSupplier;
        protected int mPartnerType;
        protected int mPartnerOrigin;
        protected DateTime mAmountPaid;
        protected string mCreatedBy = String.Empty;
        protected DateTime mChangedAt;
        protected string mChangedBy = String.Empty; 
        protected int mStatus;
        protected decimal mDiscount;
        protected int mPaymentTypeId;
        protected bool mImportOrLocal;

        #endregion

        #region Class constuctors
        ///Default constructor
        public Partner()
        {
        }

        ///Class type constructor
        public Partner(Partner obj)
        {
            mId = obj.Id;
            mName = obj.Name;
            mSurname = obj.Surname;
            mCompanyName = obj.CompanyName;
            mSaveAs = obj.SaveAs;
            mPartnerType = obj.PartnerType;
            mPartnerOrigin = obj.PartnerOrigin;
            mPhone = obj.Phone;
            mMobilePhone = obj.MobilePhone;
            mComment = obj.Comment;
            mBusinessNo = obj.BusinessNo;
            mFiscalNo = obj.FiscalNo;
            mVatNo = obj.VatNo;
            mAddress = obj.Address;
            mCity = obj.City;
            mCountry = obj.Country;
            mCustomer = obj.Customer;
            mSupplier = obj.Supplier;
            mAmountPaid = obj.AmountPaid;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            mStatus = obj.Status;
            mDiscount = obj.Discount;
            mPaymentTypeId = obj.PaymentTypeId;
            mImportOrLocal = obj.ImportOrLocal;
        }

        #endregion

        #region Public Properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public string Surname
        {
            get { return mSurname; }
            set { mSurname = value; }
        }

        public string CompanyName
        {
            get { return mCompanyName; }
            set { mCompanyName = value; }
        }
        public int PartnerType
        {
            get { return mPartnerType; }
            set { mPartnerType = value; }
        }
        public int PartnerOrigin
        {
            get { return mPartnerOrigin; }
            set { mPartnerOrigin = value; }
        }
        public string SaveAs
        {
            get { return mSaveAs; }
            set { mSaveAs = value; }
        }

        public string Phone
        {
            get { return mPhone; }
            set { mPhone = value; }
        }

        public string MobilePhone
        {
            get { return mMobilePhone; }
            set { mMobilePhone = value; }
        }

        public string Comment
        {
            get { return mComment; }
            set { mComment = value; }
        }

        public string BusinessNo
        {
            get { return mBusinessNo; }
            set { mBusinessNo = value; }
        }

        public string FiscalNo
        {
            get { return mFiscalNo; }
            set { mFiscalNo = value; }
        }

        public string VatNo
        {
            get { return mVatNo; }
            set { mVatNo = value; }
        }

        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }

        public int City
        {
            get { return mCity; }
            set { mCity = value; }
        }

        public Nullable<int> Country
        {
            get { return mCountry; }
            set { mCountry = value; }
        }
        public bool Customer
        {
            get { return mCustomer; }
            set { mCustomer = value; }
        }

        public bool Supplier
        {
            get { return mSupplier; }
            set { mSupplier = value; }
        }

        public DateTime AmountPaid
        {
            get { return mAmountPaid; }
            set { mAmountPaid = value; }
        }

        public string CreatedBy
        {
            get { return mCreatedBy; }
            set { mCreatedBy = value; }
        }

        public DateTime ChangedAt
        {
            get { return mChangedAt; }
            set { mChangedAt = value; }
        }

        public string ChangedBy
        {
            get { return mChangedBy; }
            set { mChangedBy = value; }
        }

        public int Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
        public decimal Discount
        {
            get { return mDiscount; }
            set { mDiscount = value; }
        }
        public int PaymentTypeId
        {
            get { return mPaymentTypeId; }
            set { mPaymentTypeId = value; }
        }
        public bool ImportOrLocal
        {
            get { return mImportOrLocal; }
            set { mImportOrLocal = value; }
        }
        #endregion

    }
}



