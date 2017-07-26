using Tradonix.Core.Entities.Meta;
using Tradonix.Core.Repository;

namespace Tradonix.EFRepository.Repositories
{
    public class TickerRepository : EntityBaseRepository<Ticker>, ITickerRepository
    {
        public TickerRepository(TradonixContext context)
            : base(context)
        { }

    }
}
