using Deacon_Database_Manager.Geographical;
using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Deacon_Database_Manager.MemberData
{

    public class Member : IComparable<Member>
    {
        
        private int id;
        private string firstName;
        private string middleName;
        private string lastName;
        private string suffix;
        private Image profilePicture = Properties.Resources.NoPhoto;

        private string gender;
        private DateTime birthDate;
        private string ethnicity;

        private string homeEmail;
        private string homePhone;
        private string emergencyContact;
        private string emergencyNumber;

        private DateTime membershipStart;
        private DateTime membershipEnd;
        private string previousChurch;

        private Location address = new Location();
        private Deacon deaconInfo = new Deacon();

        private DateTime lastContactDate = DateTime.MinValue;
        private DateTime nextContactDate = DateTime.MinValue;

        private string comments;

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
                return firstName ?? String.Empty;
            }

            set
            {
                firstName = value ?? String.Empty;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName ?? String.Empty;
            }

            set
            {
                middleName = value ?? String.Empty;
            }
        }

        public string LastName
        {
            get
            {
                return lastName ?? String.Empty;
            }

            set
            {
                lastName = value ?? String.Empty;
            }
        }

        public string Suffix
        {
            get
            {
                return suffix ?? String.Empty;
            }

            set
            {
                suffix = value ?? String.Empty;
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
                return gender ?? String.Empty;
            }

            set
            {
                gender = value ?? String.Empty;
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
                return ethnicity ?? String.Empty;
            }

            set
            {
                ethnicity = value ?? String.Empty;
            }
        }

        public string HomeEmail
        {
            get
            {
                return homeEmail ?? String.Empty;
            }

            set
            {
                homeEmail = value ?? String.Empty;
            }
        }

        public string HomePhone
        {
            get
            {
                return homePhone ?? String.Empty;
            }

            set
            {
                homePhone = value ?? String.Empty;
                homePhone = Regex.Replace(homePhone, "[^0-9]", String.Empty);
            }
        }

        public string EmergencyContact
        {
            get
            {
                return emergencyContact ?? String.Empty;
            }

            set
            {
                emergencyContact = value ?? String.Empty;
            }
        }

        public string EmergencyNumber
        {
            get
            {
                return emergencyNumber ?? String.Empty;
            }

            set
            {
                emergencyNumber = value ?? String.Empty;
                emergencyNumber = Regex.Replace(emergencyNumber, "[^0-9]", String.Empty);
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
                return previousChurch ?? String.Empty;
            }

            set
            {
                previousChurch = value ?? String.Empty;
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
                return comments ?? String.Empty;
            }

            set
            {
                comments = value ?? String.Empty;
            }
        }

        public DateTime LastContactDate
        {
            get
            {
                return lastContactDate;
            }

            set
            {
                lastContactDate = value;
            }
        }

        public DateTime NextContactDate
        {
            get
            {
                return nextContactDate;
            }

            set
            {
                nextContactDate = value;
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
            PropertyInfo[] myFields = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] objFields = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < myFields.Length; i++)
            {
                if(myFields[i].GetValue(this,null).GetType() == typeof(Bitmap))
                {
                    continue;
                }
                if (!myFields[i].GetValue(this, null).Equals(objFields[i].GetValue(obj, null)))
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
