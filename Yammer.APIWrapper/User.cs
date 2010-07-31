using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;

namespace Yammer.APIWrapper
{
    public class User
    {
        #region Yammer Properties

        /// <summary>
        /// The object type.
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
        /// The username of this user.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The user's full name.
        /// </summary>
        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// The URL of this user's picture.
        /// </summary>
        [JsonProperty(PropertyName = "mugshot_url")]
        public string MugshotUrl { get; set; }

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
        /// User's job title
        /// </summary>
        [JsonProperty(PropertyName = "job_title")]
        public string JobTitle { get; set; }

        /// <summary>
        /// User location
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// User's contact information
        /// </summary>
        [JsonProperty(PropertyName = "contact")]
        public Contact Contact { get; set; }

        /// <summary>
        /// Collection of external URLs for the user
        /// </summary>
        /// <example>http://www.linkedin.com/pub/b/577/abb</example>
        [JsonProperty(PropertyName = "external_urls")]
        public List<string> ExternalUrls { get; set; }

        /// <summary>
        /// Previous companies user has worked at
        /// </summary>
        public List<Company> PreviousCompanies { get; set; }

        /// <summary>
        /// Schools user has attended
        /// </summary>
        public List<School> Schools { get; set; }

        // User's birthdate
        [JsonProperty(PropertyName = "birth_date")]
        public string BirthDate { get; set; }

        /// <summary>
        /// User's date of hire
        /// </summary>
        [JsonProperty(PropertyName = "hire_date")]
        public string HireDate { get; set; }

        /// <summary>
        /// The user's interests/hobbies
        /// </summary>
        [JsonProperty(PropertyName = "interests")]
        public string Interests { get; set; }

        /// <summary>
        /// The user's expertise
        /// </summary>
        [JsonProperty(PropertyName = "expertise")]
        public string Expertise { get; set; }

