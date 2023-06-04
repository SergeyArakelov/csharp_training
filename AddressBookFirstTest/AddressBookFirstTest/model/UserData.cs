using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookTests
{
  public class UserData 
    {
        internal string Company;
        internal string EMail;
        private string firstname = "";
        private string secondname = "";

        public UserData(string username)
        {
            firstname = firstname;
            secondname = secondname;
        }


        
        
        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string SecondName
        {
            get
            {
                return secondname;
            }
            set
            {
                secondname = value;
            }
        }
    }
}
