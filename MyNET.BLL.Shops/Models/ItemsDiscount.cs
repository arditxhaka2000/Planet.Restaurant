using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class ItemsDiscount
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PriceWithVat { get; set; }
        public int Vat { get; set; }
        public int CategoryId { get; set; }
        public string Unit { get; set; }
        public decimal Discount { get; set; }       
        public decimal Quantity { get; set; }
        public int Status { get; set; }
        public byte[] BlobData { get; set; }
    }
}
