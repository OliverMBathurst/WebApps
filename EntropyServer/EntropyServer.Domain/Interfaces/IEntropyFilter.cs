namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyFilter
    {
        int EntropyTypeID { get; }

        int Limit { get; }
    }
}
