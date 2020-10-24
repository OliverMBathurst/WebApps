using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EntropyServer.Domain
{
    public sealed class EntropyPool : IEntropyPool
    {
        private readonly ConcurrentDictionary<Type, List<object>> _entropyPoolDictionary = new ConcurrentDictionary<Type, List<object>>();

        public void AddEntropy(Type type, object entropy)
        {
            _entropyPoolDictionary.AddOrUpdate(type,
                x => new List<object> { entropy },
                (x, oldList) => oldList.AddAndReturn(entropy));
        }

        public void AddSubPool(Type type)
        {
            _entropyPoolDictionary.TryAdd(type, new List<object>());
        }

        public void DrainSubPool(Type type)
        {
            if (_entropyPoolDictionary.TryGetValue(type, out var values))
            {
                values.Clear();
            }
        }
    }
}
