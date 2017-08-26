using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Deacon_Database_Manager.MemberData
{
    class Deacon
    {
        private int id = -1;
        private string firstName = "";
        private string lastName = "";
        private string region = "";
        private int memberCount = 0;

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
                firstName = value;
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
                lastName = value;
            }
        }

        public int MemberCount
        {
            get
            {
                return memberCount;
            }

            set
            {
                memberCount = value;
            }
        }

        public string Region
        {
            get
            {
                return region;
            }

            set
            {
                region = value;
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
    }
}
