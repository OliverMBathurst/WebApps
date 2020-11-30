namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyPoolRepository
    {
        bool PoolHasEntropy<T>();

        IEntropyPool<T> GetPool<T>();

        bool PoolExists<T>();
    }
}
