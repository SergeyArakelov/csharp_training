using NUnit.Framework;



namespace AddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("aaaa");
            group.Header = ("bbbb");
            group.Footer = ("cccc");
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }
    }
}
