using System;

namespace EntropyServer.Domain.Interfaces
{
    public interface IEntropyPool
    {
        void AddEntropy(Type type, object entropy);

        void AddSubPool(Type type);

        void DrainSubPool(Type type);
    }
}
