using EntropyServer.Domain.Enums;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyServiceSelector
    {
        Task<IGenericEntropyResult> GetResult(EntropyType type);
    }
}
