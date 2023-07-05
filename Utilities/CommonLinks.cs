using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Security.Policy;
using Newtonsoft.Json.Linq;

namespace QA_Test_framework.Utilities
{
    public class CommonLinks
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private JObject config;
        WaitUtilities waitUtilities;
        public CommonLinks(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            string jsonContent = System.IO.File.ReadAllText("specflow.json");
            config = JObject.Parse(jsonContent);
            waitUtilities=new WaitUtilities(driver);
        }

        public IWebElement TextBoxPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[@id='item-0']")));
        public IWebElement CheckBoxPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div/div/div[2]/div[1]/div/div/div[1]/div/ul/li[2]")));
        public IWebElement WebTablePage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Web Tables']")));

        public IWebElement ButtonPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Buttons']")));
        
        public IWebElement UploadDownloadPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Upload and Download']")));

        public IWebElement AlertsPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Alerts']")));

        public IWebElement WindowPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Browser Windows']")));

        public IWebElement DateTimePage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Date Picker']")));

        public IWebElement ToolTipPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Tool Tips']")));

        public IWebElement SortPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Sortable']")));

        public IWebElement DropPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Droppable']")));

        public IWebElement RegPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Login']")));

        //public IWebElement RegPage => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Login']")));

        internal void NavigateToUrl(string controlPage)
        {
            driver.Navigate().GoToUrl($"{(string)config["BaseUrl"]}{controlPage}");
            waitUtilities.WaitForPageLoad(driver, 10);
        }

        public void ScrollDownforLinks()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
    }
}
