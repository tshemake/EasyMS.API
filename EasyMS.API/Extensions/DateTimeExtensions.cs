using System;
using System.Collections.Generic;
using System.Text;

namespace EasyMS.API.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static long ToUnixEpoch(this DateTime dateTime)
        {
            return Convert.ToInt64(dateTime.Subtract(UnixEpoch).TotalSeconds);
        }

        public static DateTime ToDateTime(this long unixTime)
        {
            return UnixEpoch.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
