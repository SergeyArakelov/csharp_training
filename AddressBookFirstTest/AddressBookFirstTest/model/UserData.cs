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
        
        public string FirstName { get; set; }
        
        public string SecondName { get; set; }



            public UserData(string username)
            {
            username = username;
            }



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
