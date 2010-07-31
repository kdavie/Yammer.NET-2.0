using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using Yammer.APIWrapper.OAuth;

namespace Yammer.APIWrapper
{
    public class Settings
    {
        public Settings()
        {
            this.Proxy = new ProxySettings();
            this.OAuth = new OAuthSettings();
        }
        [XmlElement]
        public ProxySettings Proxy { get; set; }
        [XmlElement]
        public OAuthSettings OAuth { get; set; }
        [XmlElement]
        public string UserId { get; set; }
        [XmlElement]
        public string Email { get; set; }
        [XmlElement]
        public string Domain { get; set; }
        private bool showAvatars = true;
        [XmlElement]
        public bool ShowAvatars
        {
            get
            {
                return showAvatars;
            }
            set
            {
                showAvatars = value;
            }
        }
        private bool showFullNames = true;
        [XmlElement]
        public bool ShowFullNames
        {
            get
            {
                return showFullNames;
            }
            set
            {
                showFullNames = value;
            }
        }
        [XmlElement]
        public bool SupressEnterKey { get; set; }

        [XmlElement]
        public bool SmtpUseSSL { get; set; }
        [XmlElement]
        public string SmtpHost { get; set; }
        [XmlElement]
        public string SmtpPort { get; set; }
        [XmlElement]
        public string SmtpUser { get; set; }
        [XmlElement]
        public string SmtpPass { get; set; }
        [XmlElement]
        public string EmailRecipients { get; set; }

        [XmlElement]
        public int PollInterval { get; set; }


        private DateTime lastUpdateCheck = DateTime.Now.Subtract(new TimeSpan(6, 0, 0));

        [XmlElement]
        public DateTime LastUpdateCheck
        {
            get { return lastUpdateCheck; }
            set { lastUpdateCheck = value; }
        }

        private int updateFrequency = 6;


        [XmlElement]
        public int UpdateFrequency
        {
            get { return updateFrequency; }
            set { updateFrequency = value; }
        }




        /// <summary>
        /// Checks if the persisted <see cref="Settings">settings</see> file exists on the client
        /// </summary>
        /// <returns></returns>
        public static Settings CheckConfiguration()
        {

            Dictionary<string, DirectoryInfo> appData = Utility.GetAppData();
            string path = appData["data"] + "\\settings.yam";
            if (System.IO.File.Exists(appData["data"] + "\\settings.yam"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                TextReader reader = new StreamReader(appData["data"] + "\\settings.yam");
                Settings settings = (Settings)serializer.Deserialize(reader);
                reader.Close();
                if (settings.OAuth.TokenKey != null && settings.OAuth.TokenSecret != null)
                    return settings;
                else
                    return null;

            }
            return null;
        }
        /// <summary>
        /// Saves the <see cref="Settings">settings</see> file to the client
        /// </summary>
        /// <param name="tokenKey"></param>
        /// <param name="tokenSecret"></param>
        public static void SaveConfiguration(string tokenKey, string tokenSecret, OAuthKey key, WebProxy proxy)
        {
            Dictionary<string, DirectoryInfo> appData = Utility.GetAppData();
            Settings settings = new Settings();
            if (proxy != null)
            {
                settings.Proxy.Address = proxy.Address.Host;
                settings.Proxy.Port = proxy.Address.Port.ToString();
                NetworkCredential creds = (NetworkCredential)proxy.Credentials;
                if (creds != null)
                {
                    settings.Proxy.Id = creds.UserName;
                    settings.Proxy.Password = creds.Password;
                }
                settings.Proxy.Enable = true;
            }
            else
                settings.Proxy.Enable = false;
            key.TokenKey = tokenKey;
            key.TokenSecret = tokenSecret;
            settings.OAuth.TokenKey = tokenKey;
            settings.OAuth.TokenSecret = tokenSecret;


            TextWriter writer = new StreamWriter(appData["data"] + "\\settings.yam");
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            serializer.Serialize(writer, settings);
            writer.Close();

        }

        public void Save()
        {
            Dictionary<string, DirectoryInfo> appData = Utility.GetAppData();
            TextWriter writer = new StreamWriter(appData["data"] + "\\settings.yam");
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            serializer.Serialize(writer, this);
            writer.Close();
        }

        public static void RemoveConfiguration()
        {
            Dictionary<string, DirectoryInfo> appData = Utility.GetAppData();
            FileInfo fi = new FileInfo(appData["data"] + "\\settings.yam");
            if (fi.Exists)
                fi.Delete();
        }
    }

    public class ProxySettings
    {
        [XmlAttribute]
        public bool Enable { get; set; }
        [XmlElement]
        public string Address { get; set; }
        [XmlElement]
        public string Port { get; set; }
        [XmlElement]
        public string Id { get; set; }
        [XmlElement]
        public string Password { get; set; }

    }

    public class OAuthSettings
    {
        [XmlElement]
        public string TokenKey { get; set; }
        [XmlElement]
        public string TokenSecret { get; set; }
    }
}
