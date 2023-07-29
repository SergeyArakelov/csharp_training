using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBookTests
{
    public class UserHelper : HelperBase
    {

        public UserHelper(ApplicationManager manager) :
        base(manager)
        {


        }
        public void Create(UserData user)
        {
            manager.Navigator.GoToUserPage();
            InitUserModification(1);
            FillUserName(user);
            SubmitUserCreation();
            manager.Navigator.GoToHomePage();

        }

        public bool IsUserExist => IsElementPresent(By.XPath("//img[@alt='Details']"));


        public void Modify(UserData user)
        {
            SelectUser(user.Id);
            InitUserModification(0);
            FillUserForm(user);
            SubmitUserModification();
            manager.Navigator.GoToHomePage();
        }

        public void CreateEmptyUser()
        {
            manager.Navigator.GoToUserPage();
            SubmitUserCreation();
            manager.Navigator.GoToHomePage();
        }

        public UserHelper FillUserForm(UserData user)
        {
            Type(By.Name("firstname"), user.FirstName);
            Type(By.Name("lastname"), user.SecondName);

            return this;
        }

        //public UserHelper RemoveViaEdit()
        //{
        //InitUserModification();
        //RemoveUserViaEdit();
        //return this;
        //}


        public void RemoveUser(UserData user)
        {
            SelectUser(user.Id);
            Remove();
            RemovalNotificationAccept();
            manager.Navigator.GoToHomePage();
        }

        public UserHelper FillUserName(UserData user)
        {
            Type(By.Name("firstname"), user.FirstName);
            Type(By.Name("lastname"), user.SecondName);
            Type(By.Name("address"), user.Address);
            Type(By.Name("home"), user.HomePhone);
            Type(By.Name("work"), user.WorkPhone);
            Type(By.Name("mobile"), user.MobilePhone);
            Type(By.Name("email"), user.Email);
            Type(By.Name("email2"), user.Email2);
            Type(By.Name("email3"), user.Email3);
            return this;
        }
        public UserHelper SubmitUserCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            userCash = null;
            return this;
        }
        //public UserHelper SelectUser(String id)
        //{
        //    driver.FindElement(By.XPath("(//input [@name= 'selected[]' and @value='" + id + "'])")).Click();
        //    return this;
        //}
        public void InitUserModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();

        }

        public UserHelper SubmitUserModification()
        {
            driver.FindElement(By.Name("update")).Click();
            userCash = null;
            return this;
        }

        public UserHelper Remove()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            userCash = null;
            return this;
        }

        public UserHelper RemovalNotificationAccept()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public UserData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string secondName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new UserData(firstName, secondName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,

            };

        }

        public UserData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitUserModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string secondName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string Email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string Email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string Email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");


            return new UserData(firstName, secondName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = Email,
                Email2 = Email2,
                Email3 = Email3,
                
            };

        }

        public UserData GetContactInformationFromDetails()
        {
            manager.Navigator.GoToHomePage();
            ViewUserDetails(0);
            string allInfo = driver.FindElement(By.XPath("/html//div[@id='content']")).Text;
            return new UserData(null, null)
            {
                AllInfo = allInfo
            };
            
        }

        public void ViewUserDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        }
        private List<UserData> userCash = null;


        public List<UserData> GetUserList()
        {
            if (userCash == null)
            {
                userCash = new List<UserData>();
                List<UserData> newusers = new List<UserData>();

                ICollection<IWebElement> firstName = driver.FindElements(By.CssSelector("tr > td:nth-of-type(3)"));
                ICollection<IWebElement> secondName = driver.FindElements(By.CssSelector("tr > td:nth-of-type(2)"));
                for (int i = 0; i < firstName.Count && i < secondName.Count; i++)
                {
                    UserData newuser = new UserData(firstName.ElementAt(i).Text, secondName.ElementAt(i).Text);

                    userCash.Add(newuser);
                }
                IList<IWebElement> cells = driver.FindElements(By.TagName("td"));
            }
        
       
        return new List<UserData>(userCash);
         }

        internal void AddUserToGroup(UserData user, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectUser(user.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingUserToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }
        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
        private void SelectUser(string userId)
        {
            driver.FindElement(By.Id(userId)).Click();
        }
        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }


        private void CommitAddingUserToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

       
    }
}
// public UserHelper RemoveUserViaEdit()
//{
//driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
//return this;
//}
