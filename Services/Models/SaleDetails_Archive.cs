using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Models
{
    public class SaleDetails_Archive
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public int No { get; set; }
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        //public string ProducerName { get; set; }
        //public string ProductNo { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityNow { get; set; }
        public decimal Price { get; set; }

        public decimal AvgPrice { get; set; }
        public decimal CategoryId { get; set; }

        public decimal CostOfGoods { get; set; }

        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }

        public decimal DiscountPriceWithVat { get; set; }

        public decimal TotalWithVatAvg { get; set; }

        public int Vat { get; set; }
        public decimal VatSum { get; set; }
        public decimal VatPrice { get; set; }
        public decimal Total { get; set; }
        public decimal TotalWithVat { get; set; }
        public decimal ClientDiscount { get; set; }
        public int Status { get; set; }
        public int PrintedQuantity { get; set; }
        public bool ForReturn { get; set; }
        public string ItemNumber { get; set; }
        public string DiscountAmount { get; set; } = "0";
        public string PosId { get;set; }
    }
}
