using NUnit.Framework;
using OpenQA.Selenium;
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
        public void Create(UserData username)
        {
            manager.Navigator.GoToUserPage();
            FillUserName(username);
            SubmitUserCreation();
            manager.Navigator.GoToHomePage();

        }

        public bool IsUserExist => IsElementPresent(By.XPath("//img[@alt='Details']"));


        public void Modify(UserData modify)
        {
            InitUserModification(0);
            FillUserForm(modify);
            SubmitUserModification();
            manager.Navigator.GoToHomePage();
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
            Type(By.Name("lastname"), modify.SecondName);

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
            manager.Navigator.GoToHomePage();
        }

        public UserHelper FillUserName(UserData username)
        {
            Type(By.Name("firstname"), username.FirstName);
            Type(By.Name("lastname"), username.SecondName);
            Type(By.Name("address"), username.Address);
            Type(By.Name("home"), username.HomePhone);
            Type(By.Name("work"), username.WorkPhone);
            Type(By.Name("mobile"), username.MobilePhone);
            Type(By.Name("email"), username.Email);
            Type(By.Name("email2"), username.Email2);
            Type(By.Name("email3"), username.Email3);
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
        public void InitUserModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();

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

        public List<UserData> GetUserList()
        {
         List<UserData> newusers = new List<UserData>();

         ICollection<IWebElement> firstName = driver.FindElements(By.CssSelector("tr > td:nth-of-type(3)"));
         ICollection<IWebElement> secondName = driver.FindElements(By.CssSelector("tr > td:nth-of-type(2)"));
         for (int i = 0; i < firstName.Count && i < secondName.Count; i++)
         {
         UserData newuser = new UserData(firstName.ElementAt(i).Text, secondName.ElementAt(i).Text);

          newusers.Add(newuser);
        }
        IList<IWebElement> cells = driver.FindElements(By.TagName("td"));
       
        return new List<UserData>(newusers);
         }

    }
}
// public UserHelper RemoveUserViaEdit()
//{
//driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
//return this;
//}
