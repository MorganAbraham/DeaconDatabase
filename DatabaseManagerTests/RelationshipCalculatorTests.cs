using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Deacon_Database_Manager.MemberData;
namespace DatabaseManagerTests
{
    [TestClass]
    public class RelationshipCalculatorTests
    {
        [TestMethod]
        public void GetRelationship_Sibling()
        {
            string RelationToMember = "Parent";
            string RelationToRelation = "Parent";
            string ExpResult = "Sibling";
            RelationshipCalculator RCalc = new RelationshipCalculator();
            string Result = RCalc.GetRelationship(RelationToMember, RelationToRelation, true);
            Assert.AreEqual(ExpResult, Result);
        }


        [TestMethod]
        public void GetRelationship_GreatGreatGrandchild()
        {
            string RelationToMember = "Grandchild";
            string RelationToRelation = "Grandparent";
            string ExpResult = "Great-Great Grandchild";
            RelationshipCalculator RCalc = new RelationshipCalculator();
            string Result = RCalc.GetRelationship(RelationToMember, RelationToRelation, true);
            Assert.AreEqual(ExpResult, Result);

        }
        [TestMethod]
        public void GetRelationship_Null()
        {
            string RelationToMember = "Grandchild";
            string RelationToRelation = "Parent-In-Law";
            string ExpResult = null;
            RelationshipCalculator RCalc = new RelationshipCalculator();
            string Result = RCalc.GetRelationship(RelationToMember, RelationToRelation, false);
            Assert.AreEqual(ExpResult, Result);

        }
    }
}
