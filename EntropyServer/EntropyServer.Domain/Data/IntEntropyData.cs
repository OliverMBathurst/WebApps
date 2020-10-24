using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.Result;
using System.Threading.Tasks;

namespace EntropyServer.Data
{
    public sealed class IntEntropyData : IEntropyData<int>
    {
        private readonly IEntropyServerBackgroundService _entropyBackgroundService;

        public IntEntropyData(IEntropyServerBackgroundService entropyBackgroundService) => _entropyBackgroundService = entropyBackgroundService;

        public async Task<IEntropyResult<int>> GetResult()
        {
            var result = await _entropyBackgroundService.GetEntropy<int>();
            return new IntEntropyResult
            {
                Success = true,
                Value = result
            };
        }
    }
}
