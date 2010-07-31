using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed
{
    public class Factory
    {
        public static Feed.Base.Static Create(FeedType type)
        {
            object feed = null;
            switch (type)
            {
                case FeedType.All:
                    feed = new All();
                    break;
                case FeedType.My:
                    feed = new My();
                    break;
                case FeedType.Received:
                    feed = new Received();
                    break;
                case FeedType.Sent:
                    feed = new Sent();
                    break;
                case FeedType.Liked:
                    feed = new Liked();
                    break;
                case FeedType.Bookmarked:
                    feed = new Bookmarked();
                    break;
            }

            return feed as Feed.Base.Static;
        }



        public static Feed.Base.Dynamic Create(FeedType type, int id)
        {
            object feed = null;
            switch (type)
            {
                case FeedType.User:
                    feed = new User(id);
                    break;
                case FeedType.Bot:
                    feed = new Bot(id);
                    break;
                case FeedType.Favorites:
                    feed = new Favorites(id);
                    break;
                case FeedType.Group:
                    feed = new Group(id);
                    break;
                case FeedType.Tag:
                    feed = new Tag(id);
                    break;
                case FeedType.Thread:
                    feed = new Thread(id);
                    break;
            }

            return feed as Feed.Base.Dynamic;
        }

        public static Feed.Base.Dynamic Create(FeedType type, int id, bool threaded)
        {
            object feed = null;
            switch (type)
            {
                case FeedType.User:
                    feed = new User(id, threaded);
                    break;
                case FeedType.Bot:
                    feed = new Bot(id, threaded);
                    break;
                case FeedType.Favorites:
                    feed = new Favorites(id, threaded);
                    break;
                case FeedType.Group:
                    feed = new Group(id, threaded);
                    break;
                case FeedType.Tag:
                    feed = new Tag(id, threaded);
                    break;
                case FeedType.Thread:
                    feed = new Thread(id);
                    break;
            }

            return feed as Feed.Base.Dynamic;
        }
    }

    public enum FeedType
    {
        All,
        Bookmarked,
        Bot,
        Favorites,
        Group,
        Liked,
        My,
        Received,
        Sent,
        Tag,
        Thread,
        User

    }

    public enum FeedOptions
    {
        Threaded
    }
}
