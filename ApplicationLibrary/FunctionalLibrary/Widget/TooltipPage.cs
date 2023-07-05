using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.Widget
{
    internal class TooltipPage
    {
        private IWebDriver driver;
        private Actions actions;
        private string tooltipContent;

        public TooltipPage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
        }

        public void WhenIHoverOverTheHighlightedItems()
        {
            IWebElement highlightedItem = driver.FindElement(By.XPath("//*[@id='toolTipButton']"));
            Thread.Sleep(2000);
            actions.MoveToElement(highlightedItem).Perform();
            Thread.Sleep(5000);
        }

        public bool ThenTheTooltipContentShouldBeDisplayedCorrectly()
        {
            // Wait for the tooltip to appear (you may need to implement a wait here)
            IWebElement tooltip = driver.FindElement(By.XPath("//*[@id='buttonToolTip']/div[2]"));
            tooltipContent = tooltip.Text;
            if (!string.IsNullOrEmpty(tooltipContent))
            {
                return true;
            }
            return false;
        }

    }
}
