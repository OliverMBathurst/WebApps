using System;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyResult<T>
    {
        bool Success { get; set; }

        T Value { get; set; }

        IGenericEntropyResult ToGenericEntropyResult();
    }
}
