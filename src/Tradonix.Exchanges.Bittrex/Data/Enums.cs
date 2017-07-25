using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradonix.Exchanges.Bittrex.Data
{
    public enum OrderBookType
    {
        Buy,
        Sell,
        Both
    }

    public enum FillType
    {
        Fill,
        Partial_Fill
    }

    public enum OrderType
    {
        Buy,
        Sell
    }

    public enum OpenOrderType
    {
        Limit_Buy,
        Limit_Sell
    }
}
