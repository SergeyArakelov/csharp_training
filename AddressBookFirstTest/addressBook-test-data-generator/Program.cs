using AddressBookTests;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressBook
{
class Program
{
    static void Main(string[] args)
    {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10)){
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                        });
 
            }

            List<UserData> users = new List<UserData>();
            for (int y = 0; y < count; y++)
            {
                users.Add(new UserData(TestBase.GenerateRandomString(15), TestBase.GenerateRandomString(15))
                {
                    MobilePhone = TestBase.GenerateRandomString(15),
                    WorkPhone = TestBase.GenerateRandomString(15),
                    Email = TestBase.GenerateRandomString(15),
                    Address = TestBase.GenerateRandomString(15)
                });
            }
            //System.Console.Out.Write(TestBase.GenerateRandomString(10));
            if (format == "csv")
            {
                writeGroupsToCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                writeGroupsToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                writeGroupsToJsonFile(groups, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
             if (format == "xml")
            {
                writeUsersToXmlFile(users, writer);
            }
            else if (format == "json")
            {
                writeUsersToJsonFile(users, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
            writer.Close();
    }
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
           foreach(GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }

        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        static void writeUsersToXmlFile(List<UserData> users, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, users);
        }

        static void writeUsersToJsonFile(List<UserData> users, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented));
        }
    }
}

