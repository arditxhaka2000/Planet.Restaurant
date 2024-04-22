using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class DailyBalance
    {
        //StationId,
        //
        //
        //
        //
        //
        //
        //
        //,Date, Amount,Status
        public int No { get; set; }
        public string Status { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }        
        public int StationId { get; set; }
        public decimal TotalShitje { get; set; }
        public decimal TotalCash { get; set; }
        public decimal TotalCreditCard { get; set; }
        public int DailyFiscalCount { get; set; }

    }
}
