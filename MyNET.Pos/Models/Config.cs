using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Pos.Models
{
    public class Config
    {
        public string LocalServerHost { get; set; }
        public int LocalServerPort { get; set; }
        public int StationId { get; set; }

        public int ParentStationId { get; set; }

        public string DeviceId { get; set; }

    }
}
