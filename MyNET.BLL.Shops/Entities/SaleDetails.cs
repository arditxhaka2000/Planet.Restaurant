using System;
using System.Collections;

namespace MyNET.Entities
{

    /// <summary>
    /// This object represents the properties and methods of a SaleDetails.
    /// </summary>
    public class SaleDetails
    {
        #region Class Members

        protected int mId;
        protected int mSaleId;
        protected int mNo;
        protected int mItemId;
        protected int mProjectId;
        protected decimal mQuantity;
        protected decimal mAvgPrice;
        protected decimal mPrice;
        protected int mVat;
        protected decimal mVatSum;
        protected decimal mDiscount;
        protected DateTime mAmountPaid;
        protected string mCreatedBy = String.Empty;
        protected DateTime mChangedAt;
        protected string mChangedBy = String.Empty;
        protected int mStatus;

        #endregion

        #region Class constuctors
        ///Default constructor
        public SaleDetails()
        {
        }

        ///Class type constructor
        public SaleDetails(SaleDetails obj)
        {
            mId = obj.Id;
            mSaleId = obj.SaleId;
            mNo = obj.No;
            mItemId = obj.ItemId;
            mProjectId = obj.ProjectId;
            mQuantity = obj.Quantity;
            mAvgPrice = obj.AvgPrice;
            mPrice = obj.Price;
            mVat = obj.Vat;
            mVatSum = obj.VatSum;
            mDiscount = obj.Discount;

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

        public int SaleId
        {
            get { return mSaleId; }
            set { mSaleId = value; }
        }

        public int No
        {
            get { return mNo; }
            set { mNo = value; }
        }

        public decimal Discount
        {
            get { return mDiscount; }
            set { mDiscount = value; }
        }

        public int ItemId
        {
            get { return mItemId; }
            set { mItemId = value; }
        }
        public int ProjectId
        {
            get { return mProjectId; }
            set { mProjectId = value; }
        }

        public decimal Quantity
        {
            get { return mQuantity; }
            set { mQuantity = value; }
        }

        public decimal Price
        {
            get { return mPrice; }
            set { mPrice = value; }
        }

        public decimal AvgPrice
        {
            get { return mAvgPrice; }
            set { mAvgPrice = value; }
        }

        public int Vat
        {
            get { return mVat; }
            set { mVat = value; }
        }

        public decimal VatSum
        {
            get { return mVatSum; }
            set { mVatSum = value; }
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