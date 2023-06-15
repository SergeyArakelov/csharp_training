using NUnit.Framework;


namespace AddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupPage();
            if (!app.Groups.IsGroupExist)
            {
                app.Groups.EmptyGroupCreation();
            }
            app.Groups.Remove();
           
        }
    }
}