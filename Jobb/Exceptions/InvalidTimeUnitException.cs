using System;
using Jobb.Utility;

namespace Jobb.Exceptions
{
    public class InvalidTimeUnitException() : Exception
    {
        public override string Message => "Invalid time unit for your chosen period.";

        public InvalidTimeUnitException(string message) : base(message)
        {
            
        }
    }
}
