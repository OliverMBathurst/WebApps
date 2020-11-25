using EntropyServer.Domain;
using EntropyServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services.GeneratorServices
{
    public sealed class FloatEntropyGeneratorService : IEntropyGeneratorService<float>
    {
        public async Task<IEntropyGenerationResult<float>> Fetch()
        {
            return EntropyGenerationResult<float>.Create(true, default);
        }

        public async Task<IEntropyGenerationResult<float>> Fetch(IEntropyFilter entropyFilter = null)
        {
            return EntropyGenerationResult<float>.Create(true, default);
        }

        public async Task<IEnumerable<IEntropyGenerationResult<float>>> Fetch(int number)
        {
            return Array.Empty<IEntropyGenerationResult<float>>();
        }
    }
}