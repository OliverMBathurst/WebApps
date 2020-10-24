using System;

namespace EntropyServer.Domain.Extensions
{
    public static class ActivatorExtensions
    {
        public static object Instantiate(this Type type) => Activator.CreateInstance(type);
    }
}
