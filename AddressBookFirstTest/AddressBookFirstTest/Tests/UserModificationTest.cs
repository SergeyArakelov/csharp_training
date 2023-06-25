using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class UserModificationTests : AuthTestBase
    {

        [Test]
        public void UserModificationTest()
        {
            if (!app.User.IsUserExist)
            {
                app.User.CreateEmptyUser();
            }
            UserData modify = new UserData("Vasiliy","Vasiliev");
            
            //modify.EMail = ("Petrov@mic.com");

            app.User.Modify(modify);
        }
    }
}
