using System;
using Jobb.Models.Implementations;

namespace Jobb.Utility
{
    public static class MillisecondsCalculator
    {
        public static ulong GetMilliseconds(Schedule schedule)
        {
            return schedule.Period switch
            {
                Period.Seconds => 1000 * Convert.ToUInt64(schedule.Unit),
                Period.Minutes => 60000 * Convert.ToUInt64(schedule.Unit),
                Period.Hours => 3600000 * Convert.ToUInt64(schedule.Unit),
                Period.Days => 86400000 * Convert.ToUInt64(schedule.Unit),
                Period.Weeks => 604800016 * Convert.ToUInt64(schedule.Unit),
                Period.Months => 2629800000 * Convert.ToUInt64(schedule.Unit),
                Period.Years => 31557600000 * Convert.ToUInt64(schedule.Unit),
                _ => 0
            };
        }
    }
}