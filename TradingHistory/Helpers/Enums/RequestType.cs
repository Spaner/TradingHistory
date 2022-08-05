using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingHistory.Helpers.Attributes;

namespace TradingHistory.Helpers.Enums
{
    public enum RequestType
    {

        [RequestPath("platform/status")] Status,
        [RequestPath("trades/tBTCEUR/hist?limit={0}&start={1}")] BTC_EUR_History,

    }
}

