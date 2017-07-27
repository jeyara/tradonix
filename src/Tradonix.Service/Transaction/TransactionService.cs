using System;
using System.Collections.Generic;
using Tradonix.Core.Entities;
using Tradonix.Core.Repository;
using Tradonix.Core.Services.Transaction;
using Tradonix.Services.Infra;

namespace Tradonix.Service.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly ILoggingService _loggingService;
        private readonly ISettingRepository _settingRepository;
        private readonly IMarketSummaryRepository _marketSummaryRepository;

        public TransactionService(ILoggingService loggingService, ISettingRepository settingRepository, IMarketSummaryRepository marketSummaryRepository)
        {
            this._loggingService = loggingService;
            this._settingRepository = settingRepository;
            this._marketSummaryRepository = marketSummaryRepository;
        }

        public void Add(MarketSummary marketSummary)
        {
            throw new NotImplementedException();
        }

        public void Add(List<MarketSummary> marketSummary)
        {
            throw new NotImplementedException();
        }
    }
}
