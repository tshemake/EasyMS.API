using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyMS.API.Entities;

namespace EasyMS.API.Web
{
    internal interface IEasyMSAPIGateway
    {
        Task<TResult> SendPostRequestAsync<TResult>(Uri uri, IDictionary<string, object> formData);

        Task SendPostRequestAsync(Uri uri, Entity data);

        Task<TResult> SendDeleteRequestAsync<TResult>(Uri uri);

        Task<TResult> SendGetRequestAsync<TResult>(Uri uri);

        Task<TResult> SendPutRequestAsync<TResult>(Uri uri, IDictionary<string, object> formData);

        Task<TResult> SendPutRequestAsync<TResult>(Uri uri);
    }
}
