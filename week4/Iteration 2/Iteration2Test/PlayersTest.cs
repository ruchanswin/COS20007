using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Iteration2
{
    [TestFixture]
    public class TestPlayer
    {
        Inventory inventory;
        Player player;
        Item sword;
        Item shield;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory();
            player = new("ruchan", "a member of a chess club");

            sword = new Item(["sword"], "diamond", "a diamond sword which has not broken once");
            shield = new Item(["shield"], "gold", "a gold shield that lasts a lifetime");

            player.Inventory.Put(sword);
            player.Inventory.Put(shield);
        }

        [Test]
        public void TestPLayerIsIdentifiable()
        {
            Assert.Multiple(() =>
            {
                Assert.That(player.AreYou("me"), Is.True, "True");
                Assert.That(player.AreYou("inventory"), Is.True, "True");
            });
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            var result = false;
            var itemsLocated = player.Locate("sword");
            if (sword == itemsLocated)
            {
                result = true;
            }
            Assert.That(result, Is.True);

            _ = player.Locate("shield");
            if (shield == itemsLocated)
            {
                result = true;
            }
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.Multiple(() =>
            {
                Assert.That(player.Locate("me"), Is.EqualTo(player));
                Assert.That(player.Locate("inventory"), Is.EqualTo(player));
            });
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.That(player.Locate("plate"), Is.EqualTo(null));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Assert.That(player.FullDescription, Is.EqualTo("You are ruchan, a member of a chess club.\nYou are carrying:\n\ta diamond (sword)\n\ta gold (shield)\n"));
        }
    }
}
