using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace Yammer.APIWrapper
{
    public class Group
    {
        #region Yammer Properties

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
        /// Name given to this group.
        /// </summary>
        [JsonProperty(PropertyName = "full-name")]
        public string FullName { get; set; }

        /// <summary>
        /// Shortened name of this group. Used in references (@salesteam), addressing (to:salesteam), 
        /// the email address for group updates (salesteam@yammer.com) and the web URL (www.yammer.com/groups/salesteam). 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Either public or private, to indicate whether updates are visible to non-members 
        /// (public) and whether joining requires a group admin's approval (private). 
        /// </summary>
        [JsonProperty(PropertyName = "privacy")]
        public string Privacy { get; set; }

        /// <summary>
        /// The API resource for fetching this object.
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The URL for viewing this object on the main Yammer website.
        /// </summary>
        [JsonProperty(PropertyName = "web-url")]
        public string WebUrl { get; set; }

        /// <summary>
        /// The URL of this group's picture.
        /// </summary>
        [JsonProperty(PropertyName = "mugshot_url")]
        public string MugshotUrl { get; set; }

        /// <summary>
        /// Group stats
        /// </summary>
        [JsonProperty(PropertyName = "stats")]
        public GroupStats Stats { get; set; }

        #endregion

    
        public static List<Group> GetAllMyGroups()
        {
            return JsonConvert.DeserializeObject<List<Group>>(Json.GetAllMyGroups());
        }

        public static List<Group> GetAllMyGroups(MembershipParameters groupParams)
        {
            return JsonConvert.DeserializeObject<List<Group>>(Json.GetAllMyGroups(groupParams));
        }

        public static List<Group> GetAllGroups()
        {
            return JsonConvert.DeserializeObject<List<Group>>(Json.GetAllGroups());
        }

        public static List<Group> GetAllGroups(MembershipParameters groupParams)
        {
            return JsonConvert.DeserializeObject<List<Group>>(Json.GetAllGroups(groupParams));
        }        

        public static Group GetGroupById(int id)
        {
            return JsonConvert.DeserializeObject<Group>(Json.GetGroupById(id));
        }

        public void Join()
        {
            Group.JoinGroup(int.Parse(this.Id));
        }

        public static void JoinGroup(int id)
        {
            Json.JoinGroup(id);
        }

        public void Leave()
        {
            Group.LeaveGroup(int.Parse(this.Id));
        }

        public static void LeaveGroup(int id)
        {
            Json.LeaveGroup(id);
        }

        public static Group CreateGroup(string name, PrivacyFlag flag)
        {
            Group g = null;
            string response = Json.CreateGroup(name, flag);
            Uri uri;
            bool successful = Uri.TryCreate(response, UriKind.Absolute, out uri);

            if (successful)
            {
                string groupId = uri.Segments[uri.Segments.Length - 1];
                g = Yammer.APIWrapper.Group.GetGroupById(int.Parse(groupId));
            }
            
            return g;
        }

        public void Modify(string name, PrivacyFlag flag)
        {
            Group.ModifyGroup(int.Parse(this.Id), name, flag);
            this.Name = name;
            this.Privacy = flag.ToString().ToLower();
        }

        public static Group ModifyGroup(int groupId, string name, PrivacyFlag flag)
        {
            bool p = flag == PrivacyFlag.Private ? false : true;
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("name", name);
            parameters.Add("private", p.ToString());
            string response = Json.ModifyGroup(groupId, name, flag);
            return Yammer.APIWrapper.Group.GetGroupById(groupId);
        }

        public static System.Drawing.Image GetAvatar(string url)
        {
            try
            {
                return HttpUtility.GetImage(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override string ToString()
        {
            return String.Format("Name:{0}, Members:{1}, Updates:{2}", this.Name, this.Stats.Members, this.Stats.Updates);
        }

        public override bool Equals(object obj)
        {
            return this.Id == ((Group)obj).Id;
        }
    }

    public class GroupStats
    {
        [JsonProperty(PropertyName = "members")]
        public string Members { get; set; }

        [JsonProperty(PropertyName = "updates")]
        public string Updates { get; set; }
    }

    public class Json
    {
        Group _group;

        public Json(Group group)
        {
            _group = group;
        }

        public static string GetAllMyGroups()
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("mine", "1");
            string response = Yammer.APIWrapper.HttpUtility.Get(Resources.Groups.All, parameters);
            return response;
        }

        public static string GetAllMyGroups(MembershipParameters groupParams)
        {
            MembershipParameters.AddMembershipParams(groupParams);
            MembershipParameters.Parameters.Add("mine", "1");
            string response = Yammer.APIWrapper.HttpUtility.Get(Resources.Groups.All, MembershipParameters.Parameters);
            return response;
        }

        public static string GetAllGroups()
        {
            string response = Yammer.APIWrapper.HttpUtility.Get(Resources.Groups.All);
            return response;
        }

        public static string GetAllGroups(MembershipParameters groupParams)
        {
            MembershipParameters.AddMembershipParams(groupParams);
            string response = Yammer.APIWrapper.HttpUtility.Get(Resources.Groups.All, MembershipParameters.Parameters);
            return response;
        }

        public static string GetGroupById(int id)
        {
            string response = Yammer.APIWrapper.HttpUtility.Get(Resources.Groups.Detail(id.ToString()));
            return response;
        }

        public void Join()
        {
            Group.JoinGroup(int.Parse(this._group.Id));
        }

        public static string JoinGroup(int id)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("group_id", id.ToString());
            string response = Yammer.APIWrapper.HttpUtility.Post(Resources.Groups.Join, parameters);
            return response;
        }

        public void Leave()
        {
            Group.LeaveGroup(int.Parse(this._group.Id));
        }

        public static string LeaveGroup(int id)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("group_id", id.ToString());
            string response = Yammer.APIWrapper.HttpUtility.Delete(Resources.Groups.Leave(id.ToString()), parameters);
            return response;
        }

        public static string CreateGroup(string name, PrivacyFlag flag)
        {
            Group g = null;
            bool p = flag == PrivacyFlag.Private ? true : false;
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("name", name);
            parameters.Add("private", p.ToString().ToLower());
            string response = Yammer.APIWrapper.HttpUtility.Post(Resources.Groups.Create, parameters, true);
            return response;
        }

        public void Modify(string name, PrivacyFlag flag)
        {
            Group.ModifyGroup(int.Parse(this._group.Id), name, flag);
            this._group.Name = name;
            this._group.Privacy = flag.ToString().ToLower();
        }

        public static string ModifyGroup(int groupId, string name, PrivacyFlag flag)
        {
            bool p = flag == PrivacyFlag.Private ? false : true;
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("name", name);
            parameters.Add("private", p.ToString());
            string response = Yammer.APIWrapper.HttpUtility.Put(Resources.Groups.Modify(groupId.ToString()), parameters);
            return response;
        }
    }
}
