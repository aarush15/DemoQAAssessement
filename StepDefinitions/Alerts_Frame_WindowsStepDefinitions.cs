using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Test_framework.ApplicationLibrary.FunctionalLibrary.AlertPages;
using QA_Test_framework.ApplicationLibrary.FunctionalLibrary.ElementsPage;
using QA_Test_framework.Utilities;

namespace QA_Test_framework.StepDefinitions
{
    [Binding]
    internal class Alerts_Frame_WindowsStepDefinitions
    {
        private IWebDriver driver;
        private ScenarioContext _scenarioContext;
        private AlertPage alertPage;
        private WindowPage windowPage;
        private CommonLinks commonLinks;
        public Alerts_Frame_WindowsStepDefinitions(ScenarioContext scenarioContext)
        {
            driver = new ChromeDriver();
            commonLinks = new CommonLinks(driver);
            commonLinks.NavigateToUrl("alertsWindows");
            alertPage = new AlertPage(driver);
            windowPage=new WindowPage(driver);
        }
       
        [Given(@"I click on the Alert link")]
        public void GivenINavigateToAlertLink()
        {
            commonLinks.AlertsPage.Click();
        }

        [When(@"I click on the button")]
        public void WhenIClickOnTheButton()
        {
            alertPage.ClickButton_1();
        }
        [When(@"I click on the after 5sec button")]
        public void WhenIClickOnTheAfter5SecButton()
        {
            alertPage.ClickButtonAfter5Sec();
        }

        [When(@"I click on the confirm box button")]
        public void WhenIClickOnTheConfirmButton()
        {
            alertPage.ClickOnConfirmButton();
        }

        [When(@"I click on the prompt box button")]
        public void WhenIClickOnThePromptButton()
        {
            alertPage.ClickOnPromtButtonButton();
        }

        [Then(@"the alert box should appear")]
        public void ThenTheAlertBoxShouldAppear()
        {
            Assert.IsTrue(alertPage.AlertIsPresentAfterButtonClick(), "Alert box did not appear");
        }

        [Then(@"click the button in alert box")]
        public void ThenClickTheButtonInAlertBox()
        {
            Assert.IsTrue(alertPage.ThenClickTheButtonInAlertBox(), "Alert box did not appear");
        }


        [Given(@"I click on the Window link")]
        public void GivenIAmOnTheHomePage()
        {
            commonLinks.WindowPage.Click();
        }

        [When(@"I click on the New tab button")]
        public void WhenIClickOnNewTabButton()
        {
            windowPage.WhenIClickOnTheButton();
        }

        [Then(@"a new tab should be opened")]
        public void ThenANewTabShouldBeOpened()
        {
            Assert.IsTrue(windowPage.ThenANewTabShouldBeOpened());
        }

        [Then(@"I go back to the home page")]
        public void WhenIGoBackToTheHomePage()
        {
            Assert.IsTrue(windowPage.WhenIGoBackToTheHomePage());
        }

        [When(@"I click on the New Window button")]
        public void WhenIClickOnNewWindowButton()
        {
            windowPage.WhenIClickOnNewWindowTheButton();
        }

        [Then(@"a new window should be opened")]
        public void ThenANewWindowShouldBeOpened()
        {
            Assert.IsTrue(windowPage.ThenANewWindowShouldBeOpened());
        }

        [When(@"I click on the New Window 2 button")]
        public void WhenIClickOnNewWindowWithMessageButton()
        {
            windowPage.WhenIClickOnNewWindowWithMessageTheButton();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}
