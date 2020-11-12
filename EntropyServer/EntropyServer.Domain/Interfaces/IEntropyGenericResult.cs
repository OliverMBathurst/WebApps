using System;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyGenericResult
    {
        bool Success { get; set; }

        object Value { get; set; }

        DateTime Time { get; set; }

        Exception Exception { get; set; }
    }
}
