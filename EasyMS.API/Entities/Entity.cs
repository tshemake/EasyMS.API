using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EasyMS.API.Entities
{
    public abstract class Entity
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
