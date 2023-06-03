using NUnit.Framework;


namespace AddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupPage();
        }
    }
}