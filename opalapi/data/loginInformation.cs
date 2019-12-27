using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace opalapi.data
{
    public class loginInformation
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        public string emailid { get; set; }
        public string password { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
