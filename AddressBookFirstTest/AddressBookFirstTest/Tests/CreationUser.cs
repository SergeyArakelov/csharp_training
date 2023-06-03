using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class CreationUser : TestBase
    {



        [Test]
        public void AddressBookCreationUser()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.User.AddNewUser();
            UserData newuser = new UserData("");
            newuser.FirstName = ("ivan");
            newuser.SecondName = ("ivanov");
            app.User.FillUserName(newuser);
            app.User.SubmitUserCreation();
            app.Auth.Logout();
        }
    }
}
