using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyMS.API.Entities;
using EasyMS.API.Web;

namespace EasyMS.API.Endpoints
{
    internal abstract class Endpoint
    {
        protected readonly IEasyMSAPIGateway Gateway;

        internal Endpoint(IEasyMSAPIGateway gateway)
        {
            Gateway = gateway;
        }

        protected async Task<EasyMSList<T>> GetPage<T>(Uri href, string key) where T : Entity
        {
            var page = await Gateway.SendGetRequestAsync<PagedResult<T>>(href);

            return new EasyMSList<T>(page.Resources.Embedded[key]);
        }
    }
}
