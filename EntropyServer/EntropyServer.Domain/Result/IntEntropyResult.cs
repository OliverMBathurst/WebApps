using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain.Result
{
    public sealed class IntEntropyResult : IEntropyResult<int>
    {
        public bool Success { get; set; }

        public int Value { get; set; }

        public Exception Exception { get; set; }

        public DateTime Time => DateTime.Now;

        public IEntropyGenericResult ToGenericForm() => new EntropyGenericResult
        {
            Success = Success,
            Value = Value,
            Exception = Exception,
            Time = Time
        };
    }
}
