using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text;

namespace AddressBookTests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(IWebDriver driver) :
        base(driver)
        {

        }
        public void Login(AccountData account)
        {

            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }
        public void Logout()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/index.php");
        }

    }

}    
