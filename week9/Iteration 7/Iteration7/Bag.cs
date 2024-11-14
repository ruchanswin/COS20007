using System;
using System.Xml.Linq;

namespace Iteration7
{
    public class Bag(string[] idents, string name, string desc) : Item(idents, name, desc), IHaveInventory
    {
        private readonly Inventory _inventory = new();

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            return null;

        }

        public override string FullDescription
        {
            get
            {
                string InventoryDescription = "In the " + Name + " you can see:\n";
                InventoryDescription += _inventory.ItemList;
                return InventoryDescription;
            }
        }
    }
}