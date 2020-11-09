using EntropyServer.Domain.Enums;
using System;
using System.Collections.Generic;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeRepository
    {
        IEnumerable<IGenericEntropyTypeDefinition> Definitions { get; }

        bool ToEntropyType(int value, out EntropyType result);

        bool ToEntropyType(Type type, out EntropyType entropyType);
    }
}
