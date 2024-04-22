using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class WarehouseItems 
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public string ProductNo { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public decimal Purchases { get; set; }
        public decimal Sales { get; set; }
        public decimal Quantity { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Total { get; set; }
        public decimal Totali { get; set; }
    }
}
