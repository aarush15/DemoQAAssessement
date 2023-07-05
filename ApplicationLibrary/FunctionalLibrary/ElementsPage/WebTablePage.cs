using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.ElementsPage
{
    internal class WebTablePage
    {
        private IWebDriver driver;

        public WebTablePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void ClickOnEditButton()
        {
            IWebElement editButton = driver.FindElement(By.XPath("//span[@id='edit-record-1']"));
            editButton.Click();
        }

        internal void UpdateFirstName(string value)
        {
            IWebElement textbox = driver.FindElement(By.XPath("//input[@id='firstName']"));
            textbox.Clear();
            textbox.SendKeys(value);
            Thread.Sleep(1000);
        }

        internal void ClickOnSaveButton()
        {
            IWebElement savebutton = driver.FindElement(By.XPath("//button[@id='submit']"));
            savebutton.Click();
        }
    }
}
