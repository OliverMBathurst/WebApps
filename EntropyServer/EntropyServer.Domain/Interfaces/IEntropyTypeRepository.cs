namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeRepository<T>
    {
        IEntropyGeneratorService<T> GeneratorService { get; }

        IEntropyResultService<T> ResultService { get; }
    }
}
