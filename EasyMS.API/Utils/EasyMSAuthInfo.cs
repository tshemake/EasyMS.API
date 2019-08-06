using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMS.API.Utils
{
    public class EasyMSAuthInfo
    {
        public EasyMSAuthInfo(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentException($"{nameof(accessToken)} не может быть null или пустым");
            }

            AccessToken = accessToken;
        }

        public string AccessToken { get; }
    }
}
