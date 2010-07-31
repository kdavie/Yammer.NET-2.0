using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Yammer.APIWrapper.Consumer.Group
{
    public class Directory : List<Yammer.APIWrapper.Group>
    {
        public Directory()
        {
            GetAllGroups();
        }

        public void Refresh()
        {
            this.Clear();
            m_myGroupIds = null;
            this.GetAllGroups();
        }

        private void GetAllGroups()
        {
            bool cont = true;
            int page = 1;
            while (cont)
            {
                MembershipParameters p = new MembershipParameters();
                p.PageId = page;
                List<Yammer.APIWrapper.Group> allGroups = Yammer.APIWrapper.Group.GetAllGroups(p);
                if (allGroups.Count > 0)
                {
                    this.AddRange(allGroups);
                    page++;
                }
                else
                    cont = false;
            }
        }

        private List<int> m_myGroupIds;
        
        private List<int> MyGroupIds
        {
            get
            {
                if (m_myGroupIds == null)
                {
                    bool cont = true;
                    int page = 1;
                    List<Yammer.APIWrapper.Group> allMyGroups = new List<Yammer.APIWrapper.Group>();
                    while (cont)
                    {
                        MembershipParameters p = new MembershipParameters();
                        p.PageId = page;
                        List<Yammer.APIWrapper.Group> myGroups = Yammer.APIWrapper.Group.GetAllMyGroups(p);
                        if (myGroups.Count > 0)
                        {
                            allMyGroups.AddRange(myGroups);
                            page++;
                        }
                        else
                            cont = false;
                    }

                    var _groupsIds =
                        from g in allMyGroups
                        select int.Parse(g.Id);

                    List<int> groups = new List<int>();
                    foreach (var g in _groupsIds)
                        groups.Add(g);

                    m_myGroupIds = groups;
                }
                return m_myGroupIds;
            }
        }

        public List<Data> MyGroups
        {
            get
            {
                List<Data> summaryData = new List<Data>();
                var _data =
                   from a in this
                   from m in this.MyGroupIds
                   where m == int.Parse(a.Id)
                   select new Data(a.Name, a.Stats.Members, a.Stats.Updates, a.MugshotUrl, MyGroupIds.Contains(int.Parse(a.Id)));

                foreach (var data in _data)
                    summaryData.Add((Data)data);

                return summaryData;
            }
        }

        public List<Data> AllGroups
        {
            get
            {
                List<Data> summaryData = new List<Data>();
                var _data =
                    from p in this
                    select new Data( p.Name, p.Stats.Members, p.Stats.Updates, p.MugshotUrl, MyGroupIds.Contains(int.Parse(p.Id)));

                foreach(var data in _data)
                    summaryData.Add((Data)data);

                return summaryData;
            }
        }

        public void CreatePublicGroup(string name)
        {
            Yammer.APIWrapper.Group group = Yammer.APIWrapper.Group.CreateGroup(name, PrivacyFlag.Public);
            m_myGroupIds.Add(int.Parse(group.Id));
            this.Add(group);
        }

        public void CreatePrivateGroup(string name)
        {
            Yammer.APIWrapper.Group group = Yammer.APIWrapper.Group.CreateGroup(name, PrivacyFlag.Private);
            if(!MyGroupIds.Contains(int.Parse(group.Id)))
                MyGroupIds.Add(int.Parse(group.Id));

            this.Add(group);
        }

        public APIWrapper.Group GroupById(int id)
        {
            return this.FirstOrDefault(delegate(APIWrapper.Group g) { return g.Id == id.ToString(); });
        }

        public struct Data
        {
            string Name;
            int Members;
            int Updates;
            System.Drawing.Image Image;
            bool MemberOf;

            public Data(string name, string members, string updates, string mugshotUrl, bool memberOf)
            {
                this.Name = name;
                this.Members = int.Parse(members);
                this.Updates = int.Parse(updates);
                this.Image = Yammer.APIWrapper.Group.GetAvatar(mugshotUrl);
                this.MemberOf = memberOf;
            }

            public override string ToString()
            {
                return String.Format("Name:{0}, Members:{1}, Updates:{2}, MemberOf:{3}", this.Name, this.Members, this.Updates, this.MemberOf);
            }
        }
    

    }

    
}
