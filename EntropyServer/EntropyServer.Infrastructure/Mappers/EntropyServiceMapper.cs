using EntropyServer.Domain.Interfaces;
using System.Collections.Generic;

namespace EntropyServer.Infrastructure.Mappers
{
    public sealed class EntropyServiceMapper : IEntropyServiceMapper
    {
        private readonly IEntropyService<int> _intEntropyService;

        public EntropyServiceMapper(IEntropyService<int> intEntropyService)
        {
            _intEntropyService = intEntropyService;
        }

        public IEntropyService<T> GetService<T>() => GetServiceInternal<T>();

        public IEntropyService<T> GetServiceInternal<T>()
        {
            foreach (var service in Services)
            {
                if (service is IEntropyService<T> matchedService)
                {
                    return matchedService;
                }
            }

            return null;
        }

        private HashSet<object> Services => new HashSet<object>
        {
            _intEntropyService
        };
    }
}