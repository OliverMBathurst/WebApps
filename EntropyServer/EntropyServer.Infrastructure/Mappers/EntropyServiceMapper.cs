using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Infrastructure.Mappers
{
    public sealed class EntropyServiceMapper : IEntropyServiceMapper
    {
        private readonly IEntropyService<int> _intEntropyService;
        private readonly IEntropyTypeRepository _entropyTypeRepository;

        public EntropyServiceMapper(
            IEntropyService<int> intEntropyService,
            IEntropyTypeRepository entropyTypeRepository)
        {
            _intEntropyService = intEntropyService;
            _entropyTypeRepository = entropyTypeRepository;
        }

        public IEntropyService<T> GetService<T>() 
        { 
            if (_entropyTypeRepository.ToEntropyType(typeof(T), out var result))
            {
                return GetService<T>(result);
            }

            return null;
        } 

        public IEntropyService<T> GetService<T>(EntropyType entropyType)
            => entropyType switch
            {
                EntropyType.Int => (IEntropyService<T>)_intEntropyService,
                _ => null
            };
    }
}