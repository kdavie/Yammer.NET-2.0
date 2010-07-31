using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;

namespace Yammer.APIWrapper
{
    public class Tag
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
        /// Tag stats
        /// </summary>
        [JsonProperty(PropertyName = "stats")]
        public Stats Stats { get; set; }

        /// <summary>
        /// Short text identifier
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

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

        public static List<Tag> GetAllTagsInNetwork()
        {
            return JsonConvert.DeserializeObject<List<Tag>>(Json.GetAllTagsInNetwork());
        }

        public static Tag GetTagDetail(int tagId)
        {
            return JsonConvert.DeserializeObject<Tag>(Json.GetTagDetail(tagId));
        }

        public void Subscribe()
        {
            Tag.Subscribe(this);
        }

        public void UnSubscribe()
        {
            Tag.UnSubscribe(this);
        }

        public static void Subscribe(Tag tag)
        {
            Json.Subscribe(tag);
        }

        public static void UnSubscribe(Tag tag)
        {
            Json.UnSubscribe(tag);
        }

        public bool SubscribedTo()
        {
            bool subscribed = false;
            try
            {

                string response = HttpUtility.Get(Resources.Subscriptions.ToTag(this.Id));
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

        public class Json
        {
            Tag _tag;

            public Json(Tag tag)
            {
                _tag = tag;
            }

            public static string GetAllTagsInNetwork()
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Tags.AllTagsInNetwork);
            }

            public static string GetTagDetail(int tagId)
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Tags.Detail(tagId.ToString()));
            }

            public void Subscribe()
            {
                Tag.Subscribe(this._tag);
            }

            public void UnSubscribe()
            {
                Tag.UnSubscribe(this._tag);
            }

            public static string Subscribe(Tag tag)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("target_type", "tag");
                parameters.Add("target_id", tag.Id);
                return Yammer.APIWrapper.HttpUtility.Post(Resources.Subscriptions.Subscribe, parameters);
            }

            public static string UnSubscribe(Tag tag)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("target_type", "tag");
                parameters.Add("target_id", tag.Id);
                return Yammer.APIWrapper.HttpUtility.Delete(Resources.Subscriptions.Unsubscribe, parameters);
            }

            public string SubscribedTo()
            {
                return HttpUtility.Get(Resources.Subscriptions.ToTag(this._tag.Id));             
            }
        }
    }
}
