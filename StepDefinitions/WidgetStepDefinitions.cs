using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Test_framework.ApplicationLibrary.FunctionalLibrary.InteractionPages;
using QA_Test_framework.ApplicationLibrary.FunctionalLibrary.Widget;
using QA_Test_framework.Utilities;
using TechTalk.SpecFlow;

namespace QA_Test_framework.StepDefinitions
{

    [Binding]
    internal class WidgetStepDefinitions
    {
        private IWebDriver driver;
        private ScenarioContext _scenarioContext;
        private CommonLinks commonLinks;
        private DateTimePickerPage interactionPage;
        private TooltipPage tooltipPage;

        public WidgetStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = new ChromeDriver();
            commonLinks = new CommonLinks(driver);
            commonLinks.NavigateToUrl("widgets");
            interactionPage = new DateTimePickerPage(driver);
            tooltipPage = new TooltipPage(driver);           
        }
        [Given(@"I am on the date and time page")]
        public void GivenIAmOnTheHomePage()
        {
            commonLinks.DateTimePage.Click();
        }

        [When("I select the date")]
        public void WhenISelectTheDate()
        {
            interactionPage.WhenISelectTheDate();
        }

        [When("I select the date and time")]
        public void WhenISelectTheDateTime()
        {
            interactionPage.WhenISelectTheDateTime();
        }

        [Then("check date populated in date field")]
        public void ThenTheSelectedDateShouldBeDisplayedCorrectly()
        {
            Assert.IsTrue(interactionPage.ThenTheSelectedDateShouldBeDisplayedCorrectly());
        }
        [Then("check date populated in datetime field")]
        public void ThenTheSelectedDateTimeShouldBeDisplayedCorrectly()
        {
            Assert.IsTrue(interactionPage.ThenTheSelectedDateTimeShouldBeDisplayedCorrectly());
        }

        [Given(@"I am on the toool tips page")]
        public void GivenIAmOnTheTooolTipsPage()
        {
            commonLinks.ScrollDownforLinks();
            commonLinks.ToolTipPage.Click();
        }

        [When(@"I hover over the highlighted items")]
        public void WhenIHoverOverTheHighlightedItems()
        {
            tooltipPage.WhenIHoverOverTheHighlightedItems();
        }

        [Then(@"the tooltip content should be displayed correctly")]
        public void ThenTheTooltipContentShouldBeDisplayedCorrectly()
        {
            Assert.IsTrue(tooltipPage.ThenTheTooltipContentShouldBeDisplayedCorrectly());
        }
        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
