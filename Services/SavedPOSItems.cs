using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SavedPOSItems : IBaseObj
    {
        public int Id { get; set; }
         public int ItemId { get; set; }
         public int POSId { get; set; }

        public int Insert()
        {
            int rows = Services.RestHepler<SavedPOSItems>.Insert("savedPOSItems", this);
            return rows;
        }
        public static List<SavedPOSItems> GetWithPOSId(int posId)
        {
            string searchParams = "POSId=" + posId;

            return RestHepler<SavedPOSItems>.Search("savedPOSItems", searchParams);
        }
    }
}
