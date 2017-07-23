using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tradonix.Core.Entities;

namespace Tradonix.Core.BigData
{
    public class TickerSnapShot
    {
        public MarketSummary MarketSummary { get; set; }
        public List<String> CurrentOrderBook { get; set; }
        public List<String> OrderBookHistory { get; set; }
    }
}
