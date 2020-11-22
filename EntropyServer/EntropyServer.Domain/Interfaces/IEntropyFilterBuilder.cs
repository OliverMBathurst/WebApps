namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyFilterBuilder
    {
        IEntropyFilterBuilder ResetState();

        IEntropyFilterBuilder AddEntropyTypeId(int id);

        IEntropyFilterBuilder AddLimit(int limit);
    }
}
