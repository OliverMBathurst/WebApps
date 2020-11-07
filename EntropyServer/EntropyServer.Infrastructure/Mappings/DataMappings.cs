using EntropyServer.Domain.Enums;
using System;
using System.Collections.Generic;

namespace EntropyServer.Common.Mappings
{
    //deprecated, use the repo instead
    public static class DataMappings
    {
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
    }
}
