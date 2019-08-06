using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyMS.API.Utils;

namespace EasyMS.API.Web
{
    public class EasyMSBearerAuthenticationHandler : DelegatingHandler
    {
        private readonly EasyMSAuthInfo _credentials;

        public EasyMSBearerAuthenticationHandler(EasyMSAuthInfo credentials)
        {
            _credentials = credentials;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AppendCredentials(request, _credentials);
            return await base.SendAsync(request, cancellationToken);
        }

        private static void AppendCredentials(HttpRequestMessage request, EasyMSAuthInfo credentials)
        {
            if (!string.IsNullOrEmpty(credentials.AccessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", credentials.AccessToken);
            }
        }
    }
}
