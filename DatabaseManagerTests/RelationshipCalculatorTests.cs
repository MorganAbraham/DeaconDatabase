using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Deacon_Database_Manager.MemberData;
namespace DatabaseManagerTests
{
    [TestClass]
    public class RelationshipCalculatorTests
    {
        [TestMethod]
        public void GetRelationship_Grandmother()
        {
            string RelationToMember = "Mother";
            string RelationToRelation = "Mother";
            string ExpResult = "Grandmother";
            RelationshipCalculator RCalc = new RelationshipCalculator();
            string Result = RCalc.GetRelationship(RelationToMember, RelationToRelation);
            Assert.AreEqual(ExpResult, Result);
        }


        [TestMethod]
        public void GetRelationship_Wife()
        {
            string RelationToMember = "Grandson";
            string RelationToRelation = "Grandmother";
            string ExpResult = "Wife";
            RelationshipCalculator RCalc = new RelationshipCalculator();
            string Result = RCalc.GetRelationship(RelationToMember, RelationToRelation);
            Assert.AreEqual(ExpResult, Result);

        }
        [TestMethod]
        public void GetRelationship_Null()
        {
            string RelationToMember = "Grandson";
            string RelationToRelation = "Mother-In-Law";
            string ExpResult = null;
            RelationshipCalculator RCalc = new RelationshipCalculator();
            string Result = RCalc.GetRelationship(RelationToMember, RelationToRelation);
            Assert.AreEqual(ExpResult, Result);

        }
    }
}
