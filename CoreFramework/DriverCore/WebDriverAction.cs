using NUnit.Framework;
using OpenQA.Selenium;
using CoreFramework.Reporter;

namespace CoreFramework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void GoToURL(string url)
        {
            driver.Navigate().GoToUrl(url);
            HtmlReport.Pass("Go to Url: " + url);
        }
        public By ByXpath(string locator)
        {
            return By.XPath(locator);
        }
        public string getTitle()
        {
            string title = driver.Title;
            return title;
        }
        public string getText(string locator)
        {
            string e = FindElementByXpath(locator).Text;
            return e;
        }
        public bool IsElementDisplay(string locator)
        {
            try
            {
                FindElementByXpath(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public IWebElement FindElementByXpath(string locator)
        {
            try
            {
                IWebElement e = driver.FindElement(ByXpath(locator));
                TestContext.Write("\n Find element " + locator.ToString() + " passed");
                return e;

            }
            catch (Exception ex)
            {
                TestContext.Write("\n Cannot find element " + locator.ToString());
                throw ex;
            }
        }
        public IList<IWebElement> FindElementsByXpath(string locator)
        {
            return driver.FindElements(ByXpath(locator));
        }

        public IWebElement hightlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border='2px solid red'", element);
            return element;
        }

        public void Click(IWebElement e)
        {
            try
            {
                hightlightElement(e);
                e.Click();
                TestContext.Write("\n Click into element " + e.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("\n Click into element " + e.ToString() + " failed");
                throw ex;
            }
        }

        public void Click(String locator)
        {
            try
            {
                FindElementByXpath(locator).Click();
                TestContext.Write("\n Click into element " + locator + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("\n Click into element " + locator + " failed");
                throw ex;
            }
        }
        public void SendKeys(IWebElement e, string key)
        {
            try
            {
                e.SendKeys(key);
                TestContext.Write("\n SendKey into element " + e.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("\n SendKey into element " + e.ToString() + " failed");
                throw ex;
            }
        }

        public void SendKeys(String locator, string key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                TestContext.Write("\n SendKey into element " + locator + " passed");
            }
            catch (Exception ex)
            {
                TestContext.Write("\n SendKey into element " + locator + " failed");
                throw ex;
            }
        }

        // take screenshot if sendkey fail
        public string TakeScreenshot()
        {
            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }

        // capture screen
        public void CaptureScreen()
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(HtmlReportDirectory.SCREENSHOT_PATH + ("/capturescreen_" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png");
                TestContext.Write("\n Take screenshot successfully");
            }
            catch (Exception ex)
            {
                TestContext.Write("\n  Take screenshot failed");
                throw ex;
            }
        }

        // get title
        public void GetTitle()
        {
            try
            {
                string title = driver.Title;
                TestContext.Write("\n Get title successfully! Title of page is " + title);
            }
            catch (Exception ex)
            {
                TestContext.Write("\n Get title failed");
                throw ex;
            }
        }

        // verify text
        public void VerifyText(String locator, string keyword)
        {
            try
            {
                Assert.That(getText(locator), Is.EqualTo(keyword));
                TestContext.Write("\n Text in " + locator + " is " + keyword);
            }
            catch (Exception ex)
            {
                TestContext.Write("\n Text in " + locator + " is not " + keyword);
                throw ex;
            }
        }
    }
}