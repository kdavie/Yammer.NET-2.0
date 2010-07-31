using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Yammer.APIWrapper.Consumer.Feed
{
    public class User : Yammer.APIWrapper.Consumer.Feed.Base.Dynamic
    {
        public User() : base() { }
        public User(int id) : base(id) { }
        public User(int id, bool threaded) : base(id, threaded) { }

        public override void Load(int id)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesSentByUser(id));
        }

        public override void Load(int id, bool threaded)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesSentByUser(id, threaded));
        }

        public override void Load(PageFlag flag, int id, int pageId)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesSentByUser(flag, id, id));
        }

        public override void Load(PageFlag flag, int id, int pageId, bool threaded)
        {
            this.ObjectId = id;
            this.AddRange(Message.GetMessagesSentByUser(flag, id, pageId, threaded));
        }

    }
}
 