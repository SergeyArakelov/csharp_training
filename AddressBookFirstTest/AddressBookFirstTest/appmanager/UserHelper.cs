using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        //    List<UserData> users = new List<UserData>();
        //    ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr:nth-of-type(0) > td:nth-child(1)"));
        //    foreach (IWebElement element in elements)
        //    {
        //        users.Add(new UserData(element.Text));
        //    }
        //    return users;
        //}
        public List<UserData> GetFirstNameList()
        {
            List<UserData> firstnames = new List<UserData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr:nth-of-type(3) > td:nth-of-type(3)"));
            foreach (IWebElement element in elements)
            {
                firstnames.Add(new UserData(element.Text));
            }
            return firstnames;
        }

        public List<UserData> GetSecondNameList()
        {
            List<UserData> secondnames = new List<UserData>();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr:nth-of-type(2) > td:nth-of-type(2)"));
            foreach (IWebElement element in elements)
            {
                secondnames.Add(new UserData(element.Text));
            }
            return secondnames;
        }
    }

   
}
// public UserHelper RemoveUserViaEdit()
//{
//driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
//return this;
//}
