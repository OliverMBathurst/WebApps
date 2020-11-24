using System;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyGenerationResult<T>
    {
        bool Success { get; }

        T Value { get; }

        DateTime Time { get; }

        Exception Exception { get; }
    }
}
