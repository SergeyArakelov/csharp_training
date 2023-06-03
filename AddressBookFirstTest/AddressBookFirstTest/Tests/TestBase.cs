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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Auth.Logout();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
           
        }     
    }
}
