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
    public class Exchange : IExchange
    {
        const string ApiCallTemplate = "https://bittrex.com/api/{0}/{1}";
        const string ApiVersion = "v1.1";
        const string ApiCallGetMarkets = "public/getmarkets";
        const string ApiCallGetTicker = "public/getticker";
        const string ApiCallGetOrderBook = "public/getorderbook";
        const string ApiCallGetMarketHistory = "public/getmarkethistory";
        const string ApiCallGetMarketSummary = "public/getmarketsummary";
        const string ApiCallGetMarketSummaries = "public/getmarketsummaries";

        const string ApiCallGetBalances = "account/getbalances";
        const string ApiCallGetBalance = "account/getbalance";
        const string ApiCallGetOrderHistory = "account/getorderhistory";

        const string ApiCallBuyLimit = "market/buylimit";
        const string ApiCallSellLimit = "market/selllimit";
        const string ApiCallGetOpenOrders = "market/getopenorders";
        const string ApiCallCancel = "market/cancel";

        private string apiKey;
        private string secret;
        private string quoteCurrency;
        private bool simulate;
        private ApiCall apiCall;


        public Exchange()
        {
            this.apiKey = "";
            this.secret = "";
            this.quoteCurrency = "BTC";
            this.simulate = false;
            this.apiCall = new ApiCall(this.simulate);
        }

        #region Private

        private string GetMethodUrl(string method)
        {
            return string.Format(ApiCallTemplate, ApiVersion, method);
        }

        private string GetMarketName(string ticker)
        {
            return this.quoteCurrency + "-" + ticker;
        }

        private string GetTickerName(string marketName)
        {
            if (string.IsNullOrWhiteSpace(marketName))
                return marketName;

            if (!marketName.Contains("-"))
                return marketName;

            return marketName.Split("-".ToCharArray())[1];
        }

        private T Call<T>(string method, params Tuple<string, string>[] parameters)
        {
            if (method.StartsWith("public"))
            {
                var uri = GetMethodUrl(method);
                if (parameters != null && parameters.Length > 0)
                {
                    var extraParameters = new StringBuilder();
                    foreach (var item in parameters)
                    {
                        extraParameters.Append((extraParameters.Length == 0 ? "?" : "&") + item.Item1 + "=" + item.Item2);
                    }

                    if (extraParameters.Length > 0)
                    {
                        uri = uri + extraParameters.ToString();
                    }
                }

                return this.apiCall.CallWithJsonResponse<T>(uri, false);
            }
            else
            {
                var nonce = DateTime.Now.Ticks;
                var uri = string.Format(ApiCallTemplate, ApiVersion, method + "?apikey=" + this.apiKey + "&nonce=" + nonce);

                if (parameters != null)
                {
                    var extraParameters = new StringBuilder();
                    foreach (var item in parameters)
                    {
                        extraParameters.Append("&" + item.Item1 + "=" + item.Item2);
                    }

                    if (extraParameters.Length > 0)
                    {
                        uri = uri + extraParameters.ToString();
                    }
                }

                var sign = HashHmac(uri, secret);
                return this.apiCall.CallWithJsonResponse<T>(uri,
                    !method.StartsWith("market/get") && !method.StartsWith("account/get"),
                    Tuple.Create("apisign", sign));
            }
        }

        private static string HashHmac(string message, string secret)
        {
            Encoding encoding = Encoding.UTF8;
            using (HMACSHA512 hmac = new HMACSHA512(encoding.GetBytes(secret)))
            {
                var msg = encoding.GetBytes(message);
                var hash = hmac.ComputeHash(msg);
                return BitConverter.ToString(hash).ToLower().Replace("-", string.Empty);
            }
        }


        #endregion

        #region Object Translators
        private MarketSummary GetMarketSummaryFromMarketSummaryResponse(GetMarketSummaryResponse resp)
        {
            return new MarketSummary()
            {
                UniqueId = Guid.NewGuid(),
                CurencyCode = this.quoteCurrency,
                CurrentAskPrice = resp.Ask,
                CurrentBidPrice = resp.Bid,
                CurrentOpenBuyOrders = resp.OpenBuyOrders,
                CurrentOpenSellOrders = resp.OpenSellOrders,
                TotalDayVolume = resp.BaseVolume,
                TimeStamp = new DateTimeOffset(DateTime.SpecifyKind(resp.TimeStamp, DateTimeKind.Utc)),
                DayHighestPrice = resp.High,
                DayLowestPrice = resp.Low,

                CurrentAskQty = 0,
                CurrentBidQty = 0,
                DayAvgPrice = 0,

                LastPrice = resp.Last,
                Source = this.Name,
                TickerCode = GetTickerName(resp.MarketName),
            };
        }

        #endregion

        #region IExchange

        #endregion
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
    }
}
