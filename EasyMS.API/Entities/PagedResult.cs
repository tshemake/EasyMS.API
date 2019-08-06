using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EasyMS.API.Entities
{
    public sealed class PagedResult<TEntity> : IPagedResult<TEntity> where TEntity : Entity
    {
        [JsonProperty("resources")]
        public Resources<TEntity> Resources { get; set; }

        [JsonProperty("page")]
        public Page Page { get; set; }
    }
}
