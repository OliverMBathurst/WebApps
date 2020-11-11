using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain.TypeDefinitions
{
    [Serializable]
    public sealed class IntEntropyTypeDefinition : IEntropyTypeDefinition<int>
    {
        public int NumericalValue => 1;

        public string TextValue => "Integer";

        public int DefaultValue => 0;

        public EntropyType EntropyTypeValue => EntropyType.Int;
    }
}
