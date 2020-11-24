using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain.TransferObjects;
using System;

namespace EntropyServer.Domain.Filters
{
    [Serializable]
    public sealed class EntropyFilter : IEntropyFilter
    {
        private EntropyFilter() { }

        public static IEntropyFilter Create(int entropyTypeId, int limit)
            => new EntropyFilter
            {
                EntropyTypeID = entropyTypeId,
                Limit = limit
            };

        public static IEntropyFilter Create(EntropyFilterDto entropyFilterDto) => Create(entropyFilterDto.EntropyTypeID, entropyFilterDto.Limit);

        public int EntropyTypeID { get; private set; }

        public int Limit { get; private set; }
    }
}
