using EntropyServer.Domain.Interfaces;
using EntropyServer.Exceptions;
using EntropyServer.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace EntropyServer.Domain
{
    public sealed class EntropyPoolRepository : IEntropyPoolRepository
    {
        public EntropyPoolRepository(
            IEntropyPool<int> intEntropyPool,
            IEntropyPool<float> floatEntropyPool,
            IEntropyPool<string> hashEntropyPool)
        {
            Pools = new List<object> { intEntropyPool, floatEntropyPool, hashEntropyPool };
        }

        public bool PoolExists<T>() => Pools.Any(x => x is IEntropyPool<T>);

        public IEntropyPool<T> GetPool<T>() => Pools.FirstOrDefault(x => x is IEntropyPool<T>)?.Cast<IEntropyPool<T>>();

        public bool PoolHasEntropy<T>()
        {
            var pool = GetPool<T>();
            if (pool == null)
            {
                throw new PoolDoesNotExistException();
            }

            return pool.HasEntropy();
        }

        public bool TryGetPool<T>(out IEntropyPool<T> pool)
        {
            var fetchedPool = GetPool<T>();
            if (fetchedPool == null)
            {
                pool = null;
                return false;
            }

            pool = fetchedPool;
            return true;
        }

        public IEnumerable<object> Pools { get; }
    }
}