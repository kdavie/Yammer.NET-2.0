using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Xml;

namespace Yammer.APIWrapper
{
    public class Message
    {
        #region All Messages

        /// <summary>
        /// All messages in this network. Corresponds to the "All" tab on the website.
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetAllMessages()
        {
            return ReadMessages(Json.GetAllMessages());            
        }

        /// <summary>
        /// All messages in this network. Corresponds to the "All" tab on the website.
        /// </summary>
        /// <param name="threaded">Return only the first message in each thread.</param>
        /// <returns></returns>
        public static List<Message> GetAllMessages(bool threaded)
        {
            return ReadMessages(Json.GetAllMessages(threaded));
        }


        /// <summary>
        /// Corresponds to the "All" tab on the website. 
        /// </summary>
        /// <param name="newer_than"></param>
        /// <returns></returns>
        public static List<Message> GetAllMessages(PageFlag flag, int id)
        {
            return ReadMessages(Json.GetAllMessages(flag, id));
        }

        /// <summary>
        /// Corresponds to the "All" tab on the website. 
        /// </summary>
        /// <param name="newer_than"></param>
        /// <param name="threaded">Return only the first message in each thread.</param>
        /// <returns></returns>
        public static List<Message> GetAllMessages(PageFlag flag, int id, bool threaded)
        {          
            return ReadMessages(Json.GetAllMessages(flag, id, threaded));
        }        

        #endregion

        #region Sent Messages

        /// <summary>
        /// Corresponds to the "Sent" tab on the website.
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetSentMessages()
        {
            return ReadMessages(Json.GetSentMessages());
        }

        /// <summary>
        /// Corresponds to the "Sent" tab on the website.
        /// </summary>
        /// <param name="threaded">Return only the first message in each thread.</param>
        /// <returns></returns>
        public static List<Message> GetSentMessages(bool threaded)
        {
            return ReadMessages(Json.GetSentMessages(threaded));
        }

        /// <summary>
        /// Corresponds to the "Sent" tab on the website.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="threaded"></param>
        /// <returns></returns>
        public static List<Message> GetSentMessages(PageFlag flag, int id)
        {
            return ReadMessages(Json.GetSentMessages(flag, id));
        }

        /// <summary>
        /// Corresponds to the "Sent" tab on the website.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="threaded"></param>
        /// <returns></returns>
        public static List<Message> GetSentMessages(PageFlag flag, int id, bool threaded)
        {
            return ReadMessages(Json.GetSentMessages(flag, id, threaded));
        }
        
        #endregion

        #region Received Messages

        /// <summary>
        /// Messages received by the logged-in user. Corresponds to the "Received" tab on the website.
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetReceivedMessages()
        {
            return ReadMessages(Json.GetReceivedMessages());
        }

        /// <summary>
        /// Messages received by the logged-in user. Corresponds to the "Received" tab on the website.
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetReceivedMessages(bool threaded)
        {
            return ReadMessages(Json.GetReceivedMessages(threaded));
        }

        /// <summary>
        /// Messages received by the logged-in user. Corresponds to the "Received" tab on the website.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="thread"></param>
        /// <returns></returns>
        public static List<Message> GetReceivedMessages(PageFlag flag, int id)
        {
            return ReadMessages(Json.GetReceivedMessages(flag, id));
        }

        /// <summary>
        /// Messages received by the logged-in user. Corresponds to the "Received" tab on the website.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="thread"></param>
        /// <returns></returns>
        public static List<Message> GetReceivedMessages(PageFlag flag, int id, bool threaded)
        {
            return ReadMessages(Json.GetReceivedMessages(flag, id, threaded));
        }

        #endregion

        #region Following Messages

        /// <summary>
        /// Messages followed by the logged-in user. Corresponds to the "Following" tab on the website.
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetFollowingMessages()
        {
            return ReadMessages(Json.GetFollowingMessages());
        }

        /// <summary>
        /// Messages followed by the logged-in user. Corresponds to the "Following" tab on the website.
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetFollowingMessages(bool threaded)
        {
            return ReadMessages(Json.GetFollowingMessages(threaded)); 
        }

        /// <summary>
        /// Messages followed by the logged-in user. Corresponds to the "Following" tab on the website.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Message> GetFollowingMessages(PageFlag flag, int id)
        {
            return ReadMessages(Json.GetFollowingMessages(flag, id));
        }

        /// <summary>
        /// Messages followed by the logged-in user. Corresponds to the "Following" tab on the website.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Message> GetFollowingMessages(PageFlag flag, int id, bool threaded)
        {
            return ReadMessages(Json.GetFollowingMessages(flag, id, threaded));
        }

        #endregion

        #region Liked Messages

        /// <summary>
        /// Messages liked by the logged-in user. Corresponds to the "Liked" tab on the website.
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetLikedMessages()
        {
            return ReadMessages(Json.GetLikedMessages()); 
        }

        /// <summary>
        /// Messages liked by the logged-in user. Corresponds to the "Liked" tab on the website.
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetLikedMessages(bool threaded)
        {
            return ReadMessages(Json.GetLikedMessages(threaded)); 
        }

        /// <summary>
        /// Messages liked by the logged-in user. Corresponds to the "Liked" tab on the website.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Message> GetLikedMessages(PageFlag flag, int id)
        {
            return ReadMessages(Json.GetLikedMessages(flag, id));
        }

