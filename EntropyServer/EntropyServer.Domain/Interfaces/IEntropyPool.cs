using System.Collections.Concurrent;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyPool<T>
    {
        void AddEntropy(T entropy);

        void DrainPool();

        ConcurrentBag<T> Pool { get; }
    }
}
