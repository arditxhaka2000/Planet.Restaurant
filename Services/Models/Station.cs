using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Station
    {
        public int Id { get; set; }

        public int Level { get; set; }
        public int ParentId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Tel { get; set; }
        //public string Fax { get; set; }
        //public string Web { get; set; }
        //public string Email { get; set; }
        public bool Warehouse { get; set; }
        public bool Enabled { get; set; }

        public long LastInvoiceNumber { get; set; }
        public int Status { get; set; }

        public static void UpdateStationStatus(int status, string id)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Status = status, Id = id });
            Services.RestHepler<Station>.Query("stationStatus", jsonParams);

        }

    }
}
