using NUnit.Framework;



namespace AddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupPage();
            if (!app.Groups.IsGroupExist)
            {
                app.Groups.EmptyGroupCreation();
            }

            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
          

        }
    }
}