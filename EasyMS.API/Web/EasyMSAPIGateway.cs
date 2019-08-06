using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EasyMS.API.Entities;
using EasyMS.API.Exceptions;
using EasyMS.API.Json;
using Newtonsoft.Json;

namespace EasyMS.API.Web
{
    internal sealed class EasyMSAPIGateway : IEasyMSAPIGateway
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerSettings _jsonDeserializeSettings;
        private readonly JsonSerializerSettings _jsonSerializeSettings;

        public EasyMSAPIGateway(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _jsonSerializeSettings = new JsonSerializerSettings
            {
                ContractResolver = new SpecialContractResolver()
            };

            _jsonDeserializeSettings = new JsonSerializerSettings
            {
                ContractResolver = new SpecialContractResolver()
            };
        }

        public async Task<TResult> SendPostRequestAsync<TResult>(Uri uri, IDictionary<string, object> formData)
        {
            var multipartFormDataContent = CreateMultipartFormDataContent(formData);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = multipartFormDataContent
            };

            return await SendRequestAsync<TResult>(httpRequestMessage);
        }

        public Task SendPostRequestAsync(Uri uri, Entity data)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(
                   JsonConvert.SerializeObject(data, _jsonSerializeSettings),
                   Encoding.Default,
                   "application/json"
               )
            };

            return SendRequestAsync(httpRequestMessage);
        }

        public Task<TResult> SendDeleteRequestAsync<TResult>(Uri uri)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            return SendRequestAsync<TResult>(httpRequestMessage);
        }

        public Task<TResult> SendGetRequestAsync<TResult>(Uri uri)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            return SendRequestAsync<TResult>(httpRequestMessage);
        }

        public Task<TResult> SendPutRequestAsync<TResult>(Uri uri, IDictionary<string, object> formData)
        {
            var multipartFormDataContent = CreateMultipartFormDataContent(formData);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = multipartFormDataContent
            };

            return SendRequestAsync<TResult>(httpRequestMessage);
        }

        public Task<TResult> SendPutRequestAsync<TResult>(Uri uri)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, uri);
            return SendRequestAsync<TResult>(httpRequestMessage);
        }

        private static MultipartFormDataContent CreateMultipartFormDataContent(IDictionary<string, object> formData)
        {
            var multipartFormDataContent = new MultipartFormDataContent();
            foreach (var entry in formData)
            {
                if (entry.Value is string stringParameter)
                {
                    var stringContent = new StringContent(stringParameter);
                    stringContent.Headers.Remove("Content-Type");
                    multipartFormDataContent.Add(stringContent, "\"" + entry.Key + "\"");
                }

                var intParameter = entry.Value as int?;
                if (intParameter != null)
                {
                    var stringContent = new StringContent(intParameter.ToString());
                    stringContent.Headers.Remove("Content-Type");
                    multipartFormDataContent.Add(stringContent, entry.Key);
                }

                if (entry.Value is Stream streamParameter)
                {
                    var streamContent = new StreamContent(streamParameter);
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    multipartFormDataContent.Add(streamContent, entry.Key);
                }

                if (entry.Value is Enum enumParameter)
                {
                    var stringContent = new StringContent(enumParameter.ToString());
                    stringContent.Headers.Remove("Content-Type");
                    multipartFormDataContent.Add(stringContent, entry.Key);
                }
            }

            return multipartFormDataContent;
        }

        private async Task<TResult> SendRequestAsync<TResult>(HttpRequestMessage httpRequestMessage)
        {
            var httpClient = _clientFactory.CreateClient(EasyMSClient.HttpClientName);
            var response = await httpClient.SendAsync(httpRequestMessage);

            if (!response.IsSuccessStatusCode)
            {
                throw new EasyMSAPIException(response.StatusCode, response.Content);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(responseContent, _jsonDeserializeSettings);
        }

        private async Task SendRequestAsync(HttpRequestMessage httpRequestMessage)
        {
            var httpClient = _clientFactory.CreateClient(EasyMSClient.HttpClientName);
            var response = await httpClient.SendAsync(httpRequestMessage);

            if (!response.IsSuccessStatusCode)
            {
                throw new EasyMSAPIException(response.StatusCode, response.Content);
            }
        }
    }
}
