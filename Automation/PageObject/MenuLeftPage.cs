using CoreFramework.DriverCore;
using OpenQA.Selenium;

namespace Automation.PageObject
{
    public class MenuLeftPage : WebDriverAction
    {
        public MenuLeftPage(IWebDriver driver) : base(driver)
        {
        }
        private string tfUserPage = "//*[text()='Manage User']//ancestor::li";
        private string tfAssetPage = "//*[text()='Manage Asset']//ancestor::li";
        private string tfAssignmentPage = "//*[text()='Manage Assignment']//ancestor::li";
        private string tfRequestPage = "//*[text()='Request returning']//ancestor::li";
        private string tfReportPage = "//*[text()='Report']//ancestor::li";

        public void GoToUserPage()
        {
            Click(tfUserPage);
        }

        public void GoToAssetPage()
        {
            Click(tfAssetPage);
        }
        public void GoToAssignmentPage()
        {
            Click(tfAssignmentPage);
        }
        public void GoToRequestPage()
        {
            Click(tfRequestPage);
        }    
    }
}
