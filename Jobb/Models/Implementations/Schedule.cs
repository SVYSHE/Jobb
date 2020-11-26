using Jobb.Exceptions;
using Jobb.Utility;

namespace Jobb.Models.Implementations {
    public class Schedule
    {
        private const uint GeneralLowerBound = 0;
        private const uint SecondsUpperBound = 60;
        private const uint MinutesUpperBound = 60;
        private const uint HoursUpperBound = 24;
        private const uint DaysUpperBound = 32;
        private const uint WeeksUpperBound = 52;
        private const uint MonthsUpperBound = 12;
        
        private int _unit;
        public int Unit
        {
            get => _unit;
            set
            {
                _unit = Period switch
                {
                    Period.Seconds when value > GeneralLowerBound && value < SecondsUpperBound => value,
                    Period.Seconds => throw new PeriodValueOutOfBoundsException(GeneralLowerBound, SecondsUpperBound),
                    Period.Minutes when value > GeneralLowerBound && value < MinutesUpperBound => value,
                    Period.Minutes => throw new PeriodValueOutOfBoundsException(GeneralLowerBound, MinutesUpperBound),
                    Period.Hours when value > GeneralLowerBound && value < HoursUpperBound => value,
                    Period.Hours => throw new PeriodValueOutOfBoundsException(GeneralLowerBound, HoursUpperBound),
                    Period.Days when value > GeneralLowerBound && value < DaysUpperBound => value,
                    Period.Days => throw new PeriodValueOutOfBoundsException(GeneralLowerBound, DaysUpperBound),
                    Period.Weeks when value > GeneralLowerBound && value < WeeksUpperBound => value,
                    Period.Weeks => throw new PeriodValueOutOfBoundsException(GeneralLowerBound, WeeksUpperBound),
                    Period.Months when value > GeneralLowerBound && value < MonthsUpperBound => value,
                    Period.Months => throw new PeriodValueOutOfBoundsException(GeneralLowerBound, MonthsUpperBound),
                    Period.Years when value > GeneralLowerBound => value,
                    Period.Years => throw new PeriodValueOutOfBoundsException(GeneralLowerBound),
                    _ => throw new PeriodValueOutOfBoundsException("Please specify a matching period.")
                };
            } }
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
    }
}