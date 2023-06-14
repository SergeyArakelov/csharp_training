using NUnit.Framework;


namespace AddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            
            app.Groups.Remove();
           
        }
    }
}