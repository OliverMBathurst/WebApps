using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain.Result
{
    public class EntropyGenericResult : IEntropyGenericResult
    {
        public bool Success { get; set; }

        public object Value { get; set; }

        public Exception Exception { get; set; }
    }
}
