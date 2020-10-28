using EntropyServer.Domain.Interfaces;
using System.Threading.Tasks;

namespace EntropyServer.Services.EntropyServices
{
    public sealed class IntEntropyService : IEntropyService<int>
    {
        private readonly IEntropyData<int> _entropyData;

        public IntEntropyService(IEntropyData<int> entropyData) => _entropyData = entropyData;

        public async Task<IEntropyResult<int>> GetResult() => await _entropyData.GetResult();
    }
}