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
                    return CleanUpAllForm(allInfo);
                }
                else
                {
                    return CleanUpAllForm(FirstName + SecondName + Address + HomePhone + MobilePhone + WorkPhone + Email).Trim();
                    //return CleanUpAllForm(FirstName + SecondName) + CleanUpAllForm(Address)+ CleanUpAllForm(HomePhone) + CleanUpAllForm(MobilePhone) + CleanUpAllForm(WorkPhone) + CleanUpAllForm(Email).Trim();
                }
            }
            set

            {
                allInfo = value;
            }
        }

        public string CleanUpAllForm(string fullInfo)
        {
            if (fullInfo == null || fullInfo == "")
            {
                return "";
            }
    
            return fullInfo.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("H", "").Replace("M", "").Replace("W", "").Replace(":", "").Replace("\r", "").Replace("\n", "");

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
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
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

        public  int CompareTo(UserData other)
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
