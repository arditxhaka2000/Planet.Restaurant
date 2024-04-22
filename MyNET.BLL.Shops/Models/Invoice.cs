using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        public string ProductNo { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Vat { get; set; }
        public decimal VatSum { get; set; }
        public decimal Vat8 { get; set; }
        public decimal Vat18 { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountPriceWithVat { get; set; }
        public decimal TotalWithVat { get; set; }
    }
}
