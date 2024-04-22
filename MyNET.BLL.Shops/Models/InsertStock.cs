using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class InsertStock
    {
        public int Id { get; set; }
        public int No { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public int ProjectId { get; set; }
        //public string ProductNo { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public string Project { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }

        public decimal Markup { get; set; }
        public decimal MazhaPrice { get; set; }
        public decimal SubTotal { get; set; }

        public decimal Transport { get; set; }
        public decimal TransportPercent { get; set; }
        public decimal TransportPricePerUnit { get; set; }

        public decimal OverValue { get; set; }
        public decimal OverValuePercent { get; set; }
        public decimal OverValuePricePerUnit { get; set; }

        public int Duty { get; set; }
        public decimal DutyPricePerUnit { get; set; }
        public decimal DutyValue { get; set; }

        public decimal Excise { get; set; }
        public decimal ExcisePercent { get; set; }
        public decimal ExcisePricePerUnit { get; set; }

        public decimal PurchasePrice { get; set; }
        public int Vat { get; set; }
        public decimal PurchasePriceWithVat { get; set; }

        public decimal Total { get; set; }
        public decimal Totali { get; set; }
        public decimal TotalWithOverValue { get; set; }
        public decimal VatSum { get; set; }
        public decimal TotalWithVat { get; set; }

        public int Status { get; set; }

    }
}
