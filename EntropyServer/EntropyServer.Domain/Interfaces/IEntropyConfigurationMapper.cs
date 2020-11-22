namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyConfigurationMapper
    {
        IEntropyTypeDefinitionConfiguration<int> IntegerConfiguration { get; }

        IEntropyTypeDefinitionConfiguration<float> FloatConfiguration { get; }

        IEntropyTypeDefinitionConfiguration<string> HashConfiguration { get; }

        IEntropyTypeDefinitionConfiguration<T> GetConfiguration<T>();
    }
}
