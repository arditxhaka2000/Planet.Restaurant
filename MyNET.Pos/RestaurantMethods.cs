using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using MyNET.Pos.Modules;

namespace MyNET.Pos
{
    
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class RestaurantMethods
    {
        public string No { get; set; }
        public static int GetInitialTableCount()
        {
            return Services.Tables.GetTables().Count;
        }
    }
}
