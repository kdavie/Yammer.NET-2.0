using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Yammer.APIWrapper
{
    public class Stats
    {
        [JsonProperty(PropertyName = "updates")]
        public string Updates { get; set; }

        [JsonProperty(PropertyName = "followers")]
        public string Followers { get; set; }

        [JsonProperty(PropertyName = "following")]
        public string Following { get; set; }
    }
}
