using EntropyServer.Constants;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Extensions;

namespace EntropyServer.Mappers
{
    public static class EntropyServiceMapper
    {
        public static IEntropyService<T> GetService<T>()
        {
            var result = EntropyConstants.ServiceMappings.GetValueOrDefault(typeof(T));

            if (result == null)
                return null;

            if (result.Instantiate() is IEntropyService<T> data)
                return data;

            return null;
        }
    }
}
