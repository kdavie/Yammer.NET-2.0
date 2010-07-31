using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;

namespace Yammer.APIWrapper
{
    public class Autocomplete
    {
        public static void Suggest(string prefix, out List<User> users, out List<Group> groups, out List<Tag> tags)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("prefix", prefix);

            string response = Yammer.APIWrapper.HttpUtility.Get(Resources.AutoComplete.Suggestion, parameters);
            JObject obj = JObject.Parse(response);

            users = null;
            groups = null;
            tags = null;

            if (obj["users"] != null)
            {
                users = new List<User>();
                foreach (var u in (from s in obj["users"] select s))
                {
                    User user = JsonConvert.DeserializeObject<User>(u.ToString());
                    users.Add(user);
                }
            }

            if (obj["groups"] != null)
            {
                groups = new List<Group>();
                foreach (var g in (from s in obj["groups"] select s))
                {
                    Group group = JsonConvert.DeserializeObject<Group>(g.ToString());
                    groups.Add(group);
                }
            }

            if (obj["tags"] != null)
            {
                tags = new List<Tag>();
                foreach (var t in (from s in obj["tags"] select s))
                {
                    Tag tag = JsonConvert.DeserializeObject<Tag>(t.ToString());
                    tags.Add(tag);
                }
            }
        }
    }
}
