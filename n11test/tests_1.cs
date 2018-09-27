using n11test.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n11test
{
    class Tests_1
    {
        IWebDriver driver;
        static string search_text = "samsung";
        [SetUp]
        public void StartBrowser()
        {
            
            ChromeOptions options = new ChromeOptions();                    //Start selenium
            options.AddArguments("--start-maximized");                  //Fullscreen browser
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;                   //hide the command prompt that opens with browser
            driver = new ChromeDriver(driverService, options);
           
        }

        [Test]
        public void Test1()
        {
            HomePage home = new HomePage(driver); 
            home.goToPage();
            StringAssert.IsMatch(driver.Url, "https://www.n11.com/");       //match url with homepage
            home.click_login_btn();

            LoginPage login = new LoginPage(driver);
            StringAssert.IsMatch(driver.Url, "https://www.n11.com/giris-yap/");     //match url with login page
            login.enter_credentials();
            login.click_login_btn();

            Action_page page1 = new Action_page(driver);
            page1.search(search_text);                      //enter search text and hit enter key

            page1.check_results();                              //check if there is any result by checking for an element that shows result count

            string page_2_url = driver.Url.ToString() + "&pg=2";//get to the page 2 of results by changing url
            driver.Navigate().GoToUrl(page_2_url);

            StringAssert.Contains(driver.Url, page_2_url);          //match url with page2 url

          
            string src = page1.add_favourite(2,2);              //get the id of the item to check later if we have the right item to delete,parameters page number and row

            page1.favori_liste();                   //Hover over account and click favorilerim

            page1.favorilerim_click();              //Click to favorilerim in the new page to show detailed list of favourite items

           int b= driver.FindElements(By.Id(src)).Count();      //check if an item with the id we got earlier is in the page
            Assert.AreNotEqual(0, b);                           

            page1.delete_click();           //remove from favourites

            var a = driver.FindElements(By.XPath("//*[contains(text(), 'Tamam')]"));        //alert pop up for deletion completed

            while(a.Count()!=2)
            {
                a = driver.FindElements(By.XPath("//*[contains(text(), 'Tamam')]"));        //There are one more item containin the word "Tamam", so we wait for the pop up to show here. 
            }
                a[1].Click();           //clcik the pop up

            b = driver.FindElements(By.Id(src)).Count();

            while (b!=0)
            {
                b = driver.FindElements(By.Id(src)).Count();  //verify that there is no item with the id we got earlier
            }

            Assert.AreEqual(0, b);
        }

    
        [TearDown]
        public void CloseBrowser()
        {
          
            driver.Close();
        }



    }
}
