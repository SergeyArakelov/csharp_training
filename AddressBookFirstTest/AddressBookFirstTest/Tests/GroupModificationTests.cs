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

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Modify(newData);
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            //foreach (GroupData group in newGroups) 
            //{
            //    if(group.Id = oldGroups[0].Id)
            //    {
            //        Assert.AreEqual(group.Name, newData.Name);
            //    }

            //}

        }
    }
}
