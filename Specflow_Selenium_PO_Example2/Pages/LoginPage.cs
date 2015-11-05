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
        By loginButton = By.Id("");

        public LoginPage()  {
          
        }

        public void with(String username, String password)
        {
            visit("/login");
            type(username, usernameField);
            type(password, passwordField);
        }

     

    }
}
