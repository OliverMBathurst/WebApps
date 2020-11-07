using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.TypeDefinitions;
using System;

namespace EntropyServer.Domain.AbstractClasses
{
    public abstract class EntropyTypeDefinition
    {       
        protected IGenericEntropyTypeDefinition ToGenericTypeDefinition(int numericalValue, string textValue, Type typeValue, object defaultValue) => new GenericEntropyTypeDefinition
            {
                NumericalValue = numericalValue,
                TextValue = textValue,
                TypeValue = typeValue,
                DefaultValue = defaultValue
            };
    }
}
