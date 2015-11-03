using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace Specflow_Selenium_PO_Example2
{
    [Binding]
    public class ExampleSteps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
           // ScenarioContext.Current.Pending();
            Debug.WriteLine("The Given step is doing something at least");
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
