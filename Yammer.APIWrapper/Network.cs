using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Yammer.APIWrapper
{
    public class Network
    {
        [JsonProperty(PropertyName = "permalink")]
        public string PermaLink { get; set; }
        [JsonProperty(PropertyName = "web_url")]
        public string WebUrl { get; set; }
        [JsonProperty(PropertyName = "unseen_message_count")]
        public string UnseenMessageCount { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }        

        public class NetworkInfo : List<Network>
        {
            public DateTime TimeStamp = DateTime.Now;
        }

        public static NetworkInfo GetNetworkInfo()
        {
            NetworkInfo ni = new NetworkInfo();
            string response = Yammer.APIWrapper.HttpUtility.Get(Resources.Network.All);
            JArray array = JArray.Parse(response);

            foreach (JObject o in array)
            {
                Network n = JsonConvert.DeserializeObject<Network>(o.ToString());
                ni.Add(n);

            }           

            return ni;
        }        
    }
}
