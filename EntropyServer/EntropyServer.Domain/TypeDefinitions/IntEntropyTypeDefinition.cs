using EntropyServer.Domain.AbstractClasses;
using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain.TypeDefinitions
{
    [Serializable]
    public sealed class IntEntropyTypeDefinition : EntropyTypeDefinition, IEntropyTypeDefinition<int>
    {
        public int NumericalValue => 1;

        public string TextValue => "Integer";

        public Type TypeValue => typeof(int);

        public int DefaultValue => 0;

        public EntropyType EntropyTypeValue => EntropyType.Int;

        public IGenericEntropyTypeDefinition ToGenericDefinition() => ToGenericTypeDefinition(NumericalValue, TextValue, TypeValue, DefaultValue);
    }
}
