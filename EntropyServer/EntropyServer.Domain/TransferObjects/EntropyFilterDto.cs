using System;

namespace EntropyServer.Domain.TransferObjects
{
    [Serializable]
    public sealed class EntropyFilterDto
    {
        public int EntropyTypeID { get; set; } = -1;

        public int Limit { get; set; } = 1;
    }
}
