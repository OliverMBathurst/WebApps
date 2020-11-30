using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Infrastructure.Builders;

namespace EntropyServer.Infrastructure.Services.MappingServices
{
    public sealed class EntropyTypeConfigurationMappingService : IEntropyTypeConfigurationMappingService
    {
        private readonly IEntropyTypeRepository<int> _intEntropyTypeRepository;
        private readonly IEntropyTypeRepository<float> _floatEntropyTypeRepository;
        private readonly IEntropyTypeRepository<string> _hashEntropyTypeRepository;

        public EntropyTypeConfigurationMappingService(
            IEntropyTypeRepository<int> intEntropyTypeRepository,
            IEntropyTypeRepository<float> floatEntropyTypeRepository,
            IEntropyTypeRepository<string>  hashEntropyTypeRepository)
        {
            _intEntropyTypeRepository = intEntropyTypeRepository;
            _floatEntropyTypeRepository = floatEntropyTypeRepository;
            _hashEntropyTypeRepository = hashEntropyTypeRepository;

            SetupConfigurations();
        }

        private IEntropyTypeDefinitionConfiguration<int> IntegerConfiguration { get; set; }

        private IEntropyTypeDefinitionConfiguration<float> FloatConfiguration { get; set; }

        private IEntropyTypeDefinitionConfiguration<string> HashConfiguration { get; set; }

        public IEntropyTypeDefinitionConfiguration<T> GetConfiguration<T>()
        {
            var targetType = typeof(T);
            if (targetType == typeof(int))
            {
                return (IEntropyTypeDefinitionConfiguration<T>)IntegerConfiguration;
            }
            else if (targetType == typeof(float))
            {
                return (IEntropyTypeDefinitionConfiguration<T>)FloatConfiguration;
            }
            else if (targetType == typeof(string))
            {
                return (IEntropyTypeDefinitionConfiguration<T>)HashConfiguration;
            }

            return null;
        }

        private void SetupConfigurations()
        {
            IntegerConfiguration = new EntropyTypeDefinitionBuilder<int>(_intEntropyTypeRepository)
                .SetDefaultValue(-1)
                .SetEntropyType(EntropyType.Int)
                .SetNumericValue((int)EntropyType.Int)
                .SetTextValue("Integer")
                .Configuration;

            FloatConfiguration = new EntropyTypeDefinitionBuilder<float>(_floatEntropyTypeRepository)
                .SetDefaultValue(-1f)
                .SetEntropyType(EntropyType.Float)
                .SetNumericValue((int)EntropyType.Float)
                .SetTextValue("Float")
                .Configuration;

            HashConfiguration = new EntropyTypeDefinitionBuilder<string>(_hashEntropyTypeRepository)
                .SetDefaultValue(string.Empty)
                .SetEntropyType(EntropyType.Hash)
                .SetNumericValue((int)EntropyType.Hash)
                .SetTextValue("Hash")
                .Configuration;
        }
    }
}
