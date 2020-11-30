using EntropyServer.Domain.Interfaces;
using System.Collections.Concurrent;

namespace EntropyServer.Domain
{
    public sealed class EntropyPool<T> : IEntropyPool<T>
    {
        public void AddEntropy(T entropy) => Pool.Add(entropy);

        public void DrainPool() => Pool.Clear();

        public bool HasEntropy() => Pool.Count > 0;

        public ConcurrentBag<T> Pool { get; } = new ConcurrentBag<T>();
    }
}
