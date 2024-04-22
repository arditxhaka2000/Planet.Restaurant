using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class UserSettings
    {

        public UserSettings ()
        {

        } 

        public UserSettings(MyNET.DAL.UserSettings us)
        {
            this.Id = us.Id;
            this.UserId = us.UserId;
            this.Style = us.Style;
            this.AllowToChangeSalePrice = us.AllowToChangeSalePrice;
            this.DigitsOnDetails = us.DigitsOnDetails;
            this.Digits = us.Digits;
            this.SearchStatus = us.SearchStatus;
            this.AllowToChangeWarehouse = us.AllowToChangeWarehouse;
            this.BackupPath = us.BackupPath;
            this.AllowToDelete = us.AllowToDelete;
        }

        public static implicit operator UserSettings(MyNET.DAL.UserSettings us)
        {
            return new UserSettings(us);
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public bool AllowToChangeSalePrice { get; set; }
        public string Style { get; set; }
        public int DigitsOnDetails { get; set; }
        public int Digits { get; set; }
        public bool SearchStatus { get; set; }
        public bool AllowToChangeWarehouse { get; set; }
        public bool AllowToDelete { get; set; }
        public int StationId { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string BackupPath { get; set; }
    }
}
