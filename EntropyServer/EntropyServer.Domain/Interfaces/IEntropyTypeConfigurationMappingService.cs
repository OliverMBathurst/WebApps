using System.Collections.Generic;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyTypeConfigurationMappingService
    {
        IEntropyTypeDefinitionConfiguration<T> GetConfiguration<T>();

        IEnumerable<object> Configurations { get; }
    }
}
