using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Infrastructure.Repositories
{
    public sealed class EntropyTypeRepository<T> : IEntropyTypeRepository<T>
    {
        public EntropyTypeRepository(IEntropyGeneratorService<T> generatorService)
        {
            GeneratorService = generatorService;
        }

        public IEntropyGeneratorService<T> GeneratorService { get; }
    }
}
