using System.Collections.Generic;

namespace EntropyServer.Domain.Extensions
{
    public static class DictionaryExtension
    {
        public static V GetValueOrDefault<K, V>(this IDictionary<K, V> dictionary, K key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }

            return default;
        }
    }
}
