using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Services
{
    [XmlRoot("Res")]
    public class Res
    {
        public string Code { get; set; }

        [XmlElement("settings")]
        public List<settings> Settings { get; set; }
    }
    public class settings
    {
        [XmlElement("defVer")]
        public string defVer { get; set; }
    }
}
