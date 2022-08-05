using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingHistory
{
    public static class Constants
    {
        public const int TradeIdIndex = 0;
        public const int PriceIndex = 3;

        #region Config Keys

        public const string BaseURLKey = "APIBaseURL";
        public const string RefreshIntervalKey = "RefreshInterval";
        public const string RecordLimitKey = "RecordLimit";
        public const string StartIntervalKey = "StartInterval";
        public const string MaxLinesDisplayKey = "MaxLinesDisplay";

        #endregion

        #region Default Values

        public const int REFRESH_INTERVAL = 10000; //milliseconds
        public const int RECORD_LIMIT = 10000; //max number of records to fetch
        public const int MAX_LINES_DISPLAY = 100; //max number of lines to display
        public const int START_INTERVAL = 1; //number of hours to go back and fetch records
        public const string BASE_URL = "https://api-pub.bitfinex.com/v2/"; //base API URL

        #endregion

        #region Text

        public const string START = "START";
        public const string STOP = "STOP";
        public const string PRESS_TEXT = "Press";
        public const string START_MESSAGE = "to begin";
        public const string STOP_MESSAGE = "to end";
        public const string START_TIME_MESSAGE = "Date: {0}; START";
        public const string STOP_TIME_MESSAGE = "Date: {0}; STOP";
        public const string ERROR_TIME_MESSAGE = "Date: {0}; ERROR: {1}";
        public const string TIME_TEXT = "Showing overview of BTC/EUR trades starting from {0}";
        public const string BTC_EUR_DISPLAY_TEXT = "Date: {0}; Min Price: {1}; Max Price {2}; Average Price {3}";


        #endregion

    }
}
