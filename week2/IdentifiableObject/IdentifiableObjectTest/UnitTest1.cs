using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IdentifiableObject
{
    [TestFixture]
    public class TestIdentifiableObject
    {

        [Test]
        public void TestAreYou()
        {
            string[] testIdentifiableObjectArray = ["Fred", "Bob"];
            IdentifiableObject testObject = new(testIdentifiableObjectArray);
            Assert.That(testObject.AreYou("fred"), Is.True);
        }

        [Test]
        public void TestNotAreYou()
        {
            string[] testIdentifiableObjectArray = ["Fred", "Bob"];
            IdentifiableObject testObject = new(testIdentifiableObjectArray);
            Assert.That(testObject.AreYou("wilma"), Is.False);
        }

        [Test]
        public void TestCaseSensitive()
        {
            string[] testIdentifiableObjectArray = ["Fred", "Bob"];
            IdentifiableObject testObject = new(testIdentifiableObjectArray);
            Assert.That(testObject.AreYou("bOB"), Is.True);
        }

        [Test]
        public void TestFirstID()
        {
            string[] testIdentifiableObjectArray = ["Fred", "Bob"];
            IdentifiableObject testObject = new(testIdentifiableObjectArray);
            StringAssert.AreEqualIgnoringCase("fred", testObject.FirstID);
        }

        [Test]
        public void TestFirstIDWithNoIDs()
        {
            string[] testIdentifiableObjectArray = []; 
            IdentifiableObject testObject = new(testIdentifiableObjectArray);
            StringAssert.AreEqualIgnoringCase("", testObject.FirstID);
        }

        [Test]
        public void TestAddID()
        {
            string[] testIdentifiableObjectArray = ["Fred", "Bob"];
            IdentifiableObject testObject = new(testIdentifiableObjectArray);
            testObject.AddIdentifier("Wilma");
            Assert.Multiple(() =>
            {
                Assert.That(testObject.AreYou("fred"), Is.True);
                Assert.That(testObject.AreYou("bob"), Is.True);
                Assert.That(testObject.AreYou("wilma"), Is.True);
            });
        }
    }
}