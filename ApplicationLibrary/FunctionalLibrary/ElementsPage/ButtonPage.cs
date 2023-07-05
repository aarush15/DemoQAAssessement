using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.ElementsPage
{
    internal class ButtonPage
    {
        private IWebDriver driver;

        public ButtonPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal string CrossCheckDoubleClickMessage()
        {
            IWebElement message = driver.FindElement(By.XPath("//p[@id='doubleClickMessage']"));
            return message.Text;
        }
        internal string CrossChecRightkMessage()
        {
            IWebElement message1 = driver.FindElement(By.XPath("//p[@id='rightClickMessage']"));
            return message1.Text; ;
        }

        internal string CrossCheckClickMessage()
        {
            IWebElement message2 = driver.FindElement(By.XPath("//p[@id='dynamicClickMessage']"));
            return message2.Text;
        }

        internal void DoubleClickOnButton()
        {
            IWebElement button = driver.FindElement(By.Id("doubleClickBtn"));
            Actions actions = new Actions(driver);
            actions.DoubleClick(button).Perform();
        }

        internal void RightClickOnButton()
        {
            IWebElement button = driver.FindElement(By.Id("rightClickBtn"));
            Actions actions = new Actions(driver);
            actions.ContextClick(button).Perform();
        }

        internal void ClickOnButton()
        {
            IWebElement button = driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[2]/div[2]/div[3]/button"));
            Actions actions = new Actions(driver);
            actions.Click(button).Perform();
        }
    }
}
