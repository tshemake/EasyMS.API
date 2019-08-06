using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using EasyMS.API.Json;
using Newtonsoft.Json;

namespace EasyMS.API.Entities.Enums
{
    [JsonConverter(typeof(TolerantEnumConverter))]
    public enum GrantType
    {
        [EnumMember(Value = "none")]
        None = 0,

        [EnumMember(Value = "password")]
        Password,
    }
}
