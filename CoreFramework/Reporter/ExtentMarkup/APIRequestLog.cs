using AventStack.ExtentReports.MarkupUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.APICore;

namespace CoreFramework.Reporter.ExtentMarkup
{
    internal class APIRequestLog : IMarkup
    {
        private APIRequest request { get; set; }
        private APIResponse response { get; set; }
        public APIRequestLog(APIRequest request, APIResponse response)
        {
            this.request = request;
            this.response = response;
        }
        public string GetMarkup()
        {
            string log = $@" 
                <p>Request url: {{request.url}}</p>
                <p>Response body: {{response.responseBody}}</p>
                <p>Response status: {{response.responseStatusCode}}</p>
            ";
            return log;
        }    
    }
}
