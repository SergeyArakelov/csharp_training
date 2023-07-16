using NUnit.Framework;
using System.Security.Cryptography;

namespace AddressBookTests
{
    [TestFixture]
    public class CreationUserTests : AuthTestBase
    {


        public static IEnumerable<UserData> RandomUserDataProvider()
        {
            List<UserData> users = new List<UserData>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new UserData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address = GenerateRandomString(100),
                    HomePhone = GenerateRandomString(30),
                    WorkPhone = GenerateRandomString(30),
                    MobilePhone = GenerateRandomString(30),
                    Email = GenerateRandomString(30)
                    
                });
            }
            return users;
        }
        
        
        [Test, TestCaseSource("RandomUserDataProvider")]
        public void CreationUserTest(UserData username)
        {
            
            

            List<UserData> oldUsers = app.User.GetUserList();

            app.User.Create(username);

           List<UserData> newUsers = app.User.GetUserList();
            oldUsers.Add(username);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);
        }

       
    }
}
