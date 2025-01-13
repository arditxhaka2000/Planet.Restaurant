using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Models;

namespace Services
{
    public class ItemCategory : INamedObj
    {
        #region Public Properties

        public int Id { get; set; }

        public string Name{ get; set; }
        public string TotalPrice { get; set; }

        public int ParentId { get; set; }
        public string ThermalName { get; set; }


        #endregion


        public static List<ItemCategory> Get()
        {
            return RestHepler<ItemCategory>.Search("ItemsCategories","parentId=0");

            //List<Category> retlist = new List<Category>();
           
            //var cat1 = new Category() { Id = 1, Name = "Pije" };
            //var cat2 = new Category() { Id = 2, Name = "Ushqim" };
           
            //retlist.Add(cat1); retlist.Add(cat2);

            //var cat3 = new Category() { Id = 3, Name = "Cat3" };
            //var cat4 = new Category() { Id = 4, Name = "Cat4" };
            //retlist.Add(cat3); retlist.Add(cat4);
            //return retlist;
        }

        public static List<ItemCategory> SubCategories(int param)
        {
            string searchParams = "parentid=" + param;
            return Services.RestHepler<ItemCategory>.Search("ItemsCategories", searchParams);
         


        }

    }
}
