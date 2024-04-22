using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class PaymentSale
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public decimal TotalSum { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Debts { get; set; }
        public decimal PayedSum { get; set; }
        public bool Selected { get; set; }
    }
}
