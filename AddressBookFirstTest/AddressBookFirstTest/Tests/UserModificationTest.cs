using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class UserModificationTests : AuthTestBase
    {

        [Test]
        public void UserModificationTest()
        {
            
            UserData modify = new UserData("");
            modify.FirstName = ("Vasiliy");
            //modify.EMail = ("Petrov@mic.com");

            app.User.Modify(modify);
        }
    }
}
