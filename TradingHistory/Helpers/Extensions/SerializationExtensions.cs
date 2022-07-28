using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingHistory.Helpers.Extensions
{
    public static class SerializationExtensions
    {
        public static T Deserialize<T>(this string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static string Serialize(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
