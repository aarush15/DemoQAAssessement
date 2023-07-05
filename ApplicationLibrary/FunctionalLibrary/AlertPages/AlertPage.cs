using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using QA_Test_framework.Utilities;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.AlertPages
{
    internal class AlertPage
    {
        private IWebDriver driver;
        private IWebElement submitButton;
        WaitUtilities waitUtilities;

        public AlertPage(IWebDriver driver)
        {
            this.driver = driver;
            waitUtilities=new WaitUtilities(this.driver);
        }

        public void ClickButton_1()
        {
            //button[@id='alertButton']
            var submitButton = driver.FindElement(By.XPath("//button[@id='alertButton']"));
            submitButton.Click();
        }

        public bool AlertIsPresentAfterButtonClick()
        {
            if (waitUtilities.AlertIsPresent())
            {
              return true;
            }
            return false;
        }
        public bool ThenClickTheButtonInAlertBox()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            return true;
        }

        public void ClickButtonAfter5Sec()
        {
            //button[@id='alertButton']
            var submitButton = driver.FindElement(By.XPath("//*[@id='timerAlertButton']"));
            submitButton.Click();
        }

        public void ClickOnConfirmButton()
        {
            //button[@id='alertButton']
            var submitButton = driver.FindElement(By.XPath("//*[@id='confirmButton']"));
            submitButton.Click();
        }

        public void ClickOnPromtButtonButton()
        {
            //button[@id='alertButton']
            var submitButton = driver.FindElement(By.XPath("//*[@id='confirmButton']"));
            submitButton.Click();
        }
    }
}
