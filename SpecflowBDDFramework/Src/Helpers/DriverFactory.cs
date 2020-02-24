using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace SpecflowBDDFramework.Src.Helpers
{
    public static class DriverFactory
    {
        private static IWebDriver _driver = null;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                _driver = new FirefoxDriver();
            }

            return _driver;
        }

        public static void NukeDriver()
        {
            _driver.Quit();
        }
    }
}
