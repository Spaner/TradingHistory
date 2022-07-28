using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingHistory.Helpers.Attributes;

namespace TradingHistory.Helpers.Extensions
{
    public static class RequestPathAttributeExtension
    {
        /// <summary>
        /// Gets the values from a RequestPathAttribute and builds the path and query parameters by
        /// replacing the placeholders with the given parameters
        /// </summary>
        /// <param name="e">Name of RequestType</param>
        /// <param name="args">Parameters to be replaced in path placeholders</param>
        /// <returns>Build request path</returns>
        public static string RequestPath(this Enum e, object[] args)
        {
            var result = string.Empty;
            var type = e.GetType();
            var members = type.GetMember(e.ToString());
            if (members.Length == 1)
            {
                var attrs = members[0].GetCustomAttributes(typeof(RequestPathAttribute), false);
                if (attrs.Length == 1)
                {
                    result = ((RequestPathAttribute)attrs[0]).Path;
                }
            }

            if (args.Length > 0)
            {
                result = string.Format(result, args);
            }

            return result;
        }
    }
}
