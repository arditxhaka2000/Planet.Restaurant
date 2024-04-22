using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNET.Models
{
    public class SaleDetails
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        public string ProducerName { get; set; }
        public string ProductNo { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Vat { get; set; }
        public decimal VatSum { get; set; }
        public decimal VatPrice { get; set; }
        public decimal Total { get; set; }
        public decimal TotalWithVat { get; set; }

    }
}
