using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Specflow_Selenium_PO_Example2.Utils
{
    [Binding]
    public sealed class Hooks
    {
        IWebDriver driver;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario("web")]
        public void BeforeWebScenario()
        {
            driver = new FirefoxDriver();
            ScenarioContext.Current["driver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }

        public IWebDriver WebDriver { get; private set; }
    }
}
