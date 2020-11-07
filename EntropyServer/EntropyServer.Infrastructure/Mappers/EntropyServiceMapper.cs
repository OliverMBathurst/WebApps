using EntropyServer.Common.Mappings;
using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Infrastructure.Mappers
{
    public sealed class EntropyServiceMapper : IEntropyServiceMapper
    {
        private readonly IEntropyService<int> _intEntropyService;

        public EntropyServiceMapper(IEntropyService<int> intEntropyService)
        {
            _intEntropyService = intEntropyService;            
        }

        public IEntropyService<T> GetService<T>() 
            => DataMappings.GetEntropyType<T>() switch
            {
                EntropyType.Int => (IEntropyService<T>) _intEntropyService,
                _ => null
            };

        public IEntropyService<T> GetService<T>(EntropyType entropyType)
            => entropyType switch
            {
                EntropyType.Int => (IEntropyService<T>)_intEntropyService,
                _ => null
            };
    }
}