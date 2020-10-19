using System;

namespace EntropyServer.Extensions
{
    public static class ActivatorExtensions
    {
        public static object Instantiate(this Type type) => Activator.CreateInstance(type);
    }
}
