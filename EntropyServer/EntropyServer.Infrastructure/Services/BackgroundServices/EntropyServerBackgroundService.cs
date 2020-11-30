using EntropyServer.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services.BackgroundServices
{
    public sealed class EntropyServerBackgroundService : IHostedService, IEntropyServerBackgroundService
    {
        private readonly IEntropyPoolRepository _entropyPoolRepository;
        private readonly IEntropyTypeConfigurationMappingService _entropyTypeConfigurationMappingService;

        public EntropyServerBackgroundService(
            IEntropyTypeConfigurationMappingService entropyTypeConfigurationMappingService,
            IEntropyPoolRepository entropyPoolRepository)
        {
            _entropyPoolRepository = entropyPoolRepository;
            _entropyTypeConfigurationMappingService = entropyTypeConfigurationMappingService;
        }

        public async Task<IEntropyGenerationResult<T>> GetEntropy<T>() => await GetEntropyInternal<T>();

        public async Task<IEntropyGenerationResult<T>> GetEntropy<T>(IEntropyFilter entropyFilter) => await GetEntropyInternal<T>(entropyFilter);


        private async Task<IEntropyGenerationResult<T>> GetEntropyInternal<T>(IEntropyFilter entropyFilter = null)
        {
            if(entropyFilter != null)
            {

            }

            if (_entropyPoolRepository.PoolExists<T>())
            {
                var pool = _entropyPoolRepository.GetPool<T>();

                //check if there's entropy available, if not, generate new entropy


                var generator = _entropyTypeConfigurationMappingService.GetConfiguration<T>().GeneratorService;
                if (generator != null)
                {
                    return await generator.Fetch(entropyFilter);
                }

                return null;
            }
            else
            {
                throw new System.Exception();
            }
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
