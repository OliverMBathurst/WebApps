using EntropyServer.Domain.Interfaces;
using EntropyServer.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Data
{
    public sealed class EntropyData<T> : IEntropyData<T>
    {
        private readonly IEntropyServerBackgroundService _entropyBackgroundService;
        private readonly ILogger<EntropyData<T>> _logger;

        public EntropyData(
            IEntropyServerBackgroundService entropyBackgroundService,
            ILogger<EntropyData<T>> logger)
        {
            _entropyBackgroundService = entropyBackgroundService;
            _logger = logger;
        }

        public async Task<IEntropyGenerationResult<T>> GetResult(IEntropyFilter entropyFilter = null)
        {
            var validationErrors = ValidateFilter(entropyFilter);
            if (validationErrors.Count > 0)
            {
                //throw invalid filter exception
            }

            try
            {
                return await _entropyBackgroundService.GetEntropy<T>(entropyFilter);
            }
            catch (EntropyNotGeneratedException ex)
            {
                _logger.LogError($"Could not generate entropy: {ex.Message}");
            }

            return null;
        }

        private Dictionary<string, string> ValidateFilter(IEntropyFilter entropyFilterDto)
        {
            var errors = new Dictionary<string, string>();
            if (entropyFilterDto == null)
            {
                return errors;
            }

            return errors;
        }
    }
}
