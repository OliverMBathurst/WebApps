using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyGenerator<T>
    {
        Task<T> Fetch();

        Task<IEnumerable<T>> Fetch(int number);
    }
}
