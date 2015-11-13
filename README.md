# Specflow_Selenium_PO_Example5
Main resource used to create first tests: http://ralucasuditu-softwaretesting.blogspot.co.uk/2015/06/write-your-first-test-with-specflow-and.html?m=1

1. Install Visual Studio (Enterprise 2015)
2. Install NuGet (package manager). http://docs.nuget.org/consume/package-manager-dialog#managing-packages-for-the-solution

3. Read http://ralucasuditu-softwaretesting.blogspot.co.uk/2015/06/write-your-first-test-with-specflow-and.html?m=1
4. Connect to github (View > Team Explorer), publish to github then commit solution to github
5. Create new Unit test project "SpecFlow Tests" Visual C# > Test > Unit Test Project https://my330space.wordpress.com/2015/02/18/how-to-setup-selenium-webdriver-with-visual-studio-2013/
6. Use NuGet (Project > Manage NuGet packages) to install specflow (Specflow NUnit)
7. Use NuGet to install selenuium? http://nugetmusthaves.com/Tag/selenium
8. Use NuGet to install selenium support package 
9. Create folder 'dependencies'.  Download chrome, IE drivers directly here via NuGet packages (is this always the latest version?)
   Right click on the chromedriver.exe and select Properties
    Ensure the Build Action Content is selected  Copy to Output Directory Copy Always has been selected. 
	This will ensure that chromedriver.exe is always in the folder of the running assembly so it can be used.

10. As part of the NuGet installs,  you will notice that an App.config file was generated in the structure of the project. 
    If we chosen to use MSTest instead of NUnit as a test runner, we need to do a configuration in this file.
	Add line  <unitTestProvider name="MsTest.2015" />
	For now, keep as nunit

11. Tools > Extensions and Updates > Online.  Install SpecFlow extension and restart VS

12. Create a new SpecFlow feature by right-clicking on the project name --> Add --> New Item --> Visual C# Items --> SpecFlow Feature File. Name the feature

13. Follow these steps: http://ralucasuditu-softwaretesting.blogspot.co.uk/2015/06/write-your-first-test-with-specflow-and.html?m=1

14. Add Hooks class - use tag @web for before and after scenarios involving webdriver so only fires up for web tests

15a. Install SpecRun (NuGet) for enhanced reporting and IDE intellisense, formatting etc
    As per http://tech.opentable.co.uk/blog/2013/06/07/getting-started-with-specrun/
    Change Execution "stopAfterFailures" attribute to 0 else will retry tests three times, this 
	   will also tell SpecRun not to stop after any failures and continue.
	   
15b. Set multi-threaded using Specrun... 	in Default.srprofile, change Execution atribute testThreadCount="n"
	
16. code to insert screenshots and page source html on failure: http://stackoverflow.com/questions/18512918/insert-screenshots-in-specrun-specflow-test-execution-reports
   (Note - these are not links - they are the path and filename... might need some tweaking of the standard specrun report template?)

17. Install Pickles and Pickles Command Line via NuGet to generate human readable documentation.
17b. Create bat file with contents...
	cd /D [insert full path to location of solution file (.sln)]
	.\packages\Pickles.CommandLine.2.0.0\tools\pickles.exe^
	 --feature-directory=./Specflow_Selenium_PO_Example2\Features
	 --output-directory=.\documentation^
	 --test-results-format=specrun^
	 --link-results-file=.\bin\Debug\TestResult.xml
   
	
Reporting - to be revisited:
Add nunit-console location to the PATH environment variable to avoid having to quote the whole path in accessing it
had to download "Microsoft Build Tools 2013" or running the reporting commands throws an error : http://stackoverflow.com/questions/24549921/msbuild-error-in-command-line-error-msb4067
IMPORTANT: Follow this setup to run reporting tools from the command line: http://stackoverflow.com/questions/11363202/specflow-fails-when-trying-to-generate-test-execution-report
IMPORTANT: Another change required if using Visual Studio 2015: https://github.com/techtalk/SpecFlow/issues/471
Need to execute from command line?  http://www.marcusoft.net/2010/12/specflowexe-and-mstest.html
Nice reporting templates: https://github.com/mvalipour/specflow-report-templates
https://github.com/techtalk/SpecFlow/wiki/Reporting
Specflow.exe is here: ..[project directory]\packages\SpecFlow.1.9.0\tools
C:\Users\markwinspear\.nuget\packages\SpecFlow\1.9.0\tools

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


