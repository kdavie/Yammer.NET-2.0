using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed
{
    public class Favorites : Yammer.APIWrapper.Consumer.Feed.Base.Dynamic
    {
        public Favorites() : base() { }
        public Favorites(int id) : base(id) { }
        public Favorites(int id, bool threaded) : base(id, threaded) { }

        public override void Load(int id)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesFavoritesOf(id));
        }

        public override void Load(int id, bool threaded)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesFavoritesOf(id, threaded));
        }

        public override void Load(PageFlag flag, int id, int pageId)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesFavoritesOf(flag, id, id));
        }

        public override void Load(PageFlag flag, int id, int pageId, bool threaded)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesFavoritesOf(flag, id, pageId, threaded));
        }
    }
}
