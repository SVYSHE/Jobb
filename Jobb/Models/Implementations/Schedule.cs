using Jobb.Exceptions;
using Jobb.Utility;

namespace Jobb.Models.Implementations {
    public class Schedule {
        private const uint GeneralLowerBound = 0;
        private const uint SecondsUpperBound = 60;
        private const uint MinutesUpperBound = 60;
        private const uint HoursUpperBound = 24;
        private const uint DaysUpperBound = 32;
        private const uint WeeksUpperBound = 52;
        private const uint MonthsUpperBound = 12;

        private int _unit;
        public int Unit {
            get => _unit;
            set {
                _unit = Period switch {
                    Period.Seconds when value > GeneralLowerBound && value < SecondsUpperBound => value,
                    Period.Seconds => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GeneralLowerBound, SecondsUpperBound)),
                    Period.Minutes when value > GeneralLowerBound && value < MinutesUpperBound => value,
                    Period.Minutes => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GeneralLowerBound, MinutesUpperBound)),
                    Period.Hours when value > GeneralLowerBound && value < HoursUpperBound => value,
                    Period.Hours => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GeneralLowerBound, HoursUpperBound)),
                    Period.Days when value > GeneralLowerBound && value < DaysUpperBound => value,
                    Period.Days => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GeneralLowerBound, DaysUpperBound)),
                    Period.Weeks when value > GeneralLowerBound && value < WeeksUpperBound => value,
                    Period.Weeks => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GeneralLowerBound, WeeksUpperBound)),
                    Period.Months when value > GeneralLowerBound && value < MonthsUpperBound => value,
                    Period.Months => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GeneralLowerBound, MonthsUpperBound)),
                    Period.Years when value > GeneralLowerBound => value,
                    Period.Years => throw new PeriodValueOutOfBoundsException(GetExceptionMessage(GeneralLowerBound)),
                    _ => throw new PeriodValueOutOfBoundsException("Please specify a matching period.")
                };
            }
        }
        public Period Period { get; set; }

        public Schedule() {
            Period = Period.Seconds;
            Unit = 1;
        }

        public Schedule(Period period, int unit) {
            Period = period;
            Unit = unit;
        }

        private static string GetExceptionMessage(uint lowerBound, uint upperBound = 0) {
            return upperBound > 0 ? $"Invalid value for Period. Value has to be between <{lowerBound + 1}> and <{upperBound - 1}>."
            : $"Invalid value for Period. Value has to be at least <{lowerBound + 1}>.";
        }
    }
}