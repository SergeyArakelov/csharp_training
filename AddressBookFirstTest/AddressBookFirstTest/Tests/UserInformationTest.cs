using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class UserInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationTableandForm()
        {
            UserData fromTable = app.User.GetContactInformationFromTable(0);
            UserData fromFrom = app.User.GetContactInformationFromEditForm(0);

            Assert.That(fromFrom, Is.EqualTo(fromTable));
            Assert.That(fromFrom.Address, Is.EqualTo(fromTable.Address));
            Assert.That(fromFrom.AllPhones, Is.EqualTo(fromTable.AllPhones));
        }

        [Test]
        public void TestContactInformationDetailsandForm()
        {
            UserData fromFrom = app.User.GetContactInformationFromEditForm(0);
            //UserData fromDetails = app.User.GetContactInformationFromDetails(0);
        }
    }
}
