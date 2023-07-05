using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA_Test_framework.ApplicationLibrary.FunctionalLibrary.ElementsPage;
using QA_Test_framework.ApplicationLibrary.FunctionalLibrary.InteractionPages;
using QA_Test_framework.ApplicationLibrary.FunctionalLibrary.Widget;
using QA_Test_framework.Utilities;

namespace QA_Test_framework.StepDefinitions
{
    [Binding]
    internal class InteractionStepDefinitions
    {
        private IWebDriver driver;   
        private ScenarioContext _scenarioContext;
        private CommonLinks commonLinks;       
        private SortingPage sortingPage;
        public InteractionStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = new ChromeDriver();
            commonLinks = new CommonLinks(driver);
            commonLinks.NavigateToUrl("interaction");
            
            sortingPage=new SortingPage(driver);
        }

        [Given(@"I am on the sorting tips page")]
        public void GivenIAmOnTheSortingTipsPage()
        {
            commonLinks.ScrollDownforLinks();
            commonLinks.SortPage.Click();
        }      
        

        [Then(@"I drag and drop the div elements in descending order")]
        public void ThenIDragAndDropTheDivElementsInDescendingOrder()
        {
            sortingPage.ThenIDragAndDropTheDivElementsInDescendingOrder();
        }

        [Given(@"I am on the Drag and Drop page")]
        public void GivenIAmOnTheDroppablePage()
        {
            commonLinks.ScrollDownforLinks();
            commonLinks.DropPage.Click();
        }

        [When(@"I drag and drop the elements in descending order")]
        public void WhenIDragAndDropTheElementsInDescendingOrder()
        {
           
        }

        [Then(@"I should see the message ""([^""]*)""")]
        public void ThenIShouldSeeTheMessage(string p0)
        {
           
        }



        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
