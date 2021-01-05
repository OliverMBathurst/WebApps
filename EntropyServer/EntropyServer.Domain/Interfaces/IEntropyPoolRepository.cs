using System.Collections.Generic;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyPoolRepository
    {
        IEnumerable<object> Pools { get; }

        bool PoolHasEntropy<T>();

        IEntropyPool<T> GetPool<T>();

        bool PoolExists<T>();

        bool TryGetPool<T>(out IEntropyPool<T> pool);
    }
}
