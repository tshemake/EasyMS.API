using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMS.API.Entities
{
    internal interface IPagedResult<TEntity>
    {
        Resources<TEntity> Resources { get; set; }

        Page Page { get; set; }
    }
}
