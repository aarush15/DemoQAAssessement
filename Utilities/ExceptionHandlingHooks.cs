using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using TechTalk.SpecFlow;

namespace QA_Test_framework.Utilities
{
    [Binding]
    public class ExceptionHandlingHooks
    {
        private readonly ScenarioContext scenarioContext;

        public ExceptionHandlingHooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [AfterStep]
        public void AfterStep()
        {
            if (scenarioContext.TestError != null)
            {
                Exception exception = scenarioContext.TestError;
                //Log error
            }
        }
    }
}
