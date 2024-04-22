using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Models
{
    public class UpdateDetails
    {
        public Update update { get; set; }

        public List<FilesDetails> listoffiles { get; set; }
    }


    public class FilesDetails
    {
        public string baseFolder { get; set; }
        public string fileWithoutBaseFolder { get; set; }
    }
}
