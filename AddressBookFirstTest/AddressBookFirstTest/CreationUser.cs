using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class CreationUser : TestBase
    {



        [Test]
        public void AddressBookCreationUser()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewUser();
            UserData newuser = new UserData("");
            newuser.FirstName = ("ivan");
            newuser.SecondName = ("ivanov");
            FillUserName(newuser);
            SubmitUserCreation();
            BackToHomePage();
            Logout();
        }
    }
}
