using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LinqToDB.Mapping;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace AddressBookTests
{
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation : HelperBase
    {
        public GroupContactRelation(ApplicationManager manager) : base(manager)
        {
        }

        [Column(Name = "group_id")]
        public string GroupId { get; set; }

        [Column(Name = "id")]
        public string UserId { get; set; }


        //public void DeleteUserToGroup(UserData user, GroupData group)
        //{
        //    manager.Navigator.GoToHomePage();
        //    ClearGroupFilter();
        //    SelectGroupToDelete(group_);
        //    SelectUser(user.Id);
        //    Remove();
        //    RemovalNotificationAccept();
        //    manager.Navigator.GoToHomePage();

        //}

        //private void SelectGroupToDelete(string name)
        //{
        //    new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        //}
    }
}
