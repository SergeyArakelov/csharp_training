using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AddressBookTests
{
[SetUpFixture]
public class TestSuitFixture
{
    public static ApplicationManager app;

    [SetUp]
    public void InitApplicationManager()
    {
            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Auth.Logout();

        }
        [TearDown]
        public void StopApplicationManager()
        {
            app.Stop();
        }

    }

}
