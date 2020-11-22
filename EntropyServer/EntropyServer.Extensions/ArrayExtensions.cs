using System;

namespace EntropyServer.Extensions
{
    public static class ArrayExtensions
    {
        public static bool Find<T>(this T[] array, Func<T, bool> predicate, out T result)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    result = array[i];
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}
