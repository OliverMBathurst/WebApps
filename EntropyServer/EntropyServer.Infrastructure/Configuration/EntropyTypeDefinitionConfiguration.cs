using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Infrastructure.Configuration
{
    public sealed class EntropyTypeDefinitionConfiguration<T> : IEntropyTypeDefinitionConfiguration<T>
    {
        public IEntropyGeneratorService<T> GeneratorService { get; set; }

        public IEntropyResultService<T> ResultService { get; set; }

        public int NumericValue { get; set; }

        public string TextValue { get; set; }

        public T DefaultValue { get; set; }

        public EntropyType EntropyType { get; set; }
    }
}
