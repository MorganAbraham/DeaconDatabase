using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Deacon_Database_Manager.Geographical
{
    class AddressConverter
    {
        public static double[] GetCoordinates(string SearchAddress)
        {
            double[] Result = new double[] { 0.0, 0.0 };
            string UrlString = @"http://maps.googleapis.com/maps/api/geocode/xml?&address=" + SearchAddress;
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(UrlString);
            XmlNodeList LocationNode = XmlDoc.GetElementsByTagName("location");

            string Lat = "";
            string Lon = "";
            try
            {
                Lat = LocationNode.Item(0)["lat"].InnerText;
                Lon = LocationNode.Item(0)["lng"].InnerText;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.Print(e.Message);
            }

            double d;
            if(double.TryParse(Lat, out d))
            {
                Result[0] = d;
            }
            if(double.TryParse(Lon, out d))
            {
                Result[1] = d;
            }

            return Result;
        }
    }
}

