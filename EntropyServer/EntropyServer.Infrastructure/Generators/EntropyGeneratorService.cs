using EntropyServer.Domain;
using EntropyServer.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EntropyServer.Infrastructure.Generators
{
    public class EntropyGeneratorService<T> : IEntropyGeneratorService<T>
    {
        public async Task<IEntropyGenerationResult<T>> Fetch()
        {
            return EntropyGenerationResult<T>.Create(true, default);
        }

        public async Task<IEntropyGenerationResult<T>> Fetch(IEntropyFilter entropyFilter)
        {
            return EntropyGenerationResult<T>.Create(true, default);
        }

        public async Task<IEnumerable<T>> Fetch(int number)
        {
            return Array.Empty<T>();
        }
    }
}
