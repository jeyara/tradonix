using Newtonsoft.Json;
using System;
using Tradonix.Core;
using Tradonix.Core.Entities;
using Tradonix.Exchanges.Bittrex.Data;
using Tradonix.Core.Services.Meta;
using Tradonix.Core.Services.Transaction;
using Tradonix.Services.Infra;

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

        public string Name { get => "Bittex"; }

        public void Initialize(ILoggingService loggingService, ISettingService settingService, IMetaService metaService, ITransactionService transactionService)
        {
            throw new NotImplementedException();
        }

        public void GetAllMarketSummaries()
        {
            //Get the exchange object

            //If exchange is not there, insert.

            //Get the list of tickers

            //Get all the market summary

            //Iterate Market summary and insert new ticket if ticker is missing
            //While build the Market summary list.

            //Insert market summary
            var resp = this.Call<GetMarketSummaryResponse[]>(ApiCallGetMarketSummaries);
        }

        public void SyncAllTickers()
        {
            throw new NotImplementedException();
        }

        public void GetInDepthMarketDataByTicker(string ticker)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
