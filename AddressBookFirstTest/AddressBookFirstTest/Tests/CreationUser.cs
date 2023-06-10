using NUnit.Framework;

namespace AddressBookTests
{
    [SetUpFixture]
    public class CreationUserTests : TestBase
    {



        [Test]
        public void CreationUserTest()
        {
            
            UserData newuser = new UserData("");
            newuser.FirstName = ("petr");
            newuser.SecondName = ("Petrov");

            app.User.Create(newuser);
        }
    }
}
