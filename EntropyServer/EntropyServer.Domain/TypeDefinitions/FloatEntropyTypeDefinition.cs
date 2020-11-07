using EntropyServer.Domain.AbstractClasses;
using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain.TypeDefinitions
{
    [Serializable]
    public sealed class FloatEntropyTypeDefinition : EntropyTypeDefinition, IEntropyTypeDefinition<float>
    {
        public int NumericalValue => 2;

        public string TextValue => "Float";

        public Type TypeValue => typeof(float);

        public float DefaultValue => 0f;

        public EntropyType EntropyTypeValue => EntropyType.Float;

        public IGenericEntropyTypeDefinition ToGenericDefinition() => ToGenericTypeDefinition(NumericalValue, TextValue, TypeValue, DefaultValue);
    }
}
