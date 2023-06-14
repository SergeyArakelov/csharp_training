using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class CreationUserTests : AuthTestBase
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
