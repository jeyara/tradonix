using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Tradonix.Core;
using Tradonix.Core.Entities;
using Tradonix.Exchanges.Bittrex.Data;

namespace Tradonix.Exchanges.Bittrex
{
    public partial class Exchange : IExchange
    {
        public Exchange()
        {
            this.apiKey = "";
            this.secret = "";
            this.quoteCurrency = "BTC";
            this.simulate = false;
            this.apiCall = new ApiCall(this.simulate);
        }


        #region Object Translators
        private MarketSummary GetMarketSummaryFromMarketSummaryResponse(GetMarketSummaryResponse resp)
        {
            return new MarketSummary()
            {
                UniqueId = Guid.NewGuid(),
                //CurencyCode = GetCurrencyName(resp.MarketName),
                CurrentAskPrice = resp.Ask,
                CurrentBidPrice = resp.Bid,
                CurrentOpenBuyOrders = resp.OpenBuyOrders,
                CurrentOpenSellOrders = resp.OpenSellOrders,
                TimeStamp = new DateTimeOffset(DateTime.SpecifyKind(resp.TimeStamp, DateTimeKind.Utc)),

                LastPrice = resp.Last,
                //Source = this.Name,
                //TickerCode = GetTickerName(resp.MarketName),
                RawData = JsonConvert.SerializeObject(resp)
            };
        }

        #endregion

        #region IExchange

        public string Name { get => "Bittex.com"; }

        public IList<MarketSummary> GetMarketSummariesAll()
        {
            var resp = this.Call<GetMarketSummaryResponse[]>(ApiCallGetMarketSummaries);
            return resp.Select(r => GetMarketSummaryFromMarketSummaryResponse(r)).ToList();
        }

        public MarketSummary GetMarketSummaryByTicker(string ticker)
        {
            var resp = this.Call<GetMarketSummaryResponse[]>(ApiCallGetMarketSummary,
                Tuple.Create("market", GetMarketName(ticker))).Single();

            return GetMarketSummaryFromMarketSummaryResponse(resp);
        }

        public IList<string> GetSupportedCurrencies()
        {
            throw new NotImplementedException();
        }

        public IList<string> GetSupportedTickers()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
