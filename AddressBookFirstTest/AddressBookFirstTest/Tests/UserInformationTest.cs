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
            UserData fromForm = app.User.GetContactInformationFromEditForm(0);

            Assert.That(fromForm, Is.EqualTo(fromTable));
            Assert.That(fromForm.Address, Is.EqualTo(fromTable.Address));
            Assert.That(fromForm.AllPhones, Is.EqualTo(fromTable.AllPhones));
        }

        [Test]
        public void TestContactInformationDetailsandForm()
        {
            UserData fromForm = app.User.GetContactInformationFromEditForm(0);
            UserData fromDetails = app.User.GetContactInformationFromDetails();
           // Assert.That(actual: fromDetails.AllInfo, Is.EqualTo(fromForm.AllInfo));

            string fromFormInfo = fromForm.AllInfo;
            string fromDetailsInfo = fromDetails.AllInfo;
            StringAssert.AreEqualIgnoringCase(expected: fromForm.AllInfo, actual: fromDetails.AllInfo);
        }
    }
}
