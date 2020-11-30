using EntropyServer.Domain.Enums;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeDefinitionConfiguration<T>
    {
        IEntropyGeneratorService<T> GeneratorService { get; set; }

        string TextValue { get; set; }

        int NumericValue { get; set; }

        T DefaultValue { get; set; }

        EntropyType EntropyType { get; set; }
    }
}
