using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using EasyMS.API.Entities.Enums;
using EasyMS.API.Exceptions;
using EasyMS.API.Extensions;
using EasyMS.API.Utils;
using Newtonsoft.Json;

namespace EasyMS.API.Entities
{
    public sealed class Credentials
    {
        /// <summary>
        /// Токен доступа
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Тип токена (всегда bearer)
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Токен для получения нового токена
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("expires_in")]
        public int? ExpiresIn { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public void ValidateRefreshToken()
        {
            var messages = new ValidationMessages();

            if (string.IsNullOrEmpty(RefreshToken))
            {
                messages.Add("RefreshToken не указан. Используй refresh_token свойство для установки RefreshToken.");
            }

            if (messages.HasErrors)
            {
                throw new EasyMSValidationException(messages);
            }
        }

        public void ValidatePassword()
        {
            var messages = new ValidationMessages();

            if (string.IsNullOrEmpty(UserName))
            {
                messages.Add("UserName не указан. Используй username свойство для установки UserName.");
            }

            if (string.IsNullOrEmpty(Password))
            {
                messages.Add("Password не указан. Используй password свойство для установки Password.");
            }

            if (messages.HasErrors)
            {
                throw new EasyMSValidationException(messages);
            }
        }

        internal IDictionary<string, object> ToParameters(GrantType type)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("grant_type", type.GetAttributeOfType<EnumMemberAttribute>().Value);

            switch (type)
            {
                case GrantType.Password:
                    parameters.Add("username", UserName);
                    parameters.Add("password", Password);
                    break;
                default:
                    return parameters;
            }

            return parameters;
        }
    }
}
