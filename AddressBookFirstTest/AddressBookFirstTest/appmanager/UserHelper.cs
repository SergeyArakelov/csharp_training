using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Create(UserData newuser)
        {
            manager.Navigator.GoToUserPage();
            FillUserName(newuser);
            SubmitUserCreation();
            manager.Navigator.GoToHomePage();

        }

        public bool IsUserExist => IsElementPresent(By.XPath("//img[@alt='Details']"));


        public void Modify(UserData modify)
        {
            InitUserModification();
            FillUserForm(modify);
            SubmitUserModification();
        }

        public void CreateEmptyUser()
        {
            manager.Navigator.GoToUserPage();
            SubmitUserCreation();
            manager.Navigator.GoToHomePage();
        }

        public UserHelper FillUserForm(UserData modify)
        {
            Type(By.Name("firstname"), modify.FirstName);
            return this;
        }

        //public UserHelper RemoveViaEdit()
        //{
        //InitUserModification();
        //RemoveUserViaEdit();
        //return this;
        //}


        public void RemoveUser()
        {
            SelectUser();
            Remove();
            RemovalNotificationAccept();
        }

        public UserHelper FillUserName(UserData newuser)
        {
            Type(By.Name("firstname"), newuser.FirstName);
            Type(By.Name("lastname"), newuser.SecondName);
            return this;
        }
        public UserHelper SubmitUserCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public UserHelper SelectUser()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }
        public void InitUserModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();

        }

        public UserHelper SubmitUserModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public UserHelper Remove()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public UserHelper RemovalNotificationAccept()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        //public List<UserData> GetUserList()
        //{
        //    List<UserData> newusers = new List<UserData>();
        //    ICollection<IWebElement> FirstName = driver.FindElements(By.CssSelector("tr > td:nth-of-type(3)"));
        //    ICollection<IWebElement> SecondName = driver.FindElements(By.CssSelector("tr > td:nth-of-type(2)"));
        //    for (int i = 0; i < newusers.Count; i++)
        //    {
        //       // UserData newuser = new UserData(newuser(i));

        //       // newusers.Add(newuser);
        //    }
        //   // IList<IWebElement> cells = newuser.FindElements(By.TagName("td"));
        //    return newusers;
        //}
    }
}
// public UserHelper RemoveUserViaEdit()
//{
//driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
//return this;
//}
