using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n11test.PageObjects
{
    class Action_page
    {


        private IWebDriver driver;

        public Action_page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "searchData")]
        private IWebElement search_area;

        [FindsBy(How = How.Id, Using = "itemCount")]
        private IWebElement search_result;

        [FindsBy(How = How.XPath, Using = "//*[@title='Favorilere ekle']")]
        private IList<IWebElement> favourite_list;

        [FindsBy(How = How.XPath, Using = "//*[@title='İstek Listem / Favorilerim']")]
        private IWebElement favori_buton;

        [FindsBy(How = How.ClassName, Using = "listItemTitle")]
        private IWebElement favorilerim;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Hesabım')]")]
        private IWebElement hoverElement;

        
        [FindsBy(How = How.ClassName, Using = "deleteProFromFavorites")]
        private IWebElement delete;
        
        public void delete_click()
        {
            delete.Click();
        }
        public void favorilerim_click()
        {
           
           
            favorilerim.Click();
        }

        public void favori_liste()
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(hoverElement).Perform();
            favori_buton.Click();
        }

        public void search(string text)
        {
            search_area.SendKeys(text);
            search_area.SendKeys(Keys.Enter);
        }
        public string add_favourite(int a,int b)//a =line b=page
        {
            int t = a + 1 + ((b - 1) * 28);
           
            string id = driver.FindElements(By.XPath("//*[@data-position='" + t +"']"))[0].GetAttribute("id");
            favourite_list[a].Click();
            return id;
        }

        public bool check_results()
        {
            try
            {
                search_result.GetAttribute("innerText");
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
