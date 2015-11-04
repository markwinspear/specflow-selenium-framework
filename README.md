# Specflow_Selenium_PO_Example5
small project

Main resource used to create first tests: http://ralucasuditu-softwaretesting.blogspot.co.uk/2015/06/write-your-first-test-with-specflow-and.html?m=1

1. Install Visual Studio (Enterprise 2015)
2. Install NuGet (package manager). http://docs.nuget.org/consume/package-manager-dialog#managing-packages-for-the-solution

3. Read http://ralucasuditu-softwaretesting.blogspot.co.uk/2015/06/write-your-first-test-with-specflow-and.html?m=1
4. Connect to github (View > Team Explorer), publish to github then commit solution to github
5. Create new Unit test project "SpecFlow Tests" Visual C# > Test > Unit Test Project https://my330space.wordpress.com/2015/02/18/how-to-setup-selenium-webdriver-with-visual-studio-2013/
6. Use NuGet (Project > Manage NuGet packages) to install specflow (Specflow NUnit)
7. Use NuGet to install selenuium? http://nugetmusthaves.com/Tag/selenium
8. Use NuGet to install selenium support package 
9. Create folder 'dependencies'.  Download chrome, IE drivers directly here rather than use NuGet packages (might be out of date?)
   Right click on the chromedriver.exe and select Properties
    Ensure the Build Action Content is selected  Copy to Output Directory Copy Always has been selected. 
	This will ensure that chromedriver.exe is always in the folder of the running assembly so it can be used.

10. As part of the NuGet installs,  you will notice that an App.config file was generated in the structure of the project. 
    Because we chosen to use MSTest to execute out tests, we need to do a configuration in this file.
	Add line  <unitTestProvider name="MsTest.2015" />

11. Tools > Extensions and Updates > Online.  Install SpecFlow extension and restart VS

12. Create a new SpecFlow feature by right-clicking on the project name --> Add --> New Item --> Visual C# Items --> SpecFlow Feature File. Name the feature

13. Follow these steps: http://ralucasuditu-softwaretesting.blogspot.co.uk/2015/06/write-your-first-test-with-specflow-and.html?m=1

Nuget - install Specflow.mstest 


n. Create new Project "SpecFlow Pages" (Separate out page objects from tests)

TO READ:
https://github.com/alisterscott/SpecDriver
Zukini (github)
https://github.com/mvalipour/specflow-report-templates (specflow - pretty reports)

DECISIONS:
Reshaper (JetBrains extension) - investigate
xUnit/ nUnit / Specflow+ (Execution) - chosen NUnit for now
Reporting??? 

LESSONS:
Ensure there is no ampersand in any local directories as it will cause a random parser error on build

