using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EasyMS.API.Entities
{
    public class Resources<TEntity>
    {
        [JsonProperty("_embedded")]
        public Dictionary<string, List<TEntity>> Embedded { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }
}
