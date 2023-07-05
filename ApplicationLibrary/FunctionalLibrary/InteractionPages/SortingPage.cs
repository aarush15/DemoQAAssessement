using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.InteractionPages
{

    internal class SortingPage
    {
        
        private IWebDriver driver;       
        private static Dictionary<string, int> numericMapping = new Dictionary<string, int>()
        {
            { "One", 6 },
            { "Two", 5 },
            { "Three",4 },
            { "Four", 3 },
            { "Five", 2 },
            { "Six", 1},

        };

        public SortingPage(IWebDriver driver)
        {
            this.driver = driver;            
        }

        public void ThenIDragAndDropTheDivElementsInDescendingOrder()
        {
           
            IWebElement containerElement = driver.FindElement(By.XPath("//*[@id='demo-tabpane-list']/div"));
          
            IList<IWebElement> divElements = containerElement.FindElements(By.XPath("//*[@id='demo-tabpane-list']/div/div"));

            var sortedElements = divElements.OrderByDescending(e => GetNumericValue(e.Text)).ToList();
            int yOffset = 0;

            Actions actions = new Actions(driver);

            foreach (var element in sortedElements)
            {
                actions.DragAndDropToOffset(element, 0, yOffset).Perform();
                yOffset -= element.Size.Height;
                Thread.Sleep(2000);
            }  
        }
        static int GetNumericValue(string text)
        {
            int numericValue;
            if (numericMapping.TryGetValue(text, out numericValue))
            {
                return numericValue;
            }
            return 0; // Default value if mapping not found
        }

    }
}
