using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Iteration6
{
    [TestFixture]
    public class TestIdentifiableObject
    {

        [Test]
        public void TestAreYou()
        {
            string[] testArray = ["Fred", "Bob"];
            IdentifiableObject testIdentifiableObject = new(testArray);
            Assert.That(testIdentifiableObject.AreYou("fred"), Is.True);
        }

        [Test]
        public void TestNotAreYou()
        {
            string[] testArray = ["Fred", "Bob"];
            IdentifiableObject testIdentifiableObject = new(testArray);
            Assert.That(testIdentifiableObject.AreYou("wilma"), Is.False);
        }

        [Test]
        public void TestCaseSensitive()
        {
            string[] testArray = ["Fred", "Bob"];
            IdentifiableObject testIdentifiableObject = new(testArray);
            Assert.That(testIdentifiableObject.AreYou("bOB"), Is.True);
        }

        [Test]
        public void TestFirstID()
        {
            string[] testArray = ["Fred", "Bob"];
            IdentifiableObject testIdentifiableObject = new(testArray);
            StringAssert.AreEqualIgnoringCase("fred", testIdentifiableObject.FirstID);
        }

        [Test]
        public void TestFirstIDWithNoIDs()
        {
            string[] testArray = [];
            IdentifiableObject testIdentifableObject = new(testArray);
            StringAssert.AreEqualIgnoringCase("", testIdentifableObject.FirstID);
        }

        [Test]
        public void TestAddID()
        {
            string[] testArray = ["Fred", "Bob"];
            IdentifiableObject testIdentifiableObject = new(testArray);
            testIdentifiableObject.AddIdentifier("Wilma");
            Assert.Multiple(() =>
            {
                Assert.That(testIdentifiableObject.AreYou("fred"), Is.True);
                Assert.That(testIdentifiableObject.AreYou("bob"), Is.True);
                Assert.That(testIdentifiableObject.AreYou("wilma"), Is.True);
            });
        }
    }
}