using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]

    public class UserRemovalTests : TestBase
    {
        [Test]
        public void UserRemovalTestViaEdit()
        {
            app.User.RemoveViaEdit();
        }

        [Test]
        public void UserRemovalTest()
        {
            app.User.RemoveUser();
        }
    }
}
