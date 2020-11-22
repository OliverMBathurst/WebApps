using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.TransferObjects;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services
{
    public sealed class EntropyResultService : IEntropyResultService
    {
        private readonly IEntropyConfigurationMapper _entropyConfigurationMapper;

        public EntropyResultService(IEntropyConfigurationMapper entropyConfigurationMapper) => _entropyConfigurationMapper = entropyConfigurationMapper;

        public async Task<IEntropyResult<T>> GetResult<T>(EntropyFilterDto entropyFilterDto)
            => await _entropyConfigurationMapper
                    .GetConfiguration<T>()
                    .Service
                    .GetResult();
    }
}
