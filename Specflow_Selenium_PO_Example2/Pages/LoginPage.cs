using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow_Selenium_PO_Example2.Pages
{
    class LoginPage : BasePage
    {
        By usernameField = By.Id("username");
        By passwordField = By.Id("password");
        By loginFormLocator = By.Id("login");
        By loginButton = By.CssSelector("button[class='radius']");
        By successMessageLocator = By.CssSelector(".flash.success");
        By failureMessageLocator = By.CssSelector(".flash.error");


        public LoginPage()  {
          
        }

        public void with(String username, String password)
        {
            visit("/login");
            type(username, usernameField);
            type(password, passwordField);
        }

        public void submit()
        {
           // submit(loginFormLocator);
            click(loginButton);
        }

        public void successMessagePresent()
        {
            Assert.True(isDisplayed(successMessageLocator));
        }

        public void failureMessagePresent()
        {
            Assert.True(isDisplayed(failureMessageLocator));
          //  return isDisplayed(failureMessageLocator);
            
        }
    }
}
