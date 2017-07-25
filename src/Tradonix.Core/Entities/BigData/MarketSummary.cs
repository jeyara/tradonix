using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradonix.Core.Entities.BigData;

namespace Tradonix.Core.Entities
{
    public class MarketSummary
    {
        public int Id { get; set; }
        public MarketType MarketType { get; set; }
        public Guid UniqueId { get; set; }
        public string Source { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string TickerCode { get; set; }
        public string CurencyCode { get; set; }

        public decimal CurrentAskPrice { get; set; }
        public decimal CurrentBidPrice { get; set; }
        public int CurrentOpenBuyOrders { get; set; }
        public int CurrentOpenSellOrders { get; set; }
        public decimal LastPrice { get; set; }
        public string RawData { get; set; }
    }
}
