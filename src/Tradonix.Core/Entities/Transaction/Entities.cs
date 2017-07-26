using System;
using Tradonix.Core.Entities.Meta;

namespace Tradonix.Core.Entities
{
    public class MarketSummary : IEntityBase
    {
        public long Id { get; set; }
        public ExchangeTicker ExchangeTicker { get; set; }
        public int ExchangeTickerId { get; set; }
        public Guid UniqueId { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public decimal CurrentAskPrice { get; set; }
        public decimal CurrentBidPrice { get; set; }
        public int? CurrentOpenBuyOrders { get; set; }
        public int? CurrentOpenSellOrders { get; set; }
        public decimal? LastPrice { get; set; }
        public string RawData { get; set; }
        public DateTimeOffset AddedOn { get; set; }
        public string AddedBy { get; set; }
    }

}
