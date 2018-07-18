using System;
using System.Xml;

namespace Deacon_Database_Manager.Geographical
{
    class AddressConverter
    {
        /// <summary>
        /// Finds the latitude or longitude of an address
        /// </summary>
        /// <param name="searchAddress"></param>
        /// <returns>An array containing the latitude and longitude of a given address</returns>
        public static double[] GetCoordinates(string searchAddress)
        {
            double[] result = new double[] { 0.0, 0.0 };
            string urlString = @"http://maps.googleapis.com/maps/api/geocode/xml?&address=" + searchAddress;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(urlString);
            XmlNodeList locationNode = xmlDoc.GetElementsByTagName("location");

            string lat = String.Empty;
            string lon = String.Empty;
            try
            {
                lat = locationNode.Item(0)["lat"].InnerText;
                lon = locationNode.Item(0)["lng"].InnerText;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
            }

            double d;
            if(double.TryParse(lat, out d))
            {
                result[0] = d;
            }
            if(double.TryParse(lon, out d))
            {
                result[1] = d;
            }

            return result;
        }
    }
}

