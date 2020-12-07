using System;
using System.Runtime.Serialization;

namespace Jobb.Exceptions {
    [Serializable]
    public class InvalidJobbParametersException : Exception {
        public InvalidJobbParametersException() { }
        public InvalidJobbParametersException(string message) : base(message) { }
        public InvalidJobbParametersException(string message, Exception innerException) : base(message, innerException) { }
        protected InvalidJobbParametersException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
