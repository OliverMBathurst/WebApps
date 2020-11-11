using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using System.Threading.Tasks;

namespace EntropyServer.Infrastructure.Services
{
    public sealed class EntropyResultService : IEntropyResultService
    {
        private readonly IEntropyServiceMapper _entropyServiceMapper;

        public EntropyResultService(IEntropyServiceMapper entropyServiceMapper)
        {
            _entropyServiceMapper = entropyServiceMapper;
        }

        public async Task<IEntropyGenericResult> GetResult(EntropyType entropyType)
        {
            IEntropyGenericResult result = null;

            switch (entropyType)
            {
                case EntropyType.Int:
                    result = (await _entropyServiceMapper.GetService<int>().GetResult()).ToGenericForm();
                    break;
            }

            return result;
        }
    }
}
