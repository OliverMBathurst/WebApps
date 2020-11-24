using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyResultService<T>
    {
        Task<IEntropyGenerationResult<T>> GetResult();

        Task<IEntropyGenerationResult<T>> GetResult(IEntropyFilter entropyFilter);
    }
}
