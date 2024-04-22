using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Services.Models
{
    public class ItemsDiscount : INamedObj
    {
        public int Id { get; set; }
        public string Name { get { return ItemName; } set { } }
        public int No { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public string ProductNo { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal SalePrice { get { return RetailPrice; } set { } }
        public decimal PriceWithVat { get; set; }
        public string TotalPrice { get { return Math.Round(SalePrice + (SalePrice * Vat / 100), 2).ToString(); } set { } }
        public int Vat { get; set; }
        public int CategoryId { get; set; }
        public int Nen_Category { get; set; }
        public int Favorite { get; set; }
        public int Location { get; set; }
        public string Unit { get; set; }
        public decimal Discount { get; set; }
        public string Cover { get; set; }
        public Image image { get; set; }
        public decimal Quantity { get; set; }

        public Warehouse warehouse{get{return Warehouse.GetbyId(Id); } set{ }}
        public string IdItem { get { return$"{Id}\r\n{ItemName}"; } set { } }
        public decimal Sasia { get { return warehouse != null ? warehouse.InStock : 0; } set { } }
        public int Status { get; set; }
        public int Active { get; set; }
        public int Service { get; set; }
        public string ToDisplay { get { return $"{ItemName} - {TotalPrice}€"; } }
       

    }
}
