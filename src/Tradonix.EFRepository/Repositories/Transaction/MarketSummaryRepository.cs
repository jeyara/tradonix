using Tradonix.Core.Entities;
using Tradonix.Core.Repository;

namespace Tradonix.EFRepository.Repositories
{
    public class MarketSummaryRepository : EntityBaseRepository<MarketSummary>, IMarketSummaryRepository
    {
        public MarketSummaryRepository(TradonixContext context)
            : base(context)
        { }

    }
}
