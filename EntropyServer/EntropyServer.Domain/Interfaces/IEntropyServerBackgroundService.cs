using EntropyServer.Domain.TransferObjects;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyServerBackgroundService
    {
        Task<T> GetEntropy<T>();

        Task<T> GetEntropy<T>(EntropyFilterDto entropyFilterDto);
    }
}
