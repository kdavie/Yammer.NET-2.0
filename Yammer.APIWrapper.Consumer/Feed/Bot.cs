using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed
{
    public class Bot : Yammer.APIWrapper.Consumer.Feed.Base.Dynamic
    {
        public Bot() : base() { }
        public Bot(int id) : base(id) { }
        public Bot(int id, bool threaded) : base(id, threaded) { }

        public override void Load(int id)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesSentByBot(id));
        }

        public override void Load(int id, bool threaded)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesSentByBot(id, threaded));
        }

        public override void Load(PageFlag flag, int id, int pageId)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesSentByBot(flag, id, id));
        }

        public override void Load(PageFlag flag, int id, int pageId, bool threaded)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesSentByBot(flag, id, pageId, threaded));
        }

    }
}
