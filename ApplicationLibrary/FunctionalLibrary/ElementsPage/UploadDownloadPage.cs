using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Test_framework.Utilities;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.ElementsPage
{
    internal class UploadDownloadPage
    {
        private IWebDriver driver;

        public UploadDownloadPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Download()
        {
            IWebElement buttonClick = driver.FindElement(By.XPath("//a[@id='downloadButton']"));
            if (buttonClick != null)
            {
                buttonClick.Click();
            }
        }

        public void upload()
        {
            IWebElement fileInput = driver.FindElement(By.Id("uploadFile"));
            if (fileInput != null)
            {
                string filePath = @"C:\Users\sampleFile.jpeg";
                fileInput.SendKeys(filePath);
            }
        }


    }
}
