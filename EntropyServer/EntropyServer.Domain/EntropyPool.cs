using EntropyServer.Domain.Enums;
using EntropyServer.Domain.Interfaces;
using EntropyServer.Extensions;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EntropyServer.Domain
{
    public sealed class EntropyPool : IEntropyPool
    {
        private readonly ConcurrentDictionary<EntropyType, List<object>> _entropyPoolDictionary = new ConcurrentDictionary<EntropyType, List<object>>();

        public void AddEntropy(EntropyType type, object entropy)
        {
            _entropyPoolDictionary.AddOrUpdate(type,
                x => new List<object> { entropy },
                (x, oldList) => oldList.AddAndReturn(entropy));
        }

        public void AddSubPool(EntropyType type)
        {
            //add logic here
        }

        public void DrainSubPool(EntropyType type)
        {
            if (_entropyPoolDictionary.TryGetValue(type, out var values))
            {
                values.Clear();
            }
        }
    }
}
