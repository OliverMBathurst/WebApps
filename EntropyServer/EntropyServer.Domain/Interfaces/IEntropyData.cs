using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyData<T>
    {
        Task<IEntropyGenerationResult<T>> GetResult(IEntropyFilter entropyFilter = null);
    }
}
