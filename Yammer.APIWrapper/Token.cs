using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Yammer.APIWrapper
{
    [Serializable]
    [XmlRoot(ElementName = "response")]
    public class Token
    {
        [XmlElement(ElementName = "user-id")]
        public string UserId { get; set; }
        [XmlElement(ElementName = "token")]
        public string Key { get; set; }
        [XmlElement(ElementName = "secret")]
        public string Secret { get; set; }
        [XmlElement(ElementName = "network-id")]
        public int NetworkId { get; set; }
        [XmlElement(ElementName = "network-name")]
        public string NetworkName { get; set; }
        [XmlElement(ElementName = "network-permalink")]
        public string NeworkPermalink { get; set; }
        [XmlElement(ElementName = "view-messages")]
        public bool ViewMessages { get; set; }
        [XmlElement(ElementName = "view-subscriptions")]
        public bool ViewSubscriptions { get; set; }
        [XmlElement(ElementName = "view-members")]
        public bool ViewMembers { get; set; }
        [XmlElement(ElementName = "view-tags")]
        public bool ViewTags { get; set; }
        [XmlElement(ElementName = "view-groups")]
        public bool ViewGroups { get; set; }
        [XmlElement(ElementName = "modify-subscriptions")]
        public bool ModifySubscriptions { get; set; }
        [XmlElement(ElementName = "modify-messages")]
        public bool ModifyMessages { get; set; }
        [XmlElement(ElementName = "created-at")]
        public DateTime CreatedAt { get; set; }
        [XmlElement(ElementName = "authorized-at")]
        public DateTime AuthorizedAt { get; set; }

        public static List<Token> GetNetworkTokens()
        {
            string response = Yammer.APIWrapper.HttpUtility.Get(Resources.OAuth.AllAccessTokens);

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(response);

            List<Token> tokens = new List<Token>();
            XmlNodeList nodes = xdoc.SelectNodes("/response/response");
            foreach (XmlNode node in nodes)
            {
                Token token = (Token)Utility.Deserialize(typeof(Token), node.OuterXml);
                tokens.Add(token);
            }

            return tokens;
        }
    }
}
