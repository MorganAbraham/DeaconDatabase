using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeaconBaseLib.Geographical;

namespace DeaconBaseLibTests
{
    [TestClass]
    public class DistanceCalculatorTest
    {
        [TestMethod]
        public void GetDistance_AddressString()
        {
            string TimesSquare = "Times Square, Manhattan, NY 10036";
            string MadameTussaudsHollywood = "6933 Hollywood Blvd, Hollywood, CA 90028";
            double ExpResult = 2450.84;
            double Result = DistanceCalculator.GetDistance(TimesSquare, MadameTussaudsHollywood);
            Assert.IsTrue(Math.Abs(ExpResult - Result) <= 1);
        }

        [TestMethod]
        public void GetDistance_Location()
        {
            Location TimesSquare = new Location(40.758878, -73.985131);
            Location MadameTussaudsHollywood = new Location(34.101906, -118.341535);
            double ExpResult = 2450.84;
            double Result = DistanceCalculator.GetDistance(TimesSquare, MadameTussaudsHollywood);
            Assert.IsTrue(Math.Abs(ExpResult - Result) <= 1);
        }
    }
}
