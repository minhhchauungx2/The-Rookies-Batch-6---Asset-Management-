using OpenQA.Selenium;
using CoreFramework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace Automation.PageObject
{
    public class LoginPage : WebDriverAction
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private String tfUsername = "//input[@placeholder='Username']";
        private String tfPassword = "//input[@placeholder='Password']";
        private String tfUserIcon = "//*[@data-icon='user']";
        private String tfLockIcon = "//*[@data-icon='lock']";
        private String tfEyeIcon = "//*[@data-icon='eye-invisible']";
        private String tfSubmitBtn = "//button/span[text()='Log in']";

        public bool IsLoginPageDisplayed()
        {
            if (IsElementDisplay("//h1[text()='Login']")
                && IsElementDisplay(tfUsername)
                && IsElementDisplay(tfPassword)
                && IsElementDisplay(tfUserIcon)
                && IsElementDisplay(tfLockIcon)
                && IsElementDisplay(tfEyeIcon)
                && IsElementDisplay(tfSubmitBtn))
            {
                TestContext.WriteLine("\n Login Page is displayed!");
                return true;
            }
            else
            {
                TestContext.WriteLine("\n Login Page is not displayed!");
                return false;
            }
        }
        public void DoLogin(string Username, string Password)
        {
            SendKeys(tfUsername, Username);
            SendKeys(tfPassword, Password);
            Click(tfEyeIcon);
            Click(tfSubmitBtn);
        }
    }
}



