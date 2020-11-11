using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain.TypeDefinitions
{
    [Serializable]
    public sealed class HashEntropyTypeDefinition : IEntropyTypeDefinition<string>
    {
        public int NumericalValue => 3;

        public string TextValue => "Hash";

        public string DefaultValue => string.Empty;

        public EntropyType EntropyTypeValue => EntropyType.Hash;
    }
}
