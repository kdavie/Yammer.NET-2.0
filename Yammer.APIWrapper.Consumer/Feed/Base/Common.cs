using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed.Base
{
    public class Common : List<Message>
    {
        public virtual Yammer.APIWrapper.Message Post(string body)
        {
            return Yammer.APIWrapper.Message.Post(body);
        }

        public virtual Yammer.APIWrapper.Message Post(string body, List<string> attachments)
        {
            return Yammer.APIWrapper.Message.Post(body, attachments);
        }

        public virtual Yammer.APIWrapper.Message Post(string body, List<Attachment.FileInfo> attachments)
        {
            return null;
        }

        public List<Yammer.APIWrapper.Message> MessageList { get; set; }

        public new void AddRange(IEnumerable<Message> collection)
        {
            var messages =
                from _mNew in collection
                    join _mOld in this on _mNew.Id equals _mOld.Id
                select _mNew;

            foreach (Message m in collection)
                if (!messages.Contains(m))
                    this.Add(m);

        }
    }
}
