using System;
using System.Collections;
using MyNET.Models;

namespace MyNET.Entities
{

    /// <summary>
    /// This object represents the properties and methods of a Sale.
    /// </summary>
    public class Sale
    {
        #region Class Members

        protected int mId;
        protected DateTime mDate;
        protected DateTime mEndDate;
        protected int mSaleId;
        protected int mCashBoxId;
        protected int mStationId;
        protected string mReference = String.Empty;
        protected int mPartnerId;
        protected int mPaymentMethodId;
        protected int mSaleTypeId;
        protected string mInvoiceNo;
        //protected decimal mTotalCash;
        //protected decimal mTotalCoupon;
        //protected decimal mTotalCheck;
        //protected decimal mTotalAmountPaidCard;
        protected decimal mTotalSum;
        protected bool mWithVat;
        protected bool mExport;
        protected decimal mVatSum;
        protected string mCurrency = String.Empty;
        protected decimal mCurrencyRate;
        protected string mComment = String.Empty;
        protected bool mPrinted = false;
        //protected bool mPrintFiscal = false;
        protected DateTime mAmountPaid;
        protected string mCreatedBy = String.Empty;
        protected DateTime mChangedAt;
        protected string mChangedBy = String.Empty;
        protected int mStatus;

        #endregion

        #region Class constuctors
        ///Default constructor
        public Sale()
        {
        }

        ///Class type constructor
        public Sale(Sale obj)
        {
            mId = obj.Id;
            mDate = obj.Date;
            mEndDate = obj.EndDate;
            //mSaleType = obj.SaleType;
            mSaleId = obj.SaleId;
            mCashBoxId = obj.CashBoxId;
            mStationId = obj.StationId;
            mInvoiceNo = obj.mInvoiceNo;
            mReference = obj.Reference;
            mPartnerId = obj.PartnerId;
            mPaymentMethodId = obj.PaymentMethodId;
            mSaleTypeId = obj.SalesTypeId;
            //mPrintFiscal = obj.PrintFiscal;
            //mTotalCash = obj.TotalCash;
            //mTotalCoupon = obj.TotalCoupon;
            //mTotalCheck = obj.TotalCheck;
            //mTotalAmountPaidCard = obj.TotalAmountPaidCard;
            mTotalSum = obj.TotalSum;
            mWithVat = obj.WithVat;
            mExport = obj.Export;
            mVatSum = obj.VatSum;
            mCurrency = obj.Currency;
            mCurrencyRate = obj.CurrencyRate;
            mComment = obj.Comment;
            mPrinted = obj.Printed;
            mAmountPaid = obj.AmountPaid;
            mCreatedBy = obj.CreatedBy;
            mChangedAt = obj.ChangedAt;
            mChangedBy = obj.ChangedBy;
            mStatus = obj.Status;

        }

        #endregion

        #region Public Properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public DateTime Date
        {
            get { return mDate; }
            set { mDate = value; }
        }
        public DateTime EndDate
        {
            get { return mEndDate; }
            set { mEndDate = value; }
        }
        public int SaleId
        {
            get { return mSaleId; }
            set { mSaleId = value; }
        }

        //public int SaleType
        //{
        //    get { return mSaleType; }
        //    set { mSaleType = value; }
        //}

        public int CashBoxId
        {
            get { return mCashBoxId; }
            set { mCashBoxId = value; }
        }

        public int StationId
        {
            get { return mStationId; }
            set { mStationId = value; }
        }

        public string InvoiceNo
        {
            get { return mInvoiceNo; }
            set { mInvoiceNo = value; }
        }
        public string Reference
        {
            get { return mReference; }
            set { mReference = value; }
        }
        public int PartnerId
        {
            get { return mPartnerId; }
            set { mPartnerId = value; }
        }
        public int PaymentMethodId
        {
            get { return mPaymentMethodId; }
            set { mPaymentMethodId = value; }
        }
        public int SalesTypeId
        {
            get { return mSaleTypeId; }
            set { mSaleTypeId = value; }
        }

        //public decimal TotalCash
        //{
        //    get { return mTotalCash; }
        //    set { mTotalCash = value; }
        //}

        //public decimal TotalCoupon
        //{
        //    get { return mTotalCoupon; }
        //    set { mTotalCoupon = value; }
        //}

        //public decimal TotalCheck
        //{
        //    get { return mTotalCheck; }
        //    set { mTotalCheck = value; }
        //}

        //public decimal TotalAmountPaidCard
        //{
        //    get { return mTotalAmountPaidCard; }
        //    set { mTotalAmountPaidCard = value; }
        //}

        public decimal TotalSum
        {
            get { return mTotalSum; }
            set { mTotalSum = value; }
        }

        public bool WithVat
        {
            get { return mWithVat; }
            set { mWithVat = value; }
        }

        public bool Export
        {
            get { return mExport; }
            set { mExport = value; }
        }

        public decimal VatSum
        {
            get { return mVatSum; }
            set { mVatSum = value; }
        }

        public string Currency
        {
            get { return mCurrency; }
            set { mCurrency = value; }
        }

        public decimal CurrencyRate
        {
            get { return mCurrencyRate; }
            set { mCurrencyRate = value; }
        }

        public string Comment
        {
            get { return mComment; }
            set { mComment = value; }
        }

        //public bool PrintFiscal
        //{
        //    get { return mPrintFiscal; }
        //    set { mPrintFiscal = value; }
        //}

        public bool Printed
        {
            get { return mPrinted; }
            set { mPrinted = value; }
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


        #endregion

    }
}