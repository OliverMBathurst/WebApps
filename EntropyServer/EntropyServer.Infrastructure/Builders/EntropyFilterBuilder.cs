using EntropyServer.Domain.Interfaces;
using EntropyServer.Domain;

namespace EntropyServer.Infrastructure.Builders
{
    public sealed class EntropyFilterBuilder : IEntropyFilterBuilder
    {
        private EntropyFilter _entropyFilter = new EntropyFilter();

        private EntropyFilterBuilder() {}

        public static IEntropyFilterBuilder Create() => new EntropyFilterBuilder();

        public IEntropyFilterBuilder ResetState()
        {
            _entropyFilter = new EntropyFilter();
            return this;
        }

        public IEntropyFilterBuilder AddEntropyTypeId(int id)
        {
            _entropyFilter.EntropyTypeID = id;
            return this;
        }

        public IEntropyFilterBuilder AddLimit(int limit)
        {
            _entropyFilter.Limit = limit;
            return this;
        }

        public IEntropyFilter Resolve() => _entropyFilter;
    }
}
