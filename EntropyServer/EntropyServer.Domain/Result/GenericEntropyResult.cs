using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain
{
    public sealed class GenericEntropyResult : IGenericEntropyResult
    {
        public Type Type { get; set; }

        public bool Success { get; set; }

        public object Value { get; set; }
    }
}
