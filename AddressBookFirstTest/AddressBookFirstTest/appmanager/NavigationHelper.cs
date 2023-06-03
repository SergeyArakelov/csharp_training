using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTests
{
    public class NavigationHelper : HelperBase
    {
        
        private string baseURL;
        public NavigationHelper(ApplicationManager manager, string baseURL) :
        base(manager)
        { 
            this.baseURL = baseURL; 
        }
        public NavigationHelper GoToGroupPage()
        {

            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
        public NavigationHelper GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            return this;
        }

        public NavigationHelper GoToUserPage() 
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
       
    }
}
