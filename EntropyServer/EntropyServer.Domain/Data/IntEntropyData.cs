using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.Result;
using EntropyServer.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Data
{
    public sealed class IntEntropyData : IEntropyData<int>
    {
        private readonly IEntropyServerBackgroundService _entropyBackgroundService;
        private readonly ILogger<IntEntropyData> _logger;

        public IntEntropyData(
            IEntropyServerBackgroundService entropyBackgroundService,
            ILogger<IntEntropyData> logger)
        { 
            _entropyBackgroundService = entropyBackgroundService;
            _logger = logger;
        }

        public async Task<IEntropyResult<int>> GetResult()
        {
            var result = default(int);
            var success = true;
            try
            {
                result = await _entropyBackgroundService.GetEntropy<int>();
            }
            catch (EntropyNotGeneratedException ex)
            {
                _logger.LogError($"Could not generate entropy: {ex.Message}");
                success = false;
            }
            
            return new IntEntropyResult
            {
                Success = success,
                Value = result
            };
        }
    }
}
