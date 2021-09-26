using System;

namespace Core.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfDay(this DateTime value)
        {
            return value.Date;
        }

        public static DateTime EndOfDay(this DateTime value)
        {
            return value.Date.AddDays(1).AddTicks(-1);
        }
    }
}
