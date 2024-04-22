using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Services.Models;

namespace Services
{
    public class StationService
    {
        public static Station Get(int id)
        {
            Station item = Services.RestHepler<Station>.Get("stations", id);
            return item;
        }

        /// <summary>
        /// Get all items by type
        /// </summary>
        /// <returns>List of stations</returns>
        ///
        //public static List<Station> GetByType(string type)
        //{
        //    List<Station> items = Services.RestHepler<Station>.Search("stations", "type=pos");
        //    return items;
        //}


        public static List<Station> GetByType()
        {
            return RestHepler<Station>.Select("GetByType", "");
        }

        public static int UpdateLastInvoiceNumber(long lastInvoiceNumber, int stationId)
        {
            string json = JsonConvert.SerializeObject(new { LastInvoiceNumber = lastInvoiceNumber, Id = stationId });
            int rows = Services.RestHepler<Station>.Query("UpdateLastInvoiceNumber", json);
            return rows;
        }

        public static bool LockUserStation(int userId, string deviceId,int PosType)
        {
            string json = JsonConvert.SerializeObject(new { userId = userId, deviceId = deviceId, PosType = PosType });
            int noRows = Services.RestHepler<Station>.Query("LockUserStation", json);
            return noRows > 0;
        }

        public static bool UnLockUserStation(int userId, string deviceId)
        {
            string json = JsonConvert.SerializeObject(new { userId = userId, deviceId = deviceId });
            int rows = Services.RestHepler<Station>.Query("UnLockUserStation", json);
            return rows > 0;
        }
        public static bool DeleteCurrentUser(string deviceId)
        {
            string json = JsonConvert.SerializeObject(new { deviceId = deviceId });
            int rows = Services.RestHepler<Station>.Query("DeleteCurrentUser", json);
            return rows > 0;
        }

        public static bool IsStationLocked(int userId, string deviceId)
        {
            string searchParams = "&userId=" + userId;// + "&deviceId=" + deviceId;
            var items = Services.RestHepler<UserStation>.Select("GetUserStations", searchParams).ToList();
            if (items.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool GetUserStationsByDeviceId(string deviceId)
        {
            string searchParams = "&deviceId=" + deviceId;
            var items = Services.RestHepler<UserStation>.Select("GetUserStationsByDeviceId", searchParams).ToList();
            if (items.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

}
