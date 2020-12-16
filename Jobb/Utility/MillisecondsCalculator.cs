using System;
using Jobb.Models.Implementations;

namespace Jobb.Utility
{
    public static class MillisecondsCalculator
    {
        private const ulong SECOND_IN_MILLISECONDS = 1_000;
        private const ulong MINUTE_IN_MILLISECONDS = 60_000;
        private const ulong HOUR_IN_MILLISECONDS = 3_600_000;
        private const ulong DAY_IN_MILLISECONDS = 86_400_000;
        private const ulong WEEK_IN_MILLISECONDS = 604_800_016;
        private const ulong MONTH_IN_MILLISECONDS = 2_629_800_000;
        private const ulong YEAR_IN_MILLISECONDS = 31_557_600_000;

        public static ulong GetMilliseconds(Schedule schedule)
        {
            return schedule.Period switch
            {
                Period.Seconds => SECOND_IN_MILLISECONDS * Convert.ToUInt64(schedule.Unit),
                Period.Minutes => MINUTE_IN_MILLISECONDS * Convert.ToUInt64(schedule.Unit),
                Period.Hours => HOUR_IN_MILLISECONDS * Convert.ToUInt64(schedule.Unit),
                Period.Days => DAY_IN_MILLISECONDS * Convert.ToUInt64(schedule.Unit),
                Period.Weeks => WEEK_IN_MILLISECONDS * Convert.ToUInt64(schedule.Unit),
                Period.Months => MONTH_IN_MILLISECONDS * Convert.ToUInt64(schedule.Unit),
                Period.Years => YEAR_IN_MILLISECONDS * Convert.ToUInt64(schedule.Unit),
                _ => 0
            };
        }
    }
}