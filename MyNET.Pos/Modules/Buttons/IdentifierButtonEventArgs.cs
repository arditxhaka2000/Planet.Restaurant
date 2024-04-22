using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Pos.Modules
{
    public class IdentifierButtonEventArgs
    {
        public IdentifierButtonEventArgs(int id)
        {
            Identifier = id;
            //Name = name;
        }



        public int Identifier { get; set; }
        //public string Name { get; set; }
    }
}
