using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBookTests
{
  public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        // internal string Company;
        // internal string EMail;
        private string firstname = "";
        private string secondname = "";
        private string newuser;
       

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
        

        public UserData(string newuser)
        {
            this.newuser = newuser;
            firstname = firstname;
            secondname = secondname;
        }
       //public FirstName(string firstnames)
       // {
       //     this.firstname = firstnames;
       // }


        public bool Equals(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, null))
            {
                return true;
            }
            return FirstName == other.FirstName && SecondName == other.SecondName;



        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + SecondName.GetHashCode();
        }
        

        public override string ToString()
        {
            return "firstName=" + FirstName + "secondName " + SecondName;
        }

        public  int CompareTo(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
           if (SecondName == other.SecondName)
            {
                FirstName.CompareTo(other.FirstName);
                 
            }
            return SecondName.CompareTo(other.SecondName);
            
        }
    }
}
