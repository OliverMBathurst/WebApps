using EntropyServer.Services.EntropyServices;
using System;
using System.Collections.Generic;

namespace EntropyServer.Constants
{
    public static class EntropyConstants
    {
        public static IDictionary<Type, Type> ServiceMappings => new Dictionary<Type, Type> {
            { 
                typeof(int), typeof(IntEntropyService)
            }
        };
    }
}
