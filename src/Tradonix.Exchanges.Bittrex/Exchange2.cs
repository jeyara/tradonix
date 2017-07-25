using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tradonix.Exchanges.Bittrex.Data;

namespace Tradonix.Exchanges.Bittrex
{
    public partial class Exchange
    {
        const string ApiCallTemplate = "https://bittrex.com/api/{0}/{1}";
        const string ApiVersion = "v1.1";
        const string ApiCallGetMarkets = "public/getmarkets";
        const string ApiCallGetTicker = "public/getticker"; //For a specific currency
        const string ApiCallGetOrderBook = "public/getorderbook"; //Buy/Sell for specific currency
        const string ApiCallGetMarketHistory = "public/getmarkethistory"; //Buy/Sell History for Specific Currency
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
        private string GetCurrencyName(string marketName)
        {
            if (string.IsNullOrWhiteSpace(marketName))
                return marketName;

            if (!marketName.Contains("-"))
                return marketName;

            return marketName.Split("-".ToCharArray())[0];
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

        #region Public Bittrex Specific Implementation

        public AccountBalance GetBalance(string market)
        {
            return this.Call<AccountBalance>(ApiCallGetBalance, Tuple.Create("currency", market));
        }

        public GetBalancesResponse GetBalances()
        {
            return this.Call<GetBalancesResponse>(ApiCallGetBalances);
        }

        public OrderResponse PlaceBuyOrder(string market, decimal quantity, decimal price)
        {
            return this.Call<OrderResponse>(ApiCallBuyLimit, Tuple.Create("market", GetMarketName(market)), Tuple.Create("quantity", quantity.ToString()), Tuple.Create("rate", price.ToString()));
        }

        public OrderResponse PlaceSellOrder(string market, decimal quantity, decimal price)
        {
            return this.Call<OrderResponse>(ApiCallSellLimit, Tuple.Create("market", GetMarketName(market)), Tuple.Create("quantity", quantity.ToString()), Tuple.Create("rate", price.ToString()));
        }

        public decimal CalculateMinimumOrderQuantity(string market, decimal price)
        {
            var minimumQuantity = Math.Round(0.00050000M / price, 1) + 0.1M;
            return minimumQuantity;
        }

        public dynamic GetMarkets()
        {
            return this.Call<dynamic>(ApiCallGetMarkets);
        }

        public dynamic GetTicker(string market)
        {
            return this.Call<dynamic>(ApiCallGetTicker, Tuple.Create("market", GetMarketName(market)));
        }

        public GetOpenOrdersResponse GetOpenOrders(string market)
        {
            return this.Call<GetOpenOrdersResponse>(ApiCallGetOpenOrders, Tuple.Create("market", GetMarketName(market)));
        }

        public void CancelOrder(string uuid)
        {
            this.Call<dynamic>(ApiCallCancel, Tuple.Create("uuid", uuid));
        }

        public GetOrderBookResponse GetOrderBook(string market, OrderBookType type, int depth = 20)
        {
            if (type == OrderBookType.Both)
            {
                return this.Call<GetOrderBookResponse>(ApiCallGetOrderBook,
                    Tuple.Create("market", GetMarketName(market)),
                    Tuple.Create("type", type.ToString().ToLower()),
                    Tuple.Create("depth", depth.ToString()));
            }
            else
            {
                var results = this.Call<List<OrderEntry>>(ApiCallGetOrderBook,
                    Tuple.Create("market", GetMarketName(market)),
                    Tuple.Create("type", type.ToString().ToLower()),
                    Tuple.Create("depth", depth.ToString()));

                if (type == OrderBookType.Buy)
                {
                    return new GetOrderBookResponse { buy = results };
                }
                else
                {
                    return new GetOrderBookResponse { sell = results };
                }
            }
        }

        public GetMarketHistoryResponse GetMarketHistory(string market, int count = 20)
        {
            return this.Call<GetMarketHistoryResponse>(ApiCallGetMarketHistory,
                Tuple.Create("market", GetMarketName(market)),
                Tuple.Create("count", count.ToString()));
        }

        public GetMarketSummaryResponse GetMarketSummary(string market)
        {
            return this.Call<GetMarketSummaryResponse[]>(ApiCallGetMarketSummary,
                Tuple.Create("market", GetMarketName(market))).Single();
        }

        public GetOrderHistoryResponse GetOrderHistory(string market, int count = 20)
        {
            return this.Call<GetOrderHistoryResponse>(ApiCallGetOrderHistory,
                Tuple.Create("market", GetMarketName(market)),
                Tuple.Create("count", count.ToString()));
        }

        #endregion
    }
}
