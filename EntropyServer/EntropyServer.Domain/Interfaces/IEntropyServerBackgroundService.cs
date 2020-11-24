using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyServerBackgroundService
    {
        Task<IEntropyGenerationResult<T>> GetEntropy<T>();

        Task<IEntropyGenerationResult<T>> GetEntropy<T>(IEntropyFilter entropyFilter);
    }
}
