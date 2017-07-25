using System.Collections.Generic;

namespace Tradonix.Exchanges.Bittrex.Data
{
    public class GetOrderBookResponse
    {
        public List<OrderEntry> buy { get; set; }
        public List<OrderEntry> sell { get; set; }
    }
}
