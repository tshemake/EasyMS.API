using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using EasyMS.API.Json;
using Newtonsoft.Json;

namespace EasyMS.API.Entities.Enums
{
    [JsonConverter(typeof(TolerantEnumConverter))]
    public enum PayMethod
    {
        [EnumMember(Value = "none")]
        None = 0,

        [EnumMember(Value = "TERMINAL")]
        Terminal,

        [EnumMember(Value = "CASH")]
        Cash,

        [EnumMember(Value = "CARD")]
        Card,

        [EnumMember(Value = "CASHLESS")]
        Cashless,
    }
}
