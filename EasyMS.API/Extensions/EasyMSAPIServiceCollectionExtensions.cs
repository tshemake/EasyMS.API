using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using EasyMS.API.Utils;
using EasyMS.API.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EasyMS.API.Extensions
{
    public static class EasyMSAPIServiceCollectionExtensions
    {
        public static IServiceCollection AddEasyMSClient(this IServiceCollection serviceCollection, EasyMSAuthInfo credentials)
        {
            serviceCollection.AddSingleton<EasyMSClient>();

            serviceCollection.AddEasyMSHttpClient(credentials);

            return serviceCollection;
        }

        public static IHttpClientBuilder AddEasyMSHttpClient(this IServiceCollection serviceCollection, EasyMSAuthInfo credentials)
        {
            var version = typeof(EasyMSClient).Assembly.GetName().Version.ToString();
            var userAgent = new ProductInfoHeaderValue("EasyMS.API", version);

            serviceCollection.TryAddSingleton(credentials);
            serviceCollection.TryAddTransient<EasyMSBearerAuthenticationHandler>();

            var builder = serviceCollection.AddHttpClient(EasyMSClient.HttpClientName);
            builder.AddHttpMessageHandler<EasyMSBearerAuthenticationHandler>();
            builder.ConfigureHttpClient(c => { c.DefaultRequestHeaders.UserAgent.Add(userAgent); });

            return builder;
        }
    }
}
