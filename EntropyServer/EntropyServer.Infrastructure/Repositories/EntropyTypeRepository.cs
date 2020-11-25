using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Infrastructure.Repositories
{
    public sealed class EntropyTypeRepository<T> : IEntropyTypeRepository<T>
    {
        public EntropyTypeRepository(
            IEntropyGeneratorService<T> generatorService,
            IEntropyResultService<T> resultService)
        {
            GeneratorService = generatorService;
            ResultService = resultService;
        }

        public IEntropyGeneratorService<T> GeneratorService { get; }

        public IEntropyResultService<T> ResultService { get; }
    }
}
