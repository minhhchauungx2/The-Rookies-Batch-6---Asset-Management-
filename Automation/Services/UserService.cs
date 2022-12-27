using Automation.TestSetUp;
using CoreFramework.APICore;
using NUnit.Framework;

namespace Automation.Services
{
    public class UserService
    {
        public string registerPath = "/user-management/register";
        public APIResponse RegisterAccount(string role)
        {
            TestContext.WriteLine(ConstantSetUp.API_URL + registerPath);
            APIResponse response = (APIResponse)new APIRequest()
                .SetUrl(ConstantSetUp.API_URL + registerPath)
                .AddHeader("Content-Type", "application/json")
                .SetBody("{\r\n  \"firstName\": \"Name\",\r\n  \"lastName\": \"Nguyen\",\r\n  \"gender\": 0," +
                          "\r\n \"dateOfBirth\": \"2001-12-07\",\r\n  \"joinedDate\": \"2019-11-01\",\r\n \"typeStaff\": \"string\", " +
                          "\r\n  \"userRole\"" + role + "\", \r\n  \"location\": \"Hanoi\"\r\n}")
                .Post();
            return response;
        }
    }
}
