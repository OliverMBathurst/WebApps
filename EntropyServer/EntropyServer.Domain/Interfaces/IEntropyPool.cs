using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyPool<T>
    {
        void AddEntropy(T entropy);

        void DrainPool();

        bool HasEntropy();

        IEnumerable<T> GetEntropy(int limit);

        ConcurrentBag<T> Pool { get; }
    }
}
