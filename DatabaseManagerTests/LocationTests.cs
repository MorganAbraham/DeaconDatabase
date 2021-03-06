﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Deacon_Database_Manager.Geographical;

namespace DatabaseManagerTests
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void Location_FullAddressConstructor()
        {
            Location Instance = new Location("970 Lake Carillon Drive, Saint Petersbug, FL 33716");
            double[] ExpResult = new double[] { 27.8896255, -82.6661437 };
            double[] Result = new double[] { Instance.Latitude, Instance.Longitude };
            CollectionAssert.AreEqual(ExpResult, Result);
        }

        [TestMethod]
        public void Location_AddressConstructor()
        {
            Location Instance = new Location("970 Lake Carillon Drive", "", "Saint Petersbug", "FL", "33716");
            double[] ExpResult = new double[] { 27.8896255, -82.6661437 };
            double[] Result = new double[] { Instance.Latitude, Instance.Longitude };
            CollectionAssert.AreEqual(ExpResult, Result);
        }

        [TestMethod]
        public void Location_Equals()
        {
            Location Location1 = new Location("Street", "Street2", "City", "State", "Zip");
            Location Location2 = new Location("Street", "Street2", "City", "State", "Zip");
            Assert.AreEqual(Location1, Location2);
        }

        [TestMethod]
        public void Location_NotEqual()
        {
            Location Location1 = new Location("Street", "Street2", "City", "State", "Zip");
            Location Location2 = new Location("Street", "", "City", "State", "Zip");
            Assert.AreNotEqual(Location1, Location2);
        }
    }
}
