using System;

namespace EntropyServer.Domain.Interfaces
{
    public interface IGenericEntropyResult
    {
        Type Type { get; set; }

        bool Success { get; set; }

        object Value { get; set; }
    }
}
