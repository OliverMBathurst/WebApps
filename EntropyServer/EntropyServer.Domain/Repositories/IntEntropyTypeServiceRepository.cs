using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Domain.Repositories
{
    public sealed class IntEntropyTypeServiceRepository : IEntropyTypeServiceRepository<int>
    {
        public IEntropyTypeGeneratorService<int> GeneratorService { get; set; }

        public IEntropyTypeResultService<int> ResultService { get; set; }
    }
}
