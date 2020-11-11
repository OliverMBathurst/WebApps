using EntropyServer.Domain.Enums;
using System.Collections.Generic;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeRepository
    {
        bool ToEntropyType(int value, out EntropyType result);

        bool ToEntropyType<T>(out EntropyType entropyType);

        IEnumerable<object> Definitions { get; }
    }
}
