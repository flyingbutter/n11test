using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n11test.PageObjects
{
    class LoginPage
    {

         private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement email;


        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "loginButton")]
        private IWebElement loginButton;

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://www.n11.com");
        }

        public void click_login_btn()
        {
            loginButton.Click();
        }

        public void enter_credentials()
        {
            email.SendKeys("mtanir22@gmail.com");
            password.SendKeys("qwe1asd");
        }

     
    }
}
