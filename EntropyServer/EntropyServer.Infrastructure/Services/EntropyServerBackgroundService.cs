using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.TransferObjects;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services
{
    public sealed class EntropyServerBackgroundService : IHostedService, IEntropyServerBackgroundService
    {
        private readonly IEntropyPool _entropyPool;
        private readonly IEntropyTypeConfigurationMapper _entropyConfigurationMapper;

        public EntropyServerBackgroundService(
            IEntropyPool entropyPool,
            IEntropyTypeConfigurationMapper entropyGeneratorRepository)
        {
            _entropyPool = entropyPool;
            _entropyConfigurationMapper = entropyGeneratorRepository;
        }

        public async Task<T> GetEntropy<T>() => await GetEntropyInternal<T>();

        public async Task<T> GetEntropy<T>(EntropyFilterDto entropyFilterDto) => await GetEntropyInternal<T>(entropyFilterDto);


        private async Task<T> GetEntropyInternal<T>(EntropyFilterDto entropyFilterDto = null)
        {
            var generator = _entropyConfigurationMapper.GetConfiguration<T>().GeneratorService;
            if (generator != null)
            {
                return await generator.Fetch(entropyFilterDto);
            }

            return default;
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
