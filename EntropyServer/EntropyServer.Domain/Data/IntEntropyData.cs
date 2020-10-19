using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.Result;
using System.Threading.Tasks;

namespace EntropyServer.Data
{
    public sealed class IntEntropyData : IEntropyData<int>
    {
        private readonly IEntropyGenerator<int> _entropyGenerator;

        public IntEntropyData(IEntropyGenerator<int> entropyGenerator) => _entropyGenerator = entropyGenerator;

        public async Task<IEntropyResult<int>> GetResult()
        {
            var result = await _entropyGenerator.Fetch();
            return new IntEntropyResult
            {
                Success = true,
                Value = result
            };
        }
    }
}
