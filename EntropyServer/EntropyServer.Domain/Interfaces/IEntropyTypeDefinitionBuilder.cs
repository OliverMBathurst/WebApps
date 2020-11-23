using EntropyServer.Domain.Enums;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeDefinitionBuilder<T>
    {
        IEntropyTypeDefinitionBuilder<T> SetTextValue(string value);

        IEntropyTypeDefinitionBuilder<T> SetNumericValue(int value);

        IEntropyTypeDefinitionBuilder<T> SetDefaultValue(T value);

        IEntropyTypeDefinitionBuilder<T> SetEntropyType(EntropyType value);

        IEntropyTypeDefinitionConfiguration<T> Configuration { get; }
    }
}
