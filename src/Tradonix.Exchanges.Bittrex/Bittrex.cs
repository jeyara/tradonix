using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradonix.Core;
using Tradonix.Core.Entities;

namespace Tradonix.Exchanges.Bittrex
{
    public class Bittrex : IExchange
    {
        private const string baseUrl = "https://bittrex.com/api/v1.1";
        private const string marketSummaryUrl = "public/getmarketsummaries";

        public string Name { get => "Bittex.com"; }

        public IList<MarketSummary> GetAllMarketSummaries()
        {
            throw new NotImplementedException();
        }

        public MarketSummary GetMarketSummaryByTicker(string ticker)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetSupportedCurrencies()
        {
            throw new NotImplementedException();
        }

        public IList<string> GetSupportedTickers()
        {
            throw new NotImplementedException();
        }
    }
}
