using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class UserModificationTests : UserTestBase
    {

        [Test]
        public void UserModificationTest()
        {
            if (!app.User.IsUserExist)
            {
                app.User.CreateEmptyUser();
            }
            

            //modify.EMail = ("Petrov@mic.com");
            List<UserData> oldUsers = UserData.GetAllUsers();
            UserData modify = oldUsers[0];
            modify.FirstName = "Vasiliy1";
            modify.SecondName = "Vasiliev";
            app.User.Modify(modify);

            List<UserData> newUsers = UserData.GetAllUsers();
            oldUsers[0].FirstName = modify.FirstName;
            oldUsers[0].SecondName = modify.SecondName;
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);


        }
    }
}
