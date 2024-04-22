using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class Sale 
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public string SalesType { get; set; }
        public decimal Total { get; set; }
        public decimal TotalSum { get; set; }
        public decimal Vat8 { get; set; }
        public decimal Vat18 { get; set; }
        public decimal VatSum { get; set; }
        public decimal TotalWithVat { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalBeforeDiscount { get; set; }
        public string Comment { get; set; }
    }
}
