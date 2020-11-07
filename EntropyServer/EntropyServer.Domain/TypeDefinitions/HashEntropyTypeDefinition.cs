using EntropyServer.Domain.AbstractClasses;
using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain.TypeDefinitions
{
    [Serializable]
    public sealed class HashEntropyTypeDefinition : EntropyTypeDefinition, IEntropyTypeDefinition<string>
    {
        public int NumericalValue => 3;

        public string TextValue => "Hash";

        public Type TypeValue => typeof(string);

        public string DefaultValue => string.Empty;

        public EntropyType EntropyTypeValue => EntropyType.Hash;

        public IGenericEntropyTypeDefinition ToGenericDefinition() => ToGenericTypeDefinition(NumericalValue, TextValue, TypeValue, DefaultValue);
    }
}
