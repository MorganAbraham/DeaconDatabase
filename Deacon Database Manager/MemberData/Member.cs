using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Deacon_Database_Manager.Geographical;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Drawing;

namespace Deacon_Database_Manager.MemberData
{
   
    public class Member : IComparable<Member>
    {
        
        private int id;
        private string firstName = "";
        private string middleName = "";
        private string lastName = "";
        private string suffix = "";
        private Image profilePicture = Properties.Resources.NoPhoto;


        private string gender = "";
        private DateTime birthDate;
        private string ethnicity = "";

        private string homeEmail = "";
        private string homePhone = "";
        private string emergencyContact = "";
        private string emergencyNumber = "";

        private DateTime membershipStart;
        private DateTime membershipEnd;
        private string previousChurch = "";

        private Location address = new Location();
        private Deacon deaconInfo = new Deacon();

        private string comments = "";
        public  Member()
        {
            //Image img 
        }
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

        public DateTime MembershipStart
        {
            get
            {
                return membershipStart;
            }

            set
            {
                membershipStart = value;
            }
        }

        public DateTime MembershipEnd
        {
            get
            {
                return membershipEnd;
            }

            set
            {
                membershipEnd = value;
            }
        }

        public string PreviousChurch
        {
            get
            {
                return previousChurch;
            }

            set
            {
                previousChurch = value;
            }
        }

        public Image ProfilePicture
        {
            get
            {
                return profilePicture;
            }

            set
            {
                profilePicture = value;
            }
        }


        internal Deacon DeaconInfo
        {
            get
            {
                return deaconInfo;
            }

            set
            {
                deaconInfo = value;
            }
        }

        public string Comments
        {
            get
            {
                return comments;
            }

            set
            {
                comments = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null && this != null)
            {
                return false;
            }
            else if (this == null && obj != null)
            {
                return false;
            }
            PropertyInfo[] MyFields = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] ObjFields = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < MyFields.Length; i++)
            {
                if (!MyFields[i].GetValue(this, null).Equals(ObjFields[i].GetValue(obj, null)))
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(Member other)
        {
            if(other == null)
            {
                return 1;
            }
            if(!string.Equals(this.LastName, other.LastName, StringComparison.OrdinalIgnoreCase))
            {
                return this.LastName.CompareTo(other.LastName);
            }
            
            if(!string.Equals(this.FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase))
            {
                return this.FirstName.CompareTo(other.FirstName);
            }

            return this.MiddleName.CompareTo(other.MiddleName);
        }
    }
}
