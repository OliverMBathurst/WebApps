using EntropyServer.Domain;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Exceptions;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEntropyGenerationResult<T>> GetEntropy<T>() => (await GetEntropyInternal<T>()).FirstOrDefault();

        public async Task<IEnumerable<IEntropyGenerationResult<T>>> GetEntropy<T>(IEntropyFilter entropyFilter) => await GetEntropyInternal<T>(entropyFilter);


        private async Task<IEnumerable<IEntropyGenerationResult<T>>> GetEntropyInternal<T>(IEntropyFilter entropyFilter = null)
        {
            var limit = entropyFilter != null ? entropyFilter.Limit : 1;

            if (_entropyPoolRepository.TryGetPool<T>(out var pool))
            {
                var entropy = pool.GetEntropy(limit).Select(x => EntropyGenerationResult<T>.Create(x));

                if (entropy.Count() < limit)
                {
                    var generator = _entropyTypeConfigurationMappingService.GetConfiguration<T>().GeneratorService;
                    if (generator != null)
                    {
                        return (await generator.Fetch(limit - entropy.Count())).Concat(entropy);
                    }
                    else
                    {
                        throw new NoSuchGeneratorException();
                    }
                }
                else
                {
                    return entropy;
                }
            }
            else
            {
                throw new PoolDoesNotExistException();
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
