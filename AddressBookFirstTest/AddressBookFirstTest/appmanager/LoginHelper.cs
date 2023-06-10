using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text;

namespace AddressBookTests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) :
        base(manager)
        {

        }
        public void Login(AccountData account)
        {
            Type(By.Name("user"), account.Login);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }
        public void Logout()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/index.php");
        }

    }

}    
