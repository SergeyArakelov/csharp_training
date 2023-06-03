using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTests
{
    public class UserHelper
    {
        private IWebDriver driver;
        public UserHelper(IWebDriver driver)
        {
            this.driver = driver;

        }
        public void AddNewUser()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void FillUserName(UserData newuser)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(newuser.FirstName);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(newuser.SecondName);
        }
        public void SubmitUserCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
    }
}
