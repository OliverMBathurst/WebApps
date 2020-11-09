using EntropyServer.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EntropyServer.Infrastructure.Repositories
{
    public sealed class EntropyGeneratorRepository : IEntropyGeneratorRepository
    {
        private readonly IEntropyGenerator<int> _intEntropyGenerator;

        public EntropyGeneratorRepository(
            IEntropyGenerator<int> intEntropyGenerator) 
        {
            _intEntropyGenerator = intEntropyGenerator;        
        }

        public IEntropyGenerator<T> GetGenerator<T>()
        {
            var generator = Generators.FirstOrDefault(x => x is IEntropyGenerator<T>);
            if (generator != null)
            {
                return generator as IEntropyGenerator<T>;
            }
            return null;
        }

        private IEnumerable<object> Generators => new HashSet<object> 
        {
            _intEntropyGenerator
        };
    }
}
