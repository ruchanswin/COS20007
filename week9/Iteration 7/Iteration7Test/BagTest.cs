using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Iteration7
{
    [TestFixture]
    public class TestBag
    {
        Item sword;
        Item shield;
        Bag bag;
        Bag backpack;

        [SetUp]
        public void SetUp()
        {
            sword = new Item(["sword"], "diamond sword", "a diamond sword which has not broken once");
            shield = new Item(["shield"], "gold shield", "a gold shield that lasts a lifetime");
            bag = new Bag(["bag"], "leather bag", "a light bag, suitable for short trips");
            backpack = new Bag(["backpack"], "fabric backpack", "a medium-sized backpack, suitable for abroad travelling");

            bag.Inventory.Put(sword);
            backpack.Inventory.Put(shield);
            backpack.Inventory.Put(bag);
        }

        [Test]
        public void TestBagLocateItems()
        {
            Assert.Multiple(() =>
            {
                Assert.That(bag.Locate("sword"), Is.EqualTo(sword));
                Assert.That(backpack.Locate("shield"), Is.EqualTo(shield));
            });
        }
        [Test]
        public void TestBagLocatesItself()
        {
            Assert.Multiple(() =>
            {
                Assert.That(bag.Locate("bag"), Is.EqualTo(bag));
                Assert.That(backpack.Locate("backpack"), Is.EqualTo(backpack));
            });
        }
        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.That(bag.Locate("Nothing"), Is.EqualTo(null));
        }
        [Test]
        public void TestBagFullDesc()
        {
            Assert.That(bag.FullDescription, Is.EqualTo("In the leather bag you can see:\n\ta diamond sword (sword)\n"));
        }
        [Test]
        public void TestBagInBag()
        { 
            Assert.Multiple(() =>
            {
                Assert.That(backpack.Locate("bag"), Is.EqualTo(bag));
                Assert.That(bag.Locate("sword"), Is.EqualTo(sword));
                Assert.That(bag.Locate("shield"), Is.EqualTo(null));
            });
        }
    }
}