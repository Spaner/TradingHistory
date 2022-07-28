using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingHistory.Models
{
    /// <summary>
    /// Class to receive the content from an API call
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponsePackage<T>
    {
        public ResponsePackage(T content)
        {
            Content = content;
        }

        public ResponsePackage()
        {
            Content = default;
        }

        public T Content { get; set; }
    }
}
