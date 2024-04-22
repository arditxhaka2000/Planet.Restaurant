using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class Update
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string version { get; set; }

        public int major { get; set; }
        public int minor { get; set; }
        public int build { get; set; }
        public int revision { get; set; }
        public string applicationName { get; set; }

        public string description { get; set; }

        public string createdBy { get; set; }
        public int status { get; set; }

        public string GetVerion()
        {
            return "" + major + "." + minor + "." + build + "." + revision;
        }

    }
}
