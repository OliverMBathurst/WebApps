using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain.Result
{
    public sealed class IntEntropyGenerationResult : IEntropyGenerationResult<int>
    {
        public bool Success { get; set; }

        public int Value { get; set; }

        public Exception Exception { get; set; }

        public DateTime Time => DateTime.Now;
    }
}
