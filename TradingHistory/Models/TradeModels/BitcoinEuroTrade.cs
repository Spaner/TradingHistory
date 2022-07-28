using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingHistory.Models.TradeModels
{
    public class BitcoinEuroTrade
    {
        public int TradeId { get; set; }
        public long MillisecondTimeStamp { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }

    }
}
