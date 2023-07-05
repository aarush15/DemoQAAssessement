using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Test_framework.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.ElementsPage
{
    internal class RegistrationPage
    {
        private IWebDriver driver;

        private IWebElement fullNameInput;
        private IWebElement emailInput;
        private IWebElement currentAddressInput;
        private IWebElement permanentAddressInput;
        private IWebElement submitButton;

        private string getNameDetail;
        private string getemailDetail;
        private string getcurrentAddressDetail;
        private string getpermanentAddress;
        WaitUtilities waitUtilities;


        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            waitUtilities = new WaitUtilities(this.driver);
        }

        internal void InitializeElements()
        {

            fullNameInput = driver.FindElement(By.Id("userName"));
            emailInput = driver.FindElement(By.Id("userEmail"));
            currentAddressInput = driver.FindElement(By.Id("currentAddress"));
            permanentAddressInput = driver.FindElement(By.Id("permanentAddress"));
            submitButton = driver.FindElement(By.Id("submit"));
        }

        internal void FillRegistrationForm(string fullName, string email, string currentAddress, string permanentAddress)
        {
            
            fullNameInput.Clear();
            fullNameInput.SendKeys(fullName);

            emailInput.Clear();
            emailInput.SendKeys(email);           

            currentAddressInput.Clear();
            currentAddressInput.SendKeys(currentAddress);           

            permanentAddressInput.Clear();
            permanentAddressInput.SendKeys(permanentAddress);

        }       
        internal void SubmitRegistrationForm()
        {
            submitButton.Click();
        }

        internal void SeeTheDetails()
        {
            getNameDetail = waitUtilities.WaitForElementToBePresent(driver,By.XPath("//*[@id='name']")).Split(":")[1].Trim();            
            getemailDetail = waitUtilities.WaitForElementToBePresent(driver,By.XPath("//*[@id='email']")).Split(":")[1].Trim();
            getcurrentAddressDetail = waitUtilities.WaitForElementToBePresent(driver,By.XPath("//p[@id='currentAddress']")).Split(":")[1].Trim();
            getpermanentAddress = waitUtilities.WaitForElementToBePresent(driver,By.XPath("//p[@id='permanentAddress']")).Split(":")[1].Trim();

        }

        internal void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url+ "text-box");
        }

        public bool IsDetailsDisplayedCorrectly(string expectedFullName, string expectedEmail, string expectedCurrentAddress, string expectedPermanentAddress)
        {
            if (getNameDetail != expectedFullName)
            {
                return false;
            }
            else if (getemailDetail != expectedEmail)
            {
                return false;
            }
            else if (getcurrentAddressDetail != expectedCurrentAddress)
            {
                return false;
            }
            else if (getpermanentAddress != expectedPermanentAddress)
            {
                return false;
            }
            return true;
        }          
    }
}
