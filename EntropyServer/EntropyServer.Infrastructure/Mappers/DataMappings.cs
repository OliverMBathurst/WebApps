using EntropyServer.Domain.Enums;
using System.Collections.Generic;

namespace EntropyServer.Infrastructure.Mappers
{
    public static class DataMappings
    {
        public static EntropyType ToEntropyType(int value) => NumericMappings.TryGetValue(value, out var result) ? result : EntropyType.Undefined;

        private static Dictionary<int, EntropyType> NumericMappings => new Dictionary<int, EntropyType>
        {
            { (int)EntropyType.Int, EntropyType.Int },
            { (int)EntropyType.Float, EntropyType.Float },
            { (int)EntropyType.Hash, EntropyType.Hash }
        };
    }
}
