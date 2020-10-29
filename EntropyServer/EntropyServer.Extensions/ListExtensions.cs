using System.Collections.Generic;

namespace EntropyServer.Extensions
{
    public static class ListExtensions
    {
        public static List<T> AddAndReturn<T>(this List<T> list, T addition)
        {
            list.Add(addition);
            return list;
        } 
    }
}
