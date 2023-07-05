using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QA_Test_framework.ApplicationLibrary.FunctionalLibrary.InteractionPages
{
    internal class DropablePage
    {
        private IWebDriver driver;
        public DropablePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ThenIDragAndDropTheDivElementsInDescendingOrder()
        {
        }
    }
}
