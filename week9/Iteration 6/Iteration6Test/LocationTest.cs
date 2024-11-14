using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Iteration6
{
    [TestFixture]
    public class LocationTest
    {
        Player player;
        Location location;
        Item sword;

        [SetUp]
        public void SetUp()
        {
            player = new Player("ruchan", "member of a chess club");
            sword = new Item(["sword"], "diamond sword", "a diamond sword which has not broken once");
            location = new Location(["garage"], "big garage", "a place where you store stuff");
        }

        [Test]
        public void TestLocationIdentifyItself()
        {
            GameObject result = location.Locate("garage");
            Assert.That(result, Is.EqualTo(location));
        }

        [Test]
        public void TestLocationLocateItemTheyHave()
        {
            location.Inventory.Put(sword);
            GameObject expected = sword;
            GameObject actual = location.Locate("sword");
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestPlayerCanLocateItemInTheirLocation()
        {
            location.Inventory.Put(sword);
            player.Location = location;
            GameObject expected = sword;
            GameObject actual = player.Location.Locate("sword");
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
