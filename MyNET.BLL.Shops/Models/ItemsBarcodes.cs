using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class ItemsBarcodes
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        public decimal RetailPrice { get; set; }
        public string Image { get; set; }
    }
}
