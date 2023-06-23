using NUnit.Framework;
using System.Security.Cryptography;

namespace AddressBookTests
{
    [TestFixture]
    public class CreationUserTests : AuthTestBase
    {



        [Test]
        public void CreationUserTest()
        {
            
            UserData newuser = new UserData("");
           newuser.FirstName = "petr";
            newuser.SecondName = "Petrov";

           // List<UserData> oldUsers = app.User.GetUserList();

            app.User.Create(newuser);

           // List<UserData> newUsers = app.User.GetUserList();
            
            //oldUsers.Sort();
            //newUsers.Sort();
            //Assert.AreEqual(oldUsers, newUsers);
        }

       
    }
}
