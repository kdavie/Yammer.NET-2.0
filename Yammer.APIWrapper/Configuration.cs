using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper
{
    public class Configuration
    {
     
        const string APP_NAME = "";

        const string CONSUMER_KEY = "";
        const string CONSUMER_SECRET = ""; 

       


        const string APP_PATH = "https://www.yammer.com";

        public static string ApplicationName
        {
            get
            {
                if (APP_NAME == string.Empty)
                    try
                    {
                        return System.Configuration.ConfigurationSettings.AppSettings["APP_NAME"];
                    }
                    catch (NullReferenceException ex)
                    {
                        throw new NullReferenceException("The application name cannot be null!");
                    }

                return APP_NAME;
            }
        }

        public static string WebUrl
        {
            get
            {
                try
                {
                    if (APP_PATH == string.Empty)
                        return System.Configuration.ConfigurationSettings.AppSettings["APP_PATH"];
                }
                catch (NullReferenceException ex)
                {
                    throw new NullReferenceException("The application path cannot be null!");
                }

                return APP_PATH;
            }
        }

        public static string ConsumerKey
        {
            get
            {
                try
                {
                    if (CONSUMER_KEY == string.Empty)
                        return System.Configuration.ConfigurationSettings.AppSettings["CONSUMER_KEY"];
                }
                catch (NullReferenceException ex)
                {
                    throw new NullReferenceException("The consumer key cannot be null!");
                }

                return CONSUMER_KEY;
            }
        }

        public static string ConsumerSecret
        {
            get
            {
                try
                {
                    if (CONSUMER_SECRET == string.Empty)
                        return System.Configuration.ConfigurationSettings.AppSettings["CONSUMER_SECRET"];

                }
                catch (NullReferenceException ex)
                {
                    throw new NullReferenceException("The consumer secret cannot be null!");
                }
                return CONSUMER_SECRET;
            }
        }
    }
}
