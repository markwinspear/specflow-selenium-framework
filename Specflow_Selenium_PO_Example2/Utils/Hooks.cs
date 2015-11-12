using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

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

        [AfterScenario("web")]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                TakeScreenshot(driver);
            }
            driver.Quit();
        }

        private void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = string.Format("error_{0}_{1}_{2}",
                    FeatureContext.Current.FeatureInfo.Title,
                    ScenarioContext.Current.ScenarioInfo.Title,
                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "testresults");
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                string pageSource = driver.PageSource;
                string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();
                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");
                    screenshot.SaveAsFile(screenshotFilePath, ImageFormat.Png);
                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }
    }
}
            
        

      //  public IWebDriver WebDriver { get; private set; }
    

