using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;

namespace CoreFramework.APICore
{
    public class APIResponse : APIRequest
    {
        public HttpWebResponse response;
        public HttpWebResponse httpResponse;

        public string responseBody { get; set; }
        public string responseStatusCode { get; set; }

        public APIResponse(HttpWebResponse response, string responseBody, string responeStatusCode)
        {
            this.response = response;
            GetResponseBody();
            GetResponseStatusCode();
        }

        public APIResponse(HttpWebResponse httpResponse)
        {
            this.httpResponse = httpResponse;
        }

        private string GetResponseBody()
        {
            responseBody = "";
            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        responseBody = reader.ReadToEnd();
                    }
                return responseBody;
            }
        }
        private string GetResponseStatusCode()
        {
            try
            {
                HttpStatusCode statusCode = ((HttpWebResponse)response).StatusCode;
                responseStatusCode = statusCode.ToString();
            }
            catch (WebException we)
            {
                responseStatusCode = ((HttpWebResponse)we.Response).StatusCode.ToString();
            }
            return responseStatusCode;
        }
    }
}
