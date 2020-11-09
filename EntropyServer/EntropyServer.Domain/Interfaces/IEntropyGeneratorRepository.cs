namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyGeneratorRepository
    {
        IEntropyGenerator<T> GetGenerator<T>();
    }
}
