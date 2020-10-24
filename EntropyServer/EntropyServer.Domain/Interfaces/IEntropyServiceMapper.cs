namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyServiceMapper
    {
        IEntropyService<T> GetService<T>();
    }
}
