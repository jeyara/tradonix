using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradonix.Core.Entities
{
    public class MarketSummary
    {
        public Guid UniqueId { get; set; }
        public string Source { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string TickerCode { get; set; }
        public string CurencyCode { get; set; }



        public decimal DayHighestPrice { get; set; }
        public decimal DayLowestPrice { get; set; }
        public decimal DayAvgPrice { get; set; }
        public decimal TotalDayVolume { get; set; }



        public decimal CurrentAskPrice { get; set; }
        public int CurrentAskQty { get; set; }
        public decimal CurrentBidPrice { get; set; }
        public int CurrentBidQty { get; set; }
        public int CurrentOpenBuyOrders { get; set; }
        public int CurrentOpenSellOrders { get; set; }


        public decimal LastPrice { get; set; }
    }
}
