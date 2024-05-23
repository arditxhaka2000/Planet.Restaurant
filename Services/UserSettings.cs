using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserSettings
    {
        public UserSettings ()
        {

        }         

        #region properties

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
        public string Theme { get; set; }

        #endregion

        public static UserSettings Get(int id)
        {
            var userS = Services.RestHepler<UserSettings>.Get("usersettings", id);
            return userS;
        }
        public static void InsertTheme(string theme,int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Theme = theme, Id = id});
            Services.RestHepler<Models.TablesSaleDetails>.Query("InsertThemePreference", jsonParams);
        }
        #region Update

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        /// 
        public int Insert()
        {
            return -1;

        }

        public int Update()
        {
            return -1;
        }

        #endregion
    }
}
