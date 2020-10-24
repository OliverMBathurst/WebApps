using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Mappings;

namespace EntropyServer.Domain.Extensions
{
    public static class IntExtensionMethods
    {
        public static bool ToEntropyType(this int value, out EntropyType result)
        {
            if (DataMappings.NumericalMappings.TryGetValue(value, out var type))
            {
                result = type;
                return true;
            }
            
            result = EntropyType.Undefined;
            return false;
        }
    }
}
