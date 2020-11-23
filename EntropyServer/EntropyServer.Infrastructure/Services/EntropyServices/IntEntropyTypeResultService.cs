using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.TransferObjects;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services.EntropyServices
{
    public sealed class IntEntropyTypeResultService : IEntropyTypeResultService<int>
    {
        private readonly IEntropyData<int> _entropyData;

        public IntEntropyTypeResultService(IEntropyData<int> entropyData) => _entropyData = entropyData;

        public async Task<IEntropyGenerationResult<int>> GetResult() => await _entropyData.GetResult();

        public async Task<IEntropyGenerationResult<int>> GetResult(EntropyFilterDto entropyFilterDto) => await _entropyData.GetResult(entropyFilterDto);
    }
}