using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class UserStation
    {
        public int StationId { get; set; }
        public int UserId { get; set; }

        public string DeviceId { get; set; }
        public int PosType { get; set; }


        public static UserStation Get(int userId)
        {
            string searchParams = "&userId=" + userId;// + "&deviceId=" + deviceId;

            var items = Services.RestHepler<UserStation>.Select("GetUserStations", searchParams).ToList();
            return items.FirstOrDefault();
        } 
        public static void insertPosType(int userId,int type )
        {
            string jsonParams = JsonConvert.SerializeObject(new { PosType = type, userId = userId });
            Services.RestHepler<UserStation>.Query("insertUserPosType", jsonParams);
        }
    }
}
