using Jobb.Exceptions;
using Jobb.Utility;

namespace Jobb.Models.Implementations
{
    public class Schedule
    {
        private const uint GENERAL_LOWER_BOUND = 0;
        private const uint SECONDS_UPPER_BOUND = 60;
        private const uint MINUTES_UPPER_BOUND = 60;
        private const uint HOURS_UPPER_BOUND = 24;
        private const uint DAYS_UPPER_BOUND = 32;
        private const uint WEEKS_UPPER_BOUND = 52;
        private const uint MONTHS_UPPER_BOUND = 12;

        private int _unit;

        public int Unit
        {
            get => _unit;
            set
            {
                _unit = Period switch
                {
                    Period.Seconds when value > GENERAL_LOWER_BOUND && value < SECONDS_UPPER_BOUND => value,
                    Period.Seconds => throw new PeriodValueOutOfBoundsException(
                        GetExceptionMessage(GENERAL_LOWER_BOUND, SECONDS_UPPER_BOUND)),
                    Period.Minutes when value > GENERAL_LOWER_BOUND && value < MINUTES_UPPER_BOUND => value,
                    Period.Minutes => throw new PeriodValueOutOfBoundsException(
                        GetExceptionMessage(GENERAL_LOWER_BOUND, MINUTES_UPPER_BOUND)),
                    Period.Hours when value > GENERAL_LOWER_BOUND && value < HOURS_UPPER_BOUND => value,
                    Period.Hours => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GENERAL_LOWER_BOUND,
                        HOURS_UPPER_BOUND)),
                    Period.Days when value > GENERAL_LOWER_BOUND && value < DAYS_UPPER_BOUND => value,
                    Period.Days => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GENERAL_LOWER_BOUND,
                        DAYS_UPPER_BOUND)),
                    Period.Weeks when value > GENERAL_LOWER_BOUND && value < WEEKS_UPPER_BOUND => value,
                    Period.Weeks => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GENERAL_LOWER_BOUND,
                        WEEKS_UPPER_BOUND)),
                    Period.Months when value > GENERAL_LOWER_BOUND && value < MONTHS_UPPER_BOUND => value,
                    Period.Months => throw new PeriodValueOutOfBoundsException(
                        GetExceptionMessage(GENERAL_LOWER_BOUND, MONTHS_UPPER_BOUND)),
                    Period.Years when value > GENERAL_LOWER_BOUND => value,
                    Period.Years => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GENERAL_LOWER_BOUND)),
                    _ => throw new PeriodValueOutOfBoundsException("Please specify a matching period.")
                };
            }
        }

        public Period Period { get; set; }

        public Schedule()
        {
            Period = Period.Seconds;
            Unit = 1;
        }

        public Schedule(Period period, int unit)
        {
            Period = period;
            Unit = unit;
        }

        private static string GetExceptionMessage(uint lowerBound, uint upperBound = 0)
        {
            return upperBound > 0
                ? $"Invalid value for Period. Value has to be between <{lowerBound + 1}> and <{upperBound - 1}>."
                : $"Invalid value for Period. Value has to be at least <{lowerBound + 1}>.";
        }
    }
}