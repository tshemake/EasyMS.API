using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EasyMS.API.Entities
{
    public class Customer
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("telephone")]
        public string telephone { get; set; }
    }
}
