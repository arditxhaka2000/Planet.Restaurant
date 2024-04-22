using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class SalesBookVat
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public string Reference { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime Date { get; set; }
        public string SaveAs { get; set; }
        public string FiscalNo { get; set; }
        public string Project { get; set; }
        public decimal Total { get; set; }
        public decimal Vat8 { get; set; }
        public decimal Vat18 { get; set; }
        public decimal VatSum { get; set; }
        public decimal TotalWithVat { get; set; }
    }
}
