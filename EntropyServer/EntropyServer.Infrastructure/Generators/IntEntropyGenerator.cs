using EntropyServer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntropyServer.Generators
{
    public class IntEntropyGenerator : IEntropyGenerator<int>
    {
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
