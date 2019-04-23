using System;
using System.Reflection;

namespace DeaconBaseLib.Geographical
{
    public class Location
    {
        private string street;
        private string street2;
        private string city;
        private string state;
        private string zip;
        private string address;

        private double latitude;
        private double longitude;

        public string Street
        {
            get
            {
                return street ?? String.Empty;
            }

            set
            {
                street = value;
            }
        }

        public string Street2
        {
            get
            {
                return street2 ?? String.Empty;
            }

            set
            {
                street2 = value;
            }
        }

        public string City
        {
            get
            {
                return city ?? String.Empty;
            }

            set
            {
                city = value;
            }
        }

        public string State
        {
            get
            {
                return state ?? String.Empty;
            }

            set
            {
                state = value;
            }
        }

        public string Zip
        {
            get
            {
                return zip ?? String.Empty;
            }

            set
            {
                zip = value;
            }
        }

        public string Address
        {
            get
            {
                return address ?? String.Empty;
            }

            set
            {
                address = value;
            }
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
            }
        }

        /// <summary>
        /// Represents a physical location as a set of cooridnates and an address
        /// </summary>
        public Location() : this(0.0, 0.0) { }

        /// <summary>
        /// Represents a physical location as a set of coordinates and an address
        /// </summary>
        /// <param name="fullAddress">An Address to be converted into coordinates representing a location</param>
        public Location(string fullAddress)
        {
            this.Address = fullAddress;
            //ConvertAddress();
        }

        /// <summary>
        /// Represents a physical location as a set of coordinates and an address
        /// </summary>
        /// <param name="street">The Street Address of a location</param>
        /// <param name="street2">Additional Street Address Information (i.e. Apartment  Number)</param>
        /// <param name="city">The City of a location</param>
        /// <param name="state">The State Name of a location</param>
        /// <param name="zip">The zip code of a location</param>
        public Location(string street, string street2, string city, string state, string zip)
        {
            this.Street = street;
            this.Street2 = street2;
            this.City = city;
            this.State = state;
            this.Zip = zip;

            this.Address = street + ' ' + street2 + ',' + city + ',' + state + ' ' + zip;
            //ConvertAddress();
        }

        /// <summary>
        /// Represents a physical location as a set of coordinates and an address
        /// </summary>
        /// <param name="latitude">The latitude of a location</param>
        /// <param name="longitude">The longitude of a location</param>
        public Location(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        //private void ConvertAddress()
        //{
        //    //double[] Coordinates = AddressConverter.GetCoordinates(Address);
        //    //Latitude = Coordinates[0];
        //    //Longitude = Coordinates[1];
        //}

        public override bool Equals(object obj)
        {
            if(obj == null && this != null)
            {
                return false;
            }
            else if(this == null && obj != null)
            {
                return false;
            }
            PropertyInfo[] myFields = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] objFields = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for(int i = 0; i < myFields.Length; i++)
            {
                if(!myFields[i].GetValue(this, null).Equals(objFields[i].GetValue(obj, null)))
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
