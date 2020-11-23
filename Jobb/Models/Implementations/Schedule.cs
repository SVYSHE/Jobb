using System;
using Jobb.Exceptions;
using Jobb.Utility;

namespace Jobb.Models.Implementations
{
    public class Schedule
    {
        private const UInt32 GeneralLowerBound = 0;
        private const UInt32 SecondsUpperBound = 60;
        private const UInt32 MinutesUpperBound = 60;
        private const UInt32 HoursUpperBound = 24;
        private const UInt32 DaysUpperBound = 32;
        private const UInt32 WeeksUpperBound = 52;
        private const UInt32 MonthsUpperBound = 12;
        
        private int _unit;
        public int Unit
        {
            get => _unit;
            set
            {
                _unit = Period switch
                {
                    Period.Seconds when value >= GeneralLowerBound && value < SecondsUpperBound => value,
                    Period.Seconds => throw new InvalidTimeUnitException("The biggest valid unit for seconds is <59>."),
                    Period.Minutes when value >= GeneralLowerBound && value < MinutesUpperBound => value,
                    Period.Minutes => throw new InvalidTimeUnitException("The biggest valid unit for minutes is <59>."),
                    Period.Hours when value >= GeneralLowerBound && value < HoursUpperBound => value,
                    Period.Hours => throw new InvalidTimeUnitException("The biggest valid unit for hours is <23>."),
                    Period.Days when value >= GeneralLowerBound && value < DaysUpperBound => value,
                    Period.Days => throw new InvalidTimeUnitException("The biggest valid unit for days is <31>."),
                    Period.Weeks when value >= GeneralLowerBound && value < WeeksUpperBound => value,
                    Period.Weeks => throw new InvalidTimeUnitException("The biggest valid unit for weeks is <51>."),
                    Period.Months when value >= GeneralLowerBound && value < MonthsUpperBound => value,
                    Period.Months => throw new InvalidTimeUnitException("The biggest valid unit for months is <12>."),
                    Period.Years when value >= GeneralLowerBound => value,
                    Period.Years => throw new InvalidTimeUnitException("The smallest valid unit for years is <1>."),
                    _ => throw new InvalidTimeUnitException("Please specify a matching period.")
                };
            } }
        public Period Period { get; set; }

        public Schedule(Period period, int unit)
        {
            Period = period;
            Unit = unit;
        }
    }

    
}