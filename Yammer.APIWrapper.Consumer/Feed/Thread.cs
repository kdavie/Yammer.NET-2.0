using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed
{
    public class Thread : List<Message>
    {
        public int ObjectId { get; set; }

        public Thread(int id)
        {
            this.ObjectId = id;
            Load(id);
        }
    
        
         public void Load(int threadId)
        {
            this.AddRange(Yammer.APIWrapper.Message.GetMessagesInThread(threadId));
        }

        public void GetNextPage()
        {
          
            var max = this.Max(m => int.Parse(m.Id));
            this.AddRange(Message.GetMessagesInThread(PageFlag.NEWER_THAN, ObjectId, max));
        }

        public void GetPreviousPage(int threadId, int oldestMessageId)
        {
            var min = this.Min(m => int.Parse(m.Id));
            this.AddRange(Message.GetMessagesInThread(PageFlag.OLDER_THAN, ObjectId, min));
        }
    }
}
