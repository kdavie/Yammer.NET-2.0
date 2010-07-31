using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed.Base
{
    public abstract class Dynamic : Common
    {
        public int ObjectId { get; set; }

        public Dynamic()
        {
        }

        public Dynamic(int id)
        {
            Load(id);
        }

        public Dynamic(int id, bool threaded)
        {
            Load(id, threaded);
        }
        public abstract void Load(int id);

        public abstract void Load(int id, bool threaded);

        public abstract void Load(PageFlag flag, int id, int pageId);

        public abstract void Load(PageFlag flag, int id, int pageId, bool threaded);

        public void GetNextPage()
        {
            var max = this.Max(m => int.Parse(m.Id));
            Load(PageFlag.NEWER_THAN, this.ObjectId, max);
        }

        public void GetPreviousPage()
        {
            var min = this.Min(m => int.Parse(m.Id));
            Load(PageFlag.OLDER_THAN, this.ObjectId, min);
        }

    }

    public class FeedOptions : Dictionary<Options, object>
    {
        public int Value
        {
            get
            {
                int value = 0;
                foreach (Options o in this.Keys)
                    value += (int)o;

                return value;
            }
        }

        public List<Options> Test(Options option)
        {
            List<Options> optionList = new List<Options>();

            if ((option & Options.None) != 0)
                optionList.Add(Options.None);

            if ((option & Options.Threaded) != 0)
                optionList.Add(Options.Threaded);

            if ((option & Options.PaginationFlag) != 0)
                optionList.Add(Options.PaginationFlag);

            if ((option & Options.PaginationId) != 0)
                optionList.Add(Options.PaginationId);

            return optionList;
        }
        
    }

    public enum Options
    {
        None = 0,
        Threaded = 1,
        PaginationFlag = 2,
        PaginationId = 4
    }
}
