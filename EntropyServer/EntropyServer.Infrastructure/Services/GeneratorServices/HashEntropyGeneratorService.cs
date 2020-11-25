using EntropyServer.Domain;
using EntropyServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services.GeneratorServices
{
    public sealed class HashEntropyGeneratorService : IEntropyGeneratorService<string>
    {
        public async Task<IEntropyGenerationResult<string>> Fetch()
        {
            return EntropyGenerationResult<string>.Create(true, default);
        }

        public async Task<IEntropyGenerationResult<string>> Fetch(IEntropyFilter entropyFilter = null)
        {
            return EntropyGenerationResult<string>.Create(true, default);
        }

        public async Task<IEnumerable<IEntropyGenerationResult<string>>> Fetch(int number)
        {
            return Array.Empty<IEntropyGenerationResult<string>>();
        }
    }
}
