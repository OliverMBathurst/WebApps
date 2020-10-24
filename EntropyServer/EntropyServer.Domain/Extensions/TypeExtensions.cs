using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Mappings;
using System;

namespace EntropyServer.Domain.Extensions
{
    public static class TypeExtensions
    {
        public static EntropyType ToEntropyType(this Type type)
            =>  DataMappings.TypeMappings.TryGetValue(type, out var result) 
                ? result 
                : EntropyType.Undefined;
    }
}
