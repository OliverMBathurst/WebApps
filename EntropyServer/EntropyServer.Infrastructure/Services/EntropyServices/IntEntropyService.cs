using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.TransferObjects;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services.EntropyServices
{
    public sealed class IntEntropyService : IEntropyService<int>
    {
        private readonly IEntropyData<int> _entropyData;

        public IntEntropyService(IEntropyData<int> entropyData) => _entropyData = entropyData;

        public async Task<IEntropyResult<int>> GetResult() => await _entropyData.GetResult();

        public async Task<IEntropyResult<int>> GetResult(EntropyFilterDto entropyFilterDto) => await _entropyData.GetResult(entropyFilterDto);
    }
}