using EntropyServer.Domain.Enums;
using System;
using System.Collections.Generic;

namespace EntropyServer.Common.Mappings
{
    public static class DataMappings
    {
        public static IDictionary<int, EntropyType> NumericalMappings => new Dictionary<int, EntropyType>
        {
            { 1, EntropyType.Int },
            { 2, EntropyType.Float },
            { 3, EntropyType.Hash }
        };

        public static IDictionary<Type, EntropyType> TypeMappings => new Dictionary<Type, EntropyType>
        {
            { typeof(int), EntropyType.Int },
            { typeof(float), EntropyType.Float },
            { typeof(string), EntropyType.Hash }
        };

        public static EntropyType GetEntropyType<T>()
            => TypeMappings.TryGetValue(typeof(T), out var typeResult)
                ? typeResult
                : EntropyType.Undefined;

        public static EntropyType GetEntropyType(Type type) => TypeMappings.TryGetValue(type, out var result) ? result : EntropyType.Undefined;

        public static bool ToEntropyType(int value, out EntropyType result) {
            if (NumericalMappings.TryGetValue(value, out var entropyTypeResult)) {
                result = entropyTypeResult;
                return true;
            }

            result = EntropyType.Undefined;
            return false;
        } 
    }
}
