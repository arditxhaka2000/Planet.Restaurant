using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class SalesBook
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public string InvoiceNo { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public string SaveAs { get; set; }
        public string FiscalNo { get; set; }
        public string Project { get; set; }
        public decimal Total { get; set; }
    }
}
