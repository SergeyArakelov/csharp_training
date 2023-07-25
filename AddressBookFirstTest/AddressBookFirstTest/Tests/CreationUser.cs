using Newtonsoft.Json;
using NUnit.Framework;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace AddressBookTests
{
    [TestFixture]
    public class CreationUserTests : UserTestBase
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
       public static IEnumerable<UserData> UserDataFromXmlFile()
       {

           return (List<UserData>)new XmlSerializer(typeof(List<GroupData>))
               .Deserialize(new StreamReader(@"users.xml"));

       }
        public static IEnumerable<UserData> UserDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<UserData>>(
                 File.ReadAllText(@"users.json"));
       }

        

        [Test, TestCaseSource("UserDataFromXmlFile")]
        public void CreationUserTest(UserData username)
        {
            
            

            List<UserData> oldUsers = UserData.GetAllUsers();

            app.User.Create(username);

           List<UserData> newUsers = UserData.GetAllUsers();
            oldUsers.Add(username);
            oldUsers.Sort();
            newUsers.Sort();
            Assert.AreEqual(oldUsers, newUsers);
        }

       
    }
}
