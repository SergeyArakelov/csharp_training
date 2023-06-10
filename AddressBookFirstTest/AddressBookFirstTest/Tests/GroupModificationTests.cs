using OpenQA.Selenium;
using NUnit.Framework;

namespace AddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {

        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;


            app.Groups.Modify(1, newData);

        }
    }
}
