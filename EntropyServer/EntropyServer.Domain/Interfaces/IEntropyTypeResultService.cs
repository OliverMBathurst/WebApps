using EntropyServer.Domain.TransferObjects;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeResultService<T>
    {
        Task<IEntropyGenerationResult<T>> GetResult();

        Task<IEntropyGenerationResult<T>> GetResult(EntropyFilterDto entropyFilterDto);
    }
}
