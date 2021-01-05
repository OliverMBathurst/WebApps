using System;
using System.Runtime.Serialization;

namespace EntropyServer.Exceptions
{
    [Serializable]
    public sealed class NoSuchGeneratorException : Exception
    {
        public NoSuchGeneratorException()
        {
        }

        public NoSuchGeneratorException(string message) : base(message)
        {
        }

        public NoSuchGeneratorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NoSuchGeneratorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
