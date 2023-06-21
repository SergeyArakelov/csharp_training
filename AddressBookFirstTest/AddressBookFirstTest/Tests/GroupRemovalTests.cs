using NUnit.Framework;


namespace AddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupPage();
            if (!app.Groups.IsGroupExist)
            {
                app.Groups.EmptyGroupCreation();
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove();

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}