using NUnit.Framework;



namespace AddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            
            GroupData group = new GroupData("aaaa");
            group.Header = ("bbbb");
            group.Footer = ("cccc");

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);


            List <GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
            
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            
            GroupData group = new GroupData("");
            group.Header = ("");
            group.Footer = ("");

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();   
            newGroups.Sort();   

            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