        /// <summary>
        /// Messages liked by the logged-in user. Corresponds to the "Liked" tab on the website.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Message> GetLikedMessages(PageFlag flag, int id, bool threaded)
        {
            return ReadMessages(Json.GetLikedMessages(flag, id, threaded));
        }        

        #endregion

        #region Bookmarked Messages

        /// <summary>
        /// Messages bookmarked by the logged-in user. Corresponds to the "Bookmarked" tab on the website.
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetBookmarkedMessages()
        {
            return ReadMessages(Json.GetBookmarkedMessages()); 
        }

        /// <summary>
        /// Messages bookmarked by the logged-in user. Corresponds to the "Bookmarked" tab on the website.
        /// </summary>
        /// <returns></returns>
        public static List<Message> GetBookmarkedMessages(bool threaded)
        {
            return ReadMessages(Json.GetBookmarkedMessages(threaded)); 
        }

        /// <summary>
        /// Messages bookmarked by the logged-in user. Corresponds to the "Bookmarked" tab on the website.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Message> GetBookmarkedMessages(PageFlag flag, int id)
        {
            return ReadMessages(Json.GetBookmarkedMessages(flag, id));
        }

        /// <summary>
        /// Messages bookmarked by the logged-in user. Corresponds to the "Bookmarked" tab on the website.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Message> GetBookmarkedMessages(PageFlag flag, int id, bool threaded)
        {
            return ReadMessages(Json.GetBookmarkedMessages(flag, id, threaded));
        }

        #endregion

        #region Messages Sent By User

        /// <summary>
        /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesSentByUser(int id)
        {
            return ReadMessages(Json.GetMessagesSentByUser(id));
        }

        /// <summary>
        /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesSentByUser(int id, bool threaded)
        {
            return ReadMessages(Json.GetMessagesSentByUser(id, threaded));
        }

        /// <summary>
        /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesSentByUser(PageFlag flag, int id, int pageId)
        {
            return ReadMessages(Json.GetMessagesSentByUser(flag, id, pageId));
        }

        /// <summary>
        /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesSentByUser(PageFlag flag, int id, int pageId, bool threaded)
        {
            return ReadMessages(Json.GetMessagesSentByUser(flag, id, pageId, threaded));
        }
     
        #endregion

        #region Messages Sent By Bot

        /// <summary>
        /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesSentByBot(int id)
        {
            return ReadMessages(Json.GetMessagesSentByBot(id));
        }

        /// <summary>
        /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesSentByBot(int id, bool threaded)
        {
            return ReadMessages(Json.GetMessagesSentByBot(id, threaded));
        }

        /// <summary>
        /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesSentByBot(PageFlag flag, int id, int pageId)
        {
            return ReadMessages(Json.GetMessagesSentByBot(flag, id, pageId));
        }

        /// <summary>
        /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesSentByBot(PageFlag flag, int id, int pageId, bool threaded)
        {
            return ReadMessages(Json.GetMessagesSentByBot(flag, id, pageId, threaded));
        }

        #endregion

        #region Messages Tagged With

        /// <summary>
        /// Messages including the tag with given ID. Corresponds to the messages on a tag's page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesTaggedWith(int id)
        {
            return ReadMessages(Json.GetMessagesTaggedWith(id));
        }

        /// <summary>
        /// Messages including the tag with given ID. Corresponds to the messages on a tag's page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesTaggedWith(int id, bool threaded)
        {
            return ReadMessages(Json.GetMessagesTaggedWith(id, threaded));
        }

        /// <summary>
        /// Messages including the tag with given ID. Corresponds to the messages on a tag's page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesTaggedWith(PageFlag flag, int id, int pageId)
        {
            return ReadMessages(Json.GetMessagesTaggedWith(flag, id, pageId));
        }

        /// <summary>
        /// Messages including the tag with given ID. Corresponds to the messages on a tag's page on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesTaggedWith(PageFlag flag, int id, int pageId, bool threaded)
        {
            return ReadMessages(Json.GetMessagesTaggedWith(flag, id, pageId, threaded));
        }

        #endregion

        #region Messages in Group

        /// <summary>
        /// Messages in the group with the given ID. Corresponds to the messages you'd see on a group's profile page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesInGroup(int id)
        {
            return ReadMessages(Json.GetMessagesInGroup(id));
        }

        /// <summary>
        /// Messages in the group with the given ID. Corresponds to the messages you'd see on a group's profile page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesInGroup(int id, bool threaded)
        {
            return ReadMessages(Json.GetMessagesInGroup(id, threaded));
        }

        /// <summary>
        /// Messages in the group with the given ID. Corresponds to the messages you'd see on a group's profile page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesInGroup(PageFlag flag, int id, int pageId)
        {
            return ReadMessages(Json.GetMessagesInGroup(flag, id, pageId));
        }

        /// <summary>
        /// Messages in the group with the given ID. Corresponds to the messages you'd see on a group's profile page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesInGroup(PageFlag flag, int id, int pageId, bool threaded)
        {
            return ReadMessages(Json.GetMessagesInGroup(flag, id, pageId, threaded));
        }

        #endregion

        #region Messages Favorites Of

        /// <summary>
        /// Favorite messages of the given user ID. Can pass 'current' in place of user_id for currently logged in user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesFavoritesOf(int id)
        {
            return ReadMessages(Json.GetMessagesFavoritesOf(id));
        }

