using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class CreationUser : TestBase
    {



        [Test]
        public void AddressBookCreationUser()
        {
            
            UserData newuser = new UserData("");
            newuser.FirstName = ("ivan");
            newuser.SecondName = ("ivanov");

            app.User.Create(newuser);
        }
    }
}
