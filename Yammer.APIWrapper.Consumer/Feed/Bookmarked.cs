using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed
{
    public class Bookmarked : Feed.Base.Static
    {
        /// <summary>
        /// Loads logged in user's Bookmarked Feed
        /// </summary>
        /// <returns>List of messages in feed</returns>
        public override void Load()
        {
            this.AddRange(Message.GetBookmarkedMessages());
        }

        /// <summary>
        /// Loads logged in user's Bookmarked Feed in threaded mode
        /// </summary>
        /// <param name="threaded"></param>
        /// <returns>List of messages in feed</returns>
        public override void Load(bool threaded)
        {
            this.AddRange(Message.GetBookmarkedMessages(threaded));
        }

        /// <summary>
        /// Returns specified page of messages
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="id"></param>
        /// <returns>List of messages in feed</returns>
        public override void Load(PageFlag flag, int id)
        {
            this.AddRange(Message.GetBookmarkedMessages(flag, id));
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
            this.AddRange(Message.GetBookmarkedMessages(flag, id, threaded));
        }
    }
}
