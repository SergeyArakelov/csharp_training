using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AddressBookTests
{
    public class GroupHelper : HelperBase
    {
       
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
          
        }
       
        public GroupHelper Create(GroupData group) 
        {
            manager.Navigator.GoToGroupPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public bool IsGroupExist => IsElementPresent(By.Name("selected[]"));
        //public void Remove()
        //{
            
        //    SelectGroup();
        //    RemoveGroup();
        //    ReturnToGroupPage();
            
        //}
        public void Remove(GroupData group)
        {
            manager.Navigator.GoToGroupPage();

            SelectGroupById(group.Id);
            RemoveGroup();
            ReturnToGroupPage();
        }

        public void EmptyGroupCreation()
        {
            
            InitNewGroupCreation();
            SubmitGroupCreation();
            manager.Navigator.GoToGroupPage();

        }

       
        

        public GroupHelper Modify(GroupData group)
        {

            SelectGroupById(group.Id);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupPage();

            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

       

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCash = null;
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCash = null;
            return this;
        }
       
        public GroupHelper SelectGroup()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }
        public GroupHelper SelectGroupById(String id)
        {
            driver.FindElement(By.XPath("(//input [@name= 'selected[]' and @value='" + id + "'])")).Click();
            return this;

        }
        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCash = null;
            return this;
        }


        private List<GroupData> groupCash = null;

        public List<GroupData> GetGroupList()
        {
            if ( groupCash == null)
            {
                groupCash = new List<GroupData>();
                List<GroupData> groups = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {

                    groupCash.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
                
            }
           
            return new List<GroupData>(groupCash);
        }

       
    }
}
