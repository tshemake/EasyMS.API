using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EasyMS.API.Entities
{
    public class Links
    {
        [JsonProperty("first")]
        public Link First { get; set; }

        [JsonProperty("self")]
        public Link Self { get; set; }

        [JsonProperty("last")]
        public Link Last { get; set; }
    }
}
