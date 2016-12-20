using System;

namespace NetAdmin.Auth
{
    public static class DateTimeExtensions
    {
        public static DateTimeOffset FromUnixTimeSeconds(this long seconds)
        {
            var dateTimeOffset = new DateTimeOffset(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            dateTimeOffset = dateTimeOffset.AddSeconds(seconds);
            return dateTimeOffset;
        }

        public static long ToUnixTimeSeconds(this DateTimeOffset dateTimeOffset)
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var unixTimeStampInTicks = (dateTimeOffset.ToUniversalTime() - unixStart).Ticks;
            return unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }

        public static long ToUnixTimeSeconds(this DateTime dateTime)
        {
            return ToUnixTimeSeconds((DateTimeOffset) DateTime.SpecifyKind(dateTime, DateTimeKind.Utc));
        }
    }
}