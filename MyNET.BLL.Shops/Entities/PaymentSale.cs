using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Entities
{
    public class PaymentSale:PaymentDetails
    {
        #region Class Members

        protected int mSaleId;

        #endregion

        #region Class constuctors
        ///Default constructor
        public PaymentSale()
        {
        }

        ///Class type constructor
        public PaymentSale(PaymentSale obj)
        {
            PaymentId = obj.PaymentId;
            SaleId = obj.SaleId;
            AmountPaid = obj.AmountPaid;
        }

        #endregion

        #region Public Properties
       
        public int SaleId
        { 
            get { return mSaleId; }
            set { mSaleId = value; }
        }
        
        #endregion
    }
}
