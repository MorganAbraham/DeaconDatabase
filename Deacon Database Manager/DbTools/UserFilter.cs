using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deacon_Database_Manager.DbTools
{
    class UserFilter
    {
        private string memberName;
        private int deaconId = -1;
        private string birthMonth;
        private string memberAddress;
        private int milesFromAddress;
        private int minimumAge;
        private int maximumAge = 150;
        private int minimumMembership;

        public string MemberName
        {
            get
            {
                return memberName ?? String.Empty;
            }

            set
            {
                memberName = value;
            }
        }

        public string BirthMonth
        {
            get
            {
                return birthMonth ?? String.Empty;
            }

            set
            {
                birthMonth = value;
            }
        }

        public string MemberAddress
        {
            get
            {
                return memberAddress ?? String.Empty;
            }

            set
            {
                memberAddress = value;
            }
        }

        public int MilesFromAddress
        {
            get
            {
                return milesFromAddress;
            }

            set
            {
                milesFromAddress = value;
            }
        }

        public int MinimumAge
        {
            get
            {
                return minimumAge;
            }

            set
            {
                minimumAge = value;
            }
        }

        public int MaximumAge
        {
            get
            {
                return maximumAge;
            }

            set
            {
                maximumAge = value;
            }
        }

        public int MinimumMembership
        {
            get
            {
                return minimumMembership;
            }

            set
            {
                minimumMembership = value;
            }
        }

        public int DeaconId
        {
            get
            {
                return deaconId;
            }

            set
            {
                deaconId = value;
            }
        }
    }
}
