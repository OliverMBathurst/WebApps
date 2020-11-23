using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Infrastructure.Builders;
using System;

namespace EntropyServer.Infrastructure.Mappers
{
    public sealed class EntropyTypeConfigurationMapper : IEntropyTypeConfigurationMapper
    {
        private readonly IEntropyTypeServiceRepository<int> _intEntropyTypeServiceRepository;

        public EntropyTypeConfigurationMapper(IEntropyTypeServiceRepository<int> intEntropyTypeServiceRepository)
        {
            _intEntropyTypeServiceRepository = intEntropyTypeServiceRepository;

             SetupConfigurations();
        }

        public IEntropyTypeDefinitionConfiguration<int> IntegerConfiguration { get; private set; }

        public IEntropyTypeDefinitionConfiguration<float> FloatConfiguration { get; private set; }

        public IEntropyTypeDefinitionConfiguration<string> HashConfiguration { get; private set; }

        public IEntropyTypeDefinitionConfiguration<T> GetConfiguration<T>()
        {
            var prop = Array.Find(typeof(EntropyTypeConfigurationMapper).GetProperties(), x => x.PropertyType.Equals(typeof(IEntropyTypeDefinitionConfiguration<T>)));
            if (prop == null)
            {
                //throw a more specific exception here
                throw new Exception();
            }


            return (IEntropyTypeDefinitionConfiguration<T>)prop.GetValue(this);
        }

        private void SetupConfigurations()
        {
            IntegerConfiguration = new EntropyTypeDefinitionBuilder<int>(
                _intEntropyTypeServiceRepository)
                .SetDefaultValue(-1)
                .SetEntropyType(EntropyType.Int)
                .SetNumericValue((int)EntropyType.Int)
                .SetTextValue("Integer")
                .Configuration;
        }
    }
}
