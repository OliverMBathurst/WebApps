using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System.Threading.Tasks;

namespace EntropyServer.Selectors
{
    public sealed class EntropyServiceSelector : IEntropyServiceSelector
    {
        private readonly IEntropyServiceMapper _entropyServiceMapper;

        public EntropyServiceSelector(IEntropyServiceMapper entropyServiceMapper) => _entropyServiceMapper = entropyServiceMapper;

        public async Task<IGenericEntropyResult> GetResult(EntropyType type)
        {
            return type switch
            {
                EntropyType.Int => await GetResultInternal(_entropyServiceMapper.GetService<int>()),
                _ => null,
            };
        }

        private async Task<IGenericEntropyResult> GetResultInternal<T>(IEntropyService<T> service)
        {
            if (service != null)
            {
                var result = await service.GetResult();
                if (result != null)
                {
                    return result.ToGenericEntropyResult();
                }
            }

            return null;
        }
    }
}