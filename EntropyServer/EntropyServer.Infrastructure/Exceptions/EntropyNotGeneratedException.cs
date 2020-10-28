using System;
using System.Runtime.Serialization;

namespace EntropyServer.Infrastructure.Exceptions
{
    [Serializable]
    public class EntropyNotGeneratedException : Exception
    {
        public EntropyNotGeneratedException()
        {
        }

        public EntropyNotGeneratedException(string message) : base(message)
        {
        }

        public EntropyNotGeneratedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntropyNotGeneratedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}