using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace QA_Test_framework.Utilities
{
    internal  class WaitUtilities
    {
        private  WebDriverWait wait;
        private  IWebDriver driver;
       
        public WaitUtilities(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
        }
        public string WaitForElementToBePresent(IWebDriver driver,By locator)
        {           
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return element.Text.Trim();
        }

        public void WaitForElementtoVisible(IWebDriver driver, By locator)
        {
            
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));            
        }
        public void WaitForPageLoad(IWebDriver driver, int timeoutInSeconds)
        {            
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public string WaitForFileDownload(IWebDriver driver)
        {
           
            // Set the download directory path where the file is expected to be downloaded
            string downloadDirectory = @"C:\Users\";

            // Wait for the file to be downloaded by checking if it exists in the download directory
            wait.Until(driver =>
            {
                DirectoryInfo directory = new DirectoryInfo(downloadDirectory);
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    // Check if the downloaded file matches the expected file name or any other criteria
                    if (file.Name == "sampleFile.jpeg")
                    {
                        return true;
                    }
                }
                return false;
            });

            // Return the path of the downloaded file
            return Path.Combine(downloadDirectory, "expected_file_name");
        }

        public bool AlertIsPresent()
        {
            wait.Until(ExpectedConditions.AlertIsPresent());
            return true;
        }

    }
}
