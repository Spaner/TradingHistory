﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingHistory.Helpers.Enums;

namespace TradingHistory.Helpers.Attributes
{
    public class RequestPathAttribute : Attribute
    {
        /// <summary>
        /// Request path attribute.
        /// </summary>
        /// <param name="path">Path and query parameters with placeholders for parameters</param>
        /// <param name="method">HTTP Request Method</param>
        public RequestPathAttribute(string path, HttpRequestMethod method)
        {
            Path = path;
        }
        public string Path { get; }
    }
}
