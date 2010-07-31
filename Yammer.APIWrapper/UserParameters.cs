using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Specialized;

namespace Yammer.APIWrapper
{
    public class UserParameters
    {

        [User("email")]
        public string Email { get; set; }
        [User("full_name")]
        public string FullName { get; set; }
        [User("job_title")]
        public string JobTitle { get; set; }
        [User("location")]
        public string Location { get; set; }
        [User("im_provider")]
        public string ImProvider { get; set; }
        [User("im_username")]
        public string ImUserName { get; set; }
        [User("work_telephone")]
        public string WorkPhone { get; set; }
        [User("work_extension")]
        public string WorkExtension { get; set; }
        [User("mobile_telephone")]
        public string MobilePhone { get; set; }
        [User("external_profiles")]
        public string ExternalProfiles { get; set; }
        [User("significant_other")]
        public string SignificantOther { get; set; }
        [User("kids_names")]
        public string KidsNames { get; set; }
        [User("interests")]
        public string Interests { get; set; }
        [User("summary")]
        public string Summary { get; set; }
        [User("expertise")]
        public string Expertise { get; set; }
        [User("education[]")]
        public List<UserEducation> Education { get; set; }
        [User("previous_companies[]")]
        public List<PreviousCompany> PreviousCompanies { get; set; }

        public static void AddUserParam(NameValueCollection parameters, UserParameters userParams)
        {
            PropertyInfo[] pic = userParams.GetType().GetProperties();
            UserAttribute name;
            foreach (PropertyInfo pi in pic)
            {
                object value = pi.GetValue(userParams, null);
                bool include = false;
                if (value != null)
                {
                    string typeName = value.GetType().Name;
                    switch (typeName)
                    {
                        case "String":
                            name = (UserAttribute)UserAttribute.GetCustomAttribute(pi, typeof(UserAttribute));
                            parameters.Add(name.Name, pi.GetValue(userParams, null).ToString());
                            break;
                        case "List`1":
                            name = (UserAttribute)UserAttribute.GetCustomAttribute(pi, typeof(UserAttribute));
                            if (name.Name == "education[]")
                            {
                                List<UserEducation> edl = (List<UserEducation>)pi.GetValue(userParams, null);
                                foreach (UserEducation pc in edl)
                                    parameters.Add(name.Name, pc.School + "," + pc.Degree + "," + pc.Description + "," + pc.StartYear + "," + pc.EndYear);

                            }
                            else if (name.Name == "previous_companies[]")
                            {
                                List<PreviousCompany> pcl = (List<PreviousCompany>)pi.GetValue(userParams, null);
                                foreach (PreviousCompany pc in pcl)
                                    parameters.Add(name.Name, pc.Company + "," + pc.Position + "," + pc.Description + "," + pc.StartYear + "," + pc.EndYear);
                            }
                            break;
                        default:
                            include = false;
                            break;
                    }
                }
            }
        }

    }

    public class UserAttribute : System.Attribute
    {
        public string Name { get; set; }

        public UserAttribute(string name)
        {
            this.Name = name;
        }

    }
    public struct UserEducation
    {


        public static UserEducation Create(string school, string degree, string description, string startYear, string endYear)
        {
            UserEducation ue = new UserEducation();
            ue.School = school;
            ue.Degree = degree;
            ue.Description = description;
            ue.StartYear = startYear;
            ue.EndYear = endYear;

            return ue;
        }

        public string School { get; set; }
        public string Degree { get; set; }
        public string Description { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
    }
    public struct PreviousCompany
    {
        public static PreviousCompany Create(string company, string position, string description, string startYear, string endYear)
        {
            PreviousCompany pc = new PreviousCompany();
            pc.Company = company;
            pc.Position = position;
            pc.Description = description;
            pc.StartYear = startYear;
            pc.EndYear = endYear;

            return pc;
        }

        public string Company { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
    }
}
