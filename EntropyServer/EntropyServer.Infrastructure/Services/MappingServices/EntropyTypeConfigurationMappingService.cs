using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Extensions;
using EntropyServer.Infrastructure.Builders;
using System.Collections.Generic;
using System.Linq;

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

            AddConfigurations();
        }

        public IEntropyTypeDefinitionConfiguration<T> GetConfiguration<T>()
            => Configurations.FirstOrDefault(x => x is IEntropyTypeDefinitionConfiguration<T>)?.Cast<IEntropyTypeDefinitionConfiguration<T>>();

        public IEnumerable<object> Configurations { get; private set; }

        private void AddConfigurations()
        {
            var integerConfiguration = new EntropyTypeDefinitionBuilder<int>(_intEntropyTypeRepository)
                .SetDefaultValue(-1)
                .SetEntropyType(EntropyType.Int)
                .SetNumericValue((int)EntropyType.Int)
                .SetTextValue("Integer")
                .Configuration;

            var floatConfiguration = new EntropyTypeDefinitionBuilder<float>(_floatEntropyTypeRepository)
                .SetDefaultValue(-1f)
                .SetEntropyType(EntropyType.Float)
                .SetNumericValue((int)EntropyType.Float)
                .SetTextValue("Float")
                .Configuration;

            var hashConfiguration = new EntropyTypeDefinitionBuilder<string>(_hashEntropyTypeRepository)
                .SetDefaultValue(string.Empty)
                .SetEntropyType(EntropyType.Hash)
                .SetNumericValue((int)EntropyType.Hash)
                .SetTextValue("Hash")
                .Configuration;


            Configurations = new List<object>
            {
                integerConfiguration,
                floatConfiguration,
                hashConfiguration
            };
        }
    }
}
