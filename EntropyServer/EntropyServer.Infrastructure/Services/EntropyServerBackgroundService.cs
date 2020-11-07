using EntropyServer.Common.Mappings;
using EntropyServer.Domain.Enums;
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
        private readonly IEntropyGenerator<int> _intEntropyGenerator;

        public EntropyServerBackgroundService(
            IEntropyPool entropyPool,
            IEntropyGenerator<int> intEntropyGenerator)
        {
            _entropyPool = entropyPool;
            _intEntropyGenerator = intEntropyGenerator;

            _entropyPool.AddSubPool(_intEntropyGenerator.EntropyResultType);
        }

        public async Task<T> GetEntropy<T>() => await SwitchAndFetchResult<T>();

        public async Task<T> GetEntropy<T>(EntropyFilterDto entropyFilterDto) => await SwitchAndFetchResult<T>(entropyFilterDto);


        private async Task<T> SwitchAndFetchResult<T>(EntropyFilterDto entropyFilterDto = null) => DataMappings.GetEntropyType<T>() switch 
        {
            EntropyType.Int => (await _intEntropyGenerator.Fetch(entropyFilterDto)) is T result ? result : default,
            _ => default            
        };


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
