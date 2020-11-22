using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;

namespace EntropyServer.Infrastructure.Configuration
{
    public sealed class EntropyTypeDefinitionConfiguration<T> : IEntropyTypeDefinitionConfiguration<T>
    {
        public IEntropyGenerator<T> Generator { get; set; }

        public IEntropyService<T> Service { get; set; }

        public int NumericValue { get; set; }

        public string TextValue { get; set; }

        public T DefaultValue { get; set; }

        public EntropyType EntropyType { get; set; }
    }
}
