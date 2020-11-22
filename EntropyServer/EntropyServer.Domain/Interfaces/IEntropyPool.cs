using EntropyServer.Domain.Enums;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyPool
    {
        void AddEntropy(EntropyType type, object entropy);

        void AddSubPool(EntropyType type);

        void DrainSubPool(EntropyType type);
    }
}
