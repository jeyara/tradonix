using System;
using System.Collections.Generic;
using Tradonix.Core.Entities;

namespace Tradonix.Core
{
    public interface IExchange
    {
        string Name { get; }

        IList<string> GetSupportedCurrencies();

        IList<string> GetSupportedTickers();

        IList<MarketSummary> GetMarketSummariesAll();

        MarketSummary GetMarketSummaryByTicker(string ticker);
    }
}
