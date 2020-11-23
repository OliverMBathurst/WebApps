using EntropyServer.Domain.TransferObjects;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyResultService
    {
        Task<IEntropyGenerationResult<T>> GetResult<T>(EntropyFilterDto entropyFilterDto);
    }
}
