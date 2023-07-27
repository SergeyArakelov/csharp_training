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
            UserData modify = new UserData("Vasiliy1","Vasiliev");

            //modify.EMail = ("Petrov@mic.com");
            List<UserData> oldUsers = UserData.GetAllUsers();
            
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
