using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.ElementsPage
{
    internal class CheckBoxPage
    {
        private IWebDriver driver;

        public CheckBoxPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal void checkAll()
        {
            IWebElement checkboxElement = driver.FindElement(By.XPath("//span[@class='rct-checkbox']"));
            checkboxElement.Click();
        }

        internal void GetAllChecboxCheckedItesm()
        { 
            //IList<IWebElement> checkedItems = driver.FindElements(By.XPath("//input[@type='checkbox' and @checked='checked']")); 
            //IList<IWebElement> checkedItems = driver.FindElements(By.XPath("//span[contains(@class, 'rct-icon rct-icon-check') and not(contains(@class, 'rct-icon rct-icon-uncheck'))]"));

        }
    }
}
