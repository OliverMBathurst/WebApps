using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Infrastructure.Builders;
using System;

namespace EntropyServer.Infrastructure.Mappers
{
    public sealed class EntropyConfigurationMapper : IEntropyConfigurationMapper
    {
        private readonly IEntropyService<int> _intEntropyService;
        private readonly IEntropyGenerator<int> _intEntropyGenerator;

        public EntropyConfigurationMapper(
            IEntropyService<int> intEntropyService,
            IEntropyGenerator<int> intEntropyGenerator)
        {
            _intEntropyService = intEntropyService;
            _intEntropyGenerator = intEntropyGenerator;

             SetupConfigurations();
        }

        public IEntropyTypeDefinitionConfiguration<int> IntegerConfiguration { get; private set; }

        public IEntropyTypeDefinitionConfiguration<float> FloatConfiguration { get; private set; }

        public IEntropyTypeDefinitionConfiguration<string> HashConfiguration { get; private set; }

        public IEntropyTypeDefinitionConfiguration<T> GetConfiguration<T>()
            => (IEntropyTypeDefinitionConfiguration<T>) Array.Find(typeof(EntropyConfigurationMapper)
            .GetProperties(), x => x.PropertyType == typeof(IEntropyTypeDefinitionConfiguration<T>))
            .GetValue(this);

        private void SetupConfigurations()
        {
            IntegerConfiguration = new EntropyTypeDefinitionBuilder<int>(
                _intEntropyService,
                _intEntropyGenerator)
                .SetDefaultValue(-1)
                .SetEntropyType(EntropyType.Int)
                .SetNumericValue((int)EntropyType.Int)
                .SetTextValue("Integer")
                .Result;
        }
    }
}
