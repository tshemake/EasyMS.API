using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyMS.API.Entities;
using EasyMS.API.Entities.Enums;
using EasyMS.API.QueryBuilders;
using EasyMS.API.Web;

namespace EasyMS.API.Endpoints
{
    internal sealed class OAuth : IOAuth
    {
        private const string TokenPath = "oauth/token";

        private readonly IEasyMSAPIGateway _gateway;

        public OAuth(IEasyMSAPIGateway gateway)
        {
            _gateway = gateway;
        }

        /// <summary>
        /// Аутентификация
        /// </summary>
        public async Task<Credentials> LoginAsync(Credentials credentials)
        {
            credentials.ValidatePassword();

            var builder = new OAuthQueryBuilder { Path = TokenPath };
            return await _gateway.SendPostRequestAsync<Credentials>(builder.BuildUri(), credentials.ToParameters(GrantType.Password));
        }
    }
}
