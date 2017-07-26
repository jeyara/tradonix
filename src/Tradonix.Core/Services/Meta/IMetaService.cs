using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradonix.Core.Entities.Meta;

namespace Tradonix.Core.Services.Meta
{
    public interface IMetaService
    {
        long AddUpdateExchange(Exchange exchange);
        long AddUpdateTicker(Ticker ticker);
        long AddUpdateExchangeTicker(ExchangeTicker exchangeTicker);
    }
}
