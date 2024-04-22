using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    public class Spaces : IBaseObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string station_id { get; set; }
        public string Status { get; set; }
        public string toDelete { get; set; }
        public string toUpdate { get; set; }

        public static List<Spaces> GetSpaces()
        {
            var item = Services.RestHepler<Spaces>.Search("RestaurantSpaces", "");

            return item;
        }

        public int Insert()
        {
            int rows = Services.RestHepler<Spaces>.Insert("RestaurantSpaces", this);
            return rows;
        }
        public int Update()
        {
            int rows = Services.RestHepler<Spaces>.Update("RestaurantSpaces", this);
            return rows;
        }
        //public int Delete()
        //{
        //    int rows = Services.RestHepler<Spaces>.Delete("RestaurantSpaces", this);
        //    return rows;
        //}
    }
}
