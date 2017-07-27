using System;
using Tradonix.Core.Entities.Meta;
using Tradonix.Core.Repository;
using Tradonix.Core.Services.Meta;
using Tradonix.Services.Infra;

namespace Tradonix.Service.Meta
{
    public class MetaService : IMetaService
    {
        private readonly ILoggingService _loggingService;
        private readonly ISettingRepository _settingRepository;
        private readonly IExchangeRepository _exchangeRepository;
        private readonly ITickerRepository _tickerRepository;
        private readonly IExchangeTickerRepository _exchangeTickerRepository;

        public MetaService(ILoggingService loggingService, ISettingRepository settingRepository, IExchangeRepository exchangeRepository,
            ITickerRepository tickerRepository, IExchangeTickerRepository exchangeTickerRepository)
        {
            this._loggingService = loggingService;
            this._settingRepository = settingRepository;
            this._exchangeRepository = exchangeRepository;
            this._tickerRepository = tickerRepository;
            this._exchangeTickerRepository = exchangeTickerRepository;

        }
        public long AddUpdateExchange(Exchange exchange)
        {
            throw new NotImplementedException();
        }

        public long AddUpdateExchangeTicker(ExchangeTicker exchangeTicker)
        {
            throw new NotImplementedException();
        }

        public long AddUpdateTicker(Ticker ticker)
        {
            throw new NotImplementedException();
        }
    }
}
