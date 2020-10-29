using EntropyServer.Common.Mappings;
using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
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

        public async Task<T> GetEntropy<T>() => DataMappings.GetEntropyType<T>() switch
        {
            EntropyType.Int => (await _intEntropyGenerator.Fetch()) is T result ? result : default,
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
