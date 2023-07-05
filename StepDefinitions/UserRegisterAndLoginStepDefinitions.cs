using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Test_framework.ApplicationLibrary.FunctionalLibrary.InteractionPages;
using QA_Test_framework.ApplicationLibrary.FunctionalLibrary.UserRegistrationAndLogin;
using QA_Test_framework.Utilities;

namespace QA_Test_framework.StepDefinitions
{
    [Binding]
    internal class UserRegisterAndLoginStepDefinitions
    {
        private IWebDriver driver;
        private ScenarioContext _scenarioContext;
        private CommonLinks commonLinks;
        private UserRegAndLoginPage userRegAndLogin;

        public UserRegisterAndLoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = new ChromeDriver();
            commonLinks = new CommonLinks(driver);
            commonLinks.NavigateToUrl("books");
            userRegAndLogin = new UserRegAndLoginPage(driver);
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheRegistrationPage()
        {
            commonLinks.ScrollDownforLinks();
            commonLinks.RegPage.Click();
        }

        [When(@"I click on the new user button")]
        public void ThenIClickTheNewUserButton()
        {
            userRegAndLogin.WhenIClickNewUserButton();
        }


        [When(@"I enter the following details:")]
        public void WhenIEnterTheFollowingDetails(Table table)
        {
            var registrationData = table.Rows.ToDictionary(row => row["Field"], row => row["Value"]);
            string firstName = registrationData["First Name"];
            string lastName = registrationData["Last Name"];
            string username = registrationData["Username"];
            string password = registrationData["Password"];
            userRegAndLogin.WhenIEnterTheFollowingDetails(firstName, lastName, username, password);

        }

        [Then(@"I click on the new user button")]
        public void ThenIClickTheRegisterButton()
        {
            userRegAndLogin.WhenIClickTheRegisterButton();
        }

        

        [When(@"I click the Register button")]
        public void WhenIClickTheRegisterButton()
        {
            userRegAndLogin.WhenIClickTheRegisterButton();
        }

        [Then(@"I should see a success message")]
        public void ThenIShouldSeeASuccessMessage()
        {
            Assert.IsTrue(userRegAndLogin.ThenIShouldSeeASuccessMessage());
        }
        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            driver.Dispose();
        }

    }
}
