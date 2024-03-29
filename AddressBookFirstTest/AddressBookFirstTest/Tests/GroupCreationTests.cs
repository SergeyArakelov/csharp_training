using NUnit.Framework;
using System.Xml;
using NUnit.Framework.Constraints;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(30)
                });
            }
            return groups;
        }

       public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines) 
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                    {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }
        //public static IEnumerable<GroupData> GroupDataFromXmlFile()
        //{

        //   return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));

        //}
        //public static IEnumerable<GroupData> GroupDataFromJsonFile()
        //{
        //   return JsonConvert.DeserializeObject<List<GroupData>>(
        //        File.ReadAllText(@"groups.json"));
        //}

        //[Test, TestCaseSource("GroupDataFromXmlFile")]
        
        public void GroupCreationTest(GroupData group)
        {


            List<GroupData> oldGroups = GroupData.GetAll();
            app.Groups.Create(group);


            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void TestDB() 
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<GroupData> fromDB = GroupData.GetAll();    

            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
        [Test]
        public void TestDBConnectivity() {
          foreach(UserData user in GroupData.GetAll()[0].GetUsers())
            {
                Console.Out.WriteLine(user);
            }
        }
    }
}
