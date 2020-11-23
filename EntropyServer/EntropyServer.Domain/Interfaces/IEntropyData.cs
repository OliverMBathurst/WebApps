using EntropyServer.Domain.TransferObjects;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyData<T>
    {
        Task<IEntropyGenerationResult<T>> GetResult(EntropyFilterDto entropyFilterDto = null);
    }
}
