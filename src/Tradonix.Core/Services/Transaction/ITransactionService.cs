using System.Collections.Generic;
using Tradonix.Core.Entities;

namespace Tradonix.Core.Services.Transaction
{
    public interface ITransactionService
    {
        void Add(MarketSummary marketSummary);
        void Add(List<MarketSummary> marketSummary);
    }
}
