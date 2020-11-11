using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Extensions;
using System.Collections.Generic;

namespace EntropyServer.Infrastructure.Repositories
{
    public sealed class EntropyTypeRepository : IEntropyTypeRepository
    {
        private readonly IEntropyTypeDefinition<int> _intDefinition;
        private readonly IEntropyTypeDefinition<float> _floatDefinition;
        private readonly IEntropyTypeDefinition<string> _hashDefinition;

        public EntropyTypeRepository(
            IEntropyTypeDefinition<int> intDefinition,
            IEntropyTypeDefinition<float> floatDefinition,
            IEntropyTypeDefinition<string> hashDefinition)
        {
            _intDefinition = intDefinition;
            _floatDefinition = floatDefinition;
            _hashDefinition = hashDefinition;
        }

        public bool ToEntropyType(int value, out EntropyType result)
        {
            foreach (var definition in Definitions)
            {
                if (definition.CheckValue("NumericalValue", value))
                {
                    if (definition.GetValue<EntropyType>("EntropyTypeValue", out var entropyTypeResult))
                    {
                        result = entropyTypeResult;
                        return true;
                    }
                }                
            }

            result = EntropyType.Undefined;
            return false;
        }

        public bool ToEntropyType<T>(out EntropyType entropyType)
        {
            foreach (var definition in Definitions)
            {
                if (definition is IEntropyTypeDefinition<T> entropyDefinition)
                {
                    entropyType = entropyDefinition.EntropyTypeValue;
                    return true;
                }
            }

            entropyType = EntropyType.Undefined;
            return false;
        }

        public IEnumerable<object> Definitions => new HashSet<object> {
            _intDefinition,
            _floatDefinition,
            _hashDefinition
        };
    }
}
