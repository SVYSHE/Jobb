using System;
using Jobb.Utility;

namespace Jobb.Models.Implementations
{
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
                //TODO: Create custom exception.
                _unit = Period switch
                {
                    Period.Seconds when value >= GeneralLowerBound && value < SecondsUpperBound => value,
                    Period.Seconds => throw new ArgumentException("The biggest valid unit for seconds is <59>."),
                    Period.Minutes when value >= GeneralLowerBound && value < MinutesUpperBound => value,
                    Period.Minutes => throw new ArgumentException("The biggest valid unit for minutes is <59>."),
                    Period.Hours when value >= GeneralLowerBound && value < HoursUpperBound => value,
                    Period.Hours => throw new ArgumentException("The biggest valid unit for hours is <23>."),
                    Period.Days when value >= GeneralLowerBound && value < DaysUpperBound => value,
                    Period.Days => throw new ArgumentException("The biggest valid unit for days is <31>."),
                    Period.Weeks when value >= GeneralLowerBound && value < WeeksUpperBound => value,
                    Period.Weeks => throw new ArgumentException("The biggest valid unit for weeks is <51>."),
                    Period.Months when value >= GeneralLowerBound && value < MonthsUpperBound => value,
                    Period.Months => throw new ArgumentException("The biggest valid unit for months is <12>."),
                    Period.Years when value > GeneralLowerBound => value,
                    Period.Years => throw new ArgumentException("The smallest valid unit for years is <1>."),
                    _ => throw new ArgumentException("Please specify a matching period.")
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