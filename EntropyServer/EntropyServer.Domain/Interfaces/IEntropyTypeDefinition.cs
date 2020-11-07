using EntropyServer.Domain.Enums;
using System;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeDefinition<T>
    {
        EntropyType EntropyTypeValue { get; }

        int NumericalValue { get; }

        string TextValue { get; }

        Type TypeValue { get; }

        T DefaultValue { get; }

        IGenericEntropyTypeDefinition ToGenericDefinition();
    }
}
