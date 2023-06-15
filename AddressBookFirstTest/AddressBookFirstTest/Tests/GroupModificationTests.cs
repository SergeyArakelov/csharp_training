using OpenQA.Selenium;
using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
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

            app.Groups.Modify(newData);
            

        }
    }
}
