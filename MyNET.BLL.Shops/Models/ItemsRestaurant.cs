using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Shops.Models
{
    public class ItemsRestaurant
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        public byte[] Image { get; set; }
        public override string ToString()
        {
            return $"{ItemName}, {Barcode}";
        }
    }
}
