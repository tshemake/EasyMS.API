using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using EasyMS.API.Json;
using Newtonsoft.Json;

namespace EasyMS.API.Entities.Enums
{
    [JsonConverter(typeof(TolerantEnumConverter))]
    public enum RoomStatus
    {
        [EnumMember(Value = "none")]
        None = 0,

        /// <summary>
        /// бронь
        /// </summary>
        [EnumMember(Value = "booked")]
        Booked,

        /// <summary>
        /// поселен
        /// </summary>
        [EnumMember(Value = "checkedin")]
        Checkedin,

        /// <summary>
        /// выселен
        /// </summary>
        [EnumMember(Value = "checkedout")]
        Checkedout,

        /// <summary>
        /// отменен
        /// </summary>
        [EnumMember(Value = "cancelled")]
        Cancelled,
    }
}
