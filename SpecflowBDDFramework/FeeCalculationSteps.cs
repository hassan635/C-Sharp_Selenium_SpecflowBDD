using System;
using Newtonsoft.Json;
using NUnit.Framework;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
//using log4net;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using SpecflowBDDFramework.Src.Helpers;
using SpecflowBDDFramework.Src.PageObjects;


using TechTalk.SpecFlow;

namespace SpecflowBDDFramework
{
    [Binding]
    public class FeeCalculationSteps
    {
        FeeCalculationPage feeCalculationPage = null;

        [Given(@"I am on the unregistered car permit fee page")]
        public void GivenIAmOnTheUnregisteredCarPermitFeePage()
        {
            feeCalculationPage = new FeeCalculationPage(DriverFactory.GetDriver());
            feeCalculationPage.GotoPage();
        }

        [Given(@"I have entered my vehical type")]
        public void GivenIHaveEnteredMyVehicalType()
        {
            feeCalculationPage.SelectVehicleType(TestDataProvider.GetTestInputValue("$..vehicle_type"));
        }

        [Given(@"I have entered my sub type")]
        public void GivenIHaveEnteredMySubType()
        {
            feeCalculationPage.SelectSubType(TestDataProvider.GetTestInputValue("$..sub_type"));
        }

        [Given(@"I have entered my garage location")]
        public void GivenIHaveEnteredMyGarageLocation()
        {

            feeCalculationPage.InputGarageAddress(TestDataProvider.GetTestInputValue("$..garage_address"));
        }


        [Given(@"I have entered my desired permit duration")]
        public void GivenIHaveEnteredMyDesiredPermitDuration()
        {

            feeCalculationPage.SelectPermitDuration(TestDataProvider.GetTestInputValue("$..desired_permit_duration"));
        }


        [When(@"I choose to calculate")]
        public void WhenIChooseToCalculate()
        {
            feeCalculationPage.ClickCalculateButton();
        }

        [Then(@"the result should be displayed")]
        public void TheResultShouldBeDisplayed()
        {
            Assert.AreEqual("$45.00", feeCalculationPage.GetFeeCalculation());
        }


        [Then(@"I should be taken to permit type selection page")]
        public void TakenToPermitSelectionPage()
        {
            feeCalculationPage.GotoNextStep();
            DriverFactory.NukeDriver();
        }
        
    }
}
