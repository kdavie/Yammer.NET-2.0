using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Yammer.APIWrapper
{
    public class Thread
    {
        /// <summary>
        /// The object type, such as user, tag, etc.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The ID number for this object. Note that IDs are not unique across all object types: 
        /// there may be a user and tag with the same numerical ID.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The API resource for fetching this object.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The URL for viewing this object on the main Yammer website.
        /// </summary>
        [JsonProperty(PropertyName = "web_url")]
        public string WebUrl { get; set; }

        /// <summary>
        /// Thread stats
        /// </summary>

        [JsonProperty(PropertyName = "stats")]
        public ThreadStats Stats { get; set; }
    }
    [Serializable]
    public class ThreadStats
    {
        [JsonProperty(PropertyName = "updates")]
        public string Updates { get; set; }

        [JsonProperty(PropertyName = "latest_reply_at")]
        public string LastestReplyAt { get; set; }
    }
}