        /// <summary>
        /// Favorite messages of the given user ID. Can pass 'current' in place of user_id for currently logged in user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesFavoritesOf(int id, bool threaded)
        {
            return ReadMessages(Json.GetMessagesFavoritesOf(id, threaded));
        }

        /// <summary>
        /// Favorite messages of the given user ID. Can pass 'current' in place of user_id for currently logged in user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesFavoritesOf(PageFlag flag, int id, int pageId)
        {
            return ReadMessages(Json.GetMessagesFavoritesOf(flag, id, pageId));
        }

        /// <summary>
        /// Favorite messages of the given user ID. Can pass 'current' in place of user_id for currently logged in user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesFavoritesOf(PageFlag flag, int id, int pageId, bool threaded)
        {
            return ReadMessages(Json.GetMessagesFavoritesOf(flag, id, pageId, threaded));
        }

        #endregion

        #region Messages In Thread

        /// <summary>
        /// Messages in the thread with the given ID. Corresponds to the page you'd see when clicking on "in reply to" on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesInThread(int id)
        {
            return ReadMessages(Json.GetMessagesInThread(id));
        }

        /// <summary>
        /// Messages in the thread with the given ID. Corresponds to the page you'd see when clicking on "in reply to" on the website.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Message> GetMessagesInThread(PageFlag flag, int id, int pageId)
        {
            return ReadMessages(Json.GetMessagesInThread(flag, id, pageId));
        }      

        #endregion        

        #region Post Message

        #region Static

        public static Message Post(string body) 
        { 
            return Message.Post(body, new List<string>()); 
        }

        public static Message Post(string body, List<string> attachments)
        {
            List<Message> msg = ReadMessages(Json.Post(body, attachments));
            if (msg.Count == 1)
                return msg[0];
            else
                return null;
        }

        public static Message PostReply(int replyToId, string body)
        {
            return Message.PostReply(replyToId, body, new List<string>());
        }

        public static Message PostReply(int replyToId, string body, List<string> attachments)
        {
            List<Message> msg = ReadMessages(Json.PostReply(replyToId, body, attachments));
            if (msg.Count == 1)
                return msg[0];
            else
                return null;
        }

        public static Message PostDirectMessage(int directToId, string body)
        {
            return Message.PostDirectMessage(directToId, body, new List<string>());
        }

        public static Message PostDirectMessage(int directToId, string body, List<string> attachments)
        {
            List<Message> msg = ReadMessages(Json.PostDirectMessage(directToId, body, attachments));
            if (msg.Count == 1)
                return msg[0];
            else
                return null;
        }

        public static Message PostToGroup(int groupId, string body)
        {
            return Message.PostToGroup(groupId, body, new List<string>());
        }

        public static Message PostToGroup(int groupId, string body, List<string> attachments)
        {
            List<Message> msg = ReadMessages(Json.PostToGroup(groupId, body, attachments));
            if (msg.Count == 1)
                return msg[0];
            else
                return null;
        }

        public static Message PostBroadcastMessage(string body)
        {
            return Message.PostBroadcastMessage(body, new List<string>());
        }

        public static Message PostBroadcastMessage(string body, List<string> attachments)
        {
            List<Message> msg = ReadMessages(Json.PostBroadcastMessage(body, attachments));
            if (msg.Count == 1)
                return msg[0];
            else
                return null;
        }        
        
        #endregion

        #region Instance

        public Message Reply(string body)
        {
            Yammer.APIWrapper.Message msg = Yammer.APIWrapper.Message.PostReply(int.Parse(this.Id), body);
            return msg;
        }

        #endregion

        #endregion

        #region Delete Message

        public static void DeleteMessage(string messageId)
        {
            Json.DeleteMessage(messageId);
        }

        public void Delete()
        {
            Message.DeleteMessage(this.Id);
        }

        #endregion

        #region Favorites
        public static void AddMessageToFavorites(string messageId, string userId)
        {
            Json.AddMessageToFavorites(messageId, userId);
        }

        public static void RemoveMessageFromFavorites(string messageId, string userId)
        {
            Json.RemoveMessageFromFavorites(messageId, userId);
        } 
        #endregion

        #region Email
        public static void Email(string messageId)
        {
            Json.Email(messageId);
        } 
        #endregion        

        #region Yammer Properties

        /// <summary>
        /// The ID number for this object. Note that IDs are not unique across all object types: 
        /// there may be a user and tag with the same numerical ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// (Optional) When a message is posted into a group, that group's ID will appear here 
        /// and the group will be available in the references section.
        /// </summary>
        //[DataMember(Name="group-id")]
        [JsonProperty(PropertyName = "group_id")]
        public string GroupId { get; set; }

        /// <summary>
        /// (Optional) When a message is a private 1-to-1 (or "direct") message, this will 
        /// indicate the intended recipient.
        /// </summary>
        //[DataMember(Name="direct-to-id")]
        [JsonProperty(PropertyName = "direct_to_id")]
        public string DirectToId { get; set; }

        /// <summary>
        /// The API resource for fetching this object.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The URL for viewing this object on the main Yammer website.
        /// </summary>
        //[DataMember(Name="web-url")]
        [JsonProperty(PropertyName = "web_url")]
        public string WebUrl { get; set; }

        /// <summary>
        /// The ID of the message this message is in reply to, if applicable.
        /// </summary>
        //[DataMember(Name="replied-to-id")]
        [JsonProperty(PropertyName = "replied_to_id", NullValueHandling = NullValueHandling.Include)]
        public string RepliedToId { get; set; }

