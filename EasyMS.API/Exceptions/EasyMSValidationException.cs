using System;
using System.Collections.Generic;
using System.Text;
using EasyMS.API.Utils;

namespace EasyMS.API.Exceptions
{
    public class EasyMSValidationException : Exception
    {
        internal EasyMSValidationException(string message)
            : base(message)
        {
        }

        internal EasyMSValidationException(ValidationMessages messages)
            : base(messages.ToString())
        {
        }
    }
}
