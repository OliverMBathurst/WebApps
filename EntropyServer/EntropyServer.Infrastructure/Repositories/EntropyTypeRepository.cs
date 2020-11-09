using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<IGenericEntropyTypeDefinition> Definitions => new HashSet<IGenericEntropyTypeDefinition> { 
            _intDefinition.ToGenericDefinition(),
            _floatDefinition.ToGenericDefinition(),
            _hashDefinition.ToGenericDefinition()
        };

        public bool ToEntropyType(int value, out EntropyType result)
        {
            var type = Definitions.FirstOrDefault(x => x.NumericalValue.Equals(value));
            if (type != null)
            {
                result = type.EntropyTypeValue;
                return true;
            }
            else
            {
                result = EntropyType.Undefined;
                return false;
            }
        }

        public bool ToEntropyType(Type type, out EntropyType entropyType)
        {
            var def = Definitions.FirstOrDefault(x => x.TypeValue.Equals(type));
            if (def == null)
            {
                entropyType = EntropyType.Undefined;
                return false;
            }

            entropyType = def.EntropyTypeValue;
            return true;
        }
    }
}
