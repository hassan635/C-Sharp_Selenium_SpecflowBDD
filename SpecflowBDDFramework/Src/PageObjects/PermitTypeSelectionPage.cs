using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowBDDFramework.Src.Helpers;

namespace SpecflowBDDFramework.Src.PageObjects
{
    public class PermitTypeSelectionPage
    {

        private IWebDriver _driver = null;

        public PermitTypeSelectionPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GotoPage()
        {
            _driver.Navigate().GoToUrl("https://clicktime.symantec.com/3CEByFeAhiCPSrTHqX4D7LH7Vc?u=https%3A%2F%2Fwww.vicroads.vic.gov.au%2Fregistration%2Flimited-use-permits%2Funregistered-vehicle-permits%2Fget-an-unregistered-vehicle-permit");
        }

        public void SelectPermitTypeOption(int optionNumber)
        {
            IWebElement permitTypeOption = _driver.FindElement(By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_PermitTypesRadio_RadioButtonList_" + (optionNumber -1).ToString()), 5); ;
            permitTypeOption.Click();
        }

        public void GotoNextStep()
        {
            var nextStepBtn = _driver.FindElement(By.CssSelector("input[id*=\"btnNext\"]"), 10);

            var executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", nextStepBtn);
        }

        public void InputFromTo(string from, string to)
        {
            var fromField = _driver
                .FindElement(
                By.CssSelector("input[id*=\"From_SuburbText\"]"), 5);

            fromField.SendKeys(from);
            fromField.SendKeys(Keys.Tab);

            var toField = _driver
                .FindElement(
                By.CssSelector("input[id*=\"To_SuburbText\"]"), 5);

            toField.SendKeys(to);
            toField.SendKeys(Keys.Tab);
        }
    }
}
