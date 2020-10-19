using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyData<T>
    {
        Task<IEntropyResult<T>> GetResult();
    }
}
