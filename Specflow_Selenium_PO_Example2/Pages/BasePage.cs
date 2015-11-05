using OpenQA.Selenium;
using Specflow_Selenium_PO_Example2.Step_Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Specflow_Selenium_PO_Example2.Utils;

namespace Specflow_Selenium_PO_Example2.Pages
{
    [Binding]
    class BasePage // :  Base
    {
        readonly IWebDriver driver;
        public BasePage() {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
        }
            
        public void type (String inputText, By locator) {
            find(locator).SendKeys(inputText);
        }
        public IWebElement find(By locator)
        {
            return driver.FindElement(locator);
        }

        public void visit(String url)
        {
            driver.Navigate().GoToUrl(Config.BaseUrl + url);
                
        }
    }
}
