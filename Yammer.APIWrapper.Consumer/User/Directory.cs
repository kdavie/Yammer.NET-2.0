using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Yammer.APIWrapper.Consumer.User
{
    public class Directory : List<Yammer.APIWrapper.User>
    {
        public Directory()
        {
            GetAll();
        }

        private void GetAll()
        {
            bool cont = true;
            int page = 1;
            while (cont)
            {
                MembershipParameters p = new MembershipParameters();
                p.PageId = page;
                List<Yammer.APIWrapper.User> allUsers = Yammer.APIWrapper.User.GetAllUsers(p);
                if (allUsers.Count > 0)
                {
                    this.AddRange(allUsers);
                    page++;
                }
                else
                    cont = false;
            }
        }

        public List<Data> AllUsers
        {
            get
            {
                List<Data> summaryData = new List<Data>();
                var _data =
                    from p in this
                    select new Data(p.Name, p.Stats.Updates, p.Stats.Followers, p.MugshotUrl);

                foreach (var data in _data)
                    summaryData.Add((Data)data);

                return summaryData;
            }
        }

        public APIWrapper.User UserById(int id)
        {
            return this.FirstOrDefault(delegate(APIWrapper.User u) { return u.Id == id.ToString(); });
        }

        public void CreateUser(string email, string fullName, string title)
        {
            Yammer.APIWrapper.UserParameters parameters = new UserParameters();
            parameters.Email = email;
            parameters.FullName = fullName;
            parameters.JobTitle = title;
            Yammer.APIWrapper.User.CreateUser(parameters);
        }

        public struct Data
        {
            string Name;
            int Messages;
            int Followers;
            System.Drawing.Image Image;
  

            public Data(string name, string messages, string followers, string mugshotUrl)
            {
                this.Name = name;
                this.Messages = int.Parse(messages);
                this.Followers = int.Parse(followers);
                this.Image = Yammer.APIWrapper.Group.GetAvatar(mugshotUrl);
  
            }

            public override string ToString()
            {
                return String.Format("Name:{0}, Messages:{1}, Followers:{2}, Following:{3}", this.Name, this.Messages, this.Followers);
            }

            
        }

      
    }
}
