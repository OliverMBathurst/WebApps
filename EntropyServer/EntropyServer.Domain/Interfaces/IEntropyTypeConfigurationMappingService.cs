namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeConfigurationMappingService
    {
        IEntropyTypeDefinitionConfiguration<T> GetConfiguration<T>();
    }
}
