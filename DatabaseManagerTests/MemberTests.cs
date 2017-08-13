using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Deacon_Database_Manager.MemberData;
using System.Collections.Generic;

namespace DatabaseManagerTests
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void MemberComparerTest()
        {
            Member Member1 = new Member();
            Member Member2 = new Member();
            Member Member3 = new Member();

            Member1.FirstName = "Jane";
            Member1.LastName = "Smith";

            Member2.FirstName = "Jane";
            Member2.MiddleName = "Doe";
            Member2.LastName = "Smith";

            Member3.FirstName = "John";
            Member3.LastName = "Smith";

            List<Member> Members = new List<Member> { Member2, Member3, Member1 };
            Members.Sort();
            List<Member> ExpResult = new List<Member> { Member1, Member2, Member3 };
            CollectionAssert.AreEqual(Members, ExpResult);
        }

        [TestMethod]
        public void MemberEqualsTest()
        {
            Member Member1 = new Member();
            Member Member2 = new Member();

            Member1.FirstName = "Jane";
            Member1.LastName = "Smith";

            Member2.FirstName = "Jane";
            Member2.LastName = "Smith";

            Assert.AreEqual(Member1, Member2);
        }

        [TestMethod]
        public void MemberNotEqualTest()
        {
            Member Member1 = new Member();
            Member Member2 = new Member();

            Member1.FirstName = "John";
            Member1.LastName = "Smith";

            Member2.FirstName = "Jane";
            Member2.LastName = "Smith";

            Assert.AreNotEqual(Member1, Member2);
        }
    }
}