        /// <summary>
        /// The thread in which this message appears.
        /// </summary>
        //[DataMember(Name="thread-id")]
        [JsonProperty(PropertyName = "thread_id")]
        public string ThreadId { get; set; }

        /// <summary>
        /// Message body
        /// </summary>
        public Body Body { get; set; }

        /// <summary>
        /// A list of attachments for this message.
        /// </summary>
        [JsonProperty(PropertyName = "attachments")]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// This will be system or update. A system message is automatically generated by the 
        /// system and describes an action, such as "Kris Gale has joined the Geni network." 
        /// An update message is a regular message posted by a user such as "Kris Gale: Hi everyone." 
        /// Put simply, this indicates whether a colon will separate the body of the message 
        /// from the sender's name in the web interface.
        /// </summary>
        //[DataMember(Name="message-type")]
        [JsonProperty(PropertyName = "message_type")]
        public string MessageType { get; set; }


        //[DataMember(Name="client-type")]
        [JsonProperty(PropertyName = "client_type")]
        public string ClientType { get; set; }
        /// <summary>
        /// The ID of the message's sender.
        /// </summary>
        //[DataMember(Name="sender-id")]
        [JsonProperty(PropertyName = "sender_id")]
        public int SenderId { get; set; }

        /// <summary>
        /// The sender's object type: user or guide. The guide is virtual user that exists 
        /// in the system to send messages such as the tips and initial welcome message.
        /// </summary>
        //[DataMember(Name="sender-type")]
        [JsonProperty(PropertyName = "sender_type")]
        public string SenderType { get; set; }

        /// <summary>
        /// The time and date this resource was created. This would indicate when a 
        /// user joined the network or when a message was posted.
        /// </summary>
        //[DataMember(Name="created-at")]
        [JsonProperty(PropertyName = "created_at")]
        public string CreatedAt { get; set; }

        [JsonIgnore]
        public string Participants { get; set; }



        #endregion
        
        #region Client Properties

        private Reference references = new Reference();

        public Reference References
        {
            get { return references; }
            set { references = value; }
        }

        public Guide Guide
        {
            get
            {
                return this.References.Guide;
            }
        }

        public Message RepliedToMessage
        {
            get
            {
                var _message = this.References.Messages.FirstOrDefault(m => m.Id == this.RepliedToId);
                return _message != null ? _message : null;
            }
        }

        public User RepliedToUser
        {
            get
            {
                User user = null;
                if (RepliedToMessage != null)
                {
                    var _user = this.References.Users.FirstOrDefault(u => u.Id == this.RepliedToMessage.SenderId.ToString());
                    return _user != null ? _user : User.GetUserById(this.RepliedToMessage.SenderId.ToString());
                }

                return user;
            }

        }

        public User Sender
        {
            get
            {
                var _user = this.References.Users.FirstOrDefault(u => u.Id == this.SenderId.ToString());
                return _user != null ? _user : User.GetUserById(this.SenderId.ToString());
            }
        }

        public User Recipient
        {
            get
            {
                if (!string.IsNullOrEmpty(this.DirectToId))
                {
                    var _user = this.References.Users.FirstOrDefault(u => u.Id == this.DirectToId);

                    if (_user != null)
                        return _user;
                    else
                        return User.GetUserById(this.SenderId.ToString());
                }

                return null;
            }
        }
       

        #endregion

        #region Helper Methods

        private static void AddPageFlagParam(PageFlag pf, NameValueCollection parameters, int id)
        {
            if (pf == PageFlag.NEWER_THAN)
                parameters.Add("newer_than", id.ToString());
            else
                parameters.Add("older_than", id.ToString());
        }

        #region Message Parsing

        public static List<Message> ReadMessages(string data)
        {
            List<Message> messages = new List<Message>();
            try
            {
                JObject obj = JObject.Parse(data);

                var _msgs = from m in obj["messages"] select m;

                foreach (var item in _msgs)
                    messages.Add(JsonConvert.DeserializeObject<Message>(item.ToString()));

                IEnumerable<JToken> _msgRefs;
                IEnumerable<JToken> _userRefs;
                IEnumerable<JToken> _tagRefs;
                IEnumerable<JToken> _threadRefs;
                IEnumerable<JToken> _guideRefs;
                IEnumerable<JToken> _botRefs;
                IEnumerable<JToken> _groupRefs;

                ReadReferences(obj, out _msgRefs, out _userRefs, out _tagRefs, out _threadRefs, out _guideRefs, out _botRefs, out _groupRefs);

                ParseReferences(messages, _msgRefs, _userRefs, _tagRefs, _threadRefs, _guideRefs, _botRefs, _groupRefs);

            }
            catch (Exception ex)
            {
                throw;
            }

            return messages;
        }

