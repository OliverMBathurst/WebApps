using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.TransferObjects;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services
{
    public sealed class EntropyResultService : IEntropyResultService
    {
        private readonly IEntropyTypeConfigurationMapper _entropyConfigurationMapper;

        public EntropyResultService(IEntropyTypeConfigurationMapper entropyConfigurationMapper) => _entropyConfigurationMapper = entropyConfigurationMapper;

        public async Task<IEntropyGenerationResult<T>> GetResult<T>(EntropyFilterDto entropyFilterDto)
        {
            var config = _entropyConfigurationMapper.GetConfiguration<T>();
            var resultService = config.ResultService;
            return await resultService.GetResult();
        }
    }
}
