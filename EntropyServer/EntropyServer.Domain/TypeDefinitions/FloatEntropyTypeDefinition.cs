using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain.TypeDefinitions
{
    [Serializable]
    public sealed class FloatEntropyTypeDefinition : IEntropyTypeDefinition<float>
    {
        public int NumericalValue => 2;

        public string TextValue => "Float";

        public float DefaultValue => 0f;

        public EntropyType EntropyTypeValue => EntropyType.Float;
    }
}
