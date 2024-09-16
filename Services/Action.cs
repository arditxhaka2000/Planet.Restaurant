using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Services.Models;

namespace Services
{
    public class Action : INamedObj
    {

        public ActionArticle[] article { get; set; }
        public ActionBrand[] brand { get; set; }
        public ActionCategory[] category { get; set; }
        public ActionCollection[] collection { get; set; }
        public int id { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int item_id { get; set; }
        public decimal quantity { get; set; }
        public int group_item { get; set; }
        public string relacion { get; set; }
        public int item_number { get; set; }
        public string item_name { get; set; }
        public int brand_id { get; set; }
        public string brand_name { get; set; }
        public int category_id { get; set; }
        public string category_name { get; set; }
        public int collection_id { get; set; }
        public string collection_name { get; set; }
        public string unit { get; set; }
        public decimal discount { get; set; }
        public int client_category { get; set; }
        public string client_category_name { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TotalPrice { get; set; }

        public class ActionArticle
        {
            public int id { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public int item_id { get; set; }
            public int group_item { get; set; }
            public string relacion { get; set; }
            public int item_number { get; set; }
            public string item_name { get; set; }

            [JsonProperty("item_unit")]
            public string unit { get; set; }
            public decimal quantity { get; set; }
            public decimal discount { get; set; }
            public int client_category { get; set; }
            public string client_category_name { get; set; }

        }
        public class ActionBrand
        {
            public int id { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public int brand_id { get; set; }
            public string brand_name { get; set; }
            public decimal quantity { get; set; }
            public decimal discount { get; set; }
            public string unit { get; set; }
            public int client_category { get; set; }
            public string client_category_name { get; set; }
        }
        public class ActionCategory
        {
            public int id { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public int category_id { get; set; }
            public string category_name { get; set; }
            public decimal quantity { get; set; }
            public decimal discount { get; set; }
            public string unit { get; set; }
            public int client_category { get; set; }
            public string client_category_name { get; set; }
        }
        public class ActionCollection
        {
            public int id { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public int collection_id { get; set; }
            public string collection_name { get; set; }
            public decimal quantity { get; set; }
            public decimal discount { get; set; }
            public string unit { get; set; }
            public int client_category { get; set; }
            public string client_category_name { get; set; }
        }


        public static List<Action> Get()
        {
            var action = Services.RestHepler<Action>.Search("action", "");

            return action;
        }

    }
}
    

    

