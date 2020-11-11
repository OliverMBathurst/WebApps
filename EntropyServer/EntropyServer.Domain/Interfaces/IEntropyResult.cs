using System;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyResult<T>
    {
        bool Success { get; set; }

        T Value { get; set; }

        Exception Exception { get; set; }

        IEntropyGenericResult ToGenericForm();
    }
}
