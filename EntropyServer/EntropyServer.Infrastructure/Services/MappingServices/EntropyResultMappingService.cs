using EntropyServer.Domain.Interfaces;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services.MappingServices
{
    public sealed class EntropyResultMappingService : IEntropyResultMappingService
    {
        private readonly IEntropyTypeConfigurationMappingService _entropyConfigurationMapper;

        public EntropyResultMappingService(IEntropyTypeConfigurationMappingService entropyConfigurationMapper) => _entropyConfigurationMapper = entropyConfigurationMapper;

        public async Task<IEntropyGenerationResult<T>> GetResult<T>(IEntropyFilter entropyFilter) => await _entropyConfigurationMapper.GetConfiguration<T>().GeneratorService.Fetch();
    }
}
