using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Response<T>
    {
        public bool success { get; set; }
        public ApiError error { get; set; }
        public List<T> data { get; set; }
        public int noOfRowsAffected { get; set; }
    }

    public class ApiError
    {
        public int errno { get; set; }
        public string message { get; set; }
        public string code { get; set; }
    }
}
