using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EasyMS.API.Entities
{
    public class Link
    {
        [JsonProperty("href")]
        public string Url { get; set; }
    }
}
