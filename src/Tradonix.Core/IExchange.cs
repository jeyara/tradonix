using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradonix.Core.Entities;

namespace Tradonix.Core
{
    public interface IExchange
    {
        string Name { get; }

        IList<string> GetSupportedCurrencies();

        IList<string> GetSupportedTickers();

        IList<MarketSummary> GetAllMarketSummaries();

        MarketSummary GetMarketSummaryByTicker(string ticker);
    }
}
