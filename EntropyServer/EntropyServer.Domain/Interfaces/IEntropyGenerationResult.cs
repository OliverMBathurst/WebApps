using System;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyGenerationResult<T>
    {
        bool Success { get; set; }

        T Value { get; set; }

        DateTime Time { get; }

        Exception Exception { get; set; }
    }
}
