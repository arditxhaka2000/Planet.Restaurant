using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BonusCardTemplate : IBaseObj
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Points { get; set; }
        public decimal PointsToEur { get; set; }
        public decimal PointsValue { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountP { get; set; }

        public int Insert()
        {
            int rows = Services.RestHepler<BonusCardTemplate>.Insert("BonusCardTemplate", this);
            return rows;
        }
        public int checkBonusCardTemplateP(decimal points, string type)
        {
            string searchParams = "&Type=" + type + "&Points=" + points;
            var row = Services.RestHepler<int>.SelectCount("checkBonusCardTemplateP", searchParams);
            return row;
        }
        public int checkBonusCardTemplateD(decimal discount, string type)
        {
            string searchParams = "&Type=" + type + "&Discount=" + discount;
            var row = Services.RestHepler<int>.SelectCount("checkBonusCardTemplateD", searchParams);
            return row;
        }
        public static List<BonusCardTemplate> Search(string searchParams)
        {
            return RestHepler<BonusCardTemplate>.Search("BonusCardTemplate", searchParams);
        }
        public int Delete(int id)
        {
            int rows = Services.RestHepler<BonusCardTemplate>.Delete("BonusCardTemplate", id);
            return rows;
        }
    }
}
