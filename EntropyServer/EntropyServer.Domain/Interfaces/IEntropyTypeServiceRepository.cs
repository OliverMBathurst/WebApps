namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeServiceRepository<T>
    {
        IEntropyTypeGeneratorService<T> GeneratorService { get; set; }

        IEntropyTypeResultService<T> ResultService { get; set; }
    }
}
