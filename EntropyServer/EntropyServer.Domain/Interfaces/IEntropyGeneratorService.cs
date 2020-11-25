using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyGeneratorService<T>
    {
        Task<IEntropyGenerationResult<T>> Fetch();

        Task<IEntropyGenerationResult<T>> Fetch(IEntropyFilter entropyFilter = null);

        Task<IEnumerable<IEntropyGenerationResult<T>>> Fetch(int number);
    }
}