        private static void ParseReferences(List<Message> messages, IEnumerable<JToken> _msgRefs, IEnumerable<JToken> _userRefs, IEnumerable<JToken> _tagRefs, IEnumerable<JToken> _threadRefs, IEnumerable<JToken> _guideRefs, IEnumerable<JToken> _botRefs, IEnumerable<JToken> _groupRefs)
        {
            foreach (var item in _msgRefs)
            {

                Message message = JsonConvert.DeserializeObject<Message>(item.ToString());
                Message test = messages.Find(delegate(Message m) { return m.RepliedToId != null ? m.RepliedToId == message.Id : false; });
                SetMessageReference(test, message);
            }

            foreach (var item in _userRefs)
            {


                User user = JsonConvert.DeserializeObject<User>(item.ToString());
                foreach (Message m in messages)
                    m.References.Users.Add(user);
            }

            foreach (var item in _tagRefs)
            {
                Tag tag = JsonConvert.DeserializeObject<Tag>(item.ToString());
                string tagText = "[[tag:" + tag.Id + "]]";
                List<Message> referencedMessages = messages.FindAll(delegate(Message m) { return m.Body.Parsed.Contains(tagText); });
                AddMessageReferences(referencedMessages, tag);
            }

            foreach (var item in _threadRefs)
            {
                Thread thread = JsonConvert.DeserializeObject<Thread>(item.ToString());
                AddMessageReferences(messages.FindAll(delegate(Message m) { return m.ThreadId == thread.Id; }), thread);
            }

            foreach (var item in _guideRefs)
            {
                Guide guide = JsonConvert.DeserializeObject<Guide>(item.ToString());
                SetMessageReference(messages.Find(delegate(Message m) { return m.SenderId.ToString() == guide.Id; }), guide);
            }

            foreach (var item in _botRefs)
            {
                Bot bot = JsonConvert.DeserializeObject<Bot>(item.ToString());
                AddMessageReferences(messages.FindAll(

                delegate(Message m)
                {

                    if (m.RepliedToUser != null)
                        return m.SenderId.ToString() == bot.Id || m.RepliedToUser.Id == bot.Id || m.DirectToId == bot.Id;
                    else
                        return m.SenderId.ToString() == bot.Id || m.DirectToId == bot.Id;
                }), bot);
            }

            foreach (var item in _groupRefs)
            {
                Group group = JsonConvert.DeserializeObject<Group>(item.ToString());
                AddMessageReferences(messages.FindAll(delegate(Message m) { return m.GroupId == group.Id; }), group);
            }

        }

        private static void ReadReferences(JObject obj, out IEnumerable<JToken> _msgRefs, out IEnumerable<JToken> _userRefs, out IEnumerable<JToken> _tagRefs, out IEnumerable<JToken> _threadRefs, out IEnumerable<JToken> _guideRefs, out IEnumerable<JToken> _botRefs, out IEnumerable<JToken> _groupRefs)
        {
            _msgRefs =
               from r in obj["references"]
               where r["type"].Value<string>() == "message"
               select r;

            _userRefs =
                from r in obj["references"]
                where r["type"].Value<string>() == "user"
                select r;

            _tagRefs =
                from r in obj["references"]
                where r["type"].Value<string>() == "tag"
                select r;

            _threadRefs =
                from r in obj["references"]
                where r["type"].Value<string>() == "thread"
                select r;

            _guideRefs =
                from r in obj["references"]
                where r["type"].Value<string>() == "guide"
                select r;

            _botRefs =
                from r in obj["references"]
                where r["type"].Value<string>() == "bot"
                select r;

            _groupRefs =
                from r in obj["references"]
                where r["type"].Value<string>() == "group"
                select r;
        }

        private static void SetMessageReference(Message message, Message reference)
        {
            if (message != null)
                message.References.Messages.Add(reference);

        }

        private static void SetMessageReference(Message message, Guide reference)
        {
            if (message != null)
                message.References.Guide = reference;
        }

        private static void AddMessageReferences(List<Message> messages, object reference)
        {
            if (messages != null)
            {
                User user;
                Tag tag;
                Thread thread;
                Group group;
                foreach (Message msg in messages)
                {
                    switch (ConvertReferenceType(reference, out user, out tag, out thread, out group))
                    {
                        case ObjectType.USER:
                            msg.References.Users.Add(user);
                            break;
                        case ObjectType.THREAD:
                            msg.References.Thread = thread;
                            break;
                        case ObjectType.TAG:
                            msg.References.Tags.Add(tag);
                            break;
                        case ObjectType.GROUP:
                            msg.References.Group = group;
                            break;
                    }
                }
            }

        }

        private static ObjectType ConvertReferenceType(object reference, out User user, out Tag tag, out Thread thread, out Group group)
        {
            user = null;
            tag = null;
            thread = null;
            group = null;
            user = reference as User;
            ObjectType type = ObjectType.NONE;
            try
            {
                bool converted = false;
                if (user != null) { converted = true; type = ObjectType.USER; }
                if (!converted)
                {
                    thread = reference as Thread;
                    if (thread != null) { converted = true; type = ObjectType.THREAD; }
                    if (!converted)
                    {
                        tag = reference as Tag;
                        if (tag != null) { converted = true; type = ObjectType.TAG; }
                        if (!converted)
                        {
                            group = reference as Group;
                            if (group != null) { converted = true; type = ObjectType.GROUP; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return type;
        }

        #endregion

        #endregion        

        public override bool Equals(object obj)
        {
            return this.Id == ((Message)obj).Id;
        }

        public class Json
        {
            #region All Messages

            /// <summary>
            /// All messages in this network. Corresponds to the "All" tab on the website.
            /// </summary>
            /// <returns>Response in Json format</returns>
            public static string GetAllMessages()
            {
                return HttpUtility.Get(Resources.Messages.All);
            }

            /// <summary>
            /// All messages in this network. Corresponds to the "All" tab on the website.
            /// </summary>
            /// <param name="threaded">Return only the first message in each thread.</param>
            /// <returns>Response in Json format</returns>
            public static string GetAllMessages(bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.All, parameters);
            }

            /// <summary>
            /// Corresponds to the "All" tab on the website. 
            /// </summary>
            /// <param name="newer_than"></param>
            /// <returns>Response in Json format</returns>
            public static string GetAllMessages(PageFlag flag, int id)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, id);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.All, parameters);
            }

            /// <summary>
            /// Corresponds to the "All" tab on the website. 
            /// </summary>
            /// <param name="newer_than"></param>
            /// <param name="threaded">Return only the first message in each thread.</param>
            /// <returns>Response in Json format</returns>
            public static string GetAllMessages(PageFlag flag, int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, id);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.All, parameters);
            }

