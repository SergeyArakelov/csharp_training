using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;

namespace AddressBookTests
{
    public class DeletingUserFromGroups : AuthTestBase
    {
        
        //public void DeletingUserFromGroup()
        //{
        //    GroupData group = GroupData.GetAll()[1];
        //    List<UserData> oldList = group.GetUsers();
        //    UserData user = UserData.GetAllUsers().Except(oldList).First();

        //    app.User.DeleteUserToGroup(user, group);

        //    List<UserData> newList = group.GetUsers();
        //    oldList.Remove(user);
        //    newList.Sort();
        //    oldList.Sort();
        //    Assert.AreEqual(oldList, newList);
        //}
    }
}
