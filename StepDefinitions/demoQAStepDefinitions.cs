using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using QA_Test_framework.Utilities;
using QA_Test_framework.ApplicationLibrary.FunctionalLibrary.ElementsPage;


namespace QA_Test_framework.StepDefinitions
{
    [Binding]
    internal class demoQAStepDefinitions
    {
        private RegistrationPage? registrationPage = null;
        private CheckBoxPage checkBoxPage;
        private ScenarioContext _scenarioContext;
        private CommonLinks commonLinks;
        private WebTablePage webTablePage;
        private ButtonPage buttonPage;
        private Dictionary<string, string> clickData;
        private UploadDownloadPage uploadDownloadPage;
        private IWebDriver driver;
        
        public demoQAStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = new ChromeDriver();
            commonLinks = new CommonLinks(driver);
            commonLinks.NavigateToUrl("elements");
            this.registrationPage = new RegistrationPage(driver);
            this.checkBoxPage = new CheckBoxPage(driver);
            commonLinks = new CommonLinks(driver);
            webTablePage = new WebTablePage(driver);
            buttonPage = new ButtonPage(driver);
            clickData = new Dictionary<string, string>();
            uploadDownloadPage = new UploadDownloadPage(driver);
        }

        
        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            driver.Dispose();
        }


        [Given(@"I click on the text-box Link")]
        public void GivenINavigateToTextBoxBoxLink()
        {
            commonLinks.TextBoxPage.Click();
        }


        [When(@"I fill in the following fields with example values:")]
        public void WhenIFillInTheFollowingFieldsWithExampleValues(Table table)
        {
            registrationPage.InitializeElements();
            var tableData = table.Rows.ToDictionary(row => row["Field"], row => row["Value"]);
            var fullName = tableData.ContainsKey("FullName") ? tableData["FullName"] : "";
            var email = tableData.ContainsKey("Email") ? tableData["Email"] : "";
            var currentAddress = tableData.ContainsKey("CurrentAddress") ? tableData["CurrentAddress"] : "";
            var permanentAddress = tableData.ContainsKey("PermanentAddress") ? tableData["PermanentAddress"] : "";
            registrationPage.FillRegistrationForm(fullName, email, currentAddress, permanentAddress);
        }

        [When(@"I submit the registration form")]
        public void WhenISubmitTheRegistrationForm()
        {
            registrationPage.SubmitRegistrationForm();
        }

        [Then(@"I should see the details displayed correctly on the confirmation page")]
        public void ThenIShouldSeeTheDetailsDisplayedCorrectlyOnTheConfirmationPage()
        {
            registrationPage.SeeTheDetails();
        }

        [Then(@"I verfiy details post submissions")]
        public void ThenIVerifyDetailsPostSubmission()
        {
            Assert.IsTrue(registrationPage.IsDetailsDisplayedCorrectly("Vinayak", "umadi@gmail.com", "Bangalore, City", "Banaglore, City"));
        }

        [Given(@"I click on the checkbox link")]
        public void GivenINavigateToCheckBoxLink()
        {
            commonLinks.CheckBoxPage.Click();
        }

        [When(@"I select the item")]
        public void WhenISelectTheItem()
        {
            checkBoxPage.checkAll();
        }

        [Then(@"I should see the selected items displayed correctly")]
        public void ThenIShouldSeeTheSelectedItemsDisplayedCorrectly()
        {
            checkBoxPage.GetAllChecboxCheckedItesm();
        }

        [Given(@"I click on the web link table link")]
        public void GivenIClickOnTheWebLinkTableLink()
        {
            commonLinks.WebTablePage.Click();
        }

        [When(@"I click on the edit button for record (.*)")]
        public void WhenIClickOnTheEditButtonForRecord(int p0)
        {
            webTablePage.ClickOnEditButton();
            Thread.Sleep(1000);
        }

        [When(@"I enter ""([^""]*)"" in the edit field")]
        public void WhenIEnterInTheEditField(string p0)
        {
            webTablePage.UpdateFirstName(p0);
            Thread.Sleep(1000);
        }

        [When(@"I click on the save button")]
        public void WhenIClickOnTheSaveButton()
        {
            webTablePage.ClickOnSaveButton();
        }

        [Given(@"Given I click on the button link")]
        public void GivenIAmOnTheWebPageWithTheButtons()
        {
            commonLinks.ButtonPage.Click();
        }


        [When("I perform a click on the button with the following details")]
        public void WhenIPerformAClickOnTheButton(Table table)
        {

            foreach (var row in table.Rows)
            {
                string clickType = row["clickType"];
                string expectedMessage = row["expectedMessage"];
                clickData.Add(clickType, expectedMessage);

                switch (clickType)
                {
                    case "doubleClick":
                        buttonPage.DoubleClickOnButton();
                        break;
                    case "rightClick":
                        buttonPage.RightClickOnButton();
                        break;
                    case "dynamicClick":
                        buttonPage.ClickOnButton();
                        break;
                }
            }
        }
        [Then("the corresponding messages should be displayed")]
        public void ThenTheCorrespondingMessagesShouldBeDisplayed()
        {

            Assert.IsTrue(buttonPage.CrossCheckDoubleClickMessage().Contains("double click"));
            Assert.IsTrue(buttonPage.CrossChecRightkMessage().Contains("right click"));
            Assert.IsTrue(buttonPage.CrossCheckClickMessage().Contains("dynamic click"));
        }


        [Given(@"Given I click on the upoload and download link")]
        public void GivenGivenIClickOnTheUpoloadAndDownloadLink()
        {
            commonLinks.UploadDownloadPage.Click();
        }

        [When(@"I download a file")]
        public void WhenIDownloadAFile()
        {
            uploadDownloadPage.Download();

        }

        [When(@"I upload the downloaded file")]
        public void WhenIUploadTheDownloadedFile()
        {
            uploadDownloadPage.upload();

        }

        [Then(@"the file should be uploaded successfully")]
        public void ThenTheFileShouldBeUploadedSuccessfully()
        {

        }
    }
}
