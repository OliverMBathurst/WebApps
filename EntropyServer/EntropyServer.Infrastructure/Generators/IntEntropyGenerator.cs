using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.TransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Generators
{
    public class IntEntropyGenerator : IEntropyGenerator<int>
    {
        public EntropyType EntropyResultType => EntropyType.Int;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<int> Fetch()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return 1;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<int> Fetch(EntropyFilterDto entropyFilterDto)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return 1;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IEnumerable<int>> Fetch(int number)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return new[] { 1 };
        }
    }
}
