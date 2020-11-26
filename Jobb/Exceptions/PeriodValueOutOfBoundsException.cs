using System;
using System.Runtime.Serialization;

namespace Jobb.Exceptions {
    [Serializable]
    public class PeriodValueOutOfBoundsException : Exception {
        public PeriodValueOutOfBoundsException() { }

        public PeriodValueOutOfBoundsException(string message) : base(message) { }
        public PeriodValueOutOfBoundsException(string message, Exception innerException) : base(message, innerException) { }
        protected PeriodValueOutOfBoundsException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PeriodValueOutOfBoundsException(uint lowerBound, uint upperBound = 0) : base(
            upperBound > 0 ? string.Format($"Invalid value for Period. Value has to be between <{lowerBound + 1}> and <{upperBound - 1}>.")
            : string.Format($"Invalid value for Period. Value has to be at least <{lowerBound + 1}>.")) { }

    }
}
