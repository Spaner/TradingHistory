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
                foreach (var jArray in response.Content)
                {
                    //convert to model
                    var values = jArray.Children();
                    var tradeModel = new BitcoinEuroTrade();
                    for (int i = 0; i < values.Count(); i++)
                    {
                        //properties come in the same order
                        switch (i)
                        {
                            case 0:
                                var tradeId = Convert.ToInt32(values.ElementAt(i));
                                tradeModel.TradeId = tradeId;
                                break;
                            case 1:
                                var timeStamp = Convert.ToInt64(values.ElementAt(i));
                                tradeModel.MillisecondTimeStamp = timeStamp;
                                break;
                            case 2:
                                var amount = Convert.ToDouble(values.ElementAt(i));
                                tradeModel.Amount = amount;
                                break;
                            case 3:
                                var price = Convert.ToDouble(values.ElementAt(i));
                                tradeModel.Price = price;
                                break;
                        }
                    }
                    tradeList.Add(tradeModel);
                }
            }

            return tradeList;

        }
    }
}
