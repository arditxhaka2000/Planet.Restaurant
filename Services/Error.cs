using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public class Error : IBaseObj
    {
        public int Id { get; set; }
        public int Company_Id { get; set; }
        public int Station_Id { get; set; }
        public string File { get; set; }
        public string Message { get; set; }
        public string Line { get; set; }

        //public int Status { get; set; }

        public int Insert()
        {
            int rows = Services.RestHepler<Error>.Insert("error", this);
            return rows;
        }
        public static void InsertError(int compnayId, int StationId, string message, string file, string line)
        {
            string jsonParams = JsonConvert.SerializeObject(new { Company_Id = compnayId, Station_Id = StationId, File = file, Message = message, Line = line });

            RestHepler<Services.Error>.Query("insertError", jsonParams);
        }
    }
}
