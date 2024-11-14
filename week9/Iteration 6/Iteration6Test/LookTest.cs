using System;
using System.ComponentModel;
using System.Linq;

namespace Iteration6
{
    [TestFixture]
    public class TestLook
    {
        Look look;
        Player player;
        Bag bag;
        Item sword;
        Item shield;
        Item potion;

        [SetUp]
        public void SetUp()
        {
            look = new Look();
            player = new Player("ruchan", "member of a chess club");

            bag = new Bag(["bag"], "leather bag", "a light bag, suitable for short trips");
            sword = new Item(["sword"], "diamond sword", "a diamond sword which has not broken once");
            shield = new Item(["shield"], "gold shield", "a gold shield that lasts a lifetime");
            potion = new Item(["potion"], "healing potion", "a healing potion which is needed for the adventurers");
        }

        [Test]
        public void TestLookAtMe()
        {
            Assert.That(look.Execute(player, ["look", "at", "me"]), Is.EqualTo(player.FullDescription));
        }

        [Test]
        public void TestLookAtSword()
        {
            player.Inventory.Put(sword);
            Assert.That(look.Execute(player, ["look", "at", "sword"]), Is.EqualTo(sword.FullDescription));
        }

        [Test]
        public void TestLookAtUnknownItems()
        {
            Assert.That(look.Execute(player, ["look", "at", "plate"]), Is.EqualTo($"I can't find plate"));
        }

        [Test]
        public void TestLookAtSwordInMe()
        {
            player.Inventory.Put(sword);
            Assert.That(look.Execute(player, ["look", "at", "sword", "in", "me"]), Is.EqualTo(sword.FullDescription));
        }
        [Test]
        public void TestLookAtSwordInBag()
        {
            bag.Inventory.Put(sword);
            bag.Inventory.Put(shield);
            player.Inventory.Put(bag);
            Assert.That(look.Execute(player, ["look", "at", "sword", "in", "bag"]), Is.EqualTo(sword.FullDescription));
        }

        [Test]
        public void TestLookAtPotionInNoBag()
        {
            bag.Inventory.Put(potion);
            Assert.That(look.Execute(player, ["look", "at", "potion", "in", "bag"]), Is.EqualTo("I can't find the bag"));
        }

        [Test]
        public void TestLookAtNoShieldInBag()
        {
            bag.Inventory.Put(sword);
            player.Inventory.Put(bag);
            Assert.Multiple(() =>
            {
                Assert.That(look.Execute(player, ["look", "at", "shield", "in", "bag"]), Is.EqualTo("I can't find shield in the leather bag"));
                Assert.That(look.Execute(player, ["look", "at", "potion", "in", "bag"]), Is.EqualTo("I can't find potion in the leather bag"));
            });
        }
        [Test]
        public void TestInvalidLook()
        {
            Assert.Multiple(() =>
            {
                Assert.That(look.Execute(player, ["look", "down"]), Is.EqualTo("I don't know how to look like that"));
                Assert.That(look.Execute(player, ["stare", "at", "plate"]), Is.EqualTo("Error in look input"));
                Assert.That(look.Execute(player, ["look", "at", "potion", "on", "bag"]), Is.EqualTo("What do you want to look in?"));
                Assert.That(look.Execute(player, ["look", "for", "shield"]), Is.EqualTo("What do you want to look at?"));
            });
        }
    }
}