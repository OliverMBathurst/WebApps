using EntropyServer.Domain.Interfaces;
using System;

namespace EntropyServer.Domain
{
    [Serializable]
    public sealed class EntropyFilter : IEntropyFilter
    {
        public int EntropyTypeID { get; set; } = -1;

        public int Limit { get; set; } = 1;
    }
}
