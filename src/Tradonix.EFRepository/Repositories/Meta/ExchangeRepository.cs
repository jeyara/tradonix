using Tradonix.Core.Entities;
using Tradonix.Core.Entities.Meta;
using Tradonix.Core.Repository;

namespace Tradonix.EFRepository.Repositories
{
    public class ExchangeRepository : EntityBaseRepository<Exchange>, IExchangeRepository
    {
        public ExchangeRepository(TradonixContext context)
            : base(context)
        { }

    }
}
