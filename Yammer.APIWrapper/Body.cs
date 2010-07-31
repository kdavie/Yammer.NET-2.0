using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yammer.APIWrapper
{
    public class Body
    {
        /// <summary>
        /// A plaintext version of the message body.
        /// </summary>
        public string Plain { get; set; }

        /// <summary>
        /// A version of the message body with #tags and @users replaced by [[object:id]]. 
        /// This is not present in the reference version of a message.
        /// </summary>
        public string Parsed { get; set; }

        /// <summary>
        /// Collection of URLs contained in body
        /// </summary>
        public List<string> Urls { get; set; }

        public override string ToString()
        {
            return this.Plain;
        }

    }
}
