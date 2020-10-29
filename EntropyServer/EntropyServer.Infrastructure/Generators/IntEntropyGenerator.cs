using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Generators
{
    public class IntEntropyGenerator : IEntropyGenerator<int>
    {
        public EntropyType EntropyResultType => EntropyType.Int;

        public Task<int> Fetch()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<int>> Fetch(int number)
        {
            throw new NotImplementedException();
        }
    }
}
