using EntropyServer.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services.BackgroundServices
{
    public sealed class EntropyServerBackgroundService : IHostedService, IEntropyServerBackgroundService
    {
        private readonly IEntropyPool<int> _intEntropyPool;
        private readonly IEntropyTypeConfigurationMappingService _entropyConfigurationMapper;

        public EntropyServerBackgroundService(
            IEntropyPool<int> intEntropyPool,
            IEntropyTypeConfigurationMappingService entropyGeneratorRepository)
        {
            _intEntropyPool = intEntropyPool;
            _entropyConfigurationMapper = entropyGeneratorRepository;
        }

        public async Task<IEntropyGenerationResult<T>> GetEntropy<T>() => await GetEntropyInternal<T>();

        public async Task<IEntropyGenerationResult<T>> GetEntropy<T>(IEntropyFilter entropyFilter) => await GetEntropyInternal<T>(entropyFilter);


        private async Task<IEntropyGenerationResult<T>> GetEntropyInternal<T>(IEntropyFilter entropyFilter = null)
        {
            var generator = _entropyConfigurationMapper.GetConfiguration<T>().GeneratorService;
            if (generator != null)
            {
                return await generator.Fetch(entropyFilter);
            }

            return null;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {

            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