        /// <summary>
        /// A summary about the user
        /// </summary>
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// The timezone of the user
        /// </summary>
        [JsonProperty(PropertyName = "timezone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// User's state
        /// </summary>
        /// <example>active</example>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// The network id of the user
        /// </summary>
        [JsonProperty(PropertyName = "network_id")]
        public string NetworkId { get; set; }

        /// <summary>
        /// The network name of the user
        /// </summary>
        [JsonProperty(PropertyName = "network_name")]
        public string NetworkName { get; set; }

        /// <summary>
        /// Collection of domains for the user's network
        /// </summary>
        public List<string> NetworkDomains { get; set; }

        /// <summary>
        /// User's stats
        /// </summary>
        [JsonProperty(PropertyName = "stats")]
        public Stats Stats { get; set; }

        #endregion

        private static List<Token> m_network_tokens;
        public static List<Token> NetworkTokens
        {
            get
            {
                if (m_network_tokens == null)
                    m_network_tokens = Token.GetNetworkTokens();

                return m_network_tokens;
            }

            set
            {
                m_network_tokens = value;
            }
        }

        public static User GetCurrent()
        {
            string response = Json.GetCurrent();
            User user = JsonConvert.DeserializeObject<User>(response);

            return user;
        }

        public static List<User> GetAllUsers()
        {
            string response = Json.GetAllUsers(); 
            return JsonConvert.DeserializeObject<List<User>>(response); 
        }

        public static List<User> GetAllUsers(MembershipParameters membershipParams)
        {
            string response = Json.GetAllUsers(membershipParams);
            return JsonConvert.DeserializeObject<List<User>>(response); 
        }

        public System.Drawing.Image GetAvatar(string url)
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

        public static User GetUserById(string id)
        {
            string response = Json.GetUserById(id);
            return JsonConvert.DeserializeObject<User>(response); 
        }

        public static User GetUserByEmail(string email)
        {
            string response = Json.GetUserByEmail(email);
            List<User> list = JsonConvert.DeserializeObject<List<User>>(response);

            return list.Count == 1 ? list.First() : null;         
        }

        public static void CreateUser(UserParameters userParams) 
        {
            string response = Json.CreateUser(userParams);
        }

        public static void ModifyUser(string id, UserParameters userParams)
        {
            string response = Json.ModifyUser(id, userParams); 
        }

        public static void DeleteUser(string id) 
        {
            string response = Json.DeleteUser(id);
        }

        public static void SuspendUser(string id)
        {
            string response = Json.SuspendUser(id); 
        }

        public static User InviteUser(string email)
        {
            string response = Json.InviteUser(email);
            return JsonConvert.DeserializeObject<User>(response); 
        }

        public void Create(UserParameters userParams)
        {
            User.CreateUser(userParams);
        }

        public void Modify(UserParameters userParams)
        {
            User.ModifyUser(this.Id, userParams);
        }

        public void Delete()
        {
            DeleteUser(this.Id);
        }

        public void Suspend()
        {
            SuspendUser(this.Id);
        }

        public bool SubscribedTo()
        {
            bool subscribed = false;
            try
            {                
                string response = HttpUtility.Get(Resources.Subscriptions.ToUser(this.Id));
                if (response.Trim() != string.Empty)
                    subscribed = true;
            }
            catch (WebException ex)
            {
                if (ex.Status != WebExceptionStatus.ProtocolError)
                    throw ex;
            }

            return subscribed;
        }

        public void Subscribe()
        {
            User.Subscribe(this);
        }

        public void UnSubscribe()
        {
            User.UnSubscribe(this);
        }

        public Message AtMessage(string text)
        {            
            Yammer.APIWrapper.Message msg = Yammer.APIWrapper.Message.Post(string.Format("{0}{1} {2}", "@", this.Name, text));
            return msg;
        }

        public Message DirectMessage(string text)
        {
            Yammer.APIWrapper.Message msg = Yammer.APIWrapper.Message.PostDirectMessage(int.Parse(this.Id), text);
            return msg;
        }

        public static void Subscribe(User user)
        {           
            Json.Subscribe(user);
        }

        public static void UnSubscribe(User user)
        {       
            Json.UnSubscribe(user);
        }

        public static List<User> GetRelationships()
        {
            string response = Json.GetRelationships();
            JObject obj = JObject.Parse(response);
            var _superiors = from s in obj["superiors"] select s;
            var _subordinates = from s in obj["subordinates"] select s;
            List<User> relationships = new List<User>();

            foreach (var u in _superiors)
            {
                User user = JsonConvert.DeserializeObject<User>(u.ToString());
                user.Type = "superior";
                relationships.Add(user);
            }

            foreach (var u in _subordinates)
            {
                User user = JsonConvert.DeserializeObject<User>(u.ToString());
                user.Type = "subordinate";
                relationships.Add(user);
            }

            return relationships;
             
        }

        public static void GetSuggestions(out List<User> users, out List<Group> groups)
        {
            string response = Json.GetSuggestions(); 

            JArray obj = JArray.Parse(response);

            users = new List<User>();
            groups = new List<Group>();        
           
            foreach (JObject o in obj)
            {
                string type = o["suggested"]["type"].Value<string>();
                if (type == "user")
                    users.Add(JsonConvert.DeserializeObject<User>(o["suggested"].ToString()));
                else if (type == "group")
                    groups.Add(JsonConvert.DeserializeObject<Group>(o["suggested"].ToString()));
            }           
        }

        public static List<Yammer.APIWrapper.User> GetSuggestedUsers()
        {
            string response = Json.GetSuggestedUsers();

            JArray obj = JArray.Parse(response);
            List<User> users = new List<User>();

            foreach (JObject o in obj)
            {
                users.Add(JsonConvert.DeserializeObject<User>(o["suggested"].ToString()));               
            }

            return users;
        }

        public static List<Yammer.APIWrapper.Group> GetSuggestedGroups()
        {
            string response = Json.GetSuggestedGroups(); 

            JArray obj = JArray.Parse(response);
            List<Group> groups = new List<Group>();

            foreach (JObject o in obj)
            {
                groups.Add(JsonConvert.DeserializeObject<Group>(o["suggested"].ToString()));
            }

            return groups;
        }

        public static void DeclineSuggestion(string id)
        {
            string response = Json.DeclineSuggestion(id); 
        }

        public static void CreateRelationship(User user, RelationshipType type)
        {
            Json.CreateRelationship(user, type);
        }

        public void SetAsSubordinate()
        {
            Yammer.APIWrapper.User.CreateRelationship(this, RelationshipType.SUBORDINATE);
        }

        public void SetAsSuperior()
        {
            Yammer.APIWrapper.User.CreateRelationship(this, RelationshipType.SUPERIOR);
        }

        public void SetAsColleague()
        {
            Yammer.APIWrapper.User.CreateRelationship(this, RelationshipType.COLLEAGUE);
        }

        public void DeleteRelationship(RelationshipType type)
        {
            User.DeleteRelationship(this, type);
        }

        public static void DeleteRelationship(User user, RelationshipType type)
        {
            Json.DeleteRelationship(user, type);
        }
        
        public static void SwitchNetwork(string networkName)
        {
            Yammer.APIWrapper.Network network = Yammer.APIWrapper.Network.GetNetworkInfo().FirstOrDefault(n => n.Name == networkName);
            
            if (network != null)
            {              
                Token token = NetworkTokens.FirstOrDefault(t => t.NetworkId == network.Id);

                if (token != null)
                {
                    Settings settings = Settings.CheckConfiguration();
                    string tk = settings.OAuth.TokenKey;
                    string ts = settings.OAuth.TokenSecret;

                    if (tk != token.Key || ts != token.Secret)
                    {
                        Settings.SaveConfiguration(token.Key, token.Secret, Session.Auth.Key, Session.Auth.Proxy);
                        Session.Settings = Settings.CheckConfiguration();
                    }                    
                }               
            }           
        }
        
        public override bool Equals(object obj)
        {
            return this.Id == ((User)obj).Id;
        }

        public override string ToString()
        {
            return string.Format("Id:{0}, Name:{1}, Email:{2}", this.Id, this.FullName, this.Contact.EmailAddresses.FirstOrDefault(e => e.Type == "primary").Address);
        }

        public class Json
        {
            User _user;

            public Json(User user)
            {
                _user = user;
            }

            public static string GetCurrent()
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Users.Current);
            }

            public static string GetAllUsers()
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Users.All);
            }

