using EntropyServer.Domain.Interfaces;
using System.Collections.Generic;

namespace EntropyServer.Infrastructure.Repositories
{
    public sealed class EntropyGeneratorRepository : IEntropyGeneratorRepository
    {
        private readonly IEntropyGenerator<int> _intEntropyGenerator;

        public EntropyGeneratorRepository(IEntropyGenerator<int> intEntropyGenerator) 
        {
            _intEntropyGenerator = intEntropyGenerator;        
        }

        public IEntropyGenerator<T> GetGenerator<T>()
        {
            foreach (var generator in Generators)
            {
                if (generator is IEntropyGenerator<T> entropyGenerator)
                {
                    return entropyGenerator;
                }
            }
            return null;
        }

        private IEnumerable<object> Generators => new HashSet<object> 
        {
            _intEntropyGenerator
        };
    }
}
