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
            List<UserData> oldUsers = UserData.GetAllUsers();
            UserData ToBeRemoved = oldUsers[0];

            app.User.RemoveUser(ToBeRemoved);

            List<UserData> newUsers = UserData.GetAllUsers();

            oldUsers.RemoveAt(0);
            oldUsers.Sort();
            newUsers.Sort();

            Assert.AreEqual(oldUsers, newUsers);
        }
    }
}
