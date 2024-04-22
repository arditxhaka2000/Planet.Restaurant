using System;
using System.Collections;

namespace MyNET.Entities
{

    /// <summary>
    /// This object represents the properties and methods of a Article.
    /// </summary>
    public class Item
    {
        #region Class Members

        protected int mId;
        protected string mProductNo = String.Empty;
        protected string mBarcode = String.Empty;
        protected int mCategoryId;
        protected string mUnit;
        protected int mUncitId;
        protected int mProducerId;
        protected string mItemName = String.Empty;
        protected string mDescription = String.Empty;
        protected decimal mPurchasePrice;
        protected decimal mRetailPrice;
        protected decimal mDiscount;
        protected decimal mInStock;
        protected int mDuty;
        protected int mVat;
        protected decimal mAkciza;
        protected bool mItemGoods;
        protected bool mService;
        protected bool mExpense;
        protected bool mInventoryItem;
        protected bool mMaterial;
        protected bool mProduction;
        protected bool mAssembled;
        protected bool mExpired;
        protected int mAccountA;
        protected int mAccountB;
        protected int mAccountC;
        protected DateTime mAmountPaid;
        protected string mCreatedBy = String.Empty;
        protected DateTime mChangedAt;
        protected string mChangedBy = String.Empty;
        protected int mStatus;

        protected int mImageId;
        protected int mItemId;
        protected string mName;
        protected byte[] mBlobData;

        protected int mPartnerId;

        #endregion

        #region Class constuctors
        ///Default constructor
        public Item()
        {
        }

        ///Class type constructor
        public Item(Item obj)
        {
            mId = obj.Id;
            mProductNo = obj.mProductNo;
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

            mImageId = obj.ImageId;
            mItemId = obj.ItemId;
            mName = obj.Name;
            mBlobData = obj.BlobData;
            //mPartnerId = obj.PartnerId;

        }

        #endregion

        #region Public Properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public string ProductNo
        {
            get { return mProductNo; }
            set { mProductNo = value; }
        }
        
        public string Barcode
        {
            get { return mBarcode; }
            set { mBarcode = value; }
        }

        public int CategoryId
        {
            get { return mCategoryId; }
            set { mCategoryId = value; }
        }

        public string Unit
        {
            get { return mUnit; }
            set { mUnit = value; }
        }

        public int ProducerId
        {
            get { return mProducerId; }
            set { mProducerId = value; }
        }

        public string ItemName
        {
            get { return mItemName; }
            set { mItemName = value; }
        }

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }

        public decimal PurchasePrice
        {
            get { return mPurchasePrice; }
            set { mPurchasePrice = value; }
        }

        public decimal RetailPrice
        {
            get { return mRetailPrice; }
            set { mRetailPrice = value; }
        }
        public decimal Discount
        {
            get { return mDiscount; }
            set { mDiscount = value; }
        }
        public decimal InStock
        {
            get { return mInStock; }
            set { mInStock = value; }
        }

        public int Duty
        {
            get { return mDuty; }
            set { mDuty = value; }
        }

        public int Vat
        {
            get { return mVat; }
            set { mVat = value; }
        }

        public decimal Akciza
        {
            get { return mAkciza; }
            set { mAkciza = value; }
        }
        public bool ItemGoods
        {
            get { return mItemGoods; }
            set { mItemGoods = value; }
        }
        public bool Service
        {
            get { return mService; }
            set { mService = value; }
        }
        public bool Expense
        {
            get { return mExpense; }
            set { mExpense = value; }
        }
        public bool InventoryItem
        {
            get { return mInventoryItem; }
            set { mInventoryItem = value; }
        }
        public bool Material
        {
            get { return mMaterial; }
            set { mMaterial = value; }
        }
        public bool Production
        {
            get { return mProduction; }
            set { mProduction = value; }
        }
        public bool Assembled
        {
            get { return mAssembled; }
            set { mAssembled = value; }
        }
        public bool Expired
        {
            get { return mExpired; }
            set { mExpired = value; }
        }
        public int AccountA
        {
            get { return mAccountA; }
            set { mAccountA = value; }
        }
        public int AccountB
        {
            get { return mAccountB; }
            set { mAccountB = value; }
        }
        public int AccountC
        {
            get { return mAccountC; }
            set { mAccountC = value; }
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

        //public int PartnerId
        //{
        //    get { return mPartnerId; }
        //    set { mPartnerId = value; }
        //}
        #endregion

        #region Image
        public int ImageId
        {
            get { return mImageId; }
            set { mImageId = value; }
        }
        public int ItemId
        {
            get { return mItemId; }
            set { mItemId = value; }
        }
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public byte[] BlobData
        {
            get { return mBlobData; }
            set { mBlobData = value; }
        }

        #endregion

    }
}


