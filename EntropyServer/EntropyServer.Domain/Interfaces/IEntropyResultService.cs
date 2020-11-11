using EntropyServer.Domain.Enums;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyResultService
    {
        Task<IEntropyGenericResult> GetResult(EntropyType entropyType);
    }
}
