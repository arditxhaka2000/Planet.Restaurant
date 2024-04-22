using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class Response<T>
    {
        public bool success { get; set; }
        public string errorMsg { get; set; }
        public T data { get; set; }
    }
}
