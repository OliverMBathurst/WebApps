using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Extensions;
using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Domain.Mappers
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
            => typeof(T).ToEntropyType() switch
            {
                EntropyType.Int => (IEntropyService<T>) _intEntropyService,
                _ => null
            };
    }
}