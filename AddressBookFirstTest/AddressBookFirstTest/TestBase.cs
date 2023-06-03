using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text;


namespace AddressBookTests
{
  public  class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        protected void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
       
        protected void GoToGroupPage()
        {

            driver.FindElement(By.LinkText("groups")).Click();
        }
        protected void AddNewUser()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        protected void Login(AccountData account)
        {

            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }
        protected void FillUserName(UserData newuser)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(newuser.FirstName);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(newuser.SecondName);
        }
        protected void SubmitUserCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
        protected void BackToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
        protected void Logout()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook/index.php");
        }
        protected void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
        protected void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
        protected void ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        protected void InitNewGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
        }
        protected void FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        protected void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

    }
}
