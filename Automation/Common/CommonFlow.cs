using Automation.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Automation.Common
{
    public class CommonFlow
    {
        public static string RdFirstname()
        {
            string rdString = Path.GetRandomFileName();
            rdString = rdString.Replace(".", "");
            TestContext.WriteLine("Random firstname: " + rdString);
            return rdString;
        }
        public void Login(IWebDriver _driver, string username, string password)
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.DoLogin(username, password);
        }
    }
}
