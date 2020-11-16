using EntropyServer.Domain.Interfaces;
using EntropyServer.Extensions;
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

        public IEntropyService<T> GetService<T>() => Services.GetFirstOfTypeOrDefault<IEntropyService<T>>();

        public bool HasService<T>() => Services.GetFirstOfTypeOrDefault<IEntropyService<T>>() != null;

        private HashSet<object> Services => new HashSet<object>
        {
            _intEntropyService
        };
    }
}