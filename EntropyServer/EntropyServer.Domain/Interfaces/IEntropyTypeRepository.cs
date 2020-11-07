using EntropyServer.Domain.Enums;
using System.Collections.Generic;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeRepository
    {
        IEnumerable<IGenericEntropyTypeDefinition> Definitions { get; }

        bool ToEntropyType(int value, out EntropyType result);
    }
}
