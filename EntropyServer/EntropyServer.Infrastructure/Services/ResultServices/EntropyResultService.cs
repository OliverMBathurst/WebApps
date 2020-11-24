using EntropyServer.Domain.Interfaces;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services.ResultServices
{
    public sealed class EntropyResultService<T> : IEntropyResultService<T>
    {
        private readonly IEntropyData<T> _entropyData;

        public EntropyResultService(IEntropyData<T> entropyData) => _entropyData = entropyData;

        public async Task<IEntropyGenerationResult<T>> GetResult() => await _entropyData.GetResult();

        public async Task<IEntropyGenerationResult<T>> GetResult(IEntropyFilter entropyFilter) => await _entropyData.GetResult(entropyFilter);
    }
}