using EntropyServer.Domain.Enums;
using System;

namespace EntropyServer.Domain.Interfaces
{
    public interface IGenericEntropyTypeDefinition
    {
        EntropyType EntropyTypeValue { get; set; }

        int NumericalValue { get; set; }

        string TextValue { get; set; }

        Type TypeValue { get; set; }

        object DefaultValue { get; set; }
    }
}
