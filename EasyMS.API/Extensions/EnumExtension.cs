using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMS.API.Extensions
{
    internal static class EnumExtension
    {
        internal static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
        {
            var memInfo = enumVal.GetType().GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }
    }
}
