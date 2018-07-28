using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CCITU.Common
{
    class WebUtils
    {
        public class HttpPacket
        {
            public string RequestUrl
            {
                get;
                set;
            }

            //public NameValueCollection RequestHeaders
            //{
            //    get;
            //    set;
            //}

            //public byte[] RequestData
            //{
            //    get;
            //    set;
            //}

            public NameValueCollection ResponseHeaders
            {
                get;
                set;
            }

            public string ResponseBody
            {
                get;
                set;
            }
        }

        public static HttpPacket DoPost(string url, string data)
        {
            WebClient client = new WebClient();
            string responseStr = client.UploadString(url, data);

            HttpPacket packet = new HttpPacket();
            packet.RequestUrl = url;
            packet.ResponseBody = responseStr;
            packet.ResponseHeaders = client.ResponseHeaders;
            return packet;
        }

        private HttpPacket DoGet(string url)
        {
            WebClient client = new WebClient();

            string responseStr = client.DownloadString(url);
            HttpPacket packet = new HttpPacket();
            packet.RequestUrl = url;
            packet.ResponseBody = responseStr;
            packet.ResponseHeaders = client.ResponseHeaders;
            return packet;
        }
    }
}
