using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNET.Pos
{
    public class TranslationEn
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("en")]
        public string translate { get; set; }


    }
    public class TranslationSq
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("sq")]
        public string translate { get; set; }


    }
    public class TranslationTr
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("tr")]
        public string translate { get; set; }


    }
    public partial class DataEn
    {
        [JsonProperty("data")]
        public IEnumerable<TranslationEn> dataWords { get; set; }
    }
    public partial class DataSq
    {
        [JsonProperty("data")]
        public IEnumerable<TranslationSq> dataWords { get; set; }
    }
    public partial class DataTr
    {
        [JsonProperty("data")]
        public IEnumerable<TranslationTr> dataWords { get; set; }
    }
}

