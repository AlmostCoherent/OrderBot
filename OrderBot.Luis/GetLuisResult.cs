using OrderBot.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrderBot.Luis
{
    [Serializable]
    public class GetLuisResult : IGetLuisResult
    {
        private static string _subscriptionKey;

        public string GetLuisIntent(string userStringQuery, string uri, string subscriptionKey)
        {
            _subscriptionKey = subscriptionKey;

            System.Collections.Specialized.NameValueCollection queryString = GetLuisQueryString(userStringQuery);

            string jsonResponse = GetHttpResponse.GetJsonResponse(uri, queryString);

            return jsonResponse;
        }

        private static System.Collections.Specialized.NameValueCollection GetLuisQueryString(string userStringQuery)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["q"] = HttpUtility.UrlEncode(userStringQuery);
            queryString["subscription-key"] = _subscriptionKey;
            queryString["timezoneOffset"] = "0";
            queryString["verbose"] = "false";
            queryString["spellCheck"] = "false";
            queryString["staging"] = "false";
            return queryString;
        }
    }
}
