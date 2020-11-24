using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyResultMappingService
    {
        Task<IEntropyGenerationResult<T>> GetResult<T>(IEntropyFilter entropyFilter);
    }
}
