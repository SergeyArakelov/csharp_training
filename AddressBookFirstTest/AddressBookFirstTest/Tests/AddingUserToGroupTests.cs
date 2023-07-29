using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AddressBookTests
{
    public class AddingUserToGroupTests : AuthTestBase
    {
        [Test]
        public void AddingUserToGroupTest()
        {
            GroupData group = GroupData.GetAll()[2];
            List<UserData> oldList = group.GetUsers();
            UserData user = UserData.GetAllUsers().Except(oldList).First();

            //actions
            app.User.AddUserToGroup(user, group);

            List<UserData> newList = group.GetUsers();
            oldList.Add(user);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
