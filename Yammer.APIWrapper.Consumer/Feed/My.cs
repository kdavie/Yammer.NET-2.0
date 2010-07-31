using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed
{
    public class My : Yammer.APIWrapper.Consumer.Feed.Base.Static
    {
        /// <summary>
        /// Loads logged in user's My Feed
        /// </summary>
        /// <returns>List of messages in feed</returns>
        public override void Load()
        {
            this.AddRange(Message.GetFollowingMessages());
        }

        /// <summary>
        /// Loads logged in user's My Feed in threaded mode
        /// </summary>
        /// <param name="threaded"></param>
        /// <returns>List of messages in feed</returns>
        public override void Load(bool threaded)
        {
            this.AddRange(Message.GetFollowingMessages(threaded));
        }

        /// <summary>
        /// Returns specified page of messages
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="id"></param>
        /// <returns>List of messages in feed</returns>
        public override void Load(PageFlag flag, int id)
        {
            this.AddRange(Message.GetFollowingMessages(flag, id));
        }

        /// <summary>
        /// Returns specified page of messages in threaded mode
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="id"></param>
        /// <param name="threaded"></param>
        /// <returns>List of messages in feed</returns>
        public override void Load(PageFlag flag, int id, bool threaded)
        {
            this.AddRange(Message.GetFollowingMessages(flag, id, threaded));
        }
    }
}
