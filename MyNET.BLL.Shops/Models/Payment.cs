using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int No { get; set; }
        //public int PaymentBankId
        //{
        //    get { return mPaymentBankId; }
        //    set { mPaymentBankId = value; }
        //}
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string DocumentId { get; set; }

        public int PartnerId { get; set; }

        public int PaymentType { get; set; }

        public int ProjectId { get; set; }

        public int WarehouseId { get; set; }

        public int UserId { get; set; }

        public int CashBoxId { get; set; }

        public int BankId { get; set; }

        public int AccountId { get; set; }

        public decimal Debit { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal Saldo { get; set; }
                
        public int Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ChangedAt { get; set; }

        public MyNET.DAL.PaymentSale PaymentSale { get; set; }
        
    }
}
