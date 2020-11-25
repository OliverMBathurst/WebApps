using EntropyServer.Domain;
using EntropyServer.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EntropyServer.Infrastructure.Services.GeneratorServices
{
    public sealed class IntEntropyGeneratorService : IEntropyGeneratorService<int>
    {
        public async Task<IEntropyGenerationResult<int>> Fetch()
        {
            return EntropyGenerationResult<int>.Create(true, default);
        }

        public async Task<IEntropyGenerationResult<int>> Fetch(IEntropyFilter entropyFilter = null)
        {
            return EntropyGenerationResult<int>.Create(true, default);
        }

        public async Task<IEnumerable<IEntropyGenerationResult<int>>> Fetch(int number)
        {
            return Array.Empty<IEntropyGenerationResult<int>>();
        }
    }
}
