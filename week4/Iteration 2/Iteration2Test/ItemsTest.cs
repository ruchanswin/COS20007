using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration2
{
    [TestFixture]
    public class TestItem
    {
        Item shield;

        [SetUp]
        public void SetUp()
        {
            shield = new Item(["shield"], "gold", "a gold shield that lasts a lifetime");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.Multiple(() =>
            {
                Assert.That(shield.AreYou("shield"), Is.True, "True");
                Assert.That(shield.AreYou("sword"), Is.False, "True");
            });
        }

        [Test]
        public void TestShortDescprition()
        {
            Assert.That(shield.ShortDescription, Is.EqualTo("a gold (shield)"));
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(shield.FullDescription, Is.EqualTo("a gold shield that lasts a lifetime"));

        }

    }
}
