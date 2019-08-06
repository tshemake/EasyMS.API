using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EasyMS.API.Entities
{
    public class Page
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("totalElements")]
        public int TotalElements { get; set; }
    }
}
