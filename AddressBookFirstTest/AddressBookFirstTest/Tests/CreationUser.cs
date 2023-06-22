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
            List<UserData> oldFirstNames = app.User.GetFirstNameList();
            List<UserData> oldSecondNames = app.User.GetSecondNameList();

            app.User.Create(newuser);

            // List<UserData> newUsers = app.User.GetUserList();
            List<UserData> newFirstNames = app.User.GetFirstNameList();
            List<UserData> newSecondNames = app.User.GetSecondNameList();
            oldFirstNames.Add(newuser);
            oldSecondNames.Add(newuser);
            oldFirstNames.Sort();
            oldSecondNames.Sort();
            newFirstNames.Sort();
            newSecondNames.Sort();
           // oldUsers.Sort();
            //newUsers.Sort();
           // Assert.AreNotEqual(oldUsers, newUsers);
           Assert.AreNotEqual(oldFirstNames, newFirstNames);
            Assert.AreNotEqual(oldSecondNames, newSecondNames);
        }

       
    }
}
