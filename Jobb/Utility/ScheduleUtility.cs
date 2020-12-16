using System;
using System.Data;
using Jobb.Models.Implementations;

namespace Jobb.Utility
{
    public static class ScheduleUtility
    {
        public static Schedule GetScheduleFromString(string periodAsString, string unitAsString)
        {
            Period targetPeriod = GetPeriodFromString(periodAsString);
            int targetUnit = GetUnitFromString(unitAsString);
            return new Schedule(targetPeriod, targetUnit);
        }

        private static int GetUnitFromString(string unitAsString)
        {
            bool intResultTryParse = int.TryParse(unitAsString, out int targetUnit);
            if (intResultTryParse)
            {
                return targetUnit;
            }
            throw new InvalidCastException("The unit input as string is not in an integer format!");
        }

        private static Period GetPeriodFromString(string periodAsString)
        {
            periodAsString = periodAsString.ToLower();
            Period targetPeriod = periodAsString switch
            {
                "seconds" => Period.Seconds,
                "minutes" => Period.Minutes,
                "hours" => Period.Hours,
                "days" => Period.Days,
                "weeks" => Period.Weeks,
                "months" => Period.Months,
                "years" => Period.Years,
                _ => throw new InvalidExpressionException(
                    $"The value <{periodAsString}> is an invalid period expression. Valid expressions are: seconds, minutes, hours, days, weeks, months and years.")
            };
            return targetPeriod;
        }
    }
}