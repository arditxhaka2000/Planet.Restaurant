using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BonusCard : IBaseObj
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal TotalPoints { get; set; }
        public decimal CurrentPoints { get; set; }
        public decimal PointsToEur { get; set; }
        public decimal TotalPointsValue { get; set; }
        public decimal CurrentPointsValue { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountP { get; set; }
        
        public static BonusCard Get(int id)
        {
            return RestHepler<BonusCard>.Get("BonusCard", id);
        }
        public static List<BonusCard> Search(string searchParams)
        {
            return RestHepler<BonusCard>.Search("BonusCard", searchParams);
        }
        public int Insert()
        {
            int rows = Services.RestHepler<BonusCard>.Insert("BonusCard", this);
            return rows;
        }
        public int checkBonusCard(int partnerid, string type)
        {
            string searchParams = "&PartnerId=" + partnerid + "&Type=" + type;
            var row = Services.RestHepler<int>.SelectCount("checkBonusCard", searchParams);
            return row;
        }
        public static void UpdateTotalAmountBonusCard(decimal amount, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { TotalAmount = amount, Id = id });
            Services.RestHepler<BonusCard>.Query("updateTotalAmountBonusCard", jsonParams);
        }
        public static void UpdateCurrentAmountBonusCard(decimal amount, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { CurrentAmount = amount, Id = id });
            Services.RestHepler<BonusCard>.Query("updateCurrentAmountBonusCard", jsonParams);
        }
        public static void UpdateTotalPointsValueBonusCard(decimal amount, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { TotalPointsValue = amount, Id = id });
            Services.RestHepler<BonusCard>.Query("updateTotalPointsValueBonusCard", jsonParams);
        }
        public static void UpdateCurrentPointsValueBonusCard(decimal amount, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { CurrentPointsValue = amount, Id = id });
            Services.RestHepler<BonusCard>.Query("updateCurrentPointsValueBonusCard", jsonParams);
        }
        public static void UpdateTotalPointsBonusCard(decimal points, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { TotalPoints = points, Id = id });
            Services.RestHepler<BonusCard>.Query("updateTotalPointsBonusCard", jsonParams);
        }
        public static void UpdateCurrentPointsBonusCard(decimal points, int id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { CurrentPoints = points, Id = id });
            Services.RestHepler<BonusCard>.Query("updateCurrentPointsBonusCard", jsonParams);
        }
        public static List<BonusCard> GetBonusCardWithNumberOrPartner(string searchStr)
        {
            //string[] words = searchStr.Split(' ');

            //string encodedSearchStr = "%" + string.Join("%", words) + "%";

            //encodedSearchStr = System.Web.HttpUtility.UrlEncode(encodedSearchStr);

            //string selectParams = "searchstr=" + encodedSearchStr;

            string selectParams = "searchstr=" + searchStr;

            return RestHepler<BonusCard>.Select50itemsOnly("searchBonusCard", selectParams);
        }
        public static BonusCard GetWithName(string number)
        {
            string searchParams = "&Number=" + number;
            var cards = Services.RestHepler<BonusCard>.Search("BonusCard", searchParams);
            if (cards.Count > 0)
            {
                return cards.First();
            }
            else
            {
                return null;
            }
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }

            return stringBuilder.ToString();
        }

    }
}
