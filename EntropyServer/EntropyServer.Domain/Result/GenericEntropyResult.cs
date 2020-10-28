using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Domain.Result
{
    public sealed class GenericEntropyResult : IGenericEntropyResult
    {
        public EntropyType Type { get; set; }

        public bool Success { get; set; }

        public object Value { get; set; }
    }
}
