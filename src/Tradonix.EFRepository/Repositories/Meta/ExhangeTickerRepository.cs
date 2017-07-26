using Tradonix.Core.Entities.Meta;
using Tradonix.Core.Repository;

namespace Tradonix.EFRepository.Repositories
{
    public class ExhangeTickerRepository : EntityBaseRepository<ExchangeTicker>, IExchangeTickerRepository
    {
        public ExhangeTickerRepository(TradonixContext context)
            : base(context)
        { }

    }
}