using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBookTests
{
  public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllEmails { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }     
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Address { get; set; }

        public string allInfo;


        public string AllInfo
        {
            get
            {
                if (allInfo != null)
                {
                    return allInfo;
                }
                else
                {
                    return FirstName + " " +  SecondName + "\r\n" + Address + "\r\n" + "\r\n" + CleanUpHomePhone(HomePhone + "\r\n") + CleanUpMobilePhone(MobilePhone + "\r\n") + CleanUpWorkPhone(WorkPhone + "\r\n") + "\r\n" + Email.Trim();
                    
                }
            }
            set

            {
                allInfo = value;
            }
        }

        public string CleanUpWorkPhone (string WorkPhone)
        {
            if (WorkPhone != "" || WorkPhone != null)
            {
                return "W: " + WorkPhone;
            }
            return "";
        }
        public string CleanUpHomePhone(string HomePhone)
        {
            
                if (HomePhone != "")
                {
                    return "H: " + HomePhone;
                }
                return "";
        }
            public string CleanUpMobilePhone(string MobilePhone) 
            {
                if (MobilePhone != " " || WorkPhone != null)
                {
                    
                return "M: " + MobilePhone;

            }
            return "";

        }
         


        public string allPhones;

        public string AllPhones { 
            
            get 
            { 
                if (allPhones != null) 
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            } 
            set 
            
            {
                allPhones = value;
            } 
        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            StringBuilder sb = new StringBuilder(phone);
            sb.Replace(" ", "");
            sb.Replace("-", "");
            sb.Replace("(", "");
            sb.Replace(")", "");
            sb.Append("\r");
            sb.Append("\n");
            

            return sb.ToString();
                //phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
                // return Regex.Replace(phone, "[ (-)HMW:]", "") + "\r\n";
        }

       




        public UserData(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
            
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
            return "firstName=" + FirstName + "\nsecondName " + SecondName + "\naddress " + Address +
                "\nhome" + HomePhone + "\nwork" + WorkPhone + "\nmobile" + MobilePhone + "\nemail" + Email;
        }

        public int CompareTo(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
           int result = FirstName.CompareTo(other.FirstName);
            if (result != 0)
            {
                return result;
            }
            else
            {
                return SecondName.CompareTo(other.SecondName);
            }
        }
    }
}


