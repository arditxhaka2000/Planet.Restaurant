using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    internal class ItemCategory
    {
        public int Id { get; set; }
        public string Name { get { return ItemCategoryName; } set { } }
        public string ItemCategoryName { get; set; }
    }
}
