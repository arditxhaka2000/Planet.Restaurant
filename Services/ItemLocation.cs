using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ItemLocation
    {
        #region Public Properties

        public int Id { get; set; }

        public string Name { get; set; }


        #endregion


        public static List<ItemLocation> Get()
        {
            return RestHepler<ItemLocation>.Search("ItemLocation", "");
        }
    }
}
