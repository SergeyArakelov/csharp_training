using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTests
{
   public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
     
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected UserHelper userHelper;
        

        public ApplicationManager()
            {
            driver =new ChromeDriver();
            baseURL = "http://localhost/addressbook/";

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            userHelper = new UserHelper(this);
        }

        public IWebDriver Driver 
        { 
            get 
            { 
                return driver; 
            } 
        } 
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth
        {
            get 
            { 
                return loginHelper; 
            } 
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }
             public UserHelper User
        {
            get
            {
                return userHelper;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

    }
}
