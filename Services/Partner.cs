using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Partner : IBaseObj
    {
        #region properties

        public int Id { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string CompanyName { get; set; }
        public string SaveAs { get; set; }
        public int PartnerType { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Comment { get; set; }
        public string BusinessNo { get; set; } 
        public string FiscalNo { get; set; }
        public string UniqueNo { get; set; }
        public string Email { get; set; }
        public string VatNo { get; set; } 
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } 
        public DateTime ChangedAt { get; set; }
        public string ChangedBy { get; set; } 
        public int Status { get; set; }
        public decimal Discount { get; set; }
        #endregion

        public static Partner Get(int id)
        {
            return RestHepler<Partner>.Get("partners", id);
        }
        public static Partner GetSid(int sId)
        {
            return RestHepler<Partner>.Get("partners", sId);
        }

        public static List<Partner> Search(string searchParams)
        {
            return RestHepler<Partner>.Search("partners", searchParams);
        }
        public static List<Partner> GetLastIdPartner()
        {
           
            var a = Services.RestHepler<Partner>.Select("GetLastParterId", "");

            return a;
        }
        public static List<Services.Partner> GetPartnersWithNameOrPhone(string searchStr)
        {
            string[] words = searchStr.Split(' ');

            string encodedSearchStr = "%" + string.Join("%", words) + "%";

            encodedSearchStr = System.Web.HttpUtility.UrlEncode(encodedSearchStr);

            string selectParams = "searchstr=" + encodedSearchStr;

            return RestHepler<Services.Partner>.Select50itemsOnly("getBonusCardName", selectParams);
        }

        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
            int rows = Services.RestHepler<Partner>.Insert("partners", this);
            return rows;
        }

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            int rows = Services.RestHepler<Partner>.Update("partners", this);
            return rows;
        }
        public static void updateEmail(int id, string email)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Id = id, Email = email });
            Services.RestHepler<Partner>.Query("updateEmail", jsonParams);
        }

        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        //public int Delete(string username = "")
        //{
        //    int rows = Services.RestHepler<Partner>.Delete("partners", this);
        //    return rows;
        //}

        #endregion

    }
}
