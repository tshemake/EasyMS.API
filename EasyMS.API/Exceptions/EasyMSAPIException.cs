using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace EasyMS.API.Exceptions
{
    public class EasyMSAPIException : Exception
    {
        internal EasyMSAPIException(HttpStatusCode httpStatusCode, HttpContent httpContent)
        {
            HttpStatusCode = httpStatusCode;
            HttpContent = httpContent;
        }

        public HttpStatusCode HttpStatusCode { get; }

        public HttpContent HttpContent { get; }
    }
}
