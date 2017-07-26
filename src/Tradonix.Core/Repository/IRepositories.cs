using Tradonix.Core.Entities;
using Tradonix.Core.Entities.Meta;

namespace Tradonix.Core.Repository
{
    public interface ILoggingRepository : IEntityBaseRepository<LogEntry> { }

    public interface ISettingRepository : IEntityBaseRepository<Setting>
    {
        Setting GetSetting(SettingKeys key);
    }

    public interface IExchangeRepository : IEntityBaseRepository<Exchange> { }

    public interface ITickerRepository : IEntityBaseRepository<Ticker> { }

    public interface IExchangeTickerRepository : IEntityBaseRepository<ExchangeTicker> { }

    public interface IMarketSummaryRepository : IEntityBaseRepository<MarketSummary> { }

}
