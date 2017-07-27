using System.Collections.Generic;
using Tradonix.Core.Entities;
using Tradonix.Core.Entities.Meta;
using Tradonix.Core.Services.Meta;
using Tradonix.Core.Services.Transaction;
using Tradonix.Services.Infra;

namespace Tradonix.Core
{
    public interface IExchange
    {
        string Name { get; }

        void Initialize(
            ILoggingService loggingService, 
            ISettingService settingService, 
            IMetaService metaService,
            ITransactionService transactionService
            );

        void SyncAllTickers();

        void GetAllMarketSummaries();

        void GetInDepthMarketDataByTicker(string ticker);
    }
}
