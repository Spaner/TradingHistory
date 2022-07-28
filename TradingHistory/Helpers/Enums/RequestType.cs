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

        [RequestPath("platform/status", HttpRequestMethod.Get)] Status,
        [RequestPath("trades/tBTCEUR/hist?limit={0}&start={1}", HttpRequestMethod.Get)] BTC_EUR_History,

    }
}

