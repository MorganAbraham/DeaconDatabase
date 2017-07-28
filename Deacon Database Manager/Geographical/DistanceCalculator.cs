using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deacon_Database_Manager.Geographical
{
    class DistanceCalculator
    {
        public DistanceCalculator()
        {

        }

        public static double GetDistance(string Address1, string Address2)
        {
            return GetDistance(new Location(Address1), new Location(Address2));
        }

        public static double GetDistance(Location Location1, Location Location2)
        {
            if (Location1 == null || Location2 == null)
            {
                return -1;
            }
                /*
                 * R is the radius of the Earth
                 * 3959 in miles
                 * 6371 in Kilometers
                 * ΔLat = Lat2 - Lat1
                 * ΔLon = Lon2 - Lon1
                 * a = sin2 (ΔLat / 2) + cos(Lat1).cos(Lat2). sin2 (ΔLat / 2)
                 * c = 2.atan2(√a, √(1-a))
                 * d = R.c //Distance
                 * */

                try
                {
                    int R = 3959;

                    double Lat1 = Location1.Latitude;
                    double Lon1 = Location1.Longitude;
                    double Lat2 = Location2.Latitude;
                    double Lon2 = Location2.Longitude;

                    double LatDelta = GetRadians(Lat2 - Lat1);
                    double LonDelta = GetRadians(Lon2 - Lon1);
                    double a = Math.Sin(LatDelta / 2) * Math.Sin(LatDelta / 2) +
                        Math.Cos(GetRadians(Lat1)) * Math.Cos(GetRadians(Lat2)) *
                        Math.Sin(LonDelta / 2) * Math.Sin(LonDelta / 2);
                    double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                    double d = R * c;
                    return d;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.Print(e.Message);
                    return -1;
                }
            }

        private static double GetRadians(double Degrees)
        {
            return (Degrees * Math.PI) / 180.0;
        }
    }

        
}
