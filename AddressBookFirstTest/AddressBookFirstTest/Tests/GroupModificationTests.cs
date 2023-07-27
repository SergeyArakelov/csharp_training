using OpenQA.Selenium;
using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupPage();
            if (!app.Groups.IsGroupExist)
            {
                app.Groups.EmptyGroupCreation();
            }

            
            
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModify = oldGroups[5];
            toBeModify.Name = "Name";
            toBeModify.Header = null;
            toBeModify.Footer = null;

            app.Groups.Modify(toBeModify);
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = toBeModify.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            //foreach (GroupData group in newGroups) 
            //{
            //    if(group.Id = oldGroups)
            //    {
            //        Assert.AreEqual(group.Name, toBeModify.Name);
            //  }

            //}

        }
    }
}
