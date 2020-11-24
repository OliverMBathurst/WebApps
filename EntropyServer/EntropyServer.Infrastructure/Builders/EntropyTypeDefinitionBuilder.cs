using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Infrastructure.Configuration;

namespace EntropyServer.Infrastructure.Builders
{
    public sealed class EntropyTypeDefinitionBuilder<T> : IEntropyTypeDefinitionBuilder<T>
    {
        public EntropyTypeDefinitionBuilder(
            IEntropyGeneratorService<T> entropyGeneratorService,
            IEntropyResultService<T> entropyResultService)
        {
            Configuration.GeneratorService = entropyGeneratorService;
            Configuration.ResultService = entropyResultService;
        }

        public IEntropyTypeDefinitionBuilder<T> SetTextValue(string value) {
            Configuration.TextValue = value;
            return this;
        }

        public IEntropyTypeDefinitionBuilder<T> SetNumericValue(int value)
        {
            Configuration.NumericValue = value;
            return this;
        }

        public IEntropyTypeDefinitionBuilder<T> SetDefaultValue(T value)
        {
            Configuration.DefaultValue = value;
            return this;
        }

        public IEntropyTypeDefinitionBuilder<T> SetEntropyType(EntropyType value)
        {
            Configuration.EntropyType = value;
            return this;
        }

        public IEntropyTypeDefinitionConfiguration<T> Configuration { get; } = new EntropyTypeDefinitionConfiguration<T>();
    }
}
