using EntropyServer.Domain.Interfaces;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EntropyServer.Domain
{
    public sealed class EntropyPool<T> : IEntropyPool<T>
    {
        public void AddEntropy(T entropy) => Pool.Add(entropy);

        public void DrainPool() => Pool.Clear();

        public bool HasEntropy() => Pool.IsEmpty;

        public IEnumerable<T> GetEntropy(int limit)
        {
            var results = new List<T>();
            for (var i = 0; i < limit; i++)
            {
                if (Pool.TryTake(out var result))
                {
                    results.Add(result);
                }
                else
                {
                    return results;
                }
            }
            return results;
        }

        public ConcurrentBag<T> Pool { get; } = new ConcurrentBag<T>();
    }
}
