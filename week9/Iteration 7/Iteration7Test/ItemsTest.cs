using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration7
{
    [TestFixture]
    public class TestItem
    {
        Item shield;

        [SetUp]
        public void SetUp()
        {
            shield = new Item(["shield"], "gold shield", "a gold shield that lasts a lifetime");
        }
        [Test]
        public void TestItemIdentifiable()
        {
            Assert.That(shield.AreYou("shield"), Is.True, "True");
            Assert.That(shield.AreYou("sword"), Is.False, "True");
        }

        [Test]
        public void TestShortDesc()
        {
            Assert.That(shield.ShortDescription, Is.EqualTo("a gold shield (shield)"));
        }

        [Test]
        public void TestFullDesc()
        {
            Assert.That(shield.FullDescription, Is.EqualTo("a gold shield that lasts a lifetime"));

        }

    }
}
