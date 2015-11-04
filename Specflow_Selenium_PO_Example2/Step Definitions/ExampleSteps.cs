using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace Specflow_Selenium_PO_Example2
{
    [Binding]
    public class ExampleSteps
    {

        int total = 0;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            total += p0;
            
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            

        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Debug.WriteLine(total);
        }
    }
}
