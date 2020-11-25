using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Infrastructure.Builders;
using System;

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

        public IEntropyTypeDefinitionConfiguration<int> IntegerConfiguration { get; private set; }

        public IEntropyTypeDefinitionConfiguration<float> FloatConfiguration { get; private set; }

        public IEntropyTypeDefinitionConfiguration<string> HashConfiguration { get; private set; }

        public IEntropyTypeDefinitionConfiguration<T> GetConfiguration<T>()
        {
            var prop = Array.Find(typeof(EntropyTypeConfigurationMappingService).GetProperties(), x => x.PropertyType.Equals(typeof(IEntropyTypeDefinitionConfiguration<T>)));
            if (prop == null)
            {
                //throw a more specific exception here
                throw new Exception();
            }


            return (IEntropyTypeDefinitionConfiguration<T>)prop.GetValue(this);
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
