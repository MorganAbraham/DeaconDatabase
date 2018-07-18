using System;

namespace Deacon_Database_Manager.Geographical
{
    class DistanceCalculator
    {
        /// <summary>
        /// Gets the distance between two addresses in miles
        /// </summary>
        /// <param name="address1">An address starting point</param>
        /// <param name="address2">An address end point</param>
        /// <returns>The distance between two addresses in miles</returns>
        public static double GetDistance(string address1, string address2)
        {
            return GetDistance(new Location(address1), new Location(address2));
        }

        /// <summary>
        /// Gets the distance between two addresses in miles.
        /// </summary>
        /// <param name="location1">An address starting point</param>
        /// <param name="location2">An address end point</param>
        /// <returns>The distance between two addresses in miles</returns>
        public static double GetDistance(Location location1, Location location2)
        {
            if (location1 == null || location2 == null)
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

                    double lat1 = location1.Latitude;
                    double lon1 = location1.Longitude;
                    double lat2 = location2.Latitude;
                    double lon2 = location2.Longitude;

                    double latDelta = GetRadians(lat2 - lat1);
                    double lonDelta = GetRadians(lon2 - lon1);
                    double a = Math.Sin(latDelta / 2) * Math.Sin(latDelta / 2) +
                        Math.Cos(GetRadians(lat1)) * Math.Cos(GetRadians(lat2)) *
                        Math.Sin(lonDelta / 2) * Math.Sin(lonDelta / 2);
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
