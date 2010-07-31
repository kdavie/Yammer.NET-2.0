using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Relationship
{
    public class Organization : List<Connection>
    {
        public Organization()
        {
            Load();
             
        }

        private void Load()
        {
            this.Clear();

            var connections =
                from u in Yammer.APIWrapper.User.GetRelationships()
                select new Connection(u);

            foreach (var c in connections)
                this.Add((Connection)c);
        }

        public List<Connection> Superiors
        {
            get
            {
                
                if (this.Count < 1)
                    return null;

                List<Connection> list = new List<Connection>();

                foreach (var connection in this.Where(c => c.Type == "superior"))
                    list.Add(connection);

                return list;
            }
        }

        public List<Connection> Subordinates
        {
            get
            {
                if (this.Count < 1)
                    return null;

                List<Connection> list = new List<Connection>();

                foreach (var connection in this.Where(c => c.Type == "subordinate"))
                    list.Add(connection);

                return list;
            }
        }

        public void Refresh()
        {
            Load();
        }


    }

    public struct Connection
    {

        public Uri WebUrl;
        public string State;
        public string Type;
        public Uri MugshotUrl;
        public string FullName;
        public int Updates;
        public int Following;
        public int Followers;
        public Uri Url;
        public string Name;
        public int Id;
        public string JobTitle;

        public Connection(Yammer.APIWrapper.User user)
        {
            this.WebUrl = new Uri(user.WebUrl);
            this.State = user.State;
            this.Type = user.Type;
            this.MugshotUrl = new Uri(user.MugshotUrl);
            this.FullName = user.FullName;
            this.Updates = int.Parse(user.Stats.Updates);
            this.Following = int.Parse(user.Stats.Following);
            this.Followers = int.Parse(user.Stats.Followers);
            this.Url = new Uri(user.Url);
            this.Name = user.Name;
            this.Id = int.Parse(user.Id);
            this.JobTitle = user.JobTitle;

        }

        public void Delete()
        {
            RelationshipType type = RelationshipType.COLLEAGUE;

            User.Directory directory = new Yammer.APIWrapper.Consumer.User.Directory();
            string id = this.Id.ToString();
            Yammer.APIWrapper.User user = directory.Find(u => u.Id == id);

            if (this.Type == "superior")
                type = RelationshipType.SUPERIOR;
            else if (this.Type == "subordinate")
                type = RelationshipType.SUBORDINATE;

            if(user != null)
                Yammer.APIWrapper.User.DeleteRelationship(user, type);
        }

        private Yammer.APIWrapper.User GetUserObject()
        {
            User.Directory directory = new Yammer.APIWrapper.Consumer.User.Directory();
            string id = this.Id.ToString();
            Yammer.APIWrapper.User user = directory.Find(u => u.Id == id);
            return user;
        }

        public override string ToString()
        {
            return string.Format("Name:{0}, Title:{1}", FullName, JobTitle);
        }


    }


}
