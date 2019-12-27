using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opalapi.data
{
    public class user
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string salutation { get; set; }
        public string address { get; set; }
        public string emailid { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
