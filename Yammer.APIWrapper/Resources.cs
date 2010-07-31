using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper
{
    /// <summary>
    /// Yammer API Wrapper
    /// </summary>
    /// <remarks>
    /// API Version 1.8 (Beta)
    /// </remarks>
    public static class Resources
    {
        private static string APP_PATH = "https://www.yammer.com";

        public static class OAuth
        {
            public static string RequestToken = APP_PATH + "/oauth/request_token";
            public static string Authorize = APP_PATH + "/oauth/authorize";
            public static string AccessToken = APP_PATH + "/oauth/access_token";
            public static string PreAuth = APP_PATH + "/api/v1/oauth.json";
            public static string AllAccessTokens = APP_PATH + "/api/v1/oauth/tokens.xml";
        }

        public static class Messages
        {
            #region Viewing

            /// <summary>
            /// All messages in this network. Corresponds to the "All" tab on the website.
            /// </summary>
            public static string All = APP_PATH + "/api/v1/messages.json";

            /// <summary>
            /// Alias for /api/v1/messages/from_user/logged-in_user_id.format Corresponds to the "Sent" tab on the website.
            /// </summary>
            public static string Sent = APP_PATH + "/api/v1/messages/sent.json";

            /// <summary>
            /// Messages received by the logged-in user. Corresponds to the "Received" tab on the website.
            /// </summary>
            public static string Received = APP_PATH + "/api/v1/messages/received.json";

            /// <summary>
            /// Messages followed by the logged-in user. Corresponds to the "Following" tab on the website.
            /// </summary>
            public static string Following = APP_PATH + "/api/v1/messages/following.json";

            /// <summary>
            /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
            /// </summary>
            private static string yammer_messages_sent_by_user = APP_PATH + "/api/v1/messages/from_user/{0}.json";

            /// <summary>
            /// Messages sent by the user with the given ID. Corresponds to the messages on a user profile page on the website.
            /// </summary>
            /// <param name="id">Id of user</param>
            /// <returns>Resource URL</returns>
            public static string SentByUser(string id)
            {
                return string.Format(yammer_messages_sent_by_user, id);
            }
            /// <summary>
            /// Messages sent by the bot with the given ID. Corresponds to the messages on a bot profile page on the website.
            /// </summary>
            private static string yammer_messages_sent_by_bot = APP_PATH + "/api/v1/messages/from_bot/{0}.json";

            /// <summary>
            /// Messages sent by the bot with the given ID. Corresponds to the messages on a bot profile page on the website.
            /// </summary>
            /// <param name="id">Id of bot</param>
            /// <returns>Resource URL</returns>
            public static string SentByBot(string id)
            {
                return string.Format(yammer_messages_sent_by_bot, id);
            }

            /// <summary>
            /// Messages including the tag with given ID. Corresponds to the messages on a tag's page on the website.
            /// </summary>
            private static string yammer_messages_tagged_with = APP_PATH + "/api/v1/messages/tagged_with/{0}.json";

            /// <summary>
            /// Messages including the tag with given ID. Corresponds to the messages on a tag's page on the website.
            /// </summary>
            /// <param name="id">Id of tag</param>
            /// <returns>Resource URL</returns>
            public static string TaggedWith(string id)
            {
                return string.Format(yammer_messages_tagged_with, id);
            }

            /// <summary>
            /// Messages in the group with the given ID. Corresponds to the messages you'd see on a group's profile page.
            /// </summary>
            private static string yammer_messages_in_group = APP_PATH + "/api/v1/messages/in_group/{0}.json";

            /// <summary>
            /// Messages in the group with the given ID. Corresponds to the messages you'd see on a group's profile page.
            /// </summary>
            /// <param name="id">Id of group</param>
            /// <returns>Resource URL</returns>
            public static string InGroup(string id)
            {
                return string.Format(yammer_messages_in_group, id);
            }

            /// <summary>
            /// Favorite messages of the given user ID. Can pass 'current' in place of user_id for currently logged in user
            /// </summary>
            private static string yammer_messages_favorite_of = APP_PATH + "/api/v1/messages/favorites_of/{0}.json";

            /// <summary>
            /// Favorite messages of the given user ID. Can pass 'current' in place of user_id for currently logged in user
            /// </summary>
            /// <param name="id">Id of user</param>
            /// <returns>Resource URL</returns>
            public static string FavoritesOf(string id)
            {
                return string.Format(yammer_messages_favorite_of, id);
            }

            /// <summary>
            /// Messages in the thread with the given ID. Corresponds to the page you'd see when clicking on "in reply to" on the website.
            /// </summary>
            private static string yammmer_messages_in_thread = APP_PATH + "/api/v1/messages/in_thread/{0}.json";
           
            /// <summary>
            /// Messages in the thread with the given ID. Corresponds to the page you'd see when clicking on "in reply to" on the website.
            /// </summary>
            /// <param name="id">Id of thread</param>
            /// <returns>Resource URL</returns>
            public static string InThread(string id)
            {
                return string.Format(yammmer_messages_in_thread, id);
            }

            public static string Liked = APP_PATH + "/api/v1/messages/liked_by";

            public static string Bookmarked = APP_PATH + "/api/v1/messages/bookmarked_by";

            #endregion

            #region Manipulating

            /// <summary>
            /// Create a new message.
            /// </summary>
            public static string Create = APP_PATH + "/api/v1/messages/";
            /// <summary>
            /// Delete a message owned by the current user.
            /// </summary>
            private static string yammer_messages_delete = APP_PATH + "/api/v1/messages/{0}";

            /// <summary>
            /// Delete a message owned by the current user.
            /// </summary>
            /// <param name="id">Id of the message to delete</param>
            /// <returns>Resource URL</returns>
            public static string Delete(string id)
            {
                return string.Format(yammer_messages_delete, id);
            }



            private static string yammer_favorites_manipulate = APP_PATH + "/api/v1/messages/favorites_of/{0}";

            /// <summary>
            /// Add a message to user's favorite messages
            /// </summary>
            public static string AddToFavorites(string id)
            {
                return string.Format(yammer_favorites_manipulate, id);
            }

            /// <summary>
            /// Removes a favorite
            /// </summary>
            public static string RemoveFromFavorites(string id)
            {
                return string.Format(yammer_favorites_manipulate, id);
            }

            #endregion

            /// <summary>
            /// Send current_user a copy of this message.
            /// </summary>
            public static string Email = APP_PATH + "/api/v1/messages/email/";

        }

        public static class Users
        {
            private static string userPath = APP_PATH + "/api/v1/users/{0}.json";

            public static string All = APP_PATH + "/api/v1/users.json";

            public static string Current = APP_PATH + "/api/v1/users/current.json";

            public static string Create = APP_PATH + "/api/v1/users.json";

            public static string Delete(string id)
            {
                return string.Format(userPath, id);
            }

            public static string Get(string id)
            {
                return string.Format(userPath, id);
            }

            public static string Modify(string id)
            {
                return string.Format(userPath, id);
            }

            public static string ByEmail = APP_PATH + "/api/v1/users/by_email.json";

            public static string Invite = APP_PATH + "/api/v1/invitations.json";

        }

        public static class Groups
        {
            public static string All = APP_PATH + "/api/v1/groups.json";

            private static string detail = APP_PATH + "/api/v1/groups/{0}.json";

            public static string Detail(string id)
            {
                return string.Format(detail, id);
            }

            public static string Join = APP_PATH + "/api/v1/group_memberships.json";

            public static string leave = APP_PATH + "/api/v1/group_memberships/{0}.json";
            public static string Leave(string id)
            {
                return string.Format(leave, id);
            }

            public static string Create = APP_PATH + "/api/v1/groups.json";

            private static string modify = APP_PATH + "/api/v1/groups/{0}.json";
            public static string Modify(string id)
            {
                return string.Format(modify, id);
            }
        }

        public static class Tags
        {
            public static string AllTagsInNetwork = APP_PATH + "/api/v1/tags.json";
            private static string detail = APP_PATH + "/api/v1/tags/{0}.json";
            public static string Detail(string id)
            {
                return string.Format(detail, id);
            }
        }

        public static class Relationships
        {
            public static string Get = APP_PATH + "/api/v1/relationships.json";

            public static string Add = APP_PATH + "/api/v1/relationships.json";

            private static string delete = APP_PATH + "/api/v1/relationships/{0}.json";

            public static string Delete(string id)
            {
                return string.Format(delete, id);
            }
        }

        public static class Suggestions
        {

            public static string All = APP_PATH + "/api/v1/suggestions.json";

            public static string Users = APP_PATH + "/api/v1/suggestions/users.json";

            public static string Groups = APP_PATH + "/api/v1/suggestions/groups.json";

            public static string decline = APP_PATH + "/api/v1/suggestions/{0}.json";

            public static string Decline(string id)
            {
                return string.Format(decline, id);
            }

        
        }

        public static class Subscriptions
        {
            private static string subscriptionsPath = APP_PATH + "/api/v1/subscriptions/{0}/{1}.json";

            public static string Subscribe = APP_PATH + "/api/v1/subscriptions/";

            public static string Unsubscribe = Subscribe;

            public static string ToUser(string id)
            {
                return string.Format(subscriptionsPath, "to_user", id);            
            }

            public static string ToTag(string id)
            {
                return string.Format(subscriptionsPath, "to_tag", id);
            }
        }

        public static class AutoComplete
        {
            public static string Suggestion = APP_PATH + "/api/v1/autocomplete.json";
            
        }

        public static class Invite
        {
              public static string User = APP_PATH + "/api/v1/invitations.json";
        }

        public static class Search
        {          
            public static string DoSearch = APP_PATH + "/api/v1/search.json";
        }

        public static class Network
        {
            public static string All = APP_PATH + "/api/v1/networks/current.json";
        }
    }
}
