using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Specflow_Selenium_PO_Example2.Step_Definitions
{

    [Binding]
    public class Base
    {
      //  readonly IWebDriver driver;


        public Base()
        {
          //  driver = (IWebDriver)ScenarioContext.Current["driver"];
        }

    }
}
