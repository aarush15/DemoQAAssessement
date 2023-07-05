using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.Widget
{
    internal class DateTimePickerPage
    {
        private IWebDriver driver;

        public DateTimePickerPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WhenISelectTheDate()
        {
            IWebElement dateInput = driver.FindElement(By.Id("datePickerMonthYearInput"));
            dateInput.Click();
            Thread.Sleep(1000);
            IWebElement dateInput1 = driver.FindElement(By.XPath("//*[@id='datePickerMonthYear']/div[2]/div[2]/div/div/div[2]/div[2]/div[1]/div[1]"));
            dateInput1.Click();
            Thread.Sleep(5000);
        }

        internal void WhenISelectTheDateTime()
        {
            IWebElement dateInput = driver.FindElement(By.Id("dateAndTimePickerInput"));
            dateInput.Click();
            Thread.Sleep(1000);
            IWebElement dateInput1 = driver.FindElement(By.XPath("//*[@id='dateAndTimePicker']/div[2]/div[2]/div/div/div[3]/div[2]/div/ul/li[5]"));
            dateInput1.Click();
            Thread.Sleep(5000);
        }

        internal bool ThenTheSelectedDateShouldBeDisplayedCorrectly()
        {
            IWebElement dateInput = driver.FindElement(By.Id("datePickerMonthYearInput"));
            var value = dateInput.GetAttribute("value");
            if (value != null)
            {
                return true;
            }
            return false;

        }
        internal bool ThenTheSelectedDateTimeShouldBeDisplayedCorrectly()
        {
            IWebElement dateInput = driver.FindElement(By.Id("dateAndTimePickerInput"));
            var value = dateInput.GetAttribute("value");
            if (value != null)
            {
                return true;
            }
            return false;

        }
    }
}
