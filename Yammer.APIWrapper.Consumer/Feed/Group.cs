using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed
{
    public class Group : Yammer.APIWrapper.Consumer.Feed.Base.Dynamic
    {
        public Group() : base() { }
        public Group(int id) : base(id) { }
        public Group(int id, bool threaded) : base(id, threaded) { }

        public override void Load(int id)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesInGroup(id));
        }

        public override void Load(int id, bool threaded)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesInGroup(id, threaded));
        }

        public override void Load(PageFlag flag, int id, int pageId)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesInGroup(flag, id, id));
        }

        public override void Load(PageFlag flag, int id, int pageId, bool threaded)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesInGroup(flag, id, pageId, threaded));
        }

        public override Message Post(string body)
        {
            return Yammer.APIWrapper.Message.PostToGroup(this.ObjectId, body);
        }

        public override Message Post(string body, List<string> attachments)
        {
            return Yammer.APIWrapper.Message.PostToGroup(this.ObjectId, body, attachments);
        }
    }
}
