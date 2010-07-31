using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed
{
    public class Tag : Yammer.APIWrapper.Consumer.Feed.Base.Dynamic 
    {
        public Tag() : base() { }
        public Tag(int id) : base(id) { }
        public Tag(int id, bool threaded) : base(id, threaded) { }

        public override void Load(int id)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesTaggedWith(id));
        }

        public override void Load(int id, bool threaded)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesTaggedWith(id, threaded));
        }

        public override void Load(PageFlag flag, int id, int pageId)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesTaggedWith(flag, id, pageId));
        }

        public override void Load(PageFlag flag, int id, int pageId, bool threaded)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesTaggedWith(flag, id, pageId, threaded));
        }
    }
}
