using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using QA_Test_framework.Utilities;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.AlertPages
{
    internal class WindowPage
    {
        private IWebDriver driver;
        private IWebElement submitButton;
        WaitUtilities waitUtilities;
        private string mainWindowHandle;
        private string newTabWindowHandle;
        private string newWindowHandle;

        public WindowPage(IWebDriver driver)
        {
            this.driver = driver;
            waitUtilities = new WaitUtilities(this.driver);
        }
        public void WhenIClickOnTheButton()
        {
            IWebElement button = driver.FindElement(By.XPath("//*[@id='tabButton']"));
            button.Click();
        }
        public void WhenIClickOnNewWindowTheButton()
        {
            IWebElement button = driver.FindElement(By.XPath("//*[@id='windowButton']"));
            button.Click();
        }
        public void WhenIClickOnNewWindowWithMessageTheButton()
        {
            IWebElement button = driver.FindElement(By.XPath("//*[@id='messageWindowButton']"));
            button.Click();
        }
        public bool ThenANewTabShouldBeOpened()
        {
            mainWindowHandle = driver.CurrentWindowHandle;
            foreach (string handle in driver.WindowHandles)
            {
                if (handle != mainWindowHandle)
                {
                    newTabWindowHandle = handle;
                    return true;                    
                }
            }
            return false;
        }
        public void WhenISwitchToTheNewTab()
        {
            driver.SwitchTo().Window(newTabWindowHandle);
        }
        public void ThenIShouldSeeTheMessage(string expectedMessage)
        {
            IWebElement messageElement = driver.FindElement(By.XPath($"//p[contains(text(), '{expectedMessage}')]"));
            // Perform your assertions or verifications on the messageElement
        }
        public bool WhenIGoBackToTheHomePage()
        {
            driver.SwitchTo().Window(mainWindowHandle);
            return true;
        }

        public bool ThenANewWindowShouldBeOpened()
        {
            foreach (string handle in driver.WindowHandles)
            {
                if (handle != mainWindowHandle && handle != newTabWindowHandle)
                {
                    newWindowHandle = handle;
                    return true;
                }
            }
            return false;
        }
       
    }
}
