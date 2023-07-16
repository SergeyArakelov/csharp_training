using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]

    public class UserRemovalTests : AuthTestBase
    {
        //[Test]
        //public void UserRemovalTestViaEdit()
        //{
           // app.User.RemoveViaEdit();
       // }

        [Test]
        public void UserRemovalTest()
        {
            if (!app.User.IsUserExist)
            {
                app.User.CreateEmptyUser();
            }
            List<UserData> oldUsers = app.User.GetUserList();

            app.User.RemoveUser();

            List<UserData> newUsers = app.User.GetUserList();

            oldUsers.RemoveAt(0);

            Assert.AreEqual(oldUsers, newUsers);
        }
    }
}
