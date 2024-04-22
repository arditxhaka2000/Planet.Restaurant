using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class SalesList
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string FiscalNo { get; set; }
        public DateTime Date { get; set; }
        public string SaveAs { get; set; }
        public string InvoiceNo { get; set; }
        public string SalesTypeId { get; set; }
        public decimal TotalSum { get; set; }
        public decimal VatSum { get; set; }
        public decimal TotalWithVat { get; set; }
        
    }
}
