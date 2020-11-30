using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Domain
{
    public sealed class EntropyPoolRepository : IEntropyPoolRepository
    {
        public EntropyPoolRepository(
            IEntropyPool<int> intEntropyPool,
            IEntropyPool<float> floatEntropyPool,
            IEntropyPool<string> hashEntropyPool)
        {

        }

        public bool PoolExists<T>()
        {
            return false;
        }

        public IEntropyPool<T> GetPool<T>()
        {
            return null;
        }

        public bool PoolHasEntropy<T>()
        {
            return false;
        }
    }
}
