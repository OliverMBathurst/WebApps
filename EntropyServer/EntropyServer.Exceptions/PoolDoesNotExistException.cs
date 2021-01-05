using System;
using System.Runtime.Serialization;

namespace EntropyServer.Exceptions
{
    [Serializable]
    public class PoolDoesNotExistException : Exception
    {
        public PoolDoesNotExistException()
        {
        }

        public PoolDoesNotExistException(string message) : base(message)
        {
        }

        public PoolDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PoolDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
