using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using LinqToDB.Mapping;

namespace AddressBookTests
{
    [Table(Name = "addressbook")]
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }
        [Column(Name = "work")]
        public string WorkPhone { get; set; }
        
        public string AllEmails { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "lastname")]
        public string SecondName { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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
                    return FirstName + " " +  SecondName  + Address  + CleanUpHomePhone(HomePhone)  + CleanUpMobilePhone(MobilePhone)  + CleanUpWorkPhone(WorkPhone) + CleanUpEmail(Email);
                    
                }
            }
            set

            {
                allInfo = value;
            }
        }

        public string CleanUpWorkPhone (string WorkPhone)
        {
            if (WorkPhone != "")
            {
                return "\r\n" + "\r\n" + "W: " + WorkPhone ;
            }
            return "";
        }
            public string CleanUpHomePhone(string HomePhone)
            {
            
                if (HomePhone != "")
                {
                    return "\r\n" + "\r\n" + "H: " + HomePhone ;
                }
                return "";
            }
        public string CleanUpMobilePhone(string MobilePhone)
        {
            if (MobilePhone != "")
            {

                return "\r\n" + "\r\n" + "M: " + MobilePhone;

            }
            return "";
        }
            public string CleanUpEmail(string Email)
            {
                if (Email != "")
                {
                    return "\r\n" + "\r\n" +  Email;
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

       

        public UserData()
        {

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
        public static List<UserData> GetAllUsers()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from u in db.Users.Where(x => x.Deprecated == "0000-00-00 00:00:00") select u).ToList();
            }

        }
    }
}


