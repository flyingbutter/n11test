using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n11test.PageObjects
{
    class HomePage
    {

        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "btnSignIn")]
        private IWebElement login_btn;

       
        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://www.n11.com");
        }

        public void click_login_btn()
        {
            login_btn.Click();
        }

       

    }
}
