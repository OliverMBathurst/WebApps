using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain
{
    public sealed class EntropyGenerationResult<T> : IEntropyGenerationResult<T>
    {
        private EntropyGenerationResult() { }

        public static IEntropyGenerationResult<T> Create(
            bool success,
            T value,
            Exception exception = null)
            => new EntropyGenerationResult<T>
                {
                    Success = success,
                    Value = value,
                    Exception = exception
                };

        public bool Success { get; private set; }

        public T Value { get; private set; }

        public Exception Exception { get; private set; }

        public DateTime Time => DateTime.Now;
    }
}
