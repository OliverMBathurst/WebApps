using EntropyServer.Domain.Enums;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeDefinition<T>
    {
        EntropyType EntropyTypeValue { get; }

        int NumericalValue { get; }

        string TextValue { get; }

        T DefaultValue { get; }
    }
}
