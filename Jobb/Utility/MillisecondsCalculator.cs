using System;
using Jobb.Models.Implementations;

namespace Jobb.Utility
{
    public static class MillisecondsCalculator
    {
        private const ulong SecondInMilliseconds = 1_000;
        private const ulong MinuteInMilliseconds = 60_000;
        private const ulong HourInMilliseconds = 3_600_000;
        private const ulong DayInMilliseconds = 86_400_000;
        private const ulong WeekInMilliseconds = 604_800_016;
        private const ulong MonthInMilliseconds = 2_629_800_000;
        private const ulong YearInMilliseconds = 31_557_600_000;
        public static ulong GetMilliseconds(Schedule schedule)
        {
            return schedule.Period switch
            {
                Period.Seconds => SecondInMilliseconds * Convert.ToUInt64(schedule.Unit),
                Period.Minutes => MinuteInMilliseconds * Convert.ToUInt64(schedule.Unit),
                Period.Hours => HourInMilliseconds * Convert.ToUInt64(schedule.Unit),
                Period.Days => DayInMilliseconds * Convert.ToUInt64(schedule.Unit),
                Period.Weeks => WeekInMilliseconds * Convert.ToUInt64(schedule.Unit),
                Period.Months => MonthInMilliseconds * Convert.ToUInt64(schedule.Unit),
                Period.Years => YearInMilliseconds * Convert.ToUInt64(schedule.Unit),
                _ => 0
            };
        }
    }
}