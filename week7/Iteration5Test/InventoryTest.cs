using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Iteration5
{
    [TestFixture]
    public class TestInventory
    {
        Inventory inventory;
        Item sword;
        Item shield;
        Item potion;

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory();
          
            sword = new Item(["sword"], "diamond sword", "a diamond sword which has not broken once");
            shield = new Item(["shield"], "gold shield", "a gold shield that lasts a lifetime");
            potion = new Item(["potion"], "healing potion", "a healing potion which is needed for the adventurers");
           
            inventory.Put(sword);
            inventory.Put(shield);
        }
        [Test]
        public void TestFoundItem()
        {
            Assert.Multiple(() =>
            {
                Assert.That(inventory.HasItem("sword"), Is.True);
                Assert.That(inventory.HasItem("shield"), Is.True);
            });
        }
        [Test]
        public void TestNoItemFound()
        {
            Assert.That(inventory.HasItem("potion"), Is.False);
        }
        [Test]
        public void TestFecthItem()
        {
            Assert.Multiple(() =>
            {
                Assert.That(inventory.Fetch("sword"), Is.EqualTo(sword));
                Assert.That(inventory.HasItem("sword"), Is.True);
            });
        }
        [Test]
        public void TestTakeItem()
        {
            Assert.Multiple(() =>
            {
                Assert.That(inventory.Take("sword"), Is.EqualTo(sword));
                Assert.That(inventory.HasItem("sword"), Is.False);
                Assert.That(inventory.HasItem("shield"), Is.True);
                Assert.That(inventory.HasItem("potion"), Is.False);
            });
        }
        [Test]
        public void TestItemList()
        {
            Assert.That(inventory.ItemList, Is.EqualTo("\ta diamond sword (sword)\n\ta gold shield (shield)\n"));
        }
    }
}
