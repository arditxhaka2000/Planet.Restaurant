using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNET.Entities
{
    public class Payment
    {
        #region Class Members

        protected int mId;
        protected int mNo;
        //protected int mPaymentBankId;
        protected DateTime mDate;
        protected string mDescription = String.Empty;
        protected string mDocumentId;
        protected int mPartnerId;
        protected int mPaymentType;
        protected int mProjectId;
        protected int mWarehouseId;
        protected int mUserId;
        protected int mCashBoxId;
        protected int mBankId;
        protected int mAccountId;
        //protected decimal mDebit;
        protected decimal mAmountPaid;
        //protected int mBill;
        protected int mStatus;
        protected decimal mSaldo;
        protected DateTime mCreatedAt;
        protected DateTime mChangedAt;

        #endregion

        #region Class constuctors
        ///Default constructor
        public Payment()
        {
        }

        ///Class type constructor
        public Payment(Payment obj)
        {
            mId = obj.Id;
            mNo = obj.No;
            //mPaymentBankId = obj.PaymentBankId;
            mDate = obj.Date;
            mDescription = obj.Description;
            mDocumentId = obj.DocumentId;
            mPartnerId = obj.PartnerId;
            mPaymentType = obj.PaymentType;
            mProjectId = obj.ProjectId;
            mWarehouseId = obj.WarehouseId;
            mUserId = obj.UserId;
            mCashBoxId = obj.CashBoxId;
            mBankId = obj.BankId;
            mAccountId = obj.AccountId;
            //mDebit = obj.Debit;
            mAmountPaid = obj.AmountPaid;
            mSaldo = obj.Saldo;
            //mBill = obj.Bill;
            mStatus = obj.Status;
            mCreatedAt = obj.CreatedAt;
            mChangedAt = obj.ChangedAt;
        }

        #endregion

        #region Public Properties

        public int Id
        {
            get { return mId; }
            set { mId = value; }
        }
        public int No
        {
            get { return mNo; }
            set { mNo = value; }
        }
        //public int PaymentBankId
        //{
        //    get { return mPaymentBankId; }
        //    set { mPaymentBankId = value; }
        //}
        public DateTime Date
        {
            get { return mDate; }
            set { mDate = value; }
        }
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        public string DocumentId
        {
            get { return mDocumentId; }
            set { mDocumentId = value; }
        }
        public int PartnerId
        {
            get { return mPartnerId; }
            set { mPartnerId = value; }
        }

        public int PaymentType
        {
            get { return mPaymentType; }
            set { mPaymentType = value; }
        }
        public int ProjectId
        {
            get { return mProjectId; }
            set { mProjectId = value; }
        }
        public int WarehouseId
        {
            get { return mWarehouseId; }
            set { mWarehouseId = value; }
        }
        public int UserId
        {
            get { return mUserId; }
            set { mUserId = value; }
        }
        public int CashBoxId
        {
            get { return mCashBoxId; }
            set { mCashBoxId = value; }
        }
        public int BankId
        {
            get { return mBankId; }
            set { mBankId = value; }
        }
        public int AccountId
        {
            get { return mAccountId; }
            set { mAccountId = value; }
        }
        //public decimal Debit
        //{
        //    get { return mDebit; }
        //    set { mDebit = value; }
        //}
        public decimal AmountPaid
        {
            get { return mAmountPaid; }
            set { mAmountPaid = value; }
        }
        public decimal Saldo
        {
            get { return mSaldo; }
            set { mSaldo = value; }
        }
        //public int Bill
        //{
        //    get { return mBill; }
        //    set { mBill = value; }
        //}
        public int Status
        {
            get { return mStatus; }
            set { mStatus = value; }
        }
        public DateTime CreatedAt
        {
            get { return mCreatedAt; }
            set { mCreatedAt = value; }
        }
        public DateTime ChangedAt
        {
            get { return mChangedAt; }
            set { mChangedAt = value; }
        }
        #endregion
    }
}
