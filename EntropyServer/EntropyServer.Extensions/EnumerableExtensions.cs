using System.Collections.Generic;
using System.Linq;

namespace EntropyServer.Extensions
{
    public static class EnumerableExtensions
    {
        public static T FirstOfTypeOrDefault<T>(this IEnumerable<object> collection)
        {
            var matched = collection.FirstOrDefault(x => x is T);
            return matched != null ? (T)matched : default;
        }
    }
}
