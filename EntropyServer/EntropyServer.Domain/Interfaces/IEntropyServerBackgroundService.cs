using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyServerBackgroundService
    {
        Task<IEntropyGenerationResult<T>> GetEntropy<T>();

        Task<IEnumerable<IEntropyGenerationResult<T>>> GetEntropy<T>(IEntropyFilter entropyFilter);
    }
}
