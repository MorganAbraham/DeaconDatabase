using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeaconBaseLib.Geographical;

namespace DeaconBaseLibTests
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void Location_FullAddressConstructor()
        {
            Location instance = new Location("970 Lake Carillon Drive, Saint Petersbug, FL 33716");
            double[] expResult = new double[] { 27.8896255, -82.6661437 };
            double[] result = new double[] { instance.Latitude, instance.Longitude };
            CollectionAssert.AreEqual(expResult, result);
        }

        [TestMethod]
        public void Location_AddressConstructor()
        {
            Location instance = new Location("970 Lake Carillon Drive", "", "Saint Petersbug", "FL", "33716");
            double[] expResult = new double[] { 27.8896255, -82.6661437 };
            double[] result = new double[] { instance.Latitude, instance.Longitude };
            CollectionAssert.AreEqual(expResult, result);
        }

        [TestMethod]
        public void Location_Equals()
        {
            Location x = new Location("Street", "Street2", "City", "State", "Zip");
            Location y = new Location("Street", "Street2", "City", "State", "Zip");
            Assert.AreEqual(x, y);
        }

        [TestMethod]
        public void Location_NotEqual()
        {
            Location x = new Location("Street", "Street2", "City", "State", "Zip");
            Location y = new Location("Street", "", "City", "State", "Zip");
            Assert.AreNotEqual(x, y);
        }
    }
}
