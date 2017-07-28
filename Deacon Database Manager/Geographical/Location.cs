using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deacon_Database_Manager.Geographical
{
    class Location
    {
        private string street = "";
        private string street2 = "";
        private string city = "";
        private string state = "";
        private string zip = "";
        private string address;

        private double latitude;
        private double longitude;

        public string Street
        {
            get
            {
                return street;
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
                return street2;
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
                return city;
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
                return state;
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
                return zip;
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
                return address;
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

        public Location() : this(0.0, 0.0) { }

        public Location(string FullAddress)
        {
            this.Address = FullAddress;
            ConvertAddress();
        }

        public Location(string Street, string Street2, string City, string State, string Zip)
        {
            this.Street = Street;
            this.Street = Street2;
            this.City = City;
            this.State = State;
            this.Zip = Zip;

            this.Address = Street + ' ' + Street2 + ',' + City + ',' + State + ' ' + Zip;
            ConvertAddress();
        }

        public Location(double Latitude, double Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }

        private void ConvertAddress()
        {
            double[] Coordinates = AddressConverter.GetCoordinates(Address);
            Latitude = Coordinates[0];
            Longitude = Coordinates[1];
        }

    }
}
