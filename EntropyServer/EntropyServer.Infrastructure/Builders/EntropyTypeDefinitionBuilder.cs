using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Infrastructure.Configuration;

namespace EntropyServer.Infrastructure.Builders
{
    public sealed class EntropyTypeDefinitionBuilder<T> : IEntropyTypeDefinitionBuilder<T>
    {
        private IEntropyTypeDefinitionConfiguration<T> _config = new EntropyTypeDefinitionConfiguration<T>();

        public EntropyTypeDefinitionBuilder(
            IEntropyService<T> service,
            IEntropyGenerator<T> generator)
        {
            _config.Service = service;
            _config.Generator = generator;
        }

        public IEntropyTypeDefinitionBuilder<T> ResetState() {
            _config = new EntropyTypeDefinitionConfiguration<T>();
            return this;
        }

        public IEntropyTypeDefinitionBuilder<T> SetTextValue(string value) {
            _config.TextValue = value;
            return this;
        }

        public IEntropyTypeDefinitionBuilder<T> SetNumericValue(int value)
        {
            _config.NumericValue = value;
            return this;
        }

        public IEntropyTypeDefinitionBuilder<T> SetDefaultValue(T value)
        {
            _config.DefaultValue = value;
            return this;
        }

        public IEntropyTypeDefinitionBuilder<T> SetEntropyType(EntropyType value)
        {
            _config.EntropyType = value;
            return this;
        }

        public IEntropyTypeDefinitionConfiguration<T> Result => _config;
    }
}
