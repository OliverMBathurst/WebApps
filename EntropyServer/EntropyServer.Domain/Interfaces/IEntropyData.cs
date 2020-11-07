using EntropyServer.Domain.TransferObjects;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyData<T>
    {
        Task<IEntropyResult<T>> GetResult();

        Task<IEntropyResult<T>> GetResult(EntropyFilterDto entropyFilterDto);
    }
}
