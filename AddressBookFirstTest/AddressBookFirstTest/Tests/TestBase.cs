using NUnit.Framework;



namespace AddressBookTests
{
  public  class TestBase
    {
        
        protected ApplicationManager app;
        
        [SetUp]
        public void SetupTest()
        {
        
        app = new ApplicationManager();  
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
           
        }     
    }
}
