using EntropyServer.Domain;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services.GeneratorServices
{
    public sealed class FloatEntropyGeneratorService : IEntropyGeneratorService<float>
    {
        private readonly ILogger<FloatEntropyGeneratorService> _logger;

        public FloatEntropyGeneratorService(ILogger<FloatEntropyGeneratorService> logger) => _logger = logger;


        public async Task<IEntropyGenerationResult<float>> Fetch()
        {
            return EntropyGenerationResult<float>.Create(default);
        }

        public async Task<IEntropyGenerationResult<float>> Fetch(IEntropyFilter entropyFilter = null)
        {
            var validationErrors = ValidateFilter(entropyFilter);
            if (validationErrors.Count > 0)
            {
                //throw invalid filter exception
            }

            try
            {
                //get entropy
            }
            catch (EntropyNotGeneratedException ex)
            {
                _logger.LogError($"Could not generate entropy: {ex.Message}");
            }

            return EntropyGenerationResult<float>.Create(default);
        }

        public async Task<IEnumerable<IEntropyGenerationResult<float>>> Fetch(int number)
        {
            return Array.Empty<IEntropyGenerationResult<float>>();
        }

        private static Dictionary<string, string> ValidateFilter(IEntropyFilter entropyFilterDto)
        {
            var errors = new Dictionary<string, string>();
            if (entropyFilterDto == null)
            {
                errors.Add("Filter", "Filter cannot be null");
            }

            return errors;
        }
    }
}