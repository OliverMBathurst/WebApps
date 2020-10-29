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
            //inject more services here
            _intEntropyService = intEntropyService;            
        }

        public IEntropyService<T> GetService<T>() 
            => DataMappings.GetEntropyType<T>() switch
            {
                EntropyType.Int => (IEntropyService<T>) _intEntropyService,
                _ => null
            };
    }
}