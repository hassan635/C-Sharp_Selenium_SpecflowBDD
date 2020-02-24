using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecflowBDDFramework.Src.Helpers;

namespace SpecflowBDDFramework.Src.PageObjects
{
    public class FeeCalculationPage
    {

        private IWebDriver _driver = null;

        public FeeCalculationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GotoPage()
        {
            _driver.Navigate().GoToUrl("https://clicktime.symantec.com/3CEByFeAhiCPSrTHqX4D7LH7Vc?u=https%3A%2F%2Fwww.vicroads.vic.gov.au%2Fregistration%2Flimited-use-permits%2Funregistered-vehicle-permits%2Fget-an-unregistered-vehicle-permit");
        }

        public void SelectVehicleType(string option)
        {
            var vehicleListElement = _driver.FindElement(By.CssSelector("select[id*=\"VehicleType\"]"), 5);
            var vehicleSelectList = new SelectElement(vehicleListElement);

            vehicleSelectList.SelectByText(option);
        }

        public void SelectSubType(string option)
        {
            var vehicleListElement = _driver.FindElement(By.CssSelector("select[id*=\"SubType\"]"), 5);
            var vehicleSelectList = new SelectElement(vehicleListElement);

            vehicleSelectList.SelectByText(option);
        }

        public void InputGarageAddress(string address)
        {
            var inputField = _driver
                .FindElement(
                By.CssSelector("input[id*=\"AddressLine_SingleLine_CtrlHolderDivShown\"]"), 5);
            inputField.SendKeys(address);
            inputField.SendKeys(Keys.Tab);
        }

        public void SelectPermitDuration(string option)
        {
            var vehicleListElement = _driver.FindElement(By.CssSelector("select[id*=\"PermitDuration\"]"), 5);
            var vehicleSelectList = new SelectElement(vehicleListElement);

            vehicleSelectList.SelectByText(option);
        }

        public void ClickCalculateButton()
        {
            _driver.FindElement(By.CssSelector("a[id*=\"panel_btnCal\"]"), 5).Click();
        }

        public string GetFeeCalculation()
        {
            string result = string.Empty;
            while (result == string.Empty)
            {
                result = _driver.FindElement(By.CssSelector("span[id*=\"spnTotalPermit\"]"), 5).Text;
                System.Threading.Thread.Sleep(1);
            }

            return result;
        }

        public void GotoNextStep()
        {
            var nextStepBtn = _driver.FindElement(By.CssSelector("input[id*=\"btnNext\"]"), 10);

            var executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", nextStepBtn);
        }
    }
}
