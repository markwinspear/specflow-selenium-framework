# SpecFlow Framework 
## Uses SpecFlow, WebDriver, NUnit, specflow-report-templates (for reporting)
## Utilises Page Object Model pattern

## Background reading: 
* Getting started with Specflow: http://ralucasuditu-softwaretesting.blogspot.co.uk/2015/06/write-your-first-test-with-specflow-and.html?m=1

## Stuff to organise
* Create new Unit test project "SpecFlow Tests" Visual C# > Test > Unit Test Project https://my330space.wordpress.com/2015/02/18/how-to-setup-selenium-webdriver-with-visual-studio-2013/

##Getting started
1. Install Visual Studio (Enterprise 2015)
2. Install NuGet (package manager). http://docs.nuget.org/consume/package-manager-dialog#managing-packages-for-the-solution
3. Connect to github project (View > Team Explorer)
4. Use NuGet (Project > Manage NuGet packages) to install specflow and Nunit:
..* NUnit 2.6.47
..* NUnit.Runners 
..* NUnitTestAdaptor
..* SpecFlow
..* Specflow.NUnit
5. Use NuGet to install Selenuium http://nugetmusthaves.com/Tag/selenium
6. Use NuGet to install Selenium support package 
7. Create folder 'dependencies'.  Download chrome, IE, Edge drivers directly here via NuGet packages 
-- Right click on the chromedriver.exe and select Properties
-- Ensure the Build Action Content is selected  Copy to Output Directory Copy Always has been selected. 
-- This will ensure that chromedriver.exe is always in the folder of the running assembly so it can be used.

8. As part of the NuGet installs,  you will notice that an App.config file was generated in the structure of the project. 
-- If we chosen to use MSTest instead of NUnit as a test runner, we need to update this file.
-- Add line  <unitTestProvider name="MsTest.2015" />
-- For now, keep as nunit or specrun (if installed)

9. In Visual Studio, select Tools > Extensions and Updates > Online.  Install SpecFlow extension and restart VS

10. Create a new SpecFlow feature by right-clicking on the project name --> Add --> New Item --> Visual C# Items --> SpecFlow Feature File. Name the feature

11. Follow these steps: http://ralucasuditu-softwaretesting.blogspot.co.uk/2015/06/write-your-first-test-with-specflow-and.html?m=1

12. Install SpecRun (NuGet) for enhanced reporting and IDE intellisense, formatting etc
-- As per http://tech.opentable.co.uk/blog/2013/06/07/getting-started-with-specrun/
-- Change Execution "stopAfterFailures" attribute to 0 else will retry tests three times, this 
-- will also tell SpecRun not to stop after any failures and continue.

## Generate human-readable feature and scenarios
..* Install Pickles and Pickles Command Line via NuGet to generate human readable documentation.
..* Create bat file with contents...
	cd /D [insert full path to location of solution file (.sln)]
	.\packages\Pickles.CommandLine.2.0.0\tools\pickles.exe^
	 --feature-directory=./Specflow_Selenium_PO_Example2\Features
	 --output-directory=.\documentation^
	 --test-results-format=specrun^
	 --link-results-file=.\bin\Debug\TestResult.xml


## Reporting
..* Standard NUnit reporting via Visual Studio is limited to that displayed in the Test explorer
..* To generate standard NUnit reports, you need to use NUnit console
 To get a test result file, execute via the Nunit console (http://www.specflow.org/documentation/Reporting/)
Open command line:
cd /d to project directory  > packages > NUnit \NUnit.Runners.2.6.4\tools
nunit-console.exe /labels /out=TestResult.txt /xml=TestResult.xml "[path to project file]\BookShop.AcceptanceTests.csproj"

..* Extending specflow report generation to use custom template from https://github.com/mvalipour/specflow-report-templates)
  
  a. Add ../Nunit.Runners.2.6.4/tools to PATH environment variable in order to be able to run tools and store files in the right locations
  b. Add ../Specflow/tools to PATH environment variable
  c. restart command line or PATH changes won't be picked up
  
  Execute tests using NUnit console runner (to also generate the Xml results file)... setup a .bat file to do this with the following contents:
  cd /d [project directory(which contains the bin folder)]^
   nunit-console.exe /labels /out=TestResult.txt /xml=TestResult.xml bin\Debug\BookShop.AcceptanceTests.csproj

  forked and cloned repo specflow-report-templates (https://github.com/mvalipour/specflow-report-templates)
  set up bat file:
  cd /d E:\"Google Drive"\Documents\Cucumber_Selenium_CSharp\Specflow_Selenium_PO_Example2\packages\SpecFlow.1.9.0\tools

specflow nunitexecutionreport^
 Specflow_Selenium_PO_Example2.csproj^
 /out:"TestResult.html"^
 /xsltFile:"E:\Google Drive\Documents\Cucumber_Selenium_CSharp\specflow-report-templates\nunit-dream\ExecutionReport.xslt"^
 /xmlTestResult:"E:\Google Drive\Documents\Cucumber_Selenium_CSharp\Specflow_Selenium_PO_Example2\packages\NUnit.Runners.2.6.4\tools\TestResult.xml"
pause
	
Evaulation of 19... This method means we get decent reporting (except Scenario Outlines) and can then use Saucery

## Notes:
..* The Hooks class contains code which runs before and after scenarios (and can be expanded to use other annotations).The scenarios are tagged with "web" to ensure that webdriver instances are only created for UI tests.  Use the tag @web when creating scenarios

..* Parallel execution. NUnit 2.x does not support parallelism, but Specrun does if you are using this as your test runner.  To set multi-threaded using Specrun, in Default.srprofile change Execution atribute testThreadCount="n"
	
..* The project contains code to insert screenshots and page source html on failure and is taken from here: http://stackoverflow.com/questions/18512918/insert-screenshots-in-specrun-specflow-test-execution-reports
   (Note - these are not links - they are the path and filename... might need some tweaking of the standard specrun report template?)

..* NUnit is currently used as the test runner.  This is because integration with Saucelabs in the future (possibly using Saucery for NUnit) appears to be much more difficult using Specrun

..* If using SpecRun as the test runner, to customise reports: https://groups.google.com/forum/#!topic/specrun/8-G0TgOBUbY


	 
----

IMPORTANT: Follow this setup to run reporting tools from the command line: http://stackoverflow.com/questions/11363202/specflow-fails-when-trying-to-generate-test-execution-report
IMPORTANT: Another change required if using Visual Studio 2015: https://github.com/techtalk/SpecFlow/issues/471
Need to execute from command line?  http://www.marcusoft.net/2010/12/specflowexe-and-mstest.html
Specflow.exe if installed via NuGet ends up here: ..[project directory]\packages\SpecFlow.1.9.0\tools

TO READ:
https://github.com/alisterscott/SpecDriver
Zukini (github)
https://github.com/mvalipour/specflow-report-templates (specflow - pretty reports)

DECISIONS:
Reshaper (JetBrains extension) - investigate
TFS integration for source control (currently git)
Microsoft CI integration?
Sauce labs integration (possibly using Saucery?)
Selenium Grid
Why using NUnit 2 and not 3? (3 = parallel testing (although specflow handles this I believe)) - Saucery tests look cleaner using NUnit 3


