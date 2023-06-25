using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class UserInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            UserData fromTable = app.User.GetContactInformationFromTable(0);
            UserData fromFrom = app.User.GetContactInformationFromEditForm(0);

            Assert.That(fromFrom, Is.EqualTo(fromTable));
            Assert.That(fromFrom.Address, Is.EqualTo(fromTable.Address));
            Assert.That(fromFrom.AllPhones, Is.EqualTo(fromTable.AllPhones));
        }
    }
}
