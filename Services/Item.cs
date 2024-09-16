using Newtonsoft.Json;
using RestSharp;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Item:IBaseObj, Services.Models.INamedObj
    {
        #region Public Properties

        public int Id { get; set; } 

        public string ProductNo { get; set; }

        public string Barcode { get; set; }

        public int CategoryId { get; set; }
        public int Nen_Category { get; set; }
        public int Favorite { get; set; }


        public string Unit { get; set; }

        public int ProducerId { get; set; }
        public int Location { get; set; }

        public string ItemName { get; set; }

        public string Description { get; set; }
        public string Cover { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal InStock { get; set; }

        public int Duty { get; set; }

        public int Vat { get; set; }

        public decimal Akciza { get; set; }

        public bool ItemGoods { get; set; }

        public bool Service { get; set; }

        public bool Expense { get; set; }

        public bool InventoryItem { get; set; }

        public bool Material { get; set; }

        public bool Production { get; set; }

        public bool Assembled { get; set; }

        public bool Expired { get; set; }
        public string CreatedBy { get; set; }

        public DateTime ChangedAt { get; set; }

        public string ChangedBy { get; set; }

        public int Status { get; set; }
        public string Name { get { return ItemName; } set { }}
        public string TotalPrice { get { return Math.Round(RetailPrice + (RetailPrice * Vat / 100), 2).ToString(); } set { } }



        #endregion

        public Item()
        {

        }

       
        #region public static Get Methods

        /// <summary>
        /// Get object from database, by primary key
        /// </summary>
        public static Item Get(int id)
        {
            var item = RestHepler<Item>.Get("items", id);
            return item;
        }
        

        /// <summary>
        /// Get all objects from table
        /// </summary>
        /// <returns>List of objects</returns>
        public static List<Services.Models.ItemsDiscount> GetItemsDiscount(int stationId)
        {
            string selectParams = "stationId=" + stationId;
            return RestHepler<Services.Models.ItemsDiscount>.Select("getitemsdiscount", selectParams);
        }
        public static List<Item> GetFav(int fav)
        {
            string selectParams = "favorite=" + fav;
            return RestHepler<Item>.Select("getFav", selectParams);
        }
        public static List<Services.Models.ItemsDiscount> GetItemWithBarcode(string barc)
        {
            string selectParams = "Barcode=" + barc;
            return RestHepler< Services.Models.ItemsDiscount>.Select50itemsOnly("getItemWBarcode", selectParams);
        }
        public static List<Services.Models.ItemsDiscount> GetItemWithName(string searchStr)
        {
            string[] words = searchStr.Split(' ');

            string encodedSearchStr = "%" + string.Join("%", words) + "%";

            encodedSearchStr = System.Web.HttpUtility.UrlEncode(encodedSearchStr);

            string selectParams = "searchstr=" + encodedSearchStr;

            return RestHepler<Services.Models.ItemsDiscount>.Select50itemsOnly("getItemWNameProductId", selectParams);
        }

        public static List<Services.Models.ItemsDiscount> GetItemWithNameOrBarcode(string searchstr)
        {
            string encodedSearchStr = System.Web.HttpUtility.UrlEncode("%" + searchstr + "%");
            string selectParams = "searchstr=" + encodedSearchStr;
            return RestHepler< Services.Models.ItemsDiscount>.Select50itemsOnly("getItemWithNameOrBarcode", selectParams);
        }
        public static List<Models.ItemsDiscount> GetAllItem()
        {   
            return RestHepler<Models.ItemsDiscount>.Select("getAll","");
        } 
        public static void UpdateActiveItem(int active, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Active = active, Id = id });
            Services.RestHepler<Item>.Query("changeStatusItem", jsonParams);
        } 
        public static List<Models.ItemsDiscount> GetAllItemSS()
        {   
            return RestHepler<Models.ItemsDiscount>.Select("getItemsWithPosStock", "");
        }
        public static List<Models.ItemsDiscount> GetAllItemDetails()
        {   
            return RestHepler<Models.ItemsDiscount>.Select("getAllForDetails", "");
        }
        public static List<Models.ItemsDiscount> GetById(int id)
        {
            string selectParams = "Id=" + id;

            return RestHepler<Models.ItemsDiscount>.Select("getById", selectParams);
        }
        
        

        #endregion

        #region Insert, Update and Delete

        /// <summary>
        /// Inserts object in table
        /// </summary>
        /// <returns>Return number of rows affected</returns>
        public int Insert()
        {
             return -1;
        }

        /// <summary>
        /// Update object in table
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            return -1;
        }
        public void UpdateFav(int Fav, int ida)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Favorite = Fav, id = ida });
            Services.RestHepler<Item>.Query("updateFav", jsonParams);

        }
        public void UpdateFavAll1()
        {
            Services.RestHepler<Item>.Select("updateFavAll", "");

        }
        public void UpdateFavAll0()
        {
            Services.RestHepler<Item>.Select("updateFavAl", "");

        }

        /// <summary>
        /// Delete object from table. 
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            return -1;
        }
       
        #endregion
    }
}
