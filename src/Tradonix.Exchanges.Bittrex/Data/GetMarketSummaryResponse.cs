using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradonix.Core.Entities;

namespace Tradonix.Exchanges.Bittrex.Data
{
    public class GetMarketSummaryResponse
    {
        //        {
        //    "MarketName": "BTC-1ST",
        //    "High": 0.00039587,
        //    "Low": 0.0003445,
        //    "Volume": 362021.9314977,
        //    "Last": 0.00034764,
        //    "BaseVolume": 132.97765014,
        //    "TimeStamp": "2017-07-23T13:25:20.283",
        //    "Bid": 0.00034764,
        //    "Ask": 0.0003548,
        //    "OpenBuyOrders": 144,
        //    "OpenSellOrders": 1245,
        //    "PrevDay": 0.00036909,
        //    "Created": "2017-06-06T01:22:35.727"
        //}
        public string MarketName { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Volume { get; set; }
        public decimal Last { get; set; }
        public decimal BaseVolume { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public int OpenBuyOrders { get; set; }
        public int OpenSellOrders { get; set; }
        public decimal PrevDay { get; set; }
        public DateTime Created { get; set; }
    }
}
