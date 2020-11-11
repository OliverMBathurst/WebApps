using System;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyGenericResult
    {
        public bool Success { get; set; }

        public object Value { get; set; }

        public Exception Exception { get; set; }
    }
}
