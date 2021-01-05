using System;

namespace EntropyServer.Domain.TransferObjects
{
    [Serializable]
    public sealed class EntropyFilterDto
    {
        public int EntropyTypeID { get; init; } = -1;

        public int Limit { get; init; } = 1;
    }
}
