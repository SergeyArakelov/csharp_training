using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class UserModificationTests : TestBase
    {

        [Test]
        public void UserModificationTest()
        {

            UserData modify = new UserData("");
            modify.Company = ("Microsoft");
            modify.EMail = ("Petrov@mic.com");

            app.User.Modify(modify);
        }
    }
}