            #endregion

            #region Sent Messages

            /// <summary>
            /// Corresponds to the "Sent" tab on the website.
            /// </summary>
            /// <returns>Response in Json format</returns>
            public static string GetSentMessages()
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Sent);
            }

            /// <summary>
            /// Corresponds to the "Sent" tab on the website.
            /// </summary>
            /// <param name="threaded">Return only the first message in each thread.</param>
            /// <returns>Response in Json format</returns>
            public static string GetSentMessages(bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Sent, parameters);
            }

            /// <summary>
            /// Corresponds to the "Sent" tab on the website.
            /// </summary>
            /// <param name="flag"></param>
            /// <param name="threaded"></param>
            /// <returns>Response in Json format</returns>
            public static string GetSentMessages(PageFlag flag, int id)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, id);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Sent, parameters);
            }

            /// <summary>
            /// Corresponds to the "Sent" tab on the website.
            /// </summary>
            /// <param name="flag"></param>
            /// <param name="threaded"></param>
            /// <returns>Response in Json format</returns>
            public static string GetSentMessages(PageFlag flag, int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, id);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Sent, parameters);
            }
            #endregion

            #region Received Messages

            /// <summary>
            /// Messages received by the logged-in user. Corresponds to the "Received" tab on the website.
            /// </summary>
            /// <returns>Response in Json format</returns>
            public static string GetReceivedMessages()
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Received);
            }

            /// <summary>
            /// Messages received by the logged-in user. Corresponds to the "Received" tab on the website.
            /// </summary>
            /// <returns>Response in Json format</returns>
            public static string GetReceivedMessages(bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Received, parameters);
            }

            /// <summary>
            /// Messages received by the logged-in user. Corresponds to the "Received" tab on the website.
            /// </summary>
            /// <param name="flag"></param>
            /// <param name="thread"></param>
            /// <returns>Response in Json format</returns>
            public static string GetReceivedMessages(PageFlag flag, int id)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, id);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Received, parameters);
            }

            /// <summary>
            /// Messages received by the logged-in user. Corresponds to the "Received" tab on the website.
            /// </summary>
            /// <param name="flag"></param>
            /// <param name="thread"></param>
            /// <returns>Response in Json format</returns>
            public static string GetReceivedMessages(PageFlag flag, int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, id);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Received, parameters);
            }

            #endregion

            #region Following Messages

            /// <summary>
            /// Messages followed by the logged-in user. Corresponds to the "Following" tab on the website.
            /// </summary>
            /// <returns>Response in Json format</returns>
            public static string GetFollowingMessages()
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Following);
            }

            /// <summary>
            /// Messages followed by the logged-in user. Corresponds to the "Following" tab on the website.
            /// </summary>
            /// <returns>Response in Json format</returns>
            public static string GetFollowingMessages(bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Following, parameters);
            }

            /// <summary>
            /// Messages followed by the logged-in user. Corresponds to the "Following" tab on the website.
            /// </summary>
            /// <param name="flag"></param>
            /// <param name="date"></param>
            /// <returns>Response in Json format</returns>
            public static string GetFollowingMessages(PageFlag flag, int id)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, id);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Following, parameters);
            }

            /// <summary>
            /// Messages followed by the logged-in user. Corresponds to the "Following" tab on the website.
            /// </summary>
            /// <param name="flag"></param>
            /// <param name="date"></param>
            /// <returns>Response in Json format</returns>
            public static string GetFollowingMessages(PageFlag flag, int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, id);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Following, parameters);
            }

            #endregion

            #region Liked Messages

            /// <summary>
            /// Messages liked by the logged-in user. Corresponds to the "Liked" tab on the website.
            /// </summary>
            /// <returns>Response in Json format</returns>
            public static string GetLikedMessages()
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("format", "json");
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Liked, parameters);
            }

            /// <summary>
            /// Messages liked by the logged-in user. Corresponds to the "Liked" tab on the website.
            /// </summary>
            /// <returns>Response in Json format</returns>
            public static string GetLikedMessages(bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                parameters.Add("format", "json");
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Liked, parameters);
            }

            /// <summary>
            /// Messages liked by the logged-in user. Corresponds to the "Liked" tab on the website.
            /// </summary>
            /// <param name="flag"></param>
            /// <param name="date"></param>
            /// <returns>Response in Json format</returns>
            public static string GetLikedMessages(PageFlag flag, int id)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, id);
                parameters.Add("format", "json");
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Liked, parameters);

            }

            /// <summary>
            /// Messages liked by the logged-in user. Corresponds to the "Liked" tab on the website.
            /// </summary>
            /// <param name="flag"></param>
            /// <param name="date"></param>
            /// <returns>Response in Json format</returns>
            public static string GetLikedMessages(PageFlag flag, int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, id);
                parameters.Add("format", "json");
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Liked, parameters);

            }

            #endregion

            #region Bookmarked Messages

            /// <summary>
            /// Messages bookmarked by the logged-in user. Corresponds to the "Bookmarked" tab on the website.
            /// </summary>
            /// <returns>Response in Json format</returns>
            public static string GetBookmarkedMessages()
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("format", "json");
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Bookmarked, parameters);
            }

            /// <summary>
            /// Messages bookmarked by the logged-in user. Corresponds to the "Bookmarked" tab on the website.
            /// </summary>
            /// <returns>Response in Json format</returns>
            public static string GetBookmarkedMessages(bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                parameters.Add("format", "json");
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Bookmarked, parameters);
            }

            /// <summary>
            /// Messages bookmarked by the logged-in user. Corresponds to the "Bookmarked" tab on the website.
            /// </summary>
            /// <param name="flag"></param>
            /// <param name="date"></param>
            /// <returns>Response in Json format</returns>
            public static string GetBookmarkedMessages(PageFlag flag, int id)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, id);
                parameters.Add("format", "json");
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Bookmarked, parameters);

            }

            /// <summary>
            /// Messages bookmarked by the logged-in user. Corresponds to the "Bookmarked" tab on the website.
            /// </summary>
            /// <param name="flag"></param>
            /// <param name="date"></param>
            /// <returns>Response in Json format</returns>
            public static string GetBookmarkedMessages(PageFlag flag, int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, id);
                parameters.Add("format", "json");
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.Bookmarked, parameters);
            }

            #endregion

            #region Messages Sent By User

            /// <summary>
            /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesSentByUser(int id)
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.SentByUser(id.ToString()));
            }

            /// <summary>
            /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesSentByUser(int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.SentByUser(id.ToString()), parameters);
            }

            /// <summary>
            /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesSentByUser(PageFlag flag, int id, int pageId)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, pageId);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.SentByUser(id.ToString()), parameters);
            }

            /// <summary>
            /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesSentByUser(PageFlag flag, int id, int pageId, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, pageId);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.SentByUser(id.ToString()), parameters);
            }


            #endregion

            #region Messages Sent By Bot

            /// <summary>
            /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesSentByBot(int id)
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.SentByBot(id.ToString()));
            }

            /// <summary>
            /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesSentByBot(int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.SentByBot(id.ToString()), parameters);
            }

            /// <summary>
            /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesSentByBot(PageFlag flag, int id, int pageId)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, pageId);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.SentByBot(id.ToString()), parameters);
            }

            /// <summary>
            /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesSentByBot(PageFlag flag, int id, int pageId, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, pageId);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.SentByBot(id.ToString()), parameters);
            }

            #endregion

            #region Messages Tagged With

            /// <summary>
            /// Messages including the tag with given ID. Corresponds to the messages on a tag's page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesTaggedWith(int id)
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.TaggedWith(id.ToString()));
            }

            /// <summary>
            /// Messages including the tag with given ID. Corresponds to the messages on a tag's page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesTaggedWith(int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.TaggedWith(id.ToString()), parameters);
            }

            /// <summary>
            /// Messages including the tag with given ID. Corresponds to the messages on a tag's page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesTaggedWith(PageFlag flag, int id, int pageId)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, pageId);
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.TaggedWith(id.ToString()), parameters);
            }

            /// <summary>
            /// Messages including the tag with given ID. Corresponds to the messages on a tag's page on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesTaggedWith(PageFlag flag, int id, int pageId, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, pageId);
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.TaggedWith(id.ToString()), parameters);
            }
            #endregion

            #region Messages in Group

            /// <summary>
            /// Messages in the group with the given ID. Corresponds to the messages you'd see on a group's profile page.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesInGroup(int id)
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.InGroup(id.ToString()));
            }

            /// <summary>
            /// Messages in the group with the given ID. Corresponds to the messages you'd see on a group's profile page.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesInGroup(int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.InGroup(id.ToString()), parameters);
            }

            /// <summary>
            /// Messages in the group with the given ID. Corresponds to the messages you'd see on a group's profile page.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesInGroup(PageFlag flag, int id, int pageId)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, pageId);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.InGroup(id.ToString()), parameters);
            }


            /// <summary>
            /// Messages in the group with the given ID. Corresponds to the messages you'd see on a group's profile page.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesInGroup(PageFlag flag, int id, int pageId, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, pageId);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.InGroup(id.ToString()), parameters);
            }



            #endregion

            #region Messages Favorites Of

            /// <summary>
            /// Favorite messages of the given user ID. Can pass 'current' in place of user_id for currently logged in user
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesFavoritesOf(int id)
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.FavoritesOf(id.ToString()));
            }

            /// <summary>
            /// Favorite messages of the given user ID. Can pass 'current' in place of user_id for currently logged in user
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesFavoritesOf(int id, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.FavoritesOf(id.ToString()), parameters);
            }

            /// <summary>
            /// Favorite messages of the given user ID. Can pass 'current' in place of user_id for currently logged in user
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesFavoritesOf(PageFlag flag, int id, int pageId)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, pageId);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.FavoritesOf(id.ToString()), parameters);
            }

            /// <summary>
            /// Favorite messages of the given user ID. Can pass 'current' in place of user_id for currently logged in user
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesFavoritesOf(PageFlag flag, int id, int pageId, bool threaded)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("threaded", threaded.ToString());
                AddPageFlagParam(flag, parameters, pageId);

                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.FavoritesOf(id.ToString()), parameters);
            }
            #endregion

            #region Messages In Thread

            /// <summary>
            /// Messages in the thread with the given ID. Corresponds to the page you'd see when clicking on "in reply to" on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesInThread(int id)
            {
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.InThread(id.ToString()));
            }

            /// <summary>
            /// Messages in the thread with the given ID. Corresponds to the page you'd see when clicking on "in reply to" on the website.
            /// </summary>
            /// <param name="id"></param>
            /// <returns>Response in Json format</returns>
            public static string GetMessagesInThread(PageFlag flag, int id, int pageId)
            {
                NameValueCollection parameters = new NameValueCollection();
                AddPageFlagParam(flag, parameters, pageId);
                return Yammer.APIWrapper.HttpUtility.Get(Resources.Messages.InThread(id.ToString()), parameters);
            }

            #endregion

            #region Post Message

            #region Static

            public static string Post(string body)
            {
                return Post(body, new List<string>());
            }

            public static string Post(string body, List<string> attachments)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("body", body);
                parameters.Add("format", "json");
                string response = string.Empty;
                if (attachments.Count > 0)
                    response = Yammer.APIWrapper.HttpUtility.Upload(Resources.Messages.Create, parameters, attachments);
                else
                    response = Yammer.APIWrapper.HttpUtility.Post(Resources.Messages.Create, parameters);


                return response;
            }

            public static string PostReply(int replyToId, string body)
            {
                return PostReply(replyToId, body, new List<string>());
            }

            public static string PostReply(int replyToId, string body, List<string> attachments)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("body", body);
                parameters.Add("format", "json");
                parameters.Add("replied_to_id", replyToId.ToString());
                string response = string.Empty;
                if (attachments.Count > 0)
                    response = Yammer.APIWrapper.HttpUtility.Upload(Resources.Messages.Create, parameters, attachments);
                else
                    response = Yammer.APIWrapper.HttpUtility.Post(Resources.Messages.Create, parameters);

                return response;
            }

            public static string PostDirectMessage(int directToId, string body)
            {
                return PostDirectMessage(directToId, body, new List<string>());
            }

            public static string PostDirectMessage(int directToId, string body, List<string> attachments)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("body", body);
                parameters.Add("format", "json");
                parameters.Add("direct_to_id", directToId.ToString());
                string response = string.Empty;
                if (attachments.Count > 0)
                    response = Yammer.APIWrapper.HttpUtility.Upload(Resources.Messages.Create, parameters, attachments);
                else
                    response = Yammer.APIWrapper.HttpUtility.Post(Resources.Messages.Create, parameters);

                return response;
            }

            public static string PostToGroup(int groupId, string body)
            {
                return PostToGroup(groupId, body, new List<string>());
            }

            public static string PostToGroup(int groupId, string body, List<string> attachments)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("body", body);
                parameters.Add("group_id", groupId.ToString());
                parameters.Add("format", "json");
                string response = string.Empty;
                if (attachments.Count > 0)
                    response = Yammer.APIWrapper.HttpUtility.Upload(Resources.Messages.Create, parameters, attachments);
                else
                    response = Yammer.APIWrapper.HttpUtility.Post(Resources.Messages.Create, parameters);

                return response;
            }

            public static string PostBroadcastMessage(string body)
            {
                return PostBroadcastMessage(body, new List<string>());
            }

            public static string PostBroadcastMessage(string body, List<string> attachments)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("body", body);
                parameters.Add("broadcast", "true");
                parameters.Add("format", "json");
                string response = string.Empty;
                if (attachments.Count > 0)
                    response = Yammer.APIWrapper.HttpUtility.Upload(Resources.Messages.Create, parameters, attachments);
                else
                    response = Yammer.APIWrapper.HttpUtility.Post(Resources.Messages.Create, parameters);

                return response;
            }

            #endregion

            #endregion

            public static string DeleteMessage(string messageId)
            {
                string response = Yammer.APIWrapper.HttpUtility.Delete(Resources.Messages.Delete(messageId));
                return response;
            }

            #region Manipulate Favorites
            public static string AddMessageToFavorites(string messageId, string userId)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("message_id", messageId);
                string response = string.Empty;
                response = Yammer.APIWrapper.HttpUtility.Post(Resources.Messages.AddToFavorites(userId), parameters);
                return response;
            }

            public static string RemoveMessageFromFavorites(string messageId, string userId)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("message_id", messageId);
                string response = string.Empty;
                response = Yammer.APIWrapper.HttpUtility.Delete(Resources.Messages.RemoveFromFavorites(userId), parameters);
                return response;
            }
            #endregion

            #region Email
            public static string Email(string messageId)
            {
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("message_id", messageId);
                string response = string.Empty;
                response = Yammer.APIWrapper.HttpUtility.Post(Resources.Messages.Email, parameters);
                return response;
            }
            #endregion

            #region Helper Methods
            private static void AddPageFlagParam(PageFlag pf, NameValueCollection parameters, int id)
            {
                if (pf == PageFlag.NEWER_THAN)
                    parameters.Add("newer_than", id.ToString());
                else
                    parameters.Add("older_than", id.ToString());
            }
            #endregion
        }

    }
}


