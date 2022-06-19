using System;

namespace Xove.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToStartOfYear(this DateTime dateTime)
        {
            var startDate = dateTime.ToStartOfMonth();

            if (startDate.Month != 1)
            {
                startDate = startDate.AddMonths(-startDate.Month).AddMonths(1);
            }

            return startDate;
        }
        public static DateTime ToStartOfMonth(this DateTime dateTime)
        {
            var startDate = dateTime;

            if (startDate.Day != 1)
            {
                startDate = startDate.AddDays(-startDate.Day).AddDays(1);
            }

            return startDate;
        }

        public static DateTime ToStartOfWeek(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            var startDate = dateTime;

            while (startDate.DayOfWeek != dayOfWeek)
            {
                startDate = startDate.AddDays(-1);
            }

            return startDate;
        }

        public static DateTime ToStartOfWeek(this DateTime dateTime)
        {
            var startDate = dateTime;

            while (startDate.DayOfWeek != DayOfWeek.Sunday)
            {
                startDate = startDate.AddDays(-1);
            }

            return startDate;
        }
        public static DateTime ToEndOfYear(this DateTime dateTime)
        {
            return dateTime.ToStartOfYear().AddMonths(11).AddDays(30);

        }
        public static DateTime ToEndOfWeek(this DateTime dateTime)
        {
            return dateTime.ToStartOfWeek().AddDays(6);
        }

        public static DateTime ToEndOfWeek(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            return dateTime.ToStartOfWeek(dayOfWeek).AddDays(6);
        }

        public static DateTime ToEndOfMonth(this DateTime dateTime)
        {
            return dateTime.ToStartOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime ToMinDate(this DateTime dateTime)
        {
            return new DateTime(1753, 1, 1, dateTime.Hour, dateTime.Minute, 0);
        }

    }
}