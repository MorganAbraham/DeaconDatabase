using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deacon_Database_Manager.Geographical;
using System.Text.RegularExpressions;

namespace Deacon_Database_Manager.MemberData
{
   
    public class Member
    {
        
        private int id;
        private string firstName = "";
        private string middleName = "";
        private string lastName = "";
        private string suffix = "";
        private string photoPath = "";


        private string gender = "";
        private DateTime birthDate;
        private string ethnicity = "";

        private string homeEmail = "";
        private string homePhone = "";
        private string emergencyContact = "";
        private string emergencyNumber = "";

        private Location address = new Location();

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = string.IsNullOrEmpty(value) ? "" : value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }

            set
            {
                middleName = string.IsNullOrEmpty(value) ? "" : value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = string.IsNullOrEmpty(value) ? "" : value;
            }
        }

        public string PhotoPath
        {
            get
            {
                return photoPath;
            }

            set
            {
                photoPath = string.IsNullOrEmpty(value) ? "NoPhoto" : value;
            }
        }

        public string Suffix
        {
            get
            {
                return suffix;
            }

            set
            {
                suffix = value;
            }
        }

        internal Location Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
            }
        }

        public string Ethnicity
        {
            get
            {
                return ethnicity;
            }

            set
            {
                ethnicity = value;
            }
        }

        public string HomeEmail
        {
            get
            {
                return homeEmail;
            }

            set
            {
                homeEmail = value;
            }
        }

        public string HomePhone
        {
            get
            {
                return homePhone;
            }

            set
            {
                homePhone = value;
                if(!string.IsNullOrEmpty(homePhone))
                {
                    homePhone = Regex.Replace(homePhone, "[^0-9]", "");
                }
            }
        }

        public string EmergencyContact
        {
            get
            {
                return emergencyContact;
            }

            set
            {
                emergencyContact = value;
            }
        }

        public string EmergencyNumber
        {
            get
            {
                return emergencyNumber;
            }

            set
            {
                emergencyNumber = value;
                if(!string.IsNullOrEmpty(emergencyNumber))
                {
                    emergencyNumber = Regex.Replace(emergencyNumber, "[^0-9]", "");
                }
            }
        }
    }
}
