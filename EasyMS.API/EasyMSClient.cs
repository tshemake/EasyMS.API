using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using EasyMS.API.Endpoints;
using EasyMS.API.Extensions;
using EasyMS.API.Utils;
using EasyMS.API.Web;
using Microsoft.Extensions.DependencyInjection;

namespace EasyMS.API
{
    public class EasyMSClient : IEasyMSClient
    {
        public const string HttpClientName = "EasyMS.API";

        public EasyMSAuthInfo AuthInfo { get; }

        public IOAuth OAuth { get; }

        public EasyMSClient(IHttpClientFactory httpClientFactory, EasyMSAuthInfo authInfo)
        {
            AuthInfo = authInfo;

            var gateway = new EasyMSAPIGateway(httpClientFactory);

            OAuth = new OAuth(gateway);
        }

        public static IEasyMSClient CreateAuthorized(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentException($"'{nameof(accessToken)}' не могут быть null или пустыми");
            }

            return GetClient(new EasyMSAuthInfo(accessToken));
        }

        private static IEasyMSClient GetClient(EasyMSAuthInfo credentials)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddEasyMSClient(credentials);

            var provider = serviceCollection.BuildServiceProvider();
            return provider.GetService<EasyMSClient>();
        }
    }
}
