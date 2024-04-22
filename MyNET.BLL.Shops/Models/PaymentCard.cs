using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class PaymentCard
    {
        public int Id { get; set; }
        public int No { get; set; }
        public DateTime Date { get; set; }
        public string CompanyName { get; set; }
        public string PartnerId { get; set; }
        public string Description { get; set; }
        public string Arka { get; set; }
        public string Banka { get; set; }
        public string PaymentType { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Out { get; set; }
        public decimal Saldo { get; set; }
    }
}
