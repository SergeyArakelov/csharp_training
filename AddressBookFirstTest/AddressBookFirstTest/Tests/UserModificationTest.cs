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
            List<UserData> oldUsers = app.User.GetUserList();
            app.User.Modify(modify);
            List<UserData> newUsers = app.User.GetUserList();
    
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);


        }
    }
}
