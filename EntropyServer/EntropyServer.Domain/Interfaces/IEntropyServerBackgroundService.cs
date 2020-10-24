using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyServerBackgroundService
    {
        Task<T> GetEntropy<T>();
    }
}
