using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OverallObj : IBaseObj
    {
        public Sale sale { get; set; }
        public long LastInvoiceNumber { get; set; }
        public int stationId { get; set; }
        public int id_saler { get; set; }
        public long saleId { get; set; }
        public int dailyId { get; set; }
        public int DailyFiscalCount { get; set; }
        public decimal TotalShitje { get; set; }
        public decimal TotalCash { get; set; }
        public decimal TotalCreditCard { get; set; }
        public string status { get; set; }
        public int Id { get; set; }

        public int UpdateA()
        {
            int rows = Services.RestHepler<OverallObj>.InsertSale("sales", this);
            return rows;
        }

        public OverallObj()
        {
            this.sale = new Sale();
        }
    }
}
