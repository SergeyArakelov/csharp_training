using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base(ProviderName.MySql, @"server=localhost; database=addressbook; port = 3306; Uid=root;Pwd=;charset=utf8; Allow Zero Datetime = true") { }

        public ITable<GroupData> Groups { get { return this.GetTable<GroupData>(); } }

        public ITable<UserData> Users { get { return this.GetTable<UserData>(); } }
    }
}
