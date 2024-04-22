using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class TransferItemsDetails
    {
        #region Public Properties

        public int Id { get; set; }

        public int TransferItemsId { get; set; }

        public int No { get; set; }

        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string Unit { get; set; }

        public int ProjectId { get; set; }

        public decimal Quantity { get; set; }

        public decimal AvgPrice { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal Total { get; set; }

        public DateTime AmountPaid { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ChangedAt { get; set; }

        public string ChangedBy { get; set; }

        public int Status { get; set; }

        #endregion
    }
}
