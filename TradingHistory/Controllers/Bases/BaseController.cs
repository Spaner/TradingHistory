using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TradingHistory.Helpers.Enums;
using TradingHistory.Helpers.Extensions;
using TradingHistory.Models;

namespace TradingHistory.Controllers.Bases
{
    public class BaseController
    {

        /// <summary>
        /// Calls an URI and fetches the response.
        /// </summary>
        /// <typeparam name="T">Class to deserialize the response into</typeparam>
        /// <param name="uri">URI to</param>
        /// <returns>A response package with the fetched content</returns>
        public async Task<ResponsePackage<T>> GetAsync<T>(Uri uri) where T : class
        {
            var client = new HttpClient();
            var response = new ResponsePackage<T>();
            using (var result = await client.GetAsync(uri))
            {
                if (result?.IsSuccessStatusCode ?? false)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var deserialized = content.Deserialize<T>();
                    response = new ResponsePackage<T>(deserialized);
                }
            }
            return response;
        }

        /// <summary>
        /// Builds an URI based on the base url, path and query parameters. Takes optional parameters
        /// to replace placeholders in the request path.
        /// </summary>
        /// <param name="requestType">Request type with path and query parameters</param>
        /// <param name="args">Parameters to replace placeholders in the request type</param>
        /// <returns></returns>
        public Uri GetServerUri(RequestType requestType, params object[] args)
        {
            var uri = GetServerUri(Settings.BaseURL, requestType, args);
            return uri;
        }

        /// <summary>
        /// Builds an URI based on the base url, path and query parameters. Takes optional parameters
        /// to replace placeholders in the request path.
        /// </summary>
        /// <param name="serviceAddress">The base url address</param>
        /// <param name="requestType">Request type with path and query parameters</param>
        /// <param name="args">Parameters to replace placeholders in the request type</param>
        /// <returns>The build URI</returns>
        private Uri GetServerUri(string serviceAddress, RequestType requestType, params object[] args)
        {
            var baseAddress = serviceAddress ?? "/";
            var separator = string.Empty;
            if (baseAddress.Last() != '/')
            {
                separator = "/";
            }

            var requestPath = requestType.RequestPath(args);
            var serverUrl = string.Format("{0}{1}{2}", baseAddress, separator, requestPath);
            var uri = new Uri(serverUrl);
            return uri;
        }
    }
}
