using EntropyServer.Domain.Enums;

namespace EntropyServer.Domain.Interfaces
{
    public interface IGenericEntropyResult
    {
        EntropyType Type { get; set; }

        bool Success { get; set; }

        object Value { get; set; }
    }
}
