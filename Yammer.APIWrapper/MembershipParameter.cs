using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Specialized;

namespace Yammer.APIWrapper
{
    public class MembershipParameters
    {

        public MembershipParameters()
        {
        }

        [MembershipParameter("page")]
        public int PageId { get; set; }
        [MembershipParameter("sort_by")]
        public SortBy SortBy { get; set; }
        [MembershipParameter("letter")]
        public string Letter { get; set; }
        [MembershipParameter("reverse")]
        public bool Reverse { get; set; }

        public static NameValueCollection Parameters { get; set; }

        public static NameValueCollection AddMembershipParams(MembershipParameters groupParams)
        {
            MembershipParameters.Parameters = new NameValueCollection();
            PropertyInfo[] pic = groupParams.GetType().GetProperties();
            foreach (PropertyInfo pi in pic)
            {
                object value = pi.GetValue(groupParams, null);
                bool include = false;
                if (value != null)
                {
                    string typeName = value.GetType().Name;
                    switch (typeName)
                    {
                        case "Int32":
                            if ((int)value > 0)
                                include = true;
                            break;
                        case "SortBy":
                            if ((SortBy)value != SortBy.NONE)
                                include = true;
                            break;
                        default:
                            include = true;
                            break;
                    }


                    if (include)
                    {
                        MembershipParameterAttribute name = (MembershipParameterAttribute)MembershipParameterAttribute.GetCustomAttribute(pi, typeof(MembershipParameterAttribute));
                        if(name != null)
                            Parameters.Add(name.Name, pi.GetValue(groupParams, null).ToString());
                    }
                }
            }

            return MembershipParameters.Parameters;

        }
    }

    public class MembershipParameterAttribute : System.Attribute
    {
        public string Name { get; set; }

        public MembershipParameterAttribute(string name)
        {
            this.Name = name;
        }

    }
}
