using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SavedPOS : IBaseObj
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public decimal TotalSum { get; set; }
        public int ArticleNr { get; set; }
        public int StationId { get; set; }

        public static List<SavedPOS> GetAllSavedPOS()
        {
            return RestHepler<SavedPOS>.Search("savedPOS", "");
        }
        public int Insert()
        {
            int rows = Services.RestHepler<SavedPOS>.Insert("savedPOS", this);
            return rows;
        }
        public static void DeleteSavedPOS(string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Id = id });
            Services.RestHepler<Models.TablesSaleDetails>.RestaurantQuery("deleteSavedPos", jsonParams);

        }
    }
}
