using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Infrastructure.Builders;
using System;

namespace EntropyServer.Infrastructure.Services.MappingServices
{
    public sealed class EntropyTypeConfigurationMappingService : IEntropyTypeConfigurationMappingService
    {
        private readonly IEntropyGeneratorService<int> _intEntropyGeneratorService;
        private readonly IEntropyResultService<int> _intEntropyResultService;

        public EntropyTypeConfigurationMappingService(
            IEntropyGeneratorService<int> intEntropyGeneratorService,
            IEntropyResultService<int> intEntropyResultService)
        {
            _intEntropyGeneratorService = intEntropyGeneratorService;
            _intEntropyResultService = intEntropyResultService;

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
            IntegerConfiguration = new EntropyTypeDefinitionBuilder<int>(_intEntropyGeneratorService, _intEntropyResultService)
                .SetDefaultValue(-1)
                .SetEntropyType(EntropyType.Int)
                .SetNumericValue((int)EntropyType.Int)
                .SetTextValue("Integer")
                .Configuration;
        }
    }
}
