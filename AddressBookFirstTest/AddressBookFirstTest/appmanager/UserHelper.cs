﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public UserHelper Create(UserData newuser)
        {
            manager.Navigator.GoToUserPage();
            FillUserName(newuser);
            SubmitUserCreation();
            return this;
        }

        public UserHelper Modify(UserData modify)
        {
            InitUserModification();
            FillUserForm(modify);
            SubmitUserModification();
            return this;

        }
        public UserHelper RemoveViaEdit()
        {
            InitUserModification();
            RemoveUserViaEdit();
            return this;
        }
        public UserHelper RemoveUser() 
        {
            SelectUser();
            Remove();
            RemovalNotificationAccept();
            return this;
        }

        public UserHelper FillUserName(UserData newuser)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(newuser.FirstName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(newuser.SecondName);
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
        public UserHelper InitUserModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
        public UserHelper FillUserForm(UserData modify)
        {
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(modify.Company);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(modify.EMail);
            return this;
        }
        public UserHelper SubmitUserModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public UserHelper RemoveUserViaEdit()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
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
    }
}
