using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper
{
    public class Reference
    {
        public int Id { get; set; }
        public ObjectType ObjectType { get; set; }
        public Object Object { get; set; }

        private List<Message> messages = new List<Message>();

        public List<Message> Messages
        {
            get { return messages; }
            set { messages = value; }
        }

        private List<User> users = new List<User>();

        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        private List<Tag> tags = new List<Tag>();

        public List<Tag> Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        private List<Bot> bot = new List<Bot>();

        public List<Bot> Bot
        {
            get { return bot; }
            set { bot = value; }
        }

        public Guide Guide { get; set; }

        public Thread Thread { get; set; }

        public Group Group { get; set; }

    }
}
