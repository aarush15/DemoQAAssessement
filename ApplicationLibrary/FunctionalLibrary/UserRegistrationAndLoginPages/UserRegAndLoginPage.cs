using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Test_framework.Utilities;
using SeleniumExtras.WaitHelpers;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.UserRegistrationAndLogin
{
  
    internal class UserRegAndLoginPage
    {
        private IWebDriver driver;
        WaitUtilities waitUtilities;

        public UserRegAndLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            waitUtilities = new WaitUtilities(this.driver);
        }
        public void WhenIEnterTheFollowingDetails(string firstName, string lastName, string username, string password)
        {
            driver.FindElement(By.XPath("//*[@id='firstname']")).SendKeys(firstName);
            driver.FindElement(By.XPath("//*[@id='lastname']")).SendKeys(lastName);
            driver.FindElement(By.XPath("//*[@id='userName']")).SendKeys(username);
            driver.FindElement(By.XPath("//*[@id='password']")).SendKeys(password);            
        }
        public void WhenIClickTheRegisterButton()
        {
            // Code to click the Register button
            driver.FindElement(By.Id("register")).Click();
        }

        public void WhenIClickNewUserButton()
        {
            // Code to click the Register button
            driver.FindElement(By.Id("newUser")).Click();
        }

        public bool ThenIShouldSeeASuccessMessage()
        {
            // Code to validate the success message
            if (waitUtilities.AlertIsPresent())
            {
                return true;
            }
            return false;
        }
    }
}
