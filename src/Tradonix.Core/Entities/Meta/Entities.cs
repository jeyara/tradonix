using System;
using System.Collections.Generic;

namespace Tradonix.Core.Entities.Meta
{
    public class Exchange : IEntityBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Guid UniqueId { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset AddedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<ExchangeTicker> ExchangeTickers { get; set; }
    }

    public class Ticker : IEntityBase
    {
        public long Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal MinimumUnit { get; set; }
        public string LogoUrl { get; set; }
        public TickerType TickerType { get; set; }
        /// <summary>
        /// Use TickerType enum to update this
        /// </summary>
        public int TickerTypeId { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset AddedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<ExchangeTicker> ExchangeTickers { get; set; }
    }


    public class ExchangeTicker : IEntityBase
    {
        public long Id { get; set; }
        public long ExchangeId { get; set; }
        public long TickerId { get; set; }
        public long BaseTickerId { get; set; }
        public Guid UniqueId { get; set; }
        public decimal? TradeComission { get; set; }
        public decimal? MinimumTradableUnit { get; set; }
        public string MarketName { get; set; } //100
        public bool IsActive { get; set; }
        public DateTimeOffset AddedOn { get; set; }
        public string AddedBy { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public Exchange Exchange { get; set; }
        public Ticker Ticker { get; set; }
        public Ticker BaseTicker { get; set; }
    }
}
