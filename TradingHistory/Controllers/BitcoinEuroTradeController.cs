using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingHistory.Controllers.Bases;
using TradingHistory.Helpers.Enums;
using TradingHistory.Models;
using TradingHistory.Models.TradeModels;

namespace TradingHistory.Controllers
{
    public class BitcoinEuroTradeController : BaseController
    {
        /// <summary>
        /// Fetches a specified number of records of BTC/EUR trades starting from a set date
        /// </summary>
        /// <param name="recordLimit">Max number of records to fetch</param>
        /// <param name="startMilliseconds">Date in milliseconds from where to start fetching data</param>
        /// <returns>A list of BTC/EUR trades</returns>
        public async Task<List<BitcoinEuroTrade>> BitcoinEuroTradeHistory(int recordLimit, long startMilliseconds)
        {
            var tradeList = new List<BitcoinEuroTrade>();

            var response = await GetAsync<List<JArray>>(GetServerUri(RequestType.BTC_EUR_History, recordLimit, startMilliseconds));
            if (response != null && response.Content != null)
            {

                tradeList = response.Content.Select(jArray => jArray.Children())
                    .Select(jToken => new BitcoinEuroTrade()
                     {
                         TradeId = Convert.ToInt32(jToken.ElementAt(Constants.TradeIdIndex)),
                         Price = Convert.ToDouble(jToken.ElementAt(Constants.PriceIndex))
                     }).ToList();
            }
            return tradeList;

        }
    }
}
