using System;
using System.Threading;
using OpenQA.Selenium;

namespace CoreFramework.DriverCore
{
    internal class WebDriverManager
    {
        private static AsyncLocal<IWebDriver> driver = new AsyncLocal<IWebDriver>();

        public static void InitDriver(String Browser, Int32 Width, Int32 Height)
        {
            IWebDriver newDriver = null;
            newDriver = WebDriverCreator.CreateLocalDriver(Browser, Width, Height);

            if (newDriver == null)
                throw new Exception($"{Browser} browser is not supported");
            driver.Value = newDriver;
        }

        public static IWebDriver GetCurrentDriver()
        {
            return driver.Value;
        }

        public static void CloseDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
            }
        }
    }
} 
