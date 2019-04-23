using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeaconBaseLib.Geographical;

namespace DeaconBaseLibTests
{
    [TestClass]
    public class AddressConverterTests
    {
        [TestMethod]
        public void TestGetCoordinates_Zip()
        {
            string Zip = "33716";
            double[] ExpResult = new double[] { 27.8756643, -82.6537455 };
            double[] Result = AddressConverter.GetCoordinates(Zip);
            CollectionAssert.AreEqual(ExpResult, Result);
        }

        [TestMethod]
        public void TestGetCooridnates_Address()
        {
            string AddressString = "970 Lake Carillon Drive Suite 400, Saint Petersburg, FL 33716";
            double[] ExpResult = new double[] { 27.8896255, -82.6661437 };
            double[] Result = AddressConverter.GetCoordinates(AddressString);
            CollectionAssert.AreEqual(ExpResult, Result);
        }
    }
}
