using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingHistory.Models
{
    public static class Settings
    {
        public static string BaseURL => ConfigurationManager.AppSettings[Constants.BaseURLKey] ?? Constants.BASE_URL;
        public static int RefreshInterval => ConfigurationManager.AppSettings[Constants.RefreshIntervalKey] == null ?Constants.REFRESH_INTERVAL : Convert.ToInt32(ConfigurationManager.AppSettings[Constants.RefreshIntervalKey]);
        public static int RecordLimit => ConfigurationManager.AppSettings[Constants.RecordLimitKey] == null ? Constants.RECORD_LIMIT : Convert.ToInt32(ConfigurationManager.AppSettings[Constants.RecordLimitKey]);
        public static int StartInterval => ConfigurationManager.AppSettings[Constants.StartIntervalKey] == null ? Constants.START_INTERVAL : Convert.ToInt32(ConfigurationManager.AppSettings[Constants.StartIntervalKey]);
        public static int MaxLinesDisplay => ConfigurationManager.AppSettings[Constants.MaxLinesDisplayKey] == null ? Constants.MAX_LINES_DISPLAY : Convert.ToInt32(ConfigurationManager.AppSettings[Constants.MaxLinesDisplayKey]);
    }
}
