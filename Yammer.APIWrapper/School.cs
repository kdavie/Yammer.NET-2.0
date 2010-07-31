using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Yammer.APIWrapper
{
    public class School
    {
        /// <summary>
        /// The name of the company
        /// </summary>
        [JsonProperty(PropertyName = "school")]
        public string Name { get; set; }

        /// <summary>
        /// The degree the user earned
        /// </summary>
        [JsonProperty(PropertyName = "degree")]
        public string Degree { get; set; }

        /// <summary>
        /// A description of the user's degree
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The year the user started at the school
        /// </summary>
        [JsonProperty(PropertyName = "start_year")]
        public int StartYear { get; set; }

        /// <summary>
        /// The year the user left the school
        /// </summary>
        [JsonProperty(PropertyName = "end_year")]
        public int EndYear { get; set; }

    }
}
