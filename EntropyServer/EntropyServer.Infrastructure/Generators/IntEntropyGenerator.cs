using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Generators
{
    public class IntEntropyGenerator : IEntropyGenerator<int>
    {
        public EntropyType EntropyResultType => EntropyType.Int;

        public async Task<int> Fetch()
        {
            return 1;
        }

        public async Task<IEnumerable<int>> Fetch(int number)
        {
            return new[] { 1 };
        }
    }
}
