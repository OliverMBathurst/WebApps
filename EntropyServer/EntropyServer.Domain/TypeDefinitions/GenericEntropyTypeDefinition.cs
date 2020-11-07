using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain.TypeDefinitions
{
    [Serializable]
    public sealed class GenericEntropyTypeDefinition : IGenericEntropyTypeDefinition
    {
        public EntropyType EntropyTypeValue { get; set; }

        public int NumericalValue { get; set; }

        public string TextValue { get; set; }

        public Type TypeValue { get; set; }

        public object DefaultValue { get; set; }
    }
}
