using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EasyMS.API.Entities;
using EasyMS.API.Exceptions;
using Newtonsoft.Json;

namespace EasyMS.API
{
    public static class EasyMSAuth
    {
        private static readonly string Version = typeof(EasyMSClient).Assembly.GetName().Version.ToString();

        public static async Task<Credentials> FromPassword(string userName, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var formData = new MultipartFormDataContent();
                formData.Add(CreateStringContent("password"), "\"grant_type\"");
                formData.Add(CreateStringContent(userName), "\"username\"");
                formData.Add(CreateStringContent(password), "\"password\"");

                var message = new HttpRequestMessage(HttpMethod.Post, "https://my.easyms.co/oauth/token");
                message.Headers.UserAgent.Add(new ProductInfoHeaderValue("EasyMSAuth.API", Version));
                message.Content = formData;

                var response = await httpClient.SendAsync(message);

                if (!response.IsSuccessStatusCode)
                {
                    throw new EasyMSAPIException(response.StatusCode, response.Content);
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Credentials>(responseContent);
            }
        }

        private static StringContent CreateStringContent(string content)
        {
            var stringContent = new StringContent(content);
            stringContent.Headers.Remove("Content-Type");
            return stringContent;
        }
    }
}
