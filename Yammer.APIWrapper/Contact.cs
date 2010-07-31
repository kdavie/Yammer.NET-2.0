using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Yammer.APIWrapper
{
    public class Contact
    {
        [JsonProperty(PropertyName = "email_addresses")]
        public List<EmailAddress> EmailAddresses { get; set; }

        [JsonProperty(PropertyName = "phone_numbers")]
        public List<PhoneNumber> PhoneNumbers { get; set; }

        [JsonProperty(PropertyName = "im")]
        public InstantMessager InstantMessenger { get; set; }


    }
    [Serializable]
    public class EmailAddress
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
    }
    [Serializable]
    public class PhoneNumber
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }
    }
    [Serializable]
    public class InstantMessager
    {
        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "provider")]
        public string Provider { get; set; }
    }
}
