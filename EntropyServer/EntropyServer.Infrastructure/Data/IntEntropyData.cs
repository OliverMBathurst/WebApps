using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.Result;
using EntropyServer.Domain.TransferObjects;
using EntropyServer.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Data
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

        public async Task<IEntropyResult<int>> GetResult(EntropyFilterDto entropyFilterDto = null)
        {
            var result = 0;
            var success = true;
            try
            {
                var validationErrors = ValidateFilterDto(entropyFilterDto);
                if (validationErrors.Count == 0)
                {
                    result = await _entropyBackgroundService.GetEntropy<int>(entropyFilterDto);
                }
                else
                {
                    //throw invalid filter exception
                }
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

        private Dictionary<string, string> ValidateFilterDto(EntropyFilterDto entropyFilterDto)
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
