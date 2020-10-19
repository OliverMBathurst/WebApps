using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Domain.Result
{
    public sealed class IntEntropyResult : IEntropyResult<int>
    {
        public bool Success { get; set; }

        public int Value { get; set; }

        public IGenericEntropyResult ToGenericEntropyResult() => new GenericEntropyResult
        {
            Type = typeof(int),
            Success = Success,
            Value = Value
        };
    }
}
