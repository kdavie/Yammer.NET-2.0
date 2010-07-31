using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Yammer.APIWrapper
{
    public class Search
    {
        public static Search DoSearch(string text, int page)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("search", text);
            parameters.Add("page", page.ToString());
            string response = Yammer.APIWrapper.HttpUtility.Get(Resources.Search.DoSearch, parameters);
            Search search = JsonConvert.DeserializeObject<Search>(response);
            search.Messages = Message.ReadMessages(JObject.Parse(response)["messages"].ToString());

            return search;
        }

        public static Search DoSearch(string text, int page, int numerOfResults)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("search", text);
            parameters.Add("page", page.ToString());
            parameters.Add("num_per_page", numerOfResults.ToString());
            string response = Yammer.APIWrapper.HttpUtility.Get(Resources.Search.DoSearch, parameters);
            Search search = JsonConvert.DeserializeObject<Search>(response);
            search.Messages = Message.ReadMessages(JObject.Parse(response)["messages"].ToString());

            return search;
        }

        [JsonProperty(PropertyName = "count")]
        public Results Count;

        [JsonIgnore]
        public List<Message> Messages;

        [JsonProperty(PropertyName = "groups")]
        public List<Group> Groups;

        [JsonProperty(PropertyName = "tags")]
        public List<Tag> Tags;

        [JsonProperty(PropertyName = "users")]
        public List<User> Users;

        public class Results
        {
            [JsonProperty(PropertyName = "groups")]
            public int Groups;

            [JsonProperty(PropertyName = "messages")]
            public int Messages;

            [JsonProperty(PropertyName = "tags")]
            public int Tags;

            [JsonProperty(PropertyName = "users")]
            public int Users;
        }
 

       
    }

    
}
