using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Yammer.APIWrapper
{
    public class Company
    {
        /// <summary>
        /// The name of the company
        /// </summary>
        [JsonProperty(PropertyName = "employer")]
        public string Employer { get; set; }

        /// <summary>
        /// The position the user held
        /// </summary>
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }

        /// <summary>
        /// A description of the user's position
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The year the user started and the company
        /// </summary>
        [JsonProperty(PropertyName = "start_year")]
        public int StartYear { get; set; }

        /// <summary>
        /// The year the user left the company
        /// </summary>
        [JsonProperty(PropertyName = "end_year")]
        public int EndYear { get; set; }

    }
}
