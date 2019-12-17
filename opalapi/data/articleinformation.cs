using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opalapi.data
{
    public class articleinformation
    {
        [JsonProperty(PropertyName = "id")]
        // public string Id { get; set; }
        public string id { get; set; }
        public string articletitle { get; set; }
        public string weburl { get; set; }
        public string fileurl { get; set; }
        public string publication { get; set; }
        public string publisheddate { get; set; }
        public string revisionnumber { get; set; }
        public string published { get; set; }
        public string summary { get; set; }
        public string author { get; set; }
        public string uploadedby { get; set; }
        public string bibliography { get; set; }
        public string category { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