            public static string GetAllUsers(MembershipParameters membershipParams)
            {
                NameValueCollection parameters = Yammer.APIWrapper.MembershipParameters.AddMembershipParams(membershipParams);
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Users.All, parameters);               
            }

            public static string GetUserById(string id)
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Users.Get(id));       
            }

            public static string GetUserByEmail(string email)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("email", email);
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Users.ByEmail, parameters);                
            }

            public static string CreateUser(UserParameters userParams)
            {
                NameValueCollection parameters = new NameValueCollection();
                UserParameters.AddUserParam(parameters, userParams);
                return Yammer.APIWrapper.HttpUtility.Post(Resources.Users.Create, parameters, true);
            }

            public static string ModifyUser(string id, UserParameters userParams)
            {
                NameValueCollection parameters = new NameValueCollection();
                UserParameters.AddUserParam(parameters, userParams);
                return Yammer.APIWrapper.HttpUtility.Put(Resources.Users.Modify(id), parameters);
            }

            public static string DeleteUser(string id)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("delete", "true");
                return Yammer.APIWrapper.HttpUtility.Delete(Resources.Users.Delete(id), parameters);
            }

            public static string SuspendUser(string id)
            {
                NameValueCollection parameters = new NameValueCollection();
                return Yammer.APIWrapper.HttpUtility.Delete(Resources.Users.Delete(id), parameters);
            }

            public static string InviteUser(string email)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("email", email);
                return Yammer.APIWrapper.HttpUtility.Post(Resources.Users.Invite, parameters);         
            }

            public string Create(UserParameters userParams)
            {
                return CreateUser(userParams);
            }

            public string Modify(UserParameters userParams)
            {
                return ModifyUser(this._user.Id, userParams);
            }

            public string Delete()
            {
                return DeleteUser(this._user.Id);
            }

            public string Suspend()
            {
                return SuspendUser(this._user.Id);
            }

            public string SubscribedTo()
            {
                return HttpUtility.Get(Resources.Subscriptions.ToUser(this._user.Id));                
            }

            public void Subscribe()
            {
                Json.Subscribe(this._user);
            }

            public void UnSubscribe()
            {
                User.UnSubscribe(this._user);
            }

            public string AtMessage(string text)
            {
                return Yammer.APIWrapper.Message.Json.Post(string.Format("{0}{1} {2}", "@", this._user.Name, text));
            }

            public string DirectMessage(string text)
            {
                return Yammer.APIWrapper.Message.Json.PostDirectMessage(int.Parse(this._user.Id), text);
            }

            public static string Subscribe(User user)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("target_type", "user");
                parameters.Add("target_id", user.Id);
                return Yammer.APIWrapper.HttpUtility.Post(Resources.Subscriptions.Subscribe, parameters);
            }

            public static string UnSubscribe(User user)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("target_type", "user");
                parameters.Add("target_id", user.Id);
                return Yammer.APIWrapper.HttpUtility.Delete(Resources.Subscriptions.Unsubscribe, parameters);
            }

            public static string GetRelationships()
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Relationships.Get);         
            }

            public static string GetSuggestions()
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Suggestions.All);
            }

            public static string GetSuggestedUsers()
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Suggestions.Users);
            }

            public static string GetSuggestedGroups()
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Suggestions.Groups);
            }

            public static string DeclineSuggestion(string id)
            {
                return Yammer.APIWrapper.HttpUtility.Delete(Resources.Suggestions.Decline(id));
            }

            public static string CreateRelationship(User user, RelationshipType type)
            {
                string email = user.Contact.EmailAddresses.FirstOrDefault(e => e.Type == "primary").Address;
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("user_id", user.Id);
                parameters.Add(type.ToString().ToLower(), email);
                return Yammer.APIWrapper.HttpUtility.Post(Resources.Relationships.Add, parameters);
            }

            public string SetAsSubordinate()
            {
                return CreateRelationship(this._user, RelationshipType.SUBORDINATE);
            }

            public string SetAsSuperior()
            {
                return CreateRelationship(this._user, RelationshipType.SUPERIOR);
            }

            public string SetAsColleague()
            {
                return CreateRelationship(this._user, RelationshipType.COLLEAGUE);
            }

            public string DeleteRelationship(RelationshipType type)
            {
                return DeleteRelationship(this._user, type);
            }

            public static string DeleteRelationship(User user, RelationshipType type)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("relationship_type", type.ToString().ToLower());
                return Yammer.APIWrapper.HttpUtility.Delete(Resources.Relationships.Delete(user.Id), parameters);
            }            
        }
    }
}
 