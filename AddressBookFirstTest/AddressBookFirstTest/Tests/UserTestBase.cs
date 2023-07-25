using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTests
{
    public class UserTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareUsersUI_DB()
        {
            if (Perform_Long_Check)
            {
                List<UserData> fromUI = app.User.GetUserList();
                List<UserData> fromDB = UserData.GetAllUsers();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}
