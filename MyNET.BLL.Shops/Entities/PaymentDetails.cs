using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Entities
{
    public abstract class PaymentDetails
    {
        public int PaymentId { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
