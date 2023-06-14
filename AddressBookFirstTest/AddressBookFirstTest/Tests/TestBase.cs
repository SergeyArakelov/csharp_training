using NUnit.Framework;



namespace AddressBookTests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {

            app = ApplicationManager.GetInstance();

        }


        [OneTimeTearDown]
        public void StopApplicationManager()
        {
            ApplicationManager.Stop();
        }
    }
}
