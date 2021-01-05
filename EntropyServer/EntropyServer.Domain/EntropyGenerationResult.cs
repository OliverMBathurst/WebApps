using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain
{
    public sealed class EntropyGenerationResult<T> : IEntropyGenerationResult<T>
    {
        private EntropyGenerationResult() { }

        public static IEntropyGenerationResult<T> Create(
            T value,
            bool success = true,
            Exception exception = null)
            => new EntropyGenerationResult<T>
                {
                    Success = success,
                    Value = value,
                    Exception = exception
                };

        public bool Success { get; init; }

        public T Value { get; init; }

        public Exception Exception { get; init; }

        public DateTime Time => DateTime.Now;
    }
}
