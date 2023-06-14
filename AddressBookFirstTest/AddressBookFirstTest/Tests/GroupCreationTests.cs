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

            
            app.Groups.Create(group);
            
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            
            GroupData group = new GroupData("");
            group.Header = ("");
            group.Footer = ("");

            app.Groups.Create(group);

        }
    }
}
