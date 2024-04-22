using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class ItemsHistory
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        public string ProductNo { get; set; }
        public DateTime Date { get; set; }
        public string CompanyName { get; set; }
        public string Warehouse { get; set; }
        public string Type { get; set; }
        public decimal In { get; set; }
        public decimal Out { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithVat { get; set; }
    }
}
