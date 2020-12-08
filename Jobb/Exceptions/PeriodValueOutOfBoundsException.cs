using System;
using System.Runtime.Serialization;

namespace Jobb.Exceptions {
    [Serializable]
    public class PeriodValueOutOfBoundsException : Exception {
        public PeriodValueOutOfBoundsException() { }
        public PeriodValueOutOfBoundsException(string message) : base(message) { }
        public PeriodValueOutOfBoundsException(string message, Exception innerException) : base(message, innerException) { }
        protected PeriodValueOutOfBoundsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
