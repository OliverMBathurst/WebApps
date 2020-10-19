using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Mappers;
using System.Threading.Tasks;

namespace EntropyServer.Selectors
{
    public sealed class EntropyServiceSelector : IEntropyServiceSelector
    {
        public async Task<IGenericEntropyResult> GetResult(EntropyType type)
        {
            return type switch
            {
                EntropyType.Int => await GetResultInternal(EntropyServiceMapper.GetService<int>()),
                EntropyType.Float => await GetResultInternal(EntropyServiceMapper.GetService<float>()),
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