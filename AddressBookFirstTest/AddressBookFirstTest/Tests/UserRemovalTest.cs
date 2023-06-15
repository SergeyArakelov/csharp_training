using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]

    public class UserRemovalTests : AuthTestBase
    {
        //[Test]
        //public void UserRemovalTestViaEdit()
        //{
           // app.User.RemoveViaEdit();
       // }

        [Test]
        public void UserRemovalTest()
        {
            if (!app.User.IsUserExist)
            {
                app.User.CreateEmptyUser();
            }
            // выполняем основной сценарий
            app.User.RemoveUser();
            
        }
    }
}
