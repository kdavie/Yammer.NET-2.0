using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper.Consumer.Feed.Base
{
    public abstract class Static : Common
    {
       
        public Static()
        {
            Load();
        }

        public abstract void Load();
        public abstract void Load(bool threaded);
        public abstract void Load(PageFlag flag, int id);
        public abstract void Load(PageFlag flag, int id, bool threaded);

        public void GetNextPage()
        {
            var max = this.Max(m => int.Parse(m.Id));
            Load(PageFlag.NEWER_THAN, max);
        }

        public void GetPreviousPage()
        {
            var min = this.Min(m => int.Parse(m.Id));
            Load(PageFlag.OLDER_THAN, min);
        }
    }
}
