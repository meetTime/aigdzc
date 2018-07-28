using CCITU.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Victory.Dao;

namespace Api
{
    public class ApiHelper
    {
        public static HttpResponseMessage CreateHttpResponseMessage(object obj = null)
        {
            ActionResponse ar = CreateActionResponse(obj);

            string jsonString = ToJsonString(ar);

            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK);
            message.Content = new StringContent(jsonString);

            return message;
        }


        private static ActionResponse CreateActionResponse(object obj = null)
        {
            ActionResponse ar = obj as ActionResponse;
            if (ar != null)
            {
                return ar;
            }

            var pager = obj as IPagerModelCollection;
            if (pager != null)
            {
                return ActionResponse.CreateSuccessResponse(pager, pager.TotalRecord);
            }
            return ActionResponse.CreateSuccessResponse(obj);
        }


        public static string ToJsonString(object obj)
        {
            JsonSerializerSettings set = new JsonSerializerSettings();
            set.DateFormatString = ConfigurationManager.AppSettings["DateTimeFormat"];

            string data = JsonConvert.SerializeObject(obj, Formatting.Indented, set);
            return data;
        }

        public static string GetClientIpAddress(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }

            return null;
        }

        public static string GetRequestHeaderValue(HttpRequestMessage request, string headerKey)
        {
            IEnumerable<string> values;
            if (request.Headers.TryGetValues(headerKey, out values))
            {
                return values.First();
            }

            return null;
        }
    }
